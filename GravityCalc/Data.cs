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
            S = 1;
            DevS = 2;
            H = 3;
            DevH = 4;
            L = 5;
            DevL = 6;
            Q = 7;
            DevQ = 8;
            DevP = 9;
            DevEpsilon = 10;
            DevFi = 11;
            Pasport_mm = 12;
            DevPas_mm = 13;
            D = 14;
            DevD = 15;
            E = 16;
            DevE = 17;
            Pasport_ma = 18;
            DevPasport_ma = 19;
            Xper = 20;
            DevХper = 21;
            Yper = 22;
            DevYper = 23;
            Zper = 24;
            DevZper = 25;
            MassPer = 26;
            DevMassPer = 27;
            HPer = 28;
            DevHPer = 29;
            Xkp = 30;
            DevXkp = 31;
            Ykp = 32;
            DevYkp = 33;
            Zkp = 34;
            DevZkp = 35;
            MassKp = 36;
            DevMassKp = 37;
            MassProd = 38;
            Xprod = 39;
            Yprod = 40;
            Zprod = 41;
        }
        /// <summary>
        /// Геометрические параметры стенда
        /// </summary>
        public double S { get; set; }
        /// <summary>
        /// (±Δ)S - допустимое отклонение геометрических параметров стенда
        /// </summary>
        public double DevS { get; set; }
        /// <summary>
        /// Геометрические параметры стенда
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
        /// Груз разгрузки (корректирующий противовес)   
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
        public double HPer { get; set; }
        /// <summary>
        /// (±Δ)_h_p - допустимое отклонение длины переходника 
        /// </summary>
        public double DevHPer { get; set; }
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
    }
}
