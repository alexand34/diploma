using System;
using System.Collections.Generic;
using System.Text;
using Diploma.Data.Model;

namespace Diploma.Services.Contracts
{
    public interface IHubEventsResolver
    {
        void SendAllData(ValuesPerTime model);
    }
}
