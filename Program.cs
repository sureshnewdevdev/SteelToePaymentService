using Steeltoe.Messaging.RabbitMQ.Extensions;

namespace PaymentService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add RabbitMQ
            builder.Services.AddRabbitServices();

            // Add Rabbit Queue for orders
            builder.Services.AddRabbitQueue("orderQueue");

            // Add Rabbit Listeners

            // Register the Payment Listener
            builder.Services.AddSingleton<PaymentListener>();
            builder.Services.AddRabbitListeners<PaymentListener>();


            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Swagger configuration
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            // Home route
            //app.MapGet("/", () => "Payment Service is running");

            app.Run();
        }
    }
}
