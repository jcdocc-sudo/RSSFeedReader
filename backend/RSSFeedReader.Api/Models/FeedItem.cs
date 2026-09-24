namespace RSSFeedReader.Api.Models;

public class FeedItem
{
    public string Title { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
}

public class FeedItemDto
{
    public string Title { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
}
