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
        public double AverageValue { get; set; }

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

        /// <summary>
        /// Все углы заполнены 
        /// </summary>
        public bool AllAngelFilling { get; set; }
        public bool ArraysAreFilling { get; set; } //массивы находятся в процессе заполнения 
        public int kcmAngel_0 { get; set; } //0 - массивы не заполнены, 1 - массивы заполены на половину, 2 - массивы заполнены полностью
        public int kcmAngel_90 { get; set; }
        public int kcmAngel_180 { get; set; }
        public int kcmAngel_270 { get; set; }
        public int mAngel_0 { get; set; }
        public int mAngel_180 { get; set; }

        public List<double> BeginBalanceAngleArr0 { get; set; }
        public List<double> MiddleBalanceAngleArr0 { get; set; }
        public List<double> BeginDisbalanceSensorArr0 { get; set; }
        public List<double> MiddleDisbalanceSensorArr0 { get; set; }
        public List<double> BeginBalanceAngleArr90 { get; set; }
        public List<double> MiddleBalanceAngleArr90 { get; set; }
        public List<double> BeginDisbalanceSensorArr90 { get; set; }
        public List<double> MiddleDisbalanceSensorArr90 { get; set; }
        public List<double> BeginBalanceAngleArr180 { get; set; }
        public List<double> MiddleBalanceAngleArr180 { get; set; }
        public List<double> BeginDisbalanceSensorArr180 { get; set; }
        public List<double> MiddleDisbalanceSensorArr180 { get; set; }
        public List<double> BeginBalanceAngleArr270 { get; set; }
        public List<double> MiddleBalanceAngleArr270 { get; set; }
        public List<double> BeginDisbalanceSensorArr270 { get; set; }
        public List<double> MiddleDisbalanceSensorArr270 { get; set; }
        public List<double> BeginPowerSensor0 { get; set; }
        public List<double> MiddlePowerSensor0 { get; set; }
        public List<double> BeginPowerSensor180 { get; set; }
        public List<double> MiddlePowerSensor180 { get; set; }
        public List<double> BeginIndicationK0 { get; set; }
        public List<double> MiddleIndicationK0 { get; set; }
        public List<double> BeginIndicationK180 { get; set; }
        public List<double> MiddleIndicationK180 { get; set; }

        
        public CalculatedDataWeb(CalculatedData calculatedData)
        {
            
            RefK = calculatedData.RefK;            
          
            RES_X = calculatedData.RES_X;
            RES_Z = calculatedData.RES_Z;
            RES_Y = calculatedData.RES_Y;
            RES_M = calculatedData.RES_M;
            AverageValue = calculatedData.AverageValue;
            kcmDev = calculatedData.kcmDev;
            Amendment = calculatedData.Amendment;
           
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
            /////////////////////////////////////////////////////////
            AllAngelFilling = calculatedData.AllAngelFilling;
            ArraysAreFilling = calculatedData.ArraysAreFilling;
            kcmAngel_0 = calculatedData.kcmAngel_0;
            kcmAngel_90 = calculatedData.kcmAngel_90;
            kcmAngel_180 = calculatedData.kcmAngel_180;
            kcmAngel_270 = calculatedData.kcmAngel_270;
            mAngel_0 = calculatedData.mAngel_0;
            mAngel_180 = calculatedData.mAngel_180;

            BeginBalanceAngleArr0 = calculatedData.BeginBalanceAngleArr0 ?? new ();
            MiddleBalanceAngleArr0 = calculatedData.MiddleBalanceAngleArr0 ?? new();
            BeginDisbalanceSensorArr0 = calculatedData.BeginDisbalanceSensorArr0 ?? new();
            MiddleDisbalanceSensorArr0 = calculatedData.MiddleDisbalanceSensorArr0 ?? new();
            BeginBalanceAngleArr90 = calculatedData.BeginBalanceAngleArr90 ?? new();
            MiddleBalanceAngleArr90 = calculatedData.MiddleBalanceAngleArr90 ?? new();
            BeginDisbalanceSensorArr90 = calculatedData.BeginDisbalanceSensorArr90 ?? new();
            MiddleDisbalanceSensorArr90 = calculatedData.MiddleDisbalanceSensorArr90 ?? new();
            BeginBalanceAngleArr180 = calculatedData.BeginBalanceAngleArr180 ?? new();
            MiddleBalanceAngleArr180 = calculatedData.MiddleBalanceAngleArr180 ?? new();
            BeginDisbalanceSensorArr180 = calculatedData.BeginDisbalanceSensorArr180 ?? new();
            MiddleDisbalanceSensorArr180 = calculatedData.MiddleDisbalanceSensorArr180 ?? new();
            BeginBalanceAngleArr270 = calculatedData.BeginBalanceAngleArr270 ?? new();
            MiddleBalanceAngleArr270 = calculatedData.MiddleBalanceAngleArr270 ?? new();
            BeginDisbalanceSensorArr270 = calculatedData.BeginDisbalanceSensorArr270 ?? new();
            MiddleDisbalanceSensorArr270 = calculatedData.MiddleDisbalanceSensorArr270 ?? new();
            BeginPowerSensor0 = calculatedData.BeginPowerSensor0 ?? new();
            MiddlePowerSensor0 = calculatedData.MiddlePowerSensor0 ?? new();
            BeginPowerSensor180 = calculatedData.BeginPowerSensor180 ?? new();
            MiddlePowerSensor180 = calculatedData.MiddlePowerSensor180 ?? new();
            BeginIndicationK0 = calculatedData.BeginIndicationK0 ?? new();
            MiddleIndicationK0 = calculatedData.MiddleIndicationK0 ?? new();
            BeginIndicationK180 = calculatedData.BeginIndicationK180 ?? new();
            MiddleIndicationK180 = calculatedData.MiddleIndicationK180 ?? new();




    }
    }
}
