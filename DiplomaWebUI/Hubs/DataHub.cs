using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diploma.Data.Common;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.AspNetCore.SignalR;

namespace DiplomaWebUI.Hubs
{
    public class DataHub : Hub
    {
        public static readonly ConnectionMapping<string> _connections = new ConnectionMapping<string>();

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception ex)
        {

            await base.OnDisconnectedAsync(ex);
        }
    }
}
