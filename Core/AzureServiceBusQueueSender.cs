using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_servicebus_usecase.Core
{
    internal class AzureServiceBusQueueSender
    {
        private readonly string ServiceBusConnectionString;
        private readonly string QName;

        internal AzureServiceBusQueueSender(string connectionString, string queueName)
        {
            ServiceBusConnectionString = connectionString;
            QName = queueName;
        }

        internal bool SendMessage(string messageBody)
        {
            try
            {
                var queueClient = new QueueClient(ServiceBusConnectionString, QName);
                var message = new Message(Encoding.UTF8.GetBytes(messageBody));
                queueClient.SendAsync(message).GetAwaiter().GetResult();
                queueClient.CloseAsync().GetAwaiter().GetResult();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
