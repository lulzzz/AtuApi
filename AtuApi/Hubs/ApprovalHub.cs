using AtuApi.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtuApi.Hubs
{
    public class ApprovalHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("xz",user,message);
        }
        public async Task SendMessage2()
        {
            await Clients.All.SendAsync("aaaaaaaaaa");
        }
        public void MethodNoParametersNoReturnValue()
        {
            Console.WriteLine("'MethodNoParametersNoReturnValue' invoked.");
        }
    }
}
