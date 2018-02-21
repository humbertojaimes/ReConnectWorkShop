using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
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
            var account = CloudStorageAccount.Parse("Tu cadena de conexión");

            var client = account.CreateCloudBlobClient();
            var containers = client.ListContainersSegmentedAsync(null).Result;
            return client.GetContainerReference("faces");
        }
    }
}
