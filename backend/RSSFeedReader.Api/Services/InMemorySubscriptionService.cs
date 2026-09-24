using System.Net.Http;
using System.Xml.Linq;
using RSSFeedReader.Api.Models;

namespace RSSFeedReader.Api.Services;

public class InMemorySubscriptionService
{
    private static readonly HttpClient HttpClient = new();
    private readonly List<Subscription> _subscriptions = new();

    public IReadOnlyList<Subscription> GetAll()
    {
        return _subscriptions.AsReadOnly();
    }

    public Subscription Add(string url)
    {
        var trimmed = url?.Trim() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(trimmed))
            throw new ArgumentException("Subscription URL is required.", nameof(url));

        var subscription = new Subscription
        {
            Id = _subscriptions.Count == 0 ? 1 : _subscriptions.Max(x => x.Id) + 1,
            Url = trimmed,
            AddedAt = DateTimeOffset.UtcNow
        };

        _subscriptions.Add(subscription);
        return subscription;
    }

    public async Task<List<FeedItem>> FetchFeedItemsAsync(string url)
    {
        var trimmed = url?.Trim() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(trimmed))
            throw new ArgumentException("Subscription URL is required.", nameof(url));

        var response = await HttpClient.GetAsync(trimmed);
        response.EnsureSuccessStatusCode();

        var xml = await response.Content.ReadAsStringAsync();
        return ParseFeedItems(xml);
    }

    public List<FeedItem> ParseFeedItems(string xml)
    {
        if (string.IsNullOrWhiteSpace(xml))
            return new List<FeedItem>();

        var document = XDocument.Parse(xml);
        var items = new List<FeedItem>();

        if (document.Root?.Name.LocalName == "rss")
        {
            items = document.Root
                .Element("channel")?
                .Elements("item")
                .Select(item => new FeedItem
                {
                    Title = item.Element("title")?.Value ?? "Untitled",
                    Link = item.Element("link")?.Value ?? string.Empty
                })
                .ToList() ?? new List<FeedItem>();
        }
        else if (document.Root?.Name.LocalName == "feed")
        {
            items = document.Root
                .Elements()
                .Where(x => x.Name.LocalName == "entry")
                .Select(entry => new FeedItem
                {
                    Title = entry.Element("title")?.Value ?? "Untitled",
                    Link = entry.Element("link")?.Attribute("href")?.Value
                        ?? entry.Element("link")?.Value
                        ?? string.Empty
                })
                .ToList();
        }

        return items;
    }
}
