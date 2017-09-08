using System;
using Microsoft.ServiceBus.Messaging;

namespace MessageSender
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isExits = false;
            while (!isExits)
            {
                Console.WriteLine("Type the message and press enter to send. If you want to exit type 'exit'");
                var message = Console.ReadLine();
                if (!string.IsNullOrEmpty(message) && message != "exit")
                    SendMessage(message);
                isExits = message == "exit";
            }
        }

        private static void SendMessage(string messageStr)
        {
            var connectionString = "YOUR_SERVICE_BUS_END_POINT";
            var queueName = "queuemytest";

            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);
            var message = new BrokeredMessage(messageStr);

            Console.WriteLine(String.Format("Message id: {0}", message.MessageId));

            client.Send(message);

            Console.WriteLine("Message successfully sent!");
        }
    }
}
