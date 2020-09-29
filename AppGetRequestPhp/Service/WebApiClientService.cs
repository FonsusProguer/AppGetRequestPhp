using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppGetRequestPhp.Service
{
    public class WebApiClientService
    {
        Uri urlBase = new Uri("http://192.168.140.2");


        public async Task<T> executeRequestGet<T>(string stParams)
        {
            string requestUri = "/WebServiceGet/index.php?";
            var client = new HttpClient();
            client.BaseAddress = urlBase;

            HttpResponseMessage response = await client.GetAsync($"{requestUri}{stParams}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                return default(T);
            }
        }


    }
}
