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
                        PasK = 837.5,
                        PasS = 440,
                        PasDevS = 0,
                        PasH = 385,
                        PasDevH = 0,
                        PasL = 2405,
                        PasDevL = 0,
                        PasQ = 445,
                        PasDevQ = 0.02,
                        PasDevPdisbal = 0,
                        PasDevPpower = 0,
                        PasDevEpsilon = 0,
                        PasDevFi = 0,
                        PasMm = 0,
                        PasDevMm = 0,
                        PasD = 2120,
                        PasDevD = 0,
                        PasE = 0,
                        PasDevE = 0,
                        PasMa = 0,
                        PasDevMa = 0,
                        PerX = 0,
                        PerDevX = 0,
                        PerY = 0,
                        PerDevY = 0,
                        PerZ = 0,
                        PerDevZ = 0,
                        PerMas = 0,
                        PerDevMas = 0,
                        PerH = 0,
                        PerDevH = 0,
                        KpX = 0,
                        KpDevX = 0,
                        KpY = 0,
                        KpDevY = 0,
                        KpZ = 0,
                        KpDevZ = 0,
                        KpMas = 0,
                        KpDevMas = 0,
                        Fi = 0,
                        Dev = -0.022,                       
                        Cargo = true,
                        KP = true,
                        MassPG = 0,
                        DevMassPG = 0,
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
                        _devSx = 0.227193, _devHx = 0.030195, _devLx = 7.97E-10, _devQx = 4.517E-09, _devPx = 2.624E-06, _devEPSILx = 0.8533847, _devFIx = 0, _devXpx = 0.0101948, _devYpx = 0, _devZpx = 0, _devMpx = 0.0030387, _devHpx = 0.02, _devDx = 0.00564, _devEx = 0.00058,_devMAx = 0, _devMMx = 0, _devMASSx = 0,
                        //Y1
                        _devSy = 6.581E-05, _devHy = 0, _devLy = 6.63E-12, _devQy = 3.747E-11, _devPy = 2.658E-09, _devEPSILy = 0.0002378, _devFIy = 0.000393, _devXpy = 0, _devYpy = 0.0101948, _devZpy = 0, _devMpy = 2.995E-06, _devHpy = 0, _devDy = 5.6E-06, _devEy = 5.7E-07, _devMAy = 0, _devMMy = 0, _devMASSy = 0,
                        //Z1
                        _devSz = 0.0001483, _devHz = 0, _devLz = 5.51E-12, _devQz = 3.106E-11, _devPz = 1.738E-09, _devEPSILz = 0.0005358, _devFIz = 0.0002346, _devXpz = 0, _devYpz = 0, _devZpz = 0.0101948, _devMpz = 6.747E-06, _devHpz = 0, _devDz = 1.3E-05, _devEz = 1.3E-06, _devMAz = 0, _devMMz = 0, _devMASSz = 0,
                        //M1
                        _devSm = 0.2637498, _devHm = 0, _devLm = 3.456E-10, _devQm = 1.962E-09, _devPm = 3.167E-06, _devEPSILm = 0.954966, _devFIm = 0, _devXpm = 0, _devYpm = 0, _devZpm = 0, _devMpm = 0.012, _devHpm = 0, _devDm = 0.066, _devEm = 0.00682, _devMAm = 0, _devMMm = 0, _devMASSm = 0,
                        //X2
                        _devSx2 = -0.2227182, _devHx2 = -0.030195, _devLx2 = -7.97E-10, _devQx2 = -4.52E-09, _devPx2 = -2.62E-06, _devEPSILx2 = -0.85296, _devFIx2 = 0, _devXpx2 = -0.010195, _devYpx2 = 0, _devZpx2 = 0, _devMpx2 = -0.003039, _devHpx2 = -0.02, _devDx2 = -0.00564, _devEx2 = -0.00058, _devMAx2 = 0, _devMMx2 = 0, _devMASSx2 = 0,
                        //Y2
                        _devSy2 = -6.58E-05, _devHy2 = 0, _devLy2 = -6.58E-12, _devQy2 = -3.75E-11, _devPy2 = -2.66E-09, _devEPSILy2 = -0.000238, _devFIy2 = -0.000393, _devXpy2 = 0, _devYpy2 = -0.010195, _devZpy2 = 0, _devMpy2 = -2.99E-06, _devHpy2 = 0, _devDy2 = -5.6E-06, _devEy2 = -5.7E-07, _devMAy2 = 0, _devMMy2 = 0, _devMASSy2 = 0,
                        //Z2
                        _devSz2 = -0.000148277, _devHz2 = 0, _devLz2 = -5.43898E-12, _devQz2 = -3.10445E-11, _devPz2 = -1.73831E-09, _devEPSILz2 = -0.000535553, _devFIz2 = -0.000234616, _devXpz2 = 0, _devYpz2 = 0, _devZpz2 = -0.01019483, _devMpz2 = -6.74668E-06, _devHpz2 = 0, _devDz2 = -1.252E-05, _devEz2 = -1.295E-06, _devMAz2 = 0, _devMMz2 = 0, _devMASSz2 = 0,
                        //M2
                        _devSm2 = -0.263726, _devHm2 = 0, _devLm2 = -3.47E-10, _devQm2 = -1.96E-09, _devPm2 = -3.17E-06, _devEPSILm2 = -0.954979, _devFIm2 = 0, _devXpm2 = 0, _devYpm2 = 0, _devZpm2 = 0, _devMpm2 = -0.012, _devHpm2 = 0, _devDm2 = -0.066, _devEm2 = -0.00682, _devMAm2 = 0, _devMMm2 = 0, _devMASSm2 = 0,
                    }
                );
                context.SaveChanges();
            }

            //NSP
            if (!context.RecomValWebData.Any())
            {
                context.RecomValWebData.Add(
                    new RecomValWebData()
                    {
                        ProdX = 0,
                        ProdDevX = 0,
                        ProdY = 0,
                        ProdDevY = 0,
                        ProdZ = 0,
                        ProdDevZ = 0,
                        ProdMas = 0,
                        ProdDevMas = 0,
                        EpsilonMa = 6,
                        EpsilonMm = 16,
                        ArrMasMa1 = 270,
                        ArrMasMa2 = 540,
                        ArrMasMa3 = 810,
                        ArrMasMa4 = 1180,
                        ArrMasMa5 = 1350,
                        ArrMasMa6 = 0,
                        DevArrMasMa1 = 0,
                        DevArrMasMa2 = 0,
                        DevArrMasMa3 = 0,
                        DevArrMasMa4 = 0,
                        DevArrMasMa5 = 0,
                        DevArrMasMa6 = 0,
                        ArrMasMm1 = 270,
                        ArrMasMm2 = 540,
                        ArrMasMm3 = 810,
                        ArrMasMm4 = 1180,
                        ArrMasMm5 = 1350,
                        ArrMasMm6 = 0,
                        DevArrMasMm1 = 0,
                        DevArrMasMm2 = 0,
                        DevArrMasMm3 = 0,
                        DevArrMasMm4 = 0,
                        DevArrMasMm5 = 0,
                        DevArrMasMm6 = 0,
                
            }
                );
                context.SaveChanges();
            }

        }
    }
}
