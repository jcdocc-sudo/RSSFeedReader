using Microsoft.AspNetCore.Mvc;
using RSSFeedReader.Api.Models;
using RSSFeedReader.Api.Services;

namespace RSSFeedReader.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionsController : ControllerBase
{
    private readonly InMemorySubscriptionService _subscriptionService;

    public SubscriptionsController(InMemorySubscriptionService subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Subscription>> GetAll()
    {
        return Ok(_subscriptionService.GetAll());
    }

    [HttpPost]
    public ActionResult<Subscription> Add([FromBody] CreateSubscriptionRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Url))
        {
            return BadRequest(new { message = "Subscription URL is required." });
        }

        var subscription = _subscriptionService.Add(request.Url);
        return CreatedAtAction(nameof(GetAll), new { id = subscription.Id }, subscription);
    }

    [HttpGet("feed-items")]
    public async Task<ActionResult<IEnumerable<FeedItem>>> GetFeedItems([FromQuery] string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            return BadRequest(new { message = "Subscription URL is required." });
        }

        try
        {
            var items = await _subscriptionService.FetchFeedItemsAsync(url);
            return Ok(items);
        }
        catch (HttpRequestException)
        {
            return BadRequest(new { message = "Failed to load feed." });
        }
    }
}
