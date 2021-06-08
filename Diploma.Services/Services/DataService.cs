using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diploma.Data;
using Diploma.Data.Model;
using Diploma.Services.Contracts;

namespace Diploma.Services.Services
{
    public class DataService : IDataService
    {
        private readonly DataContext _context;

        public DataService(DataContext context)
        {
            _context = context;
        }

        public List<ValuesPerTime> GetLastPeriodData(int days)
        {
            var date = DateTime.Now.AddDays(-days);
            return _context.Measurements.Where(x => x.DateTime > date).ToList();
        }

        public async Task WriteMeasurement(ValuesPerTime model)
        {
            model.Id = 0;
            _context.Add(model);
            await _context.SaveChangesAsync();
        }

        public void FillDb()
        {
            var date = DateTime.Now.AddDays(-3);
            Random rnd = new Random();
            while (date <= DateTime.Now)
            {
                date = date.AddMinutes(10);
                _context.Measurements.Add(new ValuesPerTime()
                {
                    APressure = rnd.Next(650, 900),
                    Humidity = rnd.Next(20, 90),
                    Ppm = rnd.Next(200, 3000),
                    Temp = rnd.Next(15, 30),
                    DateTime = date
                });
            }

            _context.SaveChanges();
        }

        public ValuesPerTime AddNow()
        {
            Random rnd = new Random();
            var model = new ValuesPerTime()
            {
                APressure = rnd.Next(650, 900),
                Humidity = rnd.Next(20, 90),
                Ppm = rnd.Next(200, 3000),
                Temp = rnd.Next(15, 30),
                DateTime = DateTime.Now
            };
            _context.Measurements.Add(model);
            _context.SaveChanges();

            return model;
        }
    }
}
