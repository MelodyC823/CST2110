using _2110_Sep2022.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2110_Sep2022.Queue
{
    public class OrderQueueRepository : BaseMessageQueueRepository
    {
        public OrderQueueRepository(IStorageConfiguration storageConfiguration, string queueName)
            : base(storageConfiguration, queueName)
        {
        }

        public void Enqueue(Order order)
        {
            var queueClient = GetQueueClient();
            queueClient.SendMessage(order.ToString());
        }

        public void Peek()
        {
            var queueClient = GetQueueClient();
            var peekedMessage = queueClient.PeekMessage();

            Console.WriteLine($"peeked message body: {peekedMessage.Value.Body}");
        }

        public void Dequeue()
        {
            var queueClient = GetQueueClient();
            // get the message
            var message = queueClient.ReceiveMessage();

            // process the message 
            Console.WriteLine($"dequeue message body: {message.Value.Body}");
            
            // remove from queue
            queueClient.DeleteMessage(message.Value.MessageId, message.Value.PopReceipt);
        }
    }
}
