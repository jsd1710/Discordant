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
            return await Task.Run(() => http.HttpPost("auth/login", credentials_json));
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
