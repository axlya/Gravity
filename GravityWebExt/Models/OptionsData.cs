using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GravityCalc;

namespace GravityWebExt.Models
{
    /// <summary>
    /// Параметры - копия данных структуры PassportData (GravityCalc)
    /// </summary>
    public class OptionsData
    {
        public int Id { get; set; }
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
        /// ±ΔР - погрешность измерения усилия датчиком дисбаланса
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
        /// Расстояние установки эталонного груза от оси наклона
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
        /// (±Δ)_h_p - допустимое отклонение высоты переходника 
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

        //// методы
        

        /// <summary>
        /// Создание структуры данных для расчёта
        /// </summary>
        /// <returns></returns>
        public GravityCalc.PasportData SetDataForCalculate()
        {
            PasportData data = new();
            data.DefaultInit();
            data.S = this.S;
            data.DevS = this.DevS;
            data.H = this.H;
            data.DevH = this.DevH;
            data.L = this.L;
            data.DevL = this.DevL;
            data.Q = this.Q;
            data.DevQ = this.DevQ;
            data.DevP = this.DevP;
            data.DevEpsilon = this.DevEpsilon;
            data.DevFi = this.DevFi;
            data.Pasport_mm = this.Pasport_mm;
            data.DevPas_mm = this.DevPas_mm;
            data.D = this.D;
            data.DevD = this.DevD;
            data.E = this.E;
            data.DevE = this.DevE;
            data.Pasport_ma = this.Pasport_ma;
            data.DevPasport_ma = this.DevPasport_ma;
            data.Xper = this.Xper;
            data.DevХper = this.DevХper;
            data.Yper = this.Yper;
            data.DevYper = this.DevYper;
            data.Zper = this.Zper;
            data.DevZper = this.DevZper;
            data.MassPer = this.MassPer;
            data.DevMassPer = this.DevMassPer;
            data.Hper = this.HPer;
            data.DevHPer = this.DevHPer;
            data.Xkp = this.Xkp;
            data.DevXkp = this.DevXkp;
            data.Ykp = this.Ykp;
            data.DevYkp = this.DevYkp;
            data.Zkp = this.Zkp;
            data.DevZkp = this.DevZkp;
            data.DevMassKp = this.DevMassKp;
            data.MassProd = this.MassProd;
            data.Xprod = this.Xprod;
            data.Yprod = this.Yprod;
            data.Zprod = this.Zprod;
            return data;
        } 
    }
}
