using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQReceiverExample
{
    public static class RabbitMQReceiver
    {
        public static ConnectionFactory factory = new ConnectionFactory()
            { HostName = "localhost", Password = "guest", UserName = "guest", VirtualHost = "/", Port = 5672 };

        public static void Receive(string exchange, string routingKey, string exchangeType)
        {
            var factory = new ConnectionFactory();
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: exchange, type: exchangeType);
                var queueName = channel.QueueDeclare(exclusive: false);
                channel.QueueBind(queue: queueName,
                    exchange: exchange,
                    routingKey: routingKey);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine("Received {0}", message);
                };

                channel.BasicConsume(queue: queueName,
                    autoAck: true,
                    consumer: consumer);

                Console.WriteLine("Waiting for messages, press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}