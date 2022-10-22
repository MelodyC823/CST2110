using _2110_Sep2022.Common;
using Azure.Storage.Queues;

namespace _2110_Sep2022.Queue
{
    public class BaseMessageQueueRepository
    {
        protected IStorageConfiguration storageConfiguration;
        protected string queueName;

        public BaseMessageQueueRepository(IStorageConfiguration storageConfiguration, string queueName)
        {
            this.queueName = queueName;
            this.storageConfiguration = storageConfiguration;
        }

        protected QueueClient GetQueueClient()
        {
            return new QueueClient(storageConfiguration.GetStorageConnectionString(), queueName);
        }
    }
}
