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
                        S = 449.2,
                        DevS = 0.02,
                        H = 386,
                        DevH = 0.02,
                        L = 1349,
                        DevL = 0.02,
                        Q = 238,
                        DevQ = 0.02,
                        DevP = 0.001,
                        DevEpsilon = 5,
                        DevFi = 1,
                        Pasport_mm = 443.8,
                        DevPas_mm = 0,
                        D = 1779,
                        DevD = 0.02,
                        E = -41,
                        DevE = 0.02,
                        Pasport_ma = 0,
                        DevPasport_ma = 0,
                        Xper = 2000,
                        DevХper = 0.02,
                        Yper = 0,
                        DevYper = 0.02,
                        Zper = 0,
                        DevZper = 0.02,
                        MassPer = 2000,
                        DevMassPer = 0.012,
                        HPer = 1800.01,
                        DevHPer = 0.02,
                        Xkp = 500,
                        DevXkp = 0.04,
                        Ykp = 0,
                        DevYkp = 0.04,
                        Zkp = 0,
                        DevZkp = 0.04,
                        MassKp = 3000,
                        DevMassKp = 0.024,
                        MassProd = 3000,
                        Xprod = 500,
                        Yprod = 0,
                        Zprod = 0
                    }
                ) ;
                context.SaveChanges();
            }
        }
    }
}
