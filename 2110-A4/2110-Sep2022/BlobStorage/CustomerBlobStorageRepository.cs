using _2110_Sep2022.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _2110_Sep2022.BlobStorage
{
    public class CustomerBlobStorageRepository : BaseBlobStorageRepository
    {
        public CustomerBlobStorageRepository(IStorageConfiguration storageConfiguration, string containerName) :
            base(storageConfiguration, containerName)
        { 
        }

        public void UploadFile(string fileName)
        {
            var blobClient = this.GetBlobClient(fileName);
            blobClient.Upload(fileName);
        }

        public void Download(string filePath, string localFilePath)
        {
            var blobClient = this.GetBlobClient(filePath);
            FileStream fileStream = File.OpenWrite(localFilePath);
            blobClient.DownloadTo(fileStream);
            fileStream.Close();
        }
    }
}
