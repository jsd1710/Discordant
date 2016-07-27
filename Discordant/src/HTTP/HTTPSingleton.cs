using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Discordant.src.HTTP
{
    public class HTTPSingleton
    {
        private static HTTPSingleton instance;
        private static HttpClient client;

        private HTTPSingleton()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://discordapp.com/api/");
            client.DefaultRequestHeaders
              .Accept
              .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static HTTPSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HTTPSingleton();
                }
                return instance;
            }
        }


        public async Task<string> HttpGet(string url)
        {
            // ... Use HttpClient.
            using (HttpResponseMessage response = await client.GetAsync(url))
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                string result = await content.ReadAsStringAsync();

                // ... Display the result.
                return result;
            }
        }

        public async Task<string> HttpPost(string relative_url, string json_string)
        {

            var httpContent = new StringContent(json_string, Encoding.UTF8, "application/json");

            String result = "";
            var httpResponse = await client.PostAsync(relative_url, httpContent);
            if (httpResponse.Content != null)
            {
                result = await httpResponse.Content.ReadAsStringAsync();
            }
            return result;
        }

        public void addHttpAuthenticationHeader(string header)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(header);
        }
    }
}
