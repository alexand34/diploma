using System;
using System.Collections.Generic;
using System.Text;

namespace Diploma.Data.Model
{
    public class ValuesPerTime
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public double Temp { get; set; }
        public double Humidity { get; set; }
        public double APressure { get; set; }
        public int Ppm { get; set; }
    }
}
