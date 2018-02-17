using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FacesApp
{
    public class Photo
    {
        public byte[] PhotoData
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }
    public class MediaHelper
    {
        public static async Task<Photo> TakePhotoAsync(string name)
        {
            byte[] photo = null;
            await Plugin.Media.CrossMedia.Current.Initialize();
            if (Plugin.Media.CrossMedia.Current.IsCameraAvailable
               && Plugin.Media.CrossMedia.Current.IsTakePhotoSupported)
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Full,
                    Directory = "People",
                    Name = name +".jpg",
                    MaxWidthHeight = 512,
                    AllowCropping = true
                });

                if (file != null)
                    using (var photoStream = file.GetStream())
                    {
                        photo = new byte[photoStream.Length];
                        await photoStream.ReadAsync(photo, 0, (int)photoStream.Length);
                    }
            }

            return new Photo() { PhotoData = photo, Name= name + ".jpg" };
        }
    }
}
