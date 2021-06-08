using System.Collections.Generic;
using System.Threading.Tasks;
using Diploma.Data.Model;

namespace Diploma.Services.Contracts
{
    public interface IDataService
    {
        List<ValuesPerTime> GetLastPeriodData(int days);
        Task WriteMeasurement(ValuesPerTime model);

        void FillDb();
        ValuesPerTime AddNow();
    }
}
