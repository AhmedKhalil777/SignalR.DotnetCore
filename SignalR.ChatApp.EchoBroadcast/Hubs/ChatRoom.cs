using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.ChatApp.EchoBroadcast.Hubs
{
    public class ChatRoom : Hub
    {
        public Task BroadcastMessage(string username , string message)
        {
            return Clients.All.SendAsync("RecieveBroadcastedMessage", username, message);
        }

        public Task Echo(string username, string message)
        {
            return Clients.Client(Context.ConnectionId).SendAsync("RecievedEchoMessage", username , message);
        }
    }
}
