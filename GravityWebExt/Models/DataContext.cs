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
        // Данные с датчиков
        public DbSet<MeasurementData> Measurement { get; set; }
        // Расчитанные данные
        public DbSet<CalculatedData> Calculated { get; set; }
        // Параметры
        public DbSet<OptionsData> Options { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
