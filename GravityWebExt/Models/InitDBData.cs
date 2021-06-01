using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GravityWebExt.Models
{
    /// <summary>
    /// Инициализация БД с параметрами по-умолчанию
    /// </summary>
    public class InitDBData
    {
        public static void Initialize(DataContext context)
        {
            //Параметры
            if (!context.Options.Any())
            {
                context.Options.Add(
                    new OptionsData()
                    {
                        S = 1,
                        DevS = 2,
                        H = 3,
                        DevH = 4,
                        L = 5,
                        DevL = 6,
                        Q = 7,
                        DevQ = 8,
                        DevP = 9,
                        DevEpsilon = 10,
                        DevFi = 11,
                        Pasport_mm = 12,
                        DevPas_mm = 13,
                        D = 14,
                        DevD = 15,
                        E = 16,
                        DevE = 17,
                        Pasport_ma = 18,
                        DevPasport_ma = 19,
                        Xper = 20,
                    }
                ) ;
                context.SaveChanges();
            }
        }
    }
}
