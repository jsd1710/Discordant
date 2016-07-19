using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discordant.src.Authentication
{
    public static class Authentication
    {
        public static async Task<string> login(string email, string password)
        {
            var credentials = new Credentials
            {
                email = email,
                password = password
            };
            return await Task.Run(() => JsonConvert.SerializeObject(credentials));
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
