using CleverChat.CleverBot;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleverChat.SignalRChat.Hubs
{
    public class CleverHub : Hub
    {
        public async Task SendMessage(string user, string message, string conversation)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message, conversation);

            var response = await Clever.TalkToCleverAsync(message, conversation);

            await Clients.All.SendAsync("ReceiveMessage", Clever.BotName, response.Output, response.Cs, user);
        }
    }
}
