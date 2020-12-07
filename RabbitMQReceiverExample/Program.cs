using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQReceiverExample
{
    class Program
    {
        static void Main(string[] args)
        {
            RabbitMQReceiver.Receive("Messages", "", ExchangeType.Fanout);
        }
    }
}
