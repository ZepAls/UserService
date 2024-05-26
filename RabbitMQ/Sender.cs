namespace RabbitMQ;
using System.Text;
using RabbitMQ.Client;

public class Sender
{
    public void SendRemoveRoleMessage(int id)
    {
        var factory = new ConnectionFactory { HostName = "localhost" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "RoleQueue",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

        string message = "deleted userId: " + id;
        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(exchange: string.Empty,
                             routingKey: "RoleQueue",
                             basicProperties: null,
                             body: body);
        Console.WriteLine($" [x] Sent [{message}]");
    }
}
