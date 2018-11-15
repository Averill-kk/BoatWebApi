using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatWebApi.Models
{
    public class GpsBoatData
    {
        public int Id { get; set; }
        public double Latitude { get; set; }

        public double Lontitude { get; set; }
        public double Angle { get; set; }

        public int Satellite { get; set; }
    }
}
