using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FacesApp
{
    public class StorageHelper
    {
        

        public static async Task UploadPhoto(Photo photoInfo)
        {
            try
            {
                using (var stream = new MemoryStream())
                {


                    var container = GetContainer();

                    var fileBlob = container.GetBlockBlobReference(photoInfo.Name);

                    await fileBlob.UploadFromByteArrayAsync(photoInfo.PhotoData, 0, photoInfo.PhotoData.Length);

                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private static CloudBlobContainer GetContainer()
        {
            var account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=reconnecthjrstorage;AccountKey=mSU5mc/ir1gm83ju0+n/dYihQPjiWxh5Kpr36ha4smLUelcshBLKJGI4HxbXqYGctFT4eBOa5uZXfaWlds/P9A==");

            var client = account.CreateCloudBlobClient();
            var containers = client.ListContainersSegmentedAsync(null).Result;
            return client.GetContainerReference("faces");
        }
    }
}
