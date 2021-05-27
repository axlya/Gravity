using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GravityWebExt.Models
{
    /// <summary>
    /// Взаимодействие с БД
    /// </summary>
    public class DataContext : DbContext
    {
        public DbSet<MeasurementData> Phones { get; set; }
        public DbSet<CalculatedData> Orders { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
