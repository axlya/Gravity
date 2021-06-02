using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravityCalc
{
    /// <summary>
    /// Паспортные данные
    /// </summary>
    public struct PasportData
    {
        public void DefaultInit()
        {
            /////////////////////////////////////////////////////////////////////////StandParameters
            S = 449.2;
            DevS = 0.02;
            H = 386;
            DevH = 0.02;
            L = 1349;
            DevL = 0.02;
            Q = 238;
            DevQ = 0.02;
            DevP = 0.001;
            DevEpsilon = 5;
            DevFi = 1;
            Pasport_mm = 443.8;
            DevPas_mm = 0;
            D = 1779;
            DevD = 0.02;
            E = -41;
            DevE = 0.02;
            Pasport_ma = 0;
            DevPasport_ma = 0;

            /////////////////////////////////////////////////////////////////////////AdapterParametrs
            Xper = 2000;
            DevХper = 0.02;
            Yper = 0;
            DevYper = 0.02;
            Zper = 0;
            DevZper = 0.02;
            MassPer = 2000;
            DevMassPer = 0.012;
            Hper = 1800.01;
            DevHPer = 0.02;

            /////////////////////////////////////////////////////////////////////////AdapterParametrs
            Xkp = 500;
            DevXkp = 0.04;
            Ykp = 0;
            DevYkp = 0.04;
            Zkp = 0;
            DevZkp = 0.04;
            MassKp = 3000;
            DevMassKp = 0.024;

            /////////////////////////////////////////////////////////////////////////KP_Parameters
            MassProd = 3000;
            Xprod = 500;
            Yprod = 0;
            Zprod = 0;

            /////////////////////////////////////////////////////////////////////// Тарирования углов
            Dev = -0.022;

            ///////////////////////////////////////////////////////////////////////////////////////////// Поправки по координатам (Δ=Δ600+(m–m600)∙(Δ6000–Δ600)/(m6000–m600))
            DevX600 = -0.095;
            DevX6000 = 9.9;
            DevY600 = -0.1552;
            DevY6000 = 0.49;
            DevZ600 = -0.2201;
            DevZ6000 = -1.47;


        }

        /////////////////////////////////////////////////////////////////////////StandParameters
        /// <summary>
        /// Геометрические параметры стенда (Ось наклона стенда)
        /// </summary>
        public double S { get; set; }
        /// <summary>
        /// (±Δ)S - допустимое отклонение геометрических параметров стенда
        /// </summary>
        public double DevS { get; set; }
        /// <summary>
        /// Геометрические параметры стенда (Ось наклона стенда)
        /// </summary>
        public double H { get; set; }
        /// <summary>
        /// (±Δ)H - допустимое отклонение геометрических параметров стенда
        /// </summary>
        public double DevH { get; set; }
        /// <summary>
        /// Горизонтальное расстояния от оси наклона до оси ролика в системе координат стола
        /// </summary>
        public double L { get; set; }
        /// <summary>
        /// (±Δ)L - допустимое отклонение горизонтального расстояния от оси наклона до оси ролика в системе координат стола
        /// </summary>
        public double DevL { get; set; }
        /// <summary>
        /// Вертикальное расстояния от оси наклона до оси ролика в системе координат стола
        /// </summary>
        public double Q { get; set; }
        /// <summary>
        /// (±Δ)Q - допустимое отклонение вертикального расстояния от оси наклона до оси ролика в системе координат стола
        /// </summary>
        public double DevQ { get; set; }
        /// <summary>
        /// ±ΔР - погрешность измерение усилия датчиком дисбаланса
        /// </summary>
        public double DevP { get; set; }
        /// <summary>
        /// ±Δξ - погрешность определения угла наклона 
        /// </summary>
        public double DevEpsilon { get; set; }
        /// <summary>
        /// ±Δφ - Неисключенная систематическая погрешность (НСП) углов поворота платформы
        /// </summary>
        public double DevFi { get; set; }
        /// <summary>
        /// Груз разгрузки (корректирующий противовес)   // массив {270, 540, 810, 1090, 1350}  - не изменится!  
        /// </summary>
        public double Pasport_mm { get; set; }
        /// <summary>
        /// (±Δ)_m_m - допустимое отклонение противовеса
        /// </summary>
        public double DevPas_mm { get; set; }
        /// <summary>
        /// Расстоянии установки эталонного груза от оси наклона
        /// </summary>
        public double D { get; set; }
        /// <summary>
        /// (±Δ)D - допустимое отклонение расстояния установки эталонного груза от оси наклона
        /// </summary>
        public double DevD { get; set; }
        /// <summary>
        /// Геометрические параметры стенда
        /// </summary>
        public double E { get; set; }
        /// <summary>
        /// (±Δ)E - допустимое отклонение геометрических параметров стенда
        /// </summary>
        public double DevE { get; set; }
        /// <summary>
        /// подвижный груз - Mmpg (эталонный груз) 
        /// </summary>
        public double Pasport_ma { get; set; }
        /// <summary>
        /// (±Δ)_m_a - допустимое отклонение корректирующего противовеса 
        /// </summary>
        public double DevPasport_ma { get; set; }


        /////////////////////////////////////////////////////////////////////////AdapterParametrs
        /// <summary>
        /// Координаты центра масс переходника в системе координат переходника
        /// </summary>
        public double Xper { get; set; }
        /// <summary>
        /// (±Δ)Хper - допустимое отклонение КЦМ переходника в системе координат переходника
        /// </summary>
        public double DevХper { get; set; }
        /// <summary>
        /// Координаты центра масс переходника в системе координат переходника
        /// </summary>
        public double Yper { get; set; }
        /// <summary>
        /// (±Δ)Yper - допустимое отклонение КЦМ переходника в системе координат переходника 
        /// </summary>
        public double DevYper { get; set; }
        /// <summary>
        /// Координаты центра масс переходника в системе координат переходника
        /// </summary>
        public double Zper { get; set; }
        /// <summary>
        /// (±Δ)Zper - допустимое отклонение КЦМ переходника в системе координат переходника
        /// </summary>
        public double DevZper { get; set; }
        /// <summary>
        /// масса переходника
        /// </summary>
        public double MassPer { get; set; }
        /// <summary>
        /// (±Δ)_m_per - допустимое отклонение массы переходника 
        /// </summary>
        public double DevMassPer { get; set; }
        /// <summary>
        /// высота переходника 
        /// </summary>
        public double Hper { get; set; }
        /// <summary>
        /// (±Δ)_h_p - допустимое отклонение длины переходника 
        /// </summary>
        public double DevHPer { get; set; }


        /////////////////////////////////////////////////////////////////////////KP_Parameters
        /// <summary>
        /// Координаты КП
        /// </summary>
        public double Xkp { get; set; }
        /// <summary>
        /// (±Δ)Xkp - допустимое отклонение
        /// </summary>
        public double DevXkp { get; set; }
        /// <summary>
        /// Координаты КП
        /// </summary>
        public double Ykp { get; set; }
        /// <summary>
        /// (±Δ)Ykp - допустимое отклонение
        /// </summary>
        public double DevYkp { get; set; }
        /// <summary>
        /// Координаты КП
        /// </summary>
        public double Zkp { get; set; }
        /// <summary>
        /// (±Δ)Zkp - допустимое отклонение
        /// </summary>
        public double DevZkp { get; set; }
        /// <summary>
        /// Масса КП
        /// </summary>
        public double MassKp { get; set; }
        /// <summary>
        /// (±Δ)_m_kp  - допустимое отклонение массы КП
        /// </summary>
        public double DevMassKp { get; set; }

        /////////////////////////////////////////////////////////////////////////ProductParameters
        /// <summary>
        /// Масса изделия
        /// </summary>
        public double MassProd { get; set; }
        /// <summary>
        /// Координаты изделия по КД
        /// </summary>
        public double Xprod { get; set; }
        /// <summary>
        /// Координаты изделия по КД
        /// </summary>
        public double Yprod { get; set; }
        /// <summary>
        /// Координаты изделия по КД
        /// </summary>
        public double Zprod { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////////// Reference_ma
        //// <summary>
        /// Массив эталоной массы подвижного груза (4 элемента массива)
        /// </summary>
        public double[] ArrRef_ma { get; set; }
        /// <summary>
        /// DevArrRef_ma - допустипое отклонение эталонной массы подвижного груза  (4 элемента массива))
        /// </summary>
        public double[] DevArrRef_ma { get; set; }
        /// <summary>
        /// Для наклона стенда при подвижном грузе 
        /// </  summary>
        public double Epsilon_ma { get; set; }

        //////////////////////////////////////////////////////////////////////////////////////////// Reference_mm
        //// <summary>
        /// Массив эталоной массы груза - разгрузки (4 элемента массива)
        /// </summary>
        public double[] ArrRef_mm { get; set; }
        /// <summary>
        /// DevArrRef_ma - допустипое отклонение эталонной массы груза - разгрузки
        /// </summary>
        public double[] DevArrRef_mm { get; set; }
        /// <summary>
        /// Для наклона стенда при использование груза - разгрузки
        /// </  summary>
        public double Epsilon_mm { get; set; }

        ///////////////////////////////////////////////////////////////////////////////////////////// Данные из тарировки углов
        /// <summary>
        /// Δ - участвует в формуле для поправки углов (стд отклонение углов)
        /// </summary
        public double Dev { get; set; }


        ///////////////////////////////////////////////////////////////////////////////////////////// Поправки по координатам (Δ=Δ600+(m–m600)∙(Δ6000–Δ600)/(m6000–m600))
        public double DevX600 { get; set; }
        public double DevX6000 { get; set; }
        public double DevY600 { get; set; }
        public double DevY6000 { get; set; }
        public double DevZ600 { get; set; }
        public double DevZ6000 { get; set; }

        const double m600 = 537.76;
        const double m6000 = 5385.1;

    }
}
