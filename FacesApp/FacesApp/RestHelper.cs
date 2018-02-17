using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FacesApp
{
    public class RestHelper
    {
        static HttpClient httpClient = new HttpClient();


        public static async Task<List<Person>> GetFaces()
        {
            var response = await httpClient.GetStringAsync("https://reconnecthjr.azurewebsites.net/api/faceinformation");
            List<Person> persons =
            Newtonsoft.Json.JsonConvert.DeserializeObject<List<Person>>(response);
            return persons;
        }


        public class Person
        {
            public string ImageFile { get; set; }

            public Uri ImageUri { get => new Uri("https://reconnecthjrstorage.blob.core.windows.net/faces/"+ImageFile); }

            public int Age { get; set; }

            public string Gender { get; set; }
        }

    }
}
