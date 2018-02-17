using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FacesApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
          
        }

        public object PhotoInfo { get; private set; }

        private async void BtnTakePhoto_Clicked(object sender, EventArgs e)
        {
       ;
            string name = entImageName.Text;

            Photo photo = await MediaHelper.TakePhotoAsync(name);
            imgPhoto.Source = ImageSource.FromStream(() => new MemoryStream(photo.PhotoData));
            await StorageHelper.UploadPhoto(photo);
            await Task.Delay(5000);
            lvPersons.ItemsSource = await RestHelper.GetFaces();
        }
    }
}
