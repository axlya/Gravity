using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GravityCalc;

namespace GravityWebExt.Models
{
    /// <summary>
    /// Рассчитанные данные
    /// </summary>
    /// 
    public class CalculatedDataWeb
    {
        public int Id { get; set; }
        public double RefK { get; set; }

        /// <summary>
        /// Отклоления в плоскости xOy -> 3 значения будут => Градусы \ Минуты \ Секунды
        /// </summary>
        public double DevPlane_xOy { get; set; }

        /// <summary>
        /// Отклоления в плоскости xOy -> 3 значения будут => Градусы \ Минуты \ Секунды
        /// </summary>
        public double DevPlane_xOy_ { get; set; }

        /// <summary>
        /// Отклоления в плоскости xOz -> 3 значения будут => Градусы \ Минуты \ Секунды
        /// </summary>
        public double DevPlane_xOz { get; set; }
        //_____________________________________________________________________________________________________________________________________________________________________________________________
        //Нужно еще сделать диаграммы на каждый угол 0°\90°\180... для КП тоже самое... диаграммы одинаковые. (По значениям эталонного угла, углов равновессия и среднего значения углов равновесия)!!!
        //_____________________________________________________________________________________________________________________________________________________________________________________________

        //Координаты Центра Масс (КЦМ)
        public double RES_X { get; set; }
        public double RES_Y { get; set; }
        public double RES_Z { get; set; }
        public double RES_M { get; set; }

        // Измерения связанные с подвижным грузом - Massa_mpg (эталонный груз)  
        /////////////////////////////////////////////////////////////////////////////////////////////////// угол 0°
        /// <summary>
        /// Средний угол равновесия - α
        /// </summary>
        public double AverageValue { get; set; } // Нужно для 90°\180°\270° - сделать, а так же для груза-разгрузки и КП

        /// <summary>
        /// Поправка координат при определение КМЦ
        /// </summary>
        public double kcmDev { get; set; }

        /// <summary>
        /// Для тарировки углов
        /// </summary>
        public double Amendment { get; set; }


        /////////////////////////////////////////////////////////////////////////////////////////////Определение средних значений КЦМ и массы, и их отклонений 
        /// <summary>
        /// Среднее значение Массы изделия
        /// </summary>
        public double AverProdValMas { get; set; }

        /// <summary>
        /// Среднее значение X
        /// </summary>
        public double AverProdVal_X { get; set; }

        /// <summary>
        /// Среднее значение Y
        /// </summary>
        public double AverProdVal_Y { get; set; }

        /// <summary>
        /// Среднее значение Z
        /// </summary>
        public double AverProdVal_Z { get; set; }


        /////////////////////////////////////////////////////////////////////////////////////////////Определение NSP
        // - Граница суммарной не исключённой систематической погрешности c "+" Δθ=1,1√Σ(+Δi)2
        public double ErLimX1 { get; set; }
        public double ErLimY1 { get; set; }
        public double ErLimZ1 { get; set; }
        public double ErLimM1 { get; set; }
        // - Граница суммарной не исключённой систематической погрешности c "-" Δθ=1,1√Σ(-Δi)2
        public double ErLimX2 { get; set; }
        public double ErLimY2 { get; set; }
        public double ErLimZ2 { get; set; }
        public double ErLimM2 { get; set; }

        //NSPmax = new double[4] { NSPmaxX, NSPmaxY, NSPmaxZ, NSPmaxM }; <=== (NSPmaxX = Math.Max(ErLimX1, ErLimX2); - показываю, откуда это берется
        /// <summary>
        ///  Δθi - НСП(max)
        /// </summary>
        /// //public double[] NSPmax { NSPmaxX, NSPmaxY, NSPmaxZ, NSPmaxM }

        public double NSPmaxX { get; set; }
        public double NSPmaxY { get; set; }
        public double NSPmaxZ { get; set; }
        public double NSPmaxM { get; set; }


        /// <summary>
        /// СКО НСП - (Sθ)
        /// </summary>
        public double ErLimSx { get; set; }
        public double ErLimSy { get; set; }
        public double ErLimSz { get; set; }
        public double ErLimSm { get; set; }

        /// <summary>
        /// Коэффициент Стьюдента 
        /// </summary>
        const double KF_t = 2.262;

        /// <summary>
        /// Весовой Коэффициент
        /// </summary>
        public double KvesX { get; set; }
        public double KvesY { get; set; }
        public double KvesZ { get; set; }
        public double KvesM { get; set; }

        /// <summary>
        /// Cсуммарное среднее квадратическое отклонение (СКОΣ)
        /// </summary>
        public double Sdev_reNsX { get; set; }
        public double Sdev_reNsY { get; set; }
        public double Sdev_reNsZ { get; set; }
        public double Sdev_reNsM { get; set; }

        /// <summary>
        /// Границы погрешности
        /// </summary>
        public double granX { get; set; }
        public double granY { get; set; }
        public double granZ { get; set; }
        public double granM { get; set; }



