using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleverChat.CleverBot
{
    public static class Clever
    {
        const string CleverBotKey = "CLEVERBOT_KEY";
        public const string BotName = "CleverBot";

        public static async Task<CleverResponse> TalkToCleverAsync(string message, string cs)
        {
            var client = new RestClient("http://www.cleverbot.com/");
            var request = new RestRequest("getreply");
            request.AddQueryParameter("key", CleverBotKey);
            request.AddQueryParameter("input", message);
            if (!string.IsNullOrEmpty(cs))
            {
                request.AddQueryParameter("cs", cs);
            }
            var result = await client.ExecuteTaskAsync<CleverResponse>(request);
            return result.Data;
        }
    }
}
