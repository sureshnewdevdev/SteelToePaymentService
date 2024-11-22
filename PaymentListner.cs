using Newtonsoft.Json;
using Steeltoe.Messaging.RabbitMQ.Attributes;

namespace PaymentService
{
    [RabbitListener("orderQueue")]
    public class PaymentListener
    {
        [RabbitHandler]
        public void HandleOrder(string orderJson)
        {
            // Deserialize the JSON string into an Order object
            var order = JsonConvert.DeserializeObject<Order>(orderJson);
            Console.WriteLine($"Payment processed for Order ID: {order.Id}, Amount: {order.Amount}");
        }
    }

    public record Order(int Id, string Item, double Amount);
}
