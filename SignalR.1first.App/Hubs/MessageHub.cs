﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalR._1first.App.Hubs
{
    public class MessageHub : Hub
    {
        public Task SendMessage(string user , string message )
        {
          return  Clients.All.SendAsync("RecievedMessage", user, message);
        }

    }
}
