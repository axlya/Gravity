using System.Linq;

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
                        DevEpsilon = 0,
                        DevFi = 0,
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
                        Zprod = 0,
                        Fi = 0,
                        Dev = -0.022,
                        Epsilon_ma = 4,
                        Epsilon_mm = 8,
                        ArrRef_ma1 = 47.068,
                        ArrRef_ma2 = 443.8,
                        ArrRef_ma3 = 0,
                        ArrRef_ma4 = 0,
                        DevArrRef_ma1 = 0,
                        DevArrRef_ma2 = 0,
                        DevArrRef_ma3 = 0,
                        DevArrRef_ma4 = 0,
                        ArrRef_mm1 = 47.068,
                        ArrRef_mm2 = 443.8,
                        ArrRef_mm3 = 0,
                        ArrRef_mm4 = 0,
                        DevArrRef_mm1 = 0,
                        DevArrRef_mm2 = 0,
                        DevArrRef_mm3 = 0,
                        DevArrRef_mm4 = 0,
                        Cargo = true,
            }
                );
                context.SaveChanges();
            }
            

            //NSP
            if (!context.NSP.Any())
            {
                context.NSP.Add(
                    new NSPWebData()
                    {
                        //X1
                        _devSx = 0.227193, _devHx = 0.030195, _devLx = 7.97E-10, _devQx = 4.517E-09, _devPx = 2.624E-06, _devEPSILx = 0.8533847, _devFIx = 0, _devXpx = 0.0101948, _devYpx = 0, _devZpx = 0, _devMpx = 0.0030387, _devHpx = 0.02, _devDx = 0.00564, _devEx = 0.00058,_devMAx = 0, _devMMx = 0,
                        //Y1
                        _devSy = 6.581E-05, _devHy = 0, _devLy = 6.63E-12, _devQy = 3.747E-11, _devPy = 2.658E-09, _devEPSILy = 0.0002378, _devFIy = 0.000393, _devXpy = 0, _devYpy = 0.0101948, _devZpy = 0, _devMpy = 2.995E-06, _devHpy = 0, _devDy = 5.6E-06, _devEy = 5.7E-07, _devMAy = 0, _devMMy = 0,
                        //Z1
                        _devSz = 0.0001483, _devHz = 0, _devLz = 5.51E-12, _devQz = 3.106E-11, _devPz = 1.738E-09, _devEPSILz = 0.0005358, _devFIz = 0.0002346, _devXpz = 0, _devYpz = 0, _devZpz = 0.0101948, _devMpz = 6.747E-06, _devHpz = 0, _devDz = 1.3E-05, _devEz = 1.3E-06, _devMAz = 0, _devMMz = 0,
                        //M1
                        _devSm = 0.2637498, _devHm = 0, _devLm = 3.456E-10, _devQm = 1.962E-09, _devPm = 3.167E-06, _devEPSILm = 0.954966, _devFIm = 0, _devXpm = 0, _devYpm = 0, _devZpm = 0, _devMpm = 0.012, _devHpm = 0, _devDm = 0.066, _devEm = 0.00682, _devMAm = 0, _devMMm = 0,
                        //X2
                        _devSx2 = -0.2227182, _devHx2 = -0.030195, _devLx2 = -7.97E-10, _devQx2 = -4.52E-09, _devPx2 = -2.62E-06, _devEPSILx2 = -0.85296, _devFIx2 = 0, _devXpx2 = -0.010195, _devYpx2 = 0, _devZpx2 = 0, _devMpx2 = -0.003039, _devHpx2 = -0.02, _devDx2 = -0.00564, _devEx2 = -0.00058, _devMAx2 = 0, _devMMx2 = 0,
                        //Y2
                        _devSy2 = -6.58E-05, _devHy2 = 0, _devLy2 = -6.58E-12, _devQy2 = -3.75E-11, _devPy2 = -2.66E-09, _devEPSILy2 = -0.000238, _devFIy2 = -0.000393, _devXpy2 = 0, _devYpy2 = -0.010195, _devZpy2 = 0, _devMpy2 = -2.99E-06, _devHpy2 = 0, _devDy2 = -5.6E-06, _devEy2 = -5.7E-07, _devMAy2 = 0, _devMMy2 = 0,
                        //Z2
                        _devSz2 = -0.000148277, _devHz2 = 0, _devLz2 = -5.43898E-12, _devQz2 = -3.10445E-11, _devPz2 = -1.73831E-09, _devEPSILz2 = -0.000535553, _devFIz2 = -0.000234616, _devXpz2 = 0, _devYpz2 = 0, _devZpz2 = -0.01019483, _devMpz2 = -6.74668E-06, _devHpz2 = 0, _devDz2 = -1.252E-05, _devEz2 = -1.295E-06, _devMAz2 = 0, _devMMz2 = 0,
                        //M2
                        _devSm2 = -0.263726, _devHm2 = 0, _devLm2 = -3.47E-10, _devQm2 = -1.96E-09, _devPm2 = -3.17E-06, _devEPSILm2 = -0.954979, _devFIm2 = 0, _devXpm2 = 0, _devYpm2 = 0, _devZpm2 = 0, _devMpm2 = -0.012, _devHpm2 = 0, _devDm2 = -0.066, _devEm2 = -0.00682, _devMAm2 = 0, _devMMm2 = 0,
                    }
                );
                context.SaveChanges();
            }

        }
    }
}
