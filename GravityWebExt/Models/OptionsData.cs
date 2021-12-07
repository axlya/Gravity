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
        /// Корректирующий груз для КЦМ
        /// </summary>
        public double PasMm { get; set; }
        /// <summary>
        /// Отклонения корректирующего груза для КЦМ
        /// </summary>
        public double PasDevMm { get; set; }
        /// <summary>
        /// Корректирующий груз для М
        /// </summary>
        public double PasMa { get; set; }
        /// <summary>
        /// Отклонения корректирующего груза для М
        /// </summary>
        public double PasDevMa { get; set; }
        /// <summary>
        ///Горизонтальное расстояние между осью наклона стенда и центром тяжести подвижного груза в его переднем положении (постоянное значение станка от центра изделия до центра линейки)
        /// </summary>
        public double PasK { get; set; }
        public double PasDevK { get; set; }
        /// <summary>
        /// Горизонтальное расстояние между осью наклона стенда и осью поворота планшайбы
        /// </summary>
        public double PasS { get; set; }
        /// <summary>
        /// (±Δ)S 
        /// </summary>
        public double PasDevS { get; set; }
        /// <summary>
        /// Вертикальное расстояние между осью наклона стенда и установочной поверхностью планшайбы стенда
        /// </summary>
        public double PasH { get; set; }
        /// <summary>
        /// (±Δ)H
        /// </summary>
        public double PasDevH { get; set; }
        /// <summary>
        /// Горизонтальное расстояние между осью наклона стенда ицентром опорного ролика
        /// </summary>
        public double PasL { get; set; }
        /// <summary>
        /// (±Δ)L 
        /// </summary>
        public double PasDevL { get; set; }
        /// <summary>
        /// Вертикальное расстояние между осью наклона стенда и центром опорного ролика
        /// </summary>
        public double PasQ { get; set; }
        /// <summary>
        /// (±Δ)Q 
        /// </summary>
        public double PasDevQ { get; set; }
        /// <summary>
        /// ±ΔР - погрешность измерения усилия датчиком дисбаланса
        /// </summary>
        public double PasDevPdisbal { get; set; }
        /// <summary>
        /// ±ΔР - погрешность измерение усилия датчиком силы
        /// </summary>
        public double PasDevPpower { get; set; }
        /// <summary>
        /// ±Δξ - погрешность определения угла наклона 
        /// </summary>
        public double PasDevEpsilon { get; set; }
        /// <summary>
        /// ±Δφ - Неисключенная систематическая погрешность (НСП) углов поворота платформы
        /// </summary>
        public double PasDevFi { get; set; }
        /// <summary>
        /// Горизонтальное расстояние между осью наклона стенда и осью подвеса грузов противовеса
        /// </summary>
        public double PasD { get; set; }
        /// <summary>
        /// (±Δ)D 
        /// </summary>
        public double PasDevD { get; set; }
        /// <summary>
        /// Вертикальное расстояние между осью наклона стенда и осью подвеса грузов противовеса
        /// </summary>
        public double PasE { get; set; }
        /// <summary>
        /// (±Δ)E
        /// </summary>
        public double PasDevE { get; set; }
        /// <summary>
        /// Координаты переходника по оси Х
        /// </summary>
        public double PerX { get; set; } //PerX
        /// <summary>
        /// (±Δ)PerХ - допустимое отклонение переходника в системе координат переходника
        /// </summary>
        public double PerDevX { get; set; } //PerDevX
        /// <summary>
        /// Координаты переходника по оси Y
        /// </summary>
        public double PerY { get; set; } //PerY
        /// <summary>
        /// (±Δ)PerY - допустимое отклонение переходника в системе координат переходника 
        /// </summary>
        public double PerDevY { get; set; } //PerDevY
        /// <summary>
        /// Координаты переходника по оси Z
        /// </summary>
        public double PerZ { get; set; } //PerZ
        /// <summary>
        /// (±Δ)PerZ - допустимое отклонение переходника в системе координат переходника
        /// </summary>
        public double PerDevZ { get; set; } //PerDevX
        /// <summary>
        /// Масса переходника
        /// </summary>
        public double PerMas { get; set; } //PerMas
        /// <summary>
        /// (±Δ)PerMas - допустимое отклонение массы переходника 
        /// </summary>
        public double PerDevMas { get; set; } //PerDevMas
        /// <summary>
        /// Высота переходника 
        /// </summary>
        public double PerH { get; set; } //PerH
        /// <summary>
        /// (±Δ)PerH - допустимое отклонение длины переходника 
        /// </summary>
        public double PerDevH { get; set; } //PerDevH
        /// <summary>
        /// Координаты КП по Х
        /// </summary>
        public double KpX { get; set; } //KpX
        /// <summary>
        /// (±Δ)KpX
        /// </summary>
        public double KpDevX { get; set; } //KpDevX
        /// <summary>
        /// Координаты КП по Y
        /// </summary>
        public double KpY { get; set; } //KpY
        /// <summary>
        /// (±Δ)KpY
        /// </summary>
        public double KpDevY { get; set; } //KpDevY
        /// <summary>
        /// Координаты КП по Z
        /// </summary>
        public double KpZ { get; set; } //KpZ
        /// <summary>
        /// (±Δ)KpZ
        /// </summary>
        public double KpDevZ { get; set; } //KpDevZ
        /// <summary>
        /// Масса КП
        /// </summary>
        public double KpMas { get; set; } //KpMas
        /// <summary>
        /// (±Δ)KpMas
        /// </summary>
        public double KpDevMas { get; set; } //KpDevMas
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
        /// <summary>
        /// Угол поворота платформы
        /// </summary>
        public double Fi { get; set; }
        /// <summary>
        /// Δ - участвует в формуле для поправки углов (стд отклонение углов)
        /// </summary
        public double Dev { get; set; }
        
        /// <summary>
        /// Груз разгрузки
        /// </summary>
        public bool Cargo { get; set; }
        public bool KP { get; set; }

        /// <summary>
        /// Подвижный груз
        /// </summary>
        public double MassPG { get; set; }
        /// <summary>
        /// Отклонения подвижного груза
        /// </summary>
        public double DevMassPG { get; set; }
        /// <summary>
        /// Создание структуры данных для расчёта
        /// </summary>
        /// <returns></returns>
        public GravityCalc.PassportData SetDataForCalculate()
        {
            PassportData data = new();
            
            data.DefaultInit();
            data.PasMm = this.PasMm;
            data.PasDevMm = this.PasDevMm;
            data.PasMa = this.PasMa;
            data.PasDevMa = this.PasDevMa;
            data.PasK = this.PasK;
            data.PasS = this.PasS;
            data.PasDevS = this.PasDevS;
            data.PasH = this.PasH;
            data.PasDevH = this.PasDevH;
            data.PasL = this.PasL;
            data.PasDevL = this.PasDevL;
            data.PasQ = this.PasQ;
            data.PasDevQ = this.PasDevQ;
            data.PasDevPdisbal = this.PasDevPdisbal;
            data.PasDevPpower = this.PasDevPpower;
            data.PasDevEpsilon = this.PasDevEpsilon;
            data.PasDevFi = this.PasDevFi;
            data.PasD = this.PasD;
            data.PasDevD = this.PasDevD;
            data.PasE = this.PasE;
            data.PasDevE = this.PasDevE;
            data.PerX = this.PerX;
            data.PerDevX = this.PerDevX;
            data.PerY = this.PerY;
            data.PerDevY = this.PerDevY;
            data.PerZ = this.PerZ;
            data.PerDevZ = this.PerDevZ;
            data.PerMas = this.PerMas;
            data.PerDevMas = this.PerDevMas;
            data.PerH = this.PerH;
            data.PerDevH = this.PerDevH;
            data.KpX = this.KpX;
            data.KpDevX = this.KpDevX;
            data.KpY = this.KpY;
            data.KpDevY = this.KpDevY;
            data.KpZ = this.KpZ;
            data.KpDevZ = this.KpDevZ;
            data.KpDevMas = this.KpDevMas;
            
            data.Fi = this.Fi;
            data.Dev = this.Dev;
        
            data.Cargo = this.Cargo;
            data.KP = this.KP;
            data.PasMassPG = this.MassPG;
            data.PasDevMassPG = this.DevMassPG;

            return data;
        } 
    }
}
