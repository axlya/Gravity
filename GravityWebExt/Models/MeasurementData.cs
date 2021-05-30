using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GravityWebExt.Models
{
    /// <summary>
    /// Данные, получаемые с датчиков контроллера
    /// </summary>
    /// 
    public class MeasurementData
    {
        public int Id { get; set; }
        double TimeStamp { get; set; }  
        double Data1 { get; set; }
        double Data2 { get; set; }
    }
}
