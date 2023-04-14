using Microsoft.AspNetCore.Mvc;
using Dapr;
using System.Net;

namespace checkout.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : Controller
{
    private readonly ILogger<OrderController> _logger;

    public OrderController(ILogger<OrderController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetOrder")]
    public IEnumerable<Order> Get()
    {
        return new List<Order>();
    }

    // Programtic subscription
    //Subscribe to a topic 
    [Topic("pubsub", "newOrder")]
    //[Topic("pubsub", "newOrder", "ordersdlq", false)]
    [HttpPost("/newcheckout")]
    public IActionResult GetCheckout([FromBody] Order order)
    {
        Console.WriteLine("Subscriber triggered...");
        Console.WriteLine("Subscriber received : " + order.Name);
        return StatusCode(500); //500 - Error out.. Hope to be retried
    }
}