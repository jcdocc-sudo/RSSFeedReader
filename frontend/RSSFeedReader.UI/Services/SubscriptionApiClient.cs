using System.Net.Http.Json;
using RSSFeedReader.UI.Models;

namespace RSSFeedReader.UI.Services;

public class SubscriptionApiClient
{
    private readonly HttpClient _httpClient;

    public SubscriptionApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Subscription>> GetSubscriptionsAsync()
    {
        var subscriptions = await _httpClient.GetFromJsonAsync<List<Subscription>>("subscriptions");
        return subscriptions ?? new List<Subscription>();
    }

    public async Task<Subscription?> AddSubscriptionAsync(string url)
    {
        var response = await _httpClient.PostAsJsonAsync("subscriptions", new { url });
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Subscription>();
    }

    public async Task<List<FeedItem>> GetFeedItemsAsync(string url)
    {
        var response = await _httpClient.GetAsync($"subscriptions/feed-items?url={Uri.EscapeDataString(url)}");

        if (!response.IsSuccessStatusCode)
        {
            return new List<FeedItem>();
        }

        var items = await response.Content.ReadFromJsonAsync<List<FeedItem>>();
        return items ?? new List<FeedItem>();
    }
}
