using RSSFeedReader.Api.Models;

namespace RSSFeedReader.Api.Services;

public class InMemorySubscriptionService
{
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
}
