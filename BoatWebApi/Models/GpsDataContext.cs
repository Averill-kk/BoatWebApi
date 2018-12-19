using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace BoatWebApi.Models
{
    public class GpsDataContext: DbContext
    {
        public DbSet<GpsData> GpsDatas { get; set; }
        public DbSet<GpsBoatData> GpsBoatDatas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=gpsdata.db");
        }
    }
}
