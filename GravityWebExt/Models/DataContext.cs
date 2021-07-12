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
        /// <summary>
        /// Данные с датчиков
        /// </summary>
        public DbSet<MeasurementData> Measurement { get; set; }
        /// <summary>
        /// Расчитанные данные
        /// </summary>
        public DbSet<CalculatedData> Calculated { get; set; }
        /// <summary>
        /// Параметры
        /// </summary>
        public DbSet<OptionsData> Options { get; set; }
        /// <summary>
        /// NSP
        /// </summary>
        public DbSet<NSPData> NSP { get; set; }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public static implicit operator DataContext(MeasurementData v)
        {
            throw new NotImplementedException();
        }
    }
}
