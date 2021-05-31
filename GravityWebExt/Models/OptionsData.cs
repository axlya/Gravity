using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GravityWebExt.Models
{
    /// <summary>
    /// Параметры
    /// </summary>
    public class OptionsData
    {
        public int Id { get; set; }
        /// <summary>
        /// Геометрические параметры стенда
        /// </summary>
        public double S { get; set; }
        /// <summary>
        /// Допустимое отклонение геометрических параметров стенда
        /// </summary>
        public double deltaS { get; set; }
    }
}
