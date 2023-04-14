using Dapr.Client;

var data = new Order
{
  Id = 1234,
  Name = "Shirt-B",
  Amount = 1
};

using(var daprClient = new DaprClientBuilder().Build()){
  await daprClient.PublishEventAsync<Order>("pubsub", "newOrder", data);
  Console.WriteLine("Should have published a message...");
}

public class Order
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Amount { get; set; }
}