        //////////////////////////////////////////////// Итоговые значения для КП
        /// <summary>
        /// Разница
        /// </summary>
        public double _pX { get; set; }
        /// <summary>
        /// Разница
        /// </summary>
        public double _pY { get; set; }
        /// <summary>
        /// Разница
        /// </summary>
        public double _pZ { get; set; }
        /// <summary>
        /// Разница
        /// </summary>
        public double _pM { get; set; }
        /// <summary>
        /// Системные отклоениня после введения поправок
        /// </summary>
        public double SystemDevX { get; set; }
        /// <summary>
        /// Системные отклоениня после введения поправок
        /// </summary>
        public double SystemDevY { get; set; }
        /// <summary>
        /// Системные отклоениня после введения поправок
        /// </summary>
        public double SystemDevZ { get; set; }
        /// <summary>
        /// Системные отклоениня после введения поправок
        /// </summary>
        public double SystemDevM { get; set; }
        /// <summary>
        /// КЦМ изделия при использование метода замещения
        /// </summary>
        public double _kmcKPx { get; set; }
        /// <summary>
        /// КЦМ изделия при использование метода замещения
        /// </summary>
        public double _kmcKPy { get; set; }
        /// <summary>
        /// КЦМ изделия при использование метода замещения
        /// </summary>
        public double _kmcKPz { get; set; }
        /// <summary>
        /// КЦМ изделия при использование метода замещения
        /// </summary>
        public double _kmcKPm { get; set; }
        /// <summary>
        /// Системные погрешности изделия при использование КП
        /// </summary>
        public double SystemEerX { get; set; }
        /// <summary>
        /// Системные погрешности изделия при использование КП
        /// </summary>
        public double SystemEerY { get; set; }
        /// <summary>
        /// Системные погрешности изделия при использование КП
        /// </summary>
        public double SystemEerZ { get; set; }
        /// <summary>
        /// Системные погрешности изделия при использование КП
        /// </summary>
        public double SystemEerM { get; set; }
        /// <summary>
        /// Граница погрешности изделия при методе замещения
        /// </summary>
        public double GranKPx { get; set; }
        /// <summary>
        /// Граница погрешности изделия при методе замещения
        /// </summary>
        public double GranKPy { get; set; }
        /// <summary>
        /// Граница погрешности изделия при методе замещения
        /// </summary>
        public double GranKPz { get; set; }
        /// <summary>
        /// Граница погрешности изделия при методе замещения
        /// </summary>
        public double GranKPm { get; set; }
        
        public CalculatedDataWeb()
        {
        }
        public CalculatedDataWeb(CalculatedData calculatedData)
        {
            
            RefK = calculatedData.RefK;            
            DevPlane_xOy = calculatedData.DevPlane_xOy;
            DevPlane_xOy_ = calculatedData.DevPlane_xOy; //Нужны градусы\минуты\секунды
            DevPlane_xOz = calculatedData.DevPlane_xOz;
            RES_X = calculatedData.RES_X;
            RES_Z = calculatedData.RES_Z;
            RES_Y = calculatedData.RES_Y;
            RES_M = calculatedData.RES_M;
            AverageValue = calculatedData.AverageValue;
            kcmDev = calculatedData.kcmDev;
            Amendment = calculatedData.Amendment;
            //AverProdValMas = calculatedData.AverProdValMas;
            //AverProdVal_X = calculatedData.AverProdVal_X;
            //AverProdVal_Y = calculatedData.AverProdVal_Y;
            //AverProdVal_Z = calculatedData.AverProdVal_Z;
            //ErLimX1 = calculatedData.ErLimX1;
            //ErLimY1 = calculatedData.ErLimY1;
            //ErLimZ1 = calculatedData.ErLimZ1;
            //ErLimM1 = calculatedData.ErLimM1;
            //ErLimX2 = calculatedData.ErLimX2;
            //ErLimY2 = calculatedData.ErLimY2;
            //ErLimZ2 = calculatedData.ErLimZ2;
            //ErLimM2 = calculatedData.ErLimM2;
            //NSPmaxX = calculatedData.NSPmaxX;
            //NSPmaxY = calculatedData.NSPmaxY;
            //NSPmaxZ = calculatedData.NSPmaxZ;
            //NSPmaxM = calculatedData.NSPmaxM;
            //ErLimSx = calculatedData.ErLimSx;
            //ErLimSy = calculatedData.ErLimSy;
            //ErLimSz = calculatedData.ErLimSz;
            //ErLimSm = calculatedData.ErLimSm;
            //KvesX = calculatedData.KvesX;
            //KvesY = calculatedData.KvesY;
            //KvesZ = calculatedData.KvesZ;
            //KvesM = calculatedData.KvesM;
            //Sdev_reNsX = calculatedData.Sdev_reNsX;
            //Sdev_reNsY = calculatedData.Sdev_reNsY;
            //Sdev_reNsZ = calculatedData.Sdev_reNsZ;
            //Sdev_reNsM = calculatedData.Sdev_reNsM;
            //granX = calculatedData.granX;
            //granY = calculatedData.granY;
            //granZ = calculatedData.granZ;
            //granM = calculatedData.granM;
            /////////////////////////////////////////////////////
            _pX = calculatedData._pX;
            _pY = calculatedData._pY;
            _pZ = calculatedData._pZ;
            _pM = calculatedData._pM;
            SystemDevX = calculatedData.SystemDevX;
            SystemDevY = calculatedData.SystemDevY;
            SystemDevZ = calculatedData.SystemDevZ;
            SystemDevM = calculatedData.SystemDevM;
            _kmcKPx = calculatedData._kmcKPx;
            _kmcKPy = calculatedData._kmcKPy;
            _kmcKPz = calculatedData._kmcKPz;
            _kmcKPm = calculatedData._kmcKPm;
            SystemEerX = calculatedData.SystemEerX;
            SystemEerY = calculatedData.SystemEerY;
            SystemEerZ = calculatedData.SystemEerZ;
            SystemEerM = calculatedData.SystemEerM;
            GranKPx = calculatedData.GranKPx;
            GranKPy = calculatedData.GranKPy;
            GranKPz = calculatedData.GranKPz;
            GranKPm = calculatedData.GranKPm;

        }
    }
}
