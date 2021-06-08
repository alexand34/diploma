using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diploma.Data.Model;
using Diploma.Services.Contracts;
using Microsoft.AspNetCore.SignalR;

namespace DiplomaWebUI.Hubs
{
    public class HubEventsResolver : IHubEventsResolver
    {
        private readonly IHubContext<DataHub> tableHub;

        public HubEventsResolver(IHubContext<DataHub> tableHub)
        {
            this.tableHub = tableHub;
        }

        public void SendAllData(ValuesPerTime model)
        {
            tableHub.Clients.All.SendCoreAsync("sendData", new[] {model});
        }
    }
}
