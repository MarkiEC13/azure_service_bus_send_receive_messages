using System;
using Microsoft.ServiceBus.Messaging;

namespace MessageReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "YOUR_SERVICE_BUS_END_POINT";
            var queueName = "queuemytest";

            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);

            client.OnMessage(message =>
            {
                Console.WriteLine(String.Format("Message body: {0}", message.GetBody<String>()));
                Console.WriteLine(String.Format("Message id: {0}", message.MessageId));
            });

            Console.WriteLine("Press ENTER to exit program");
            Console.ReadLine();
        }
    }
}
