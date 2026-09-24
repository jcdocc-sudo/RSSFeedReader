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
}
