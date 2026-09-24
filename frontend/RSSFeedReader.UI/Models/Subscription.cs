namespace RSSFeedReader.UI.Models;

public class Subscription
{
    public int Id { get; set; }
    public string Url { get; set; } = string.Empty;
    public DateTimeOffset AddedAt { get; set; }
}
