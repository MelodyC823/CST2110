using _2110.CommandMsg;
using _2110.Common;
using _2110.RestaurantDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace _2110.Queue
{
    public class RestaurantQueue:BaseMessageQueueRepository
    {
        public RestaurantQueue(IStorageConfiguration storageConfiguration, string queueName)
            : base(storageConfiguration, queueName)
        {
        }

        public void Enqueue(RestaurantCommand restaurant)
        {
            var queueClient = GetQueueClient();
            queueClient.SendMessage(Serialize(restaurant));
        }

        public void Peek()
        {
            var queueClient = GetQueueClient();
            var peekedMessage = queueClient.PeekMessage();

            var order = Desrialize(peekedMessage.Value.Body.ToString());
            Console.WriteLine($"peeked message body: {peekedMessage.Value.Body}");
        }

        public void Dequeue()
        {
            var queueClient = GetQueueClient();
            // get the message
            var message = queueClient.ReceiveMessage();
            var order = Desrialize(message.Value.Body.ToString());

            // process the message 
            Console.WriteLine($"dequeue message body: {message.Value.Body}");

            // remove from queue
            queueClient.DeleteMessage(message.Value.MessageId, message.Value.PopReceipt);
        }

        public string Serialize(RestaurantCommand order)
        {
            return JsonSerializer.Serialize(order);
        }

        public Restaurant Desrialize(string serializedOrder)
        {
            return JsonSerializer.Deserialize<Restaurant>(serializedOrder);
        }

    }
}
