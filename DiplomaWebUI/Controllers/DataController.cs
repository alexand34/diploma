using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diploma.Data.Model;
using Diploma.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaWebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController: Controller
    {
        private IHubEventsResolver hubEventsResolver;
        private readonly IDataService dataService;
        public DataController(IHubEventsResolver hubEventsResolver, IDataService dataService)
        {
            this.hubEventsResolver = hubEventsResolver;
            this.dataService = dataService;
        }

        [HttpGet]
        [Route("getLastData/{days}")]
        public List<ValuesPerTime> GetLastData(int days)
        {
            return dataService.GetLastPeriodData(days).OrderBy(x => x.DateTime).ToList();
        }

        [HttpPost]
        [Route("receivedata")]
        public async Task ReceiveData(ValuesPerTime model)
        {
            await dataService.WriteMeasurement(model);
            hubEventsResolver.SendAllData(model);
        }

        [HttpGet]
        [Route("fillDb")]
        public void FillDb()
        {
            dataService.FillDb();
        }

        [HttpGet]
        [Route("addnow")]
        public void AddNow()
        {
            var model = dataService.AddNow();
            hubEventsResolver.SendAllData(model);
        }
    }
}
