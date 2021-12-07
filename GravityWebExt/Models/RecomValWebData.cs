using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GravityWebExt.Models
{
    /// <summary>
    /// Параметры - копия данных структуры RecomValData (GravityCalc)
    /// </summary>
    public class RecomValWebData
    {
        public int Id { get; set; }
        //___________________________________________________ Исходные данные
        /// <summary>
        /// Номинальное значение изделия по координате Х
        /// </summary>
        public double ProdX { get; set; }
        /// <summary>
        /// Номинальное отклонение изделия по координате Х
        /// </summary>
        public double ProdDevX { get; set; }
        /// <summary>
        /// Номинальное значение изделия по координате Y
        /// </summary>
        public double ProdY { get; set; }
        /// <summary>
        /// Номинальное отклонение изделия по координате Y
        /// </summary>
        public double ProdDevY { get; set; }
        /// <summary>
        /// Номинальное значение изделия по координате Z
        /// </summary>
        public double ProdZ { get; set; }
        /// <summary>
        /// Номинальное отклонение изделия по координате Z
        /// </summary>
        public double ProdDevZ { get; set; }
        /// <summary>
        /// Номинальная масса изделия
        /// </summary>
        public double ProdMas { get; set; }
        /// <summary>
        /// Номинальное отклонение массы изделия 
        /// </summary>
        public double ProdDevMas { get; set; }

        //___________________________________________________ Данные для расчета рекомендуемых значений
        public int EpsilonMa { get; set; }
        public int EpsilonMm { get; set; }
        public double ArrMasMa1 { get; set; }
        public double ArrMasMa2 { get; set; }
        public double ArrMasMa3 { get; set; }
        public double ArrMasMa4 { get; set; }
        public double ArrMasMa5 { get; set; }
        public double ArrMasMa6 { get; set; }       

        public double ArrMasMm1 { get; set; }
        public double ArrMasMm2 { get; set; }
        public double ArrMasMm3 { get; set; }
        public double ArrMasMm4 { get; set; }
        public double ArrMasMm5 { get; set; }
        public double ArrMasMm6 { get; set; }


        //___________________________________________________ Рекомендуемые значения 
        public double Ma { get; set; }
        public double Mm { get; set; }
        public double AngleKcm { get; set; }
        public double AngleMas { get; set; }
        public double AngleNotMas { get; set; }

        public GravityCalc.RecomValData SetDataForCalculate()
        {
            GravityCalc.RecomValData data = new();
            data.DefaultInit();

            data.ProdX = this.ProdX;
            data.ProdDevX = this.ProdDevX;
            data.ProdY = this.ProdY;
            data.ProdDevY = this.ProdDevY;
            data.ProdZ = this.ProdZ;
            data.ProdDevZ = this.ProdDevZ;
            data.ProdMas = this.ProdMas;
            data.ProdDevMas = this.ProdDevMas;

            data.EpsilonMa = this.EpsilonMa;
            data.EpsilonMm = this.EpsilonMm;
            data.ArrMasMa = new double[] { this.ArrMasMa6, this.ArrMasMa1, this.ArrMasMa2, this.ArrMasMa3, this.ArrMasMa4, this.ArrMasMa5 };           
            data.ArrMasMm = new double[] { this.ArrMasMm6, this.ArrMasMm1, this.ArrMasMm2, this.ArrMasMm3, this.ArrMasMm4, this.ArrMasMm5 };
            
            return data;
        }
    }
}
