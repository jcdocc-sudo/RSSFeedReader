using RSSFeedReader.Api.Services;

namespace RSSFeedReader.Tests;

public class SubscriptionServiceTests
{
    [Fact]
    public void AddSubscription_ShouldAddUrlToInMemoryList()
    {
        var service = new InMemorySubscriptionService();

        var result = service.Add("https://example.com/feed.xml");

        Assert.NotNull(result);
        Assert.Equal("https://example.com/feed.xml", result.Url);
        Assert.Contains(service.GetAll(), x => x.Url == "https://example.com/feed.xml");
    }

    [Fact]
    public void ParseFeedItems_ShouldReturnTitleAndLinkFromSampleRss()
    {
        var service = new InMemorySubscriptionService();
        const string xml = """
            <rss version="2.0">
              <channel>
                <title>Sample Feed</title>
                <link>https://example.com</link>
                <item>
                  <title>First item</title>
                  <link>https://example.com/first</link>
                </item>
                <item>
                  <title>Second item</title>
                  <link>https://example.com/second</link>
                </item>
              </channel>
            </rss>
            """;

        var items = service.ParseFeedItems(xml);

        Assert.Equal(2, items.Count);
        Assert.Equal("First item", items[0].Title);
        Assert.Equal("https://example.com/first", items[0].Link);
        Assert.Equal("Second item", items[1].Title);
        Assert.Equal("https://example.com/second", items[1].Link);
    }
}
