using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discordant.src.HTTP;

namespace Discordant.src.Authentication
{
    public static class Authentication
    {
        public static async Task<string> login(string email, string password)
        {
            HTTPSingleton http = HTTPSingleton.Instance;
            var credentials = new Credentials
            {
                email = email,
                password = password
            };
            var credentials_json = JsonConvert.SerializeObject(credentials);
            string user_token = await Task.Run(async () => {
                var response = await http.HttpPost("auth/login", credentials_json);
                while (!response.Contains("token"))
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(1));
                }
                return response;
            });
            Dictionary<string, string> user_token_obj = JsonConvert.DeserializeObject<Dictionary<string, string>>(user_token);
            http.addHttpAuthenticationHeader(user_token_obj["token"]);

            return user_token_obj["token"];
        }
    }
    public class Credentials
    {
        [JsonProperty("email")]
        public string email { get; set; }
        [JsonProperty("password")]
        public string password { get; set; }
    }
}
