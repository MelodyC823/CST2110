using System;
using System.Collections.Generic;
using _2110_Sep2022.Common;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace _2110_Sep2022.BlobStorage
{
    public class BaseBlobStorageRepository
    {
        protected IStorageConfiguration storageConfiguration;
        protected string containerName;


        public BaseBlobStorageRepository(IStorageConfiguration storageConfiguration, string containerName)
        {
            this.containerName = containerName;
            this.storageConfiguration = storageConfiguration;
        }

        protected BlobClient GetBlobClient(string blobName)
        {
            return new BlobClient(storageConfiguration.GetStorageConnectionString(), this.containerName, blobName);
        }
    }
}
