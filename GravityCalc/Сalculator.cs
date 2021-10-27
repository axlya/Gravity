using System;
using System.Collections.Generic;
using System.Linq;

namespace GravityCalc
{
    public class Сalculator
    {
        const double m600 = 537.76;
        const double m6000 = 5385.1;

        public List<double> BeginBalanceAngleArr0 { get; set; }
        //public List<double> BeginBalanceAngleArr0_2 { get; set; }
        public List<double> BeginBalanceAngleArr90 { get; set; }
        public List<double> BeginBalanceAngleArr180 { get; set; }
        //public List<double> BeginBalanceAngleArr180_2 { get; set; }
        public List<double> BeginBalanceAngleArr270 { get; set; }

        public List<double> MiddleBalanceAngleArr0 { get; set; }
        //public List<double> MiddleBalanceAngleArr0_2 { get; set; }
        public List<double> MiddleBalanceAngleArr90 { get; set; }
        public List<double> MiddleBalanceAngleArr180 { get; set; }
        //public List<double> MiddleBalanceAngleArr180_2 { get; set; }
        public List<double> MiddleBalanceAngleArr270 { get; set; }

        public List<double> BeginUnbalanceSensorArr0 { get; set; }
        //public List<double> BeginUnbalanceSensorArr0_2 { get; set; }
        public List<double> BeginUnbalanceSensorArr90 { get; set; }
        public List<double> BeginUnbalanceSensorArr180 { get; set; }
        //public List<double> BeginUnbalanceSensorArr180_2 { get; set; }
        public List<double> BeginUnbalanceSensorArr270 { get; set; }

        public List<double> MiddleUnbalanceSensorArr0 { get; set; }
        //public List<double> MiddleUnbalanceSensorArr0_2 { get; set; }
        public List<double> MiddleUnbalanceSensorArr90 { get; set; }
        public List<double> MiddleUnbalanceSensorArr180 { get; set; }
        //public List<double> MiddleUnbalanceSensorArr180_2 { get; set; }
        public List<double> MiddleUnbalanceSensorArr270 { get; set; }

        public List<double> Knom0 { get; set; }

        public List<double> Kaver0 { get; set; }

        public List<double> Pnom0 { get; set; }

        public List<double> Paver0 { get; set; }
        public List<double> Knom180 { get; set; }

        public List<double> Kaver180 { get; set; }

        public List<double> Pnom180 { get; set; }

        public List<double> Paver180 { get; set; }
        //===============================================================
        //===============================================================
        //===============================================================
        private ReceivedData _rd;
        public CalculatedData calcData;
        public Сalculator(ReceivedData receivedData)
        {
            _rd = receivedData;

            BeginBalanceAngleArr0 = new();
            //BeginBalanceAngleArr0_2 = new();
            BeginBalanceAngleArr90 = new();
            BeginBalanceAngleArr180 = new();
            //BeginBalanceAngleArr180_2 = new();
            BeginBalanceAngleArr270 = new();

            MiddleBalanceAngleArr0 = new();
            //MiddleBalanceAngleArr0_2 = new();
            MiddleBalanceAngleArr90 = new();
            MiddleBalanceAngleArr180 = new();
            //MiddleBalanceAngleArr180_2 = new();
            MiddleBalanceAngleArr270 = new();

            BeginUnbalanceSensorArr0 = new();
            //BeginUnbalanceSensorArr0_2 = new();
            BeginUnbalanceSensorArr90 = new();
            BeginUnbalanceSensorArr180 = new();
            //BeginUnbalanceSensorArr180_2 = new();
            BeginUnbalanceSensorArr270 = new();

            MiddleUnbalanceSensorArr0 = new();
            //MiddleUnbalanceSensorArr0_2 = new();
            MiddleUnbalanceSensorArr90 = new();
            MiddleUnbalanceSensorArr180 = new();
            //MiddleUnbalanceSensorArr180_2 = new();
            MiddleUnbalanceSensorArr270 = new();

            Knom0 = new();
            Kaver0 = new();
            Pnom0 = new();
            Paver0 = new();

            Knom180 = new();
            Kaver180 = new();
            Pnom180 = new();
            Paver180 = new();
        }


        // SumValue 
        /// <summary>
        /// Для расчета рекомендуемых значений
        /// MΣ = Mи + Mпер
        /// </summary>
        private double Sum_m { get; set; } = Defines.UNDEF_DBL_VALUE;
        /// <summary>
        /// Для расчета рекомендуемых значений
        /// XΣ = [MперXпер + Mи(Xи+Hпер)]/MΣ
        /// </summary>
        private double SumX { get; set; } = Defines.UNDEF_DBL_VALUE;
        /// <summary>
        /// Для расчета рекомендуемых значений
        /// YΣ = (MперYпер + MиYи)/MΣ
        /// </summary>
        private double SumY { get; set; } = Defines.UNDEF_DBL_VALUE;
        /// <summary>
        /// Для расчета рекомендуемых значений
        /// ZΣ = (MперZпер + MиZи)/MΣ
        /// </summary>
        private double SumZ { get; set; } = Defines.UNDEF_DBL_VALUE;
                       
        /// <summary>
        /// mΣ, xΣ, yΣ, zΣ рассчет суммарных значений 
        /// </summary>
        public void SumValue()
        {
           
            
            Sum_m = _rd.PassportData.PerMas + _rd.RecomValData.ProdMas; 

            SumX = (_rd.PassportData.PerMas * _rd.PassportData.PerX + _rd.RecomValData.ProdMas * (_rd.RecomValData.ProdX + _rd.PassportData.PerH)) / Sum_m; 
            if (double.IsNaN(SumX) | double.IsInfinity(SumX))
            {
                // писать в лог - деление на 0
                return;
            }
            SumY = (_rd.PassportData.PerMas * _rd.PassportData.PerY + _rd.RecomValData.ProdX * _rd.RecomValData.ProdY) / Sum_m;
            if (double.IsNaN(SumY) | double.IsInfinity(SumY))
            {
                // писать в лог - деление на 0
                return;
            }
            SumZ = (_rd.PassportData.PerMas * _rd.PassportData.PerZ + _rd.RecomValData.ProdX * _rd.RecomValData.ProdZ) / Sum_m;
            if (double.IsNaN(SumZ) | double.IsInfinity(SumZ))
            {
                // писать в лог - деление на 0
                return;
            }
        }

        //AngleNotMas
        private double val_ang_ma = Defines.UNDEF_DBL_VALUE; // - переменная для расчета (угол наклона без противовеса)
        private double ctg_not_ma = Defines.UNDEF_DBL_VALUE; // - переменная для расчета (угол наклона без противовеса)
        /// <summary>
        /// Расчет угла наклона стенда без использования корректирующего противовеса
        /// </summary>
        public void AngleNot()
        {
            val_ang_ma = (_rd.PassportData.PasS + SumY + SumZ) / (_rd.PassportData.PasH + SumX); // - сумма углаВ
            if (double.IsNaN(val_ang_ma) | double.IsInfinity(val_ang_ma))
            {
                // писать в лог - деление на 0
                return;
            }

            ctg_not_ma = Math.Atan(val_ang_ma); // - ctg наклона

           _rd.RecomValData.AngleNotMas = (ctg_not_ma * 180) / Math.PI;
        }

        //Расчет для выбора корректирующего груза для кцм
        /// <summary>
        ///  Массив из эталонных значений массы корректирующего груза дял кцм ( Мm -> mi )
        /// </summary>
        private double[] _mi_mm = new double[6];
        // - tg((ξ*Pi)/180) ______________________________________
        private double angel_mm_rad = Defines.UNDEF_DBL_VALUE; // - переменная для расчета
        private double tg_mm = Defines.UNDEF_DBL_VALUE; // - переменная для расчета
        //_____________________________________________________
        private double min_mm { get; set; } = Defines.UNDEF_DBL_VALUE; // - миниимальное значение
        private double _mm { get; set; } = Defines.UNDEF_DBL_VALUE; // - Ссылочная переменная
        /// <summary>
        /// Полный расчет для корректирующего груза - Мm, для нахождения КЦМ
        /// </summary>
        public void Computation_mm()
        {
            // Заносим значения эталоного массива корректирущего груза в расчетный массив ArrRef_mm = new double[6] {0, 270, 540, 810, 1080, 1350};
            _mi_mm = new double[6];
            for (int i = 0; i < _rd.RecomValData.ArrMasMm.Count(); i++)
            {
                _mi_mm[i] = _rd.RecomValData.ArrMasMm[i];
            }

            // Считаем угол
            // Epsilon_mm = 16 - угол ξ (Диапозон 0 - 20 градусов) - нужно сделать условие! Рекомедуемый угол - 16±4⁰
            angel_mm_rad = (_rd.RecomValData.EpsilonMm * Math.PI) / 180;
            if (double.IsNaN(angel_mm_rad) | double.IsInfinity(angel_mm_rad))
            {
                // писать в лог - деление на 0
                return;
            }
            tg_mm = Math.Tan(angel_mm_rad);

            _mm = Sum_m * (_rd.PassportData.PasS + SumY + SumZ - (_rd.PassportData.PasH + SumX) * tg_mm) / (_rd.PassportData.PasD + _rd.PassportData.PasE * tg_mm);
            if (double.IsNaN(_mm) | double.IsInfinity(_mm))
            {
                // писать в лог - деление на 0
                return;
            }

            for (int i = 0; i < _mi_mm.Length; i++) // - вычетание _ma из массива _mi_mm
            {
                _mi_mm[i] -= _mm;
                _mi_mm[i] = Math.Abs(_mi_mm[i]);
            }
            min_mm = _mi_mm.Min();
            double[] Choose_arr_mm = new double[6]; // - выбор массива ma
            for (int i = 0; i < 6; i++)
                if (_mi_mm[i] == min_mm)
                {

                    Choose_arr_mm[i] = _rd.RecomValData.ArrMasMm[i];
                }
                else
                {
                    Choose_arr_mm[i] = 0;
                }

            if (_rd.PassportData.PasMm != 0)
            {
                _rd.RecomValData.Mm = _rd.PassportData.PasMm;
            }
            else if (_rd.RecomValData.AngleNotMas < 20)
            {
                _rd.RecomValData.Mm = 0;
            }
            else
            {
                if (_rd.RecomValData.ProdMas == 0 || _rd.RecomValData.ProdMas <= 1160)
                {
                    _rd.RecomValData.Mm = 0;
                }
                if (_rd.RecomValData.ProdMas > 1160 && _rd.RecomValData.ProdMas <= 2190)
                {
                    _rd.RecomValData.Mm = 270;
                }
                if (_rd.RecomValData.ProdMas > 2190 && _rd.RecomValData.ProdMas <= 3250)
                {
                    _rd.RecomValData.Mm = 540;
                }
                if (_rd.RecomValData.ProdMas > 3250 && _rd.RecomValData.ProdMas <= 4320)
                {
                    _rd.RecomValData.Mm = 810;
                }
                if (_rd.RecomValData.ProdMas > 4320 && _rd.RecomValData.ProdMas <= 5380)
                {
                    _rd.RecomValData.Mm = 1080;
                }
                if (_rd.RecomValData.ProdMas > 5380 && _rd.RecomValData.ProdMas <= 6450)
                {
                    _rd.RecomValData.Mm = 1350;
                }
                if (_rd.RecomValData.ProdMas > 6450)
                {
                    Console.WriteLine("Перевес!");
                }                
                Console.WriteLine("Mm= {0}", Choose_arr_mm.Sum());
            }
        }

        //Подходящий ∠ равновесия при нахождение КЦМ AngleKcm
        private double val_ref_ang_mm = Defines.UNDEF_DBL_VALUE; // - переменная для расчета
        private double ctg_ref_mm = Defines.UNDEF_DBL_VALUE; // - переменная для расчета
        /// <summary>
        /// Эталонный угол равновесия с использованием корректирущего груза для нахождения КЦМ
        /// </summary>
        public void CalcRefAngle_mm()
        {
            // Проверка
            val_ref_ang_mm = (Sum_m * (_rd.PassportData.PasS + SumY + SumZ) - _rd.RecomValData.Mm * _rd.PassportData.PasD) / (_rd.RecomValData.Mm + _rd.PassportData.PasE + Sum_m * (_rd.PassportData.PasH + SumX));
            if (double.IsNaN(val_ref_ang_mm) | double.IsInfinity(val_ref_ang_mm))
            {
                // писать в лог - деление на 0
                return;
            }

            ctg_ref_mm = Math.Atan(val_ref_ang_mm);
            _rd.RecomValData.AngleKcm = (ctg_ref_mm * 180) / Math.PI; // - эталонный угол равновесия 
            if (double.IsNaN(_rd.RecomValData.AngleKcm) | double.IsInfinity(_rd.RecomValData.AngleKcm))
            {
                // писать в лог - деление на 0
                return;
            }
            // Проверка
            if ((_rd.RecomValData.AngleKcm - 20) > 0)
            {
                Console.WriteLine("Внимание! Необходима коррекция наклона!");
            }
            else
            {
                Console.WriteLine("Коррекция наклона не требуется.");
            }
        }

        ////Расчет для выбора корректирующего груза для M
        /// <summary>
        ///  Массив из эталонных значений массы корректирующего груза для М ( Мэ -> mi )
        ///  </summary>
        private double[] _mi_ma = new double[6];
        // - ctg((ξ*Pi)/180)______________________________________
        private double angel_ma_rad = Defines.UNDEF_DBL_VALUE; // - переменная для расчета
        private double tg_ma = Defines.UNDEF_DBL_VALUE; // - переменная для расчета
        //_______________________________________________________
        private double min_ma { get; set; } = Defines.UNDEF_DBL_VALUE; // - миниимальное значение
        public double _ma { get; set; } = Defines.UNDEF_DBL_VALUE; // - Ссылочная переменная принимающая значение
        /// <summary>
        ///  Полный расчет для корректирующего груза - Мэ, для нахождения М
        /// </summary>
        public void Computation_ma()
        {
            // Заносим значения эталоного массива груза-разгрузки
            _mi_ma = new double[6];
            for (int i = 0; i < _rd.RecomValData.ArrMasMa.Count(); i++)
            {
                _mi_ma[i] = _rd.RecomValData.ArrMasMa[i];
            }

            // Считаем угол
            // Epsilon_ma = 6 - угол ξ (Диапозон 0 - 20 градусов) - нужно сделать условие! Рекомедуемый угол - 6±4⁰
            angel_ma_rad = (_rd.RecomValData.EpsilonMa * Math.PI) / 180;
            if (double.IsNaN(angel_ma_rad) | double.IsInfinity(angel_ma_rad))
            {
                // писать в лог - деление на 0
                return;
            }
            tg_ma = Math.Tan(angel_ma_rad);

            _ma = Sum_m * (_rd.PassportData.PasS + SumY + SumZ - (_rd.PassportData.PasH + SumX) * tg_ma) / (_rd.PassportData.PasD + _rd.PassportData.PasE * tg_ma);
            if (double.IsNaN(_ma) | double.IsInfinity(_ma))
            {
                // писать в лог - деление на 0
                return;
            }

            for (int i = 0; i < _mi_ma.Length; i++) // - вычетание _ma из массива _mi_ma
            {
                _mi_ma[i] -= _ma;
                _mi_ma[i] = Math.Abs(_mi_ma[i]);
            }
            min_ma = _mi_ma.Min();
            double[] Choose_arr_ma = new double[6];
            for (int i = 0; i < 6; i++)
                if (_mi_ma[i] == min_ma)
                {

                    Choose_arr_ma[i] = _rd.RecomValData.ArrMasMa[i];
                }
                else
                {
                    Choose_arr_ma[i] = 0;
                }

            if (_rd.PassportData.PasMa != 0)
            {
                _rd.RecomValData.Ma = _rd.PassportData.PasMa;
            }
            else
            {
                if (_rd.RecomValData.ProdMas == 0 || _rd.RecomValData.ProdMas <= 1160)
                {
                    _rd.RecomValData.Ma = 0;
                }
                if (_rd.RecomValData.ProdMas > 1160 && _rd.RecomValData.ProdMas <= 2190)
                {
                    _rd.RecomValData.Ma = 270;
                }
                if (_rd.RecomValData.ProdMas > 2190 && _rd.RecomValData.ProdMas <= 3250)
                {
                    _rd.RecomValData.Ma = 540;
                }
                if (_rd.RecomValData.ProdMas > 3250 && _rd.RecomValData.ProdMas <= 4320)
                {
                    _rd.RecomValData.Ma = 810;
                }
                if (_rd.RecomValData.ProdMas > 4320 && _rd.RecomValData.ProdMas <= 5380)
                {
                    _rd.RecomValData.Ma = 1080;
                }
                if (_rd.RecomValData.ProdMas > 5380 && _rd.RecomValData.ProdMas <= 6450)
                {
                    _rd.RecomValData.Ma = 1350;
                }
                if (_rd.RecomValData.ProdMas > 6450)
                {
                    Console.WriteLine("Перевес!");
                }
                Console.WriteLine("Ma= {0}", Choose_arr_ma.Sum());
            }
        }

        //Подходящий ∠ равновесия при нахождение M AngleMas
        private double val_ref_ang_ma = Defines.UNDEF_DBL_VALUE; // - переменная для расчета
        private double ctg_ref_ma = Defines.UNDEF_DBL_VALUE; // - переменная для расчета
        /// <summary>
        /// Эталонный угол равновесия с использованием корректирущего груза для нахождения М
        /// </summary>
        public void CalcRefAngle_ma() 
        {
            // Проверка
            try
            {
                val_ref_ang_ma = (Sum_m * (_rd.PassportData.PasS + SumY + SumZ) - _rd.RecomValData.Ma * _rd.PassportData.PasD) / (_rd.RecomValData.Ma + _rd.PassportData.PasE + Sum_m * (_rd.PassportData.PasH + SumX));
                if (double.IsNaN(val_ref_ang_ma) | double.IsInfinity(val_ref_ang_ma))
                {
                    // писать в лог - деление на 0
                    return;
                }
                ctg_ref_ma = Math.Atan(val_ref_ang_ma);
                _rd.RecomValData.AngleMas = (ctg_ref_ma * 180) / Math.PI; // - эталонный угол равновесия 
                if (double.IsNaN(_rd.RecomValData.AngleMas) | double.IsInfinity(val_ref_ang_ma))
                {
                    // писать в лог - деление на 0
                    return;
                }
            }
            catch (Exception)
            {
                _rd.RecomValData.AngleMas = _rd.RecomValData.AngleNotMas;
            }

            // Проверка
            if ((_rd.RecomValData.AngleMas - _rd.RecomValData.AngleKcm) >= 0)
            {
                Console.WriteLine("Необходимо выбрать другую массу корректирующего груза");
            }
            else if (_rd.RecomValData.AngleMas < 1)
            {
                Console.WriteLine("УГОЛ НАКЛОНА МЕНЬШЕ ДОПУСТИМОГО!");
            }
            else
            {
                Console.WriteLine("Угол наклона в пределах допустимого");
            }
        }

        //ProductAngle
        public double[] balanceAngel { get; set; } // средние значения угла равновесия после 10 измерений
        /// <summary>
        ///  Получение и расчет углов 
        /// </summary>
        public void ProductAngle(List<double> BeginBalanceAngleArr, List<double> MiddleBalanceAngleArr, List<double> BeginUnbalanceSensorArr, List<double> MiddleUnbalanceSensorArr)
        {
            calcData.Amendment = _rd.PassportData.Dev * (_rd.RecomValData.ProdMas - m600) / (m6000 - m600); // - Расчет поправки
            for (int i = 0; i < BeginBalanceAngleArr.Count(); i++) // - ТАРИРОВКА УГЛА
            {
                BeginBalanceAngleArr[i] += calcData.Amendment;
                BeginBalanceAngleArr[i] = Math.Abs(BeginBalanceAngleArr[i]);
            }
            //_______________________________________________________________________________________________
            for (int i = 0; i < MiddleBalanceAngleArr.Count(); i++)
            {
                MiddleBalanceAngleArr[i] += calcData.Amendment;
                MiddleBalanceAngleArr[i] = Math.Abs(MiddleBalanceAngleArr[i]);
            }
            //________________________________________________________________________________________________
            balanceAngel = new double[10]; // - получившийся в итоге угол равновесия, стенд показывает все случаи измерений (10 замеров) 
            for (int i = 0; i < balanceAngel.Length; i++)
            {
                balanceAngel[i] = (BeginBalanceAngleArr[i] * MiddleUnbalanceSensorArr[i] - MiddleBalanceAngleArr[i] * BeginUnbalanceSensorArr[i]) / (MiddleUnbalanceSensorArr[i] - BeginUnbalanceSensorArr[i]);
                if (double.IsNaN(balanceAngel[i]) | double.IsInfinity(balanceAngel[i]))
                {
                    // писать в лог - деление на 0  
                    return;
                }
            }
            balanceAngel.Average();
            calcData.AverageValue = balanceAngel.Average(); // - Среднее значение угла равновесия получившегося в итоге!
            Console.WriteLine("Среднее значение угла равновесия {0} для угла {1}", calcData.AverageValue, _rd.PassportData.Fi);
        }
        public double[] kcmSum_m; // - МАССА ДЕТАЛИ!!! ( с переходником )
        public void Massa()
        {
            kcmSum_m = new double[10];
            for( int i = 0; i< kcmSum_m.Count(); i++)
            {
                kcmSum_m[i] = (2 * _rd.RecomValData.Ma * _rd.PassportData.PasD + _rd.PassportData.PasMassPG * (2 * _rd.PassportData.PasK + Kaver0[i] + Knom0[i] + Knom180[i] + Kaver180[i]) + _rd.PassportData.PasL * (Paver0[i] + Pnom0[i] + Pnom180[i] + Paver180[i])) / (2 * _rd.PassportData.PasS);
            }
        }
        


        private double[] BeginBal_gradArr0 { get; set; } // - переведенный угол в радианы
        //private double[] BeginBal_gradArr0_2 { get; set; } // - переведенный угол в радианы
        private double[] BeginBal_gradArr90 { get; set; } // - переведенный угол в радианы
        private double[] BeginBal_gradArr180 { get; set; } // - переведенный угол в радианы
        //private double[] BeginBal_gradArr180_2 { get; set; } // - переведенный угол в радианы
        private double[] BeginBal_gradArr270 { get; set; } // - переведенный угол в радианы
        private double[] MiddleBal_gradArr0 { get; set; } // - переведенный угол в радианы
        //private double[] MiddleBal_gradArr0_2 { get; set; } // - переведенный угол в радианы
        private double[] MiddleBal_gradArr90 { get; set; } // - переведенный угол в радианы
        private double[] MiddleBal_gradArr180 { get; set; } // - переведенный угол в радианы
        //private double[] MiddleBal_gradArr180_2 { get; set; } // - переведенный угол в радианы
        private double[] MiddleBal_gradArr270 { get; set; } // - переведенный угол в радианы
        
        public void TranslatVal()
        {
            //0_____________________________________________________________________________________
            BeginBal_gradArr0 = new double[10]; // - Угол равновесия переведенный в радианы
            for (int i = 0; i < _rd.BeginBalanceAngleArr0.Count(); i++)
            {
                BeginBal_gradArr0[i] = _rd.BeginBalanceAngleArr0[i];
            }
            for (int i = 0; i < BeginBal_gradArr0.Length; i++)
            {
                BeginBal_gradArr0[i] = (BeginBal_gradArr0[i] * Math.PI) / 180;
            }

            MiddleBal_gradArr0 = new double[10]; // - Угол равновесия переведенный в радианы
            for (int i = 0; i < _rd.MiddleBalanceAngleArr0.Count(); i++)
            {
                MiddleBal_gradArr0[i] = _rd.MiddleBalanceAngleArr0[i];
            }
            for (int i = 0; i < MiddleBal_gradArr0.Length; i++)
            {
                MiddleBal_gradArr0[i] = (MiddleBal_gradArr0[i] * Math.PI) / 180;
            }

            //90_____________________________________________________________________________________
            BeginBal_gradArr90 = new double[10]; // - Угол равновесия переведенный в радианы
            for (int i = 0; i < _rd.BeginBalanceAngleArr90.Count(); i++)
            {
                BeginBal_gradArr90[i] = _rd.BeginBalanceAngleArr90[i];
            }
            for (int i = 0; i < BeginBal_gradArr90.Length; i++)
            {
                BeginBal_gradArr90[i] = (BeginBal_gradArr90[i] * Math.PI) / 180;
            }

            MiddleBal_gradArr90 = new double[10]; // - Угол равновесия переведенный в радианы
            for (int i = 0; i < _rd.MiddleBalanceAngleArr90.Count(); i++)
            {
                MiddleBal_gradArr90[i] = _rd.MiddleBalanceAngleArr90[i];
            }
            for (int i = 0; i < MiddleBal_gradArr90.Length; i++)
            {
                MiddleBal_gradArr90[i] = (MiddleBal_gradArr90[i] * Math.PI) / 180;
            }

            //180_____________________________________________________________________________________
            BeginBal_gradArr180 = new double[10]; // - Угол равновесия переведенный в радианы
            for (int i = 0; i < _rd.BeginBalanceAngleArr180.Count(); i++)
            {
                BeginBal_gradArr180[i] = _rd.BeginBalanceAngleArr180[i];
            }
            for (int i = 0; i < BeginBal_gradArr180.Length; i++)
            {
                BeginBal_gradArr180[i] = (BeginBal_gradArr180[i] * Math.PI) / 180;
            }

            MiddleBal_gradArr180 = new double[10]; // - Угол равновесия переведенный в радианы
            for (int i = 0; i < _rd.MiddleBalanceAngleArr180.Count(); i++)
            {
                MiddleBal_gradArr180[i] = _rd.MiddleBalanceAngleArr180[i];
            }
            for (int i = 0; i < MiddleBal_gradArr180.Length; i++)
            {
                MiddleBal_gradArr180[i] = (MiddleBal_gradArr180[i] * Math.PI) / 180;
            }

            //270_____________________________________________________________________________________
            BeginBal_gradArr270 = new double[10]; // - Угол равновесия переведенный в радианы
            for (int i = 0; i < _rd.BeginBalanceAngleArr270.Count(); i++)
            {
                BeginBal_gradArr270[i] = _rd.BeginBalanceAngleArr270[i];
            }
            for (int i = 0; i < BeginBal_gradArr270.Length; i++)
            {
                BeginBal_gradArr270[i] = (BeginBal_gradArr270[i] * Math.PI) / 180;
            }

            MiddleBal_gradArr270 = new double[10]; // - Угол равновесия переведенный в радианы
            for (int i = 0; i < _rd.MiddleBalanceAngleArr270.Count(); i++)
            {
                MiddleBal_gradArr270[i] = _rd.MiddleBalanceAngleArr270[i];
            }
            for (int i = 0; i < MiddleBal_gradArr270.Length; i++)
            {
                MiddleBal_gradArr270[i] = (MiddleBal_gradArr270[i] * Math.PI) / 180;
            }

            ////0_2_____________________________________________________________________________________
            //BeginBal_gradArr0_2 = new double[10]; // - Угол равновесия переведенный в радианы
            //for (int i = 0; i < _rd.beginBalanceAngleArr0_2.Count(); i++)
            //{
            //    BeginBal_gradArr0_2[i] = _rd.beginBalanceAngleArr0_2[i];
            //}
            //for (int i = 0; i < BeginBal_gradArr0_2.Length; i++)
            //{
            //    BeginBal_gradArr0_2[i] = (BeginBal_gradArr0_2[i] * Math.PI) / 180;
            //}

            //MiddleBal_gradArr0_2 = new double[10]; // - Угол равновесия переведенный в радианы
            //for (int i = 0; i < _rd.MiddleBalanceAngleArr0_2.Count(); i++)
            //{
            //    MiddleBal_gradArr0_2[i] = _rd.MiddleBalanceAngleArr0_2[i];
            //}
            //for (int i = 0; i < MiddleBal_gradArr0_2.Length; i++)
            //{
            //    MiddleBal_gradArr0_2[i] = (MiddleBal_gradArr0_2[i] * Math.PI) / 180;
            //}

            ////180_2_____________________________________________________________________________________
            //BeginBal_gradArr180_2 = new double[10]; // - Угол равновесия переведенный в радианы
            //for (int i = 0; i < _rd.beginBalanceAngleArr180_2.Count(); i++)
            //{
            //    BeginBal_gradArr180_2[i] = _rd.beginBalanceAngleArr180_2[i];
            //}
            //for (int i = 0; i < BeginBal_gradArr180_2.Length; i++)
            //{
            //    BeginBal_gradArr180_2[i] = (BeginBal_gradArr180_2[i] * Math.PI) / 180;
            //}

            //MiddleBal_gradArr180_2 = new double[10]; // - Угол равновесия переведенный в радианы
            //for (int i = 0; i < _rd.MiddleBalanceAngleArr180_2.Count(); i++)
            //{
            //    MiddleBal_gradArr180_2[i] = _rd.MiddleBalanceAngleArr180_2[i];
            //}
            //for (int i = 0; i < MiddleBal_gradArr180_2.Length; i++)
            //{
            //    MiddleBal_gradArr180_2[i] = (MiddleBal_gradArr180_2[i] * Math.PI) / 180;
            //}
        }

        //Balance_tg
        /// <summary>
        /// угол между осью ОсYс стенда в горизонтальном положении и осью, проходящей через центр опорного ролика измерительной головкиперпендикулярно к оси наклона стенда
        /// </summary>
        public double Lamda { get; set; } = Defines.UNDEF_DBL_VALUE;
        
        // с использованием ma
        private double[] A0, A90, A180, A270; // - переменная для расчета
        private double[] B0, B90, B180, B270; // - переменная для расчета
        private double[] C0, C90, C180, C270; // - переменная для расчета
        private double[] D0, D90, D180, D270; // - переменная для расчета
        private double[] _tg0, _tg90, _tg180, _tg270; // - переменная для расчета
        private double[] tg0, tg90, tg180, tg270; // - переменная для расчета

        //// c использованием mm
        //private double[] A0_2, A180_2; // - переменная для расчета
        //private double[] B0_2, B180_2; // - переменная для расчета
        //private double[] C0_2, C180_2; // - переменная для расчета
        //private double[] D0_2, D180_2; // - переменная для расчета
        //private double[] tg0_2, tg180_2; // - переменная для расчета
        //private double[] Sum_tg_0_180_2; // - переменная для расчета
        /// <summary>
        /// Расчет углов для нахождения тангесов
        /// </summary>
        public void Balanse_tg()
        {
            Lamda = Math.Atan(_rd.PassportData.PasQ / _rd.PassportData.PasL);
            //0
            // α1±Δξ
            for (int i = 0; i < BeginBal_gradArr0.Length; i++)
            {
                BeginBal_gradArr0[i] = BeginBal_gradArr0[i] + _rd.PassportData.PasDevEpsilon;
            }

            for (int i = 0; i < MiddleBal_gradArr0.Length; i++)
            {
                MiddleBal_gradArr0[i] = MiddleBal_gradArr0[i] + _rd.PassportData.PasDevEpsilon;
            }

            // P1±ΔP
            for (int i = 0; i < BeginUnbalanceSensorArr0.Count; i++)
            {
                BeginUnbalanceSensorArr0[i] = BeginUnbalanceSensorArr0[i] + _rd.PassportData.PasDevPdisbal;
            }

            for (int i = 0; i < MiddleUnbalanceSensorArr0.Count; i++)
            {
                MiddleUnbalanceSensorArr0[i] = MiddleUnbalanceSensorArr0[i] + _rd.PassportData.PasDevPdisbal;
            }

            //A, B, C, D
            A0 = new double[BeginBal_gradArr0.Length];
            for (int i = 0; i < A0.Length; i++)
            {
                A0[i] = BeginUnbalanceSensorArr0[i] * Math.Cos(BeginBal_gradArr0[i] - Lamda) * Math.Sin(MiddleBal_gradArr0[i]);
            }

            B0 = new double[BeginBal_gradArr0.Length];
            for (int i = 0; i < A0.Length; i++)
            {
                B0[i] = MiddleUnbalanceSensorArr0[i] * Math.Cos(MiddleBal_gradArr0[i] - Lamda) * Math.Sin(BeginBal_gradArr0[i]);
            }

            C0 = new double[BeginBal_gradArr0.Length];
            for (int i = 0; i < A0.Length; i++)
            {
                C0[i] = BeginUnbalanceSensorArr0[i] * Math.Cos(BeginBal_gradArr0[i] - Lamda) * Math.Cos(MiddleBal_gradArr0[i]);
            }

            D0 = new double[BeginBal_gradArr0.Length];
            for (int i = 0; i < A0.Length; i++)
            {
                D0[i] = MiddleUnbalanceSensorArr0[i] * Math.Cos(MiddleBal_gradArr0[i] - Lamda) * Math.Cos(BeginBal_gradArr0[i]);
            }

            //tg0
            _tg0 = new double[A0.Length];
            for (int i = 0; i < _tg0.Length; i++)
            {
                _tg0[i] = (A0[i] - B0[i]) / (C0[i] - D0[i]);
            }
            //_____________________________________________________________________

            //90
            // α1±Δξ
            for (int i = 0; i < BeginBal_gradArr90.Length; i++)
            {
                BeginBal_gradArr90[i] = BeginBal_gradArr90[i] + _rd.PassportData.PasDevEpsilon;
            }

            for (int i = 0; i < MiddleBal_gradArr90.Length; i++)
            {
                MiddleBal_gradArr90[i] = MiddleBal_gradArr90[i] + _rd.PassportData.PasDevEpsilon;
            }

            // P1±ΔP
            for (int i = 0; i < BeginUnbalanceSensorArr90.Count; i++)
            {
                BeginUnbalanceSensorArr90[i] = BeginUnbalanceSensorArr90[i] + _rd.PassportData.PasDevPdisbal;
            }

            for (int i = 0; i < MiddleUnbalanceSensorArr90.Count; i++)
            {
                MiddleUnbalanceSensorArr90[i] = MiddleUnbalanceSensorArr90[i] + _rd.PassportData.PasDevPdisbal;
            }

            //A, B, C, D
            A90 = new double[BeginBal_gradArr90.Length];
            for (int i = 0; i < A90.Length; i++)
            {
                A90[i] = BeginUnbalanceSensorArr90[i] * Math.Cos(BeginBal_gradArr90[i] - Lamda) * Math.Sin(MiddleBal_gradArr90[i]);
            }

            B90 = new double[BeginBal_gradArr90.Length];
            for (int i = 0; i < A90.Length; i++)
            {
                B90[i] = MiddleUnbalanceSensorArr90[i] * Math.Cos(MiddleBal_gradArr90[i] - Lamda) * Math.Sin(BeginBal_gradArr90[i]);
            }

            C90 = new double[BeginBal_gradArr90.Length];
            for (int i = 0; i < A90.Length; i++)
            {
                C90[i] = BeginUnbalanceSensorArr90[i] * Math.Cos(BeginBal_gradArr90[i] - Lamda) * Math.Cos(MiddleBal_gradArr90[i]);
            }

            D90 = new double[BeginBal_gradArr90.Length];
            for (int i = 0; i < A90.Length; i++)
            {
                D90[i] = MiddleUnbalanceSensorArr90[i] * Math.Cos(MiddleBal_gradArr90[i] - Lamda) * Math.Cos(BeginBal_gradArr90[i]);
            }

            //tg90
            _tg90 = new double[A90.Length];
            for (int i = 0; i < _tg90.Length; i++)
            {
                _tg90[i] = (A90[i] - B90[i]) / (C90[i] - D90[i]);
            }
            //_____________________________________________________________________

            //180
            // α1±Δξ
            for (int i = 0; i < BeginBal_gradArr180.Length; i++)
            {
                BeginBal_gradArr180[i] = BeginBal_gradArr180[i] + _rd.PassportData.PasDevEpsilon;
            }

            for (int i = 0; i < MiddleBal_gradArr180.Length; i++)
            {
                MiddleBal_gradArr180[i] = MiddleBal_gradArr180[i] + _rd.PassportData.PasDevEpsilon;
            }

            // P1±ΔP
            for (int i = 0; i < BeginUnbalanceSensorArr180.Count; i++)
            {
                BeginUnbalanceSensorArr180[i] = BeginUnbalanceSensorArr180[i] + _rd.PassportData.PasDevPdisbal;
            }

            for (int i = 0; i < MiddleUnbalanceSensorArr180.Count; i++)
            {
                MiddleUnbalanceSensorArr180[i] = MiddleUnbalanceSensorArr180[i] + _rd.PassportData.PasDevPdisbal;
            }

            //A, B, C, D
            A180 = new double[BeginBal_gradArr180.Length];
            for (int i = 0; i < A180.Length; i++)
            {
                A180[i] = BeginUnbalanceSensorArr180[i] * Math.Cos(BeginBal_gradArr180[i] - Lamda) * Math.Sin(MiddleBal_gradArr180[i]);
            }

            B180 = new double[BeginBal_gradArr180.Length];
            for (int i = 0; i < A180.Length; i++)
            {
                B180[i] = MiddleUnbalanceSensorArr180[i] * Math.Cos(MiddleBal_gradArr180[i] - Lamda) * Math.Sin(BeginBal_gradArr180[i]);
            }

            C180 = new double[BeginBal_gradArr180.Length];
            for (int i = 0; i < A180.Length; i++)
            {
                C180[i] = BeginUnbalanceSensorArr180[i] * Math.Cos(BeginBal_gradArr180[i] - Lamda) * Math.Cos(MiddleBal_gradArr180[i]);
            }

            D180 = new double[BeginBal_gradArr180.Length];
            for (int i = 0; i < A180.Length; i++)
            {
                D180[i] = MiddleUnbalanceSensorArr180[i] * Math.Cos(MiddleBal_gradArr180[i] - Lamda) * Math.Cos(BeginBal_gradArr180[i]);
            }

            //tg180
            _tg180 = new double[A180.Length];
            for (int i = 0; i < _tg180.Length; i++)
            {
                _tg180[i] = (A180[i] - B180[i]) / (C180[i] - D180[i]);
            }
            //_____________________________________________________________________

            //270
            // α1±Δξ
            for (int i = 0; i < BeginBal_gradArr270.Length; i++)
            {
                BeginBal_gradArr270[i] = BeginBal_gradArr270[i] + _rd.PassportData.PasDevEpsilon;
            }

            for (int i = 0; i < MiddleBal_gradArr270.Length; i++)
            {
                MiddleBal_gradArr270[i] = MiddleBal_gradArr270[i] + _rd.PassportData.PasDevEpsilon;
            }

            // P1±ΔP
            for (int i = 0; i < BeginUnbalanceSensorArr270.Count; i++)
            {
                BeginUnbalanceSensorArr270[i] = BeginUnbalanceSensorArr270[i] + _rd.PassportData.PasDevPdisbal;
            }

            for (int i = 0; i < MiddleUnbalanceSensorArr270.Count; i++)
            {
                MiddleUnbalanceSensorArr270[i] = MiddleUnbalanceSensorArr270[i] + _rd.PassportData.PasDevPdisbal;
            }

            //A, B, C, D
            A270 = new double[BeginBal_gradArr270.Length];
            for (int i = 0; i < A270.Length; i++)
            {
                A270[i] = BeginUnbalanceSensorArr270[i] * Math.Cos(BeginBal_gradArr270[i] - Lamda) * Math.Sin(MiddleBal_gradArr270[i]);
            }

            B270 = new double[BeginBal_gradArr270.Length];
            for (int i = 0; i < A270.Length; i++)
            {
                B270[i] = MiddleUnbalanceSensorArr270[i] * Math.Cos(MiddleBal_gradArr270[i] - Lamda) * Math.Sin(BeginBal_gradArr270[i]);
            }

            C270 = new double[BeginBal_gradArr270.Length];
            for (int i = 0; i < A270.Length; i++)
            {
                C270[i] = BeginUnbalanceSensorArr270[i] * Math.Cos(BeginBal_gradArr270[i] - Lamda) * Math.Cos(MiddleBal_gradArr270[i]);
            }

            D270 = new double[BeginBal_gradArr270.Length];
            for (int i = 0; i < A270.Length; i++)
            {
                D270[i] = MiddleUnbalanceSensorArr270[i] * Math.Cos(MiddleBal_gradArr270[i] - Lamda) * Math.Cos(BeginBal_gradArr270[i]);
            }

            //tg270
            _tg270 = new double[A270.Length];
            for (int i = 0; i < _tg270.Length; i++)
            {
                _tg270[i] = (A270[i] - B270[i]) / (C270[i] - D270[i]);
            }
            //______________________________________________________________________________________

            ////0__2
            //// α1±Δξ
            //for (int i = 0; i < BeginBal_gradArr0_2.Length; i++)
            //{
            //    BeginBal_gradArr0_2[i] = BeginBal_gradArr0_2[i] + _rd.PassportData.DevEpsilon;
            //}

            //for (int i = 0; i < MiddleBal_gradArr0_2.Length; i++)
            //{
            //    MiddleBal_gradArr0_2[i] = MiddleBal_gradArr0_2[i] + _rd.PassportData.DevEpsilon;
            //}

            //// P1±ΔP
            //for (int i = 0; i < BeginUnbalanceSensorArr0_2.Count; i++)
            //{
            //    BeginUnbalanceSensorArr0_2[i] = BeginUnbalanceSensorArr0_2[i] + _rd.PassportData.DevPp;
            //}

            //for (int i = 0; i < MiddleUnbalanceSensorArr0_2.Count; i++)
            //{
            //    MiddleUnbalanceSensorArr0_2[i] = MiddleUnbalanceSensorArr0_2[i] + _rd.PassportData.DevPp;
            //}

            ////A, B, C, D
            //A0_2 = new double[BeginBal_gradArr0_2.Length];
            //for (int i = 0; i < A0_2.Length; i++)
            //{
            //    A0_2[i] = BeginUnbalanceSensorArr0_2[i] * Math.Cos(BeginBal_gradArr0_2[i] - Lamda) * Math.Sin(MiddleBal_gradArr0_2[i]);
            //}

            //B0_2 = new double[BeginBal_gradArr0_2.Length];
            //for (int i = 0; i < A0_2.Length; i++)
            //{
            //    B0_2[i] = MiddleUnbalanceSensorArr0_2[i] * Math.Cos(MiddleBal_gradArr0_2[i] - Lamda) * Math.Sin(BeginBal_gradArr0_2[i]);
            //}

            //C0_2 = new double[BeginBal_gradArr0_2.Length];
            //for (int i = 0; i < A0_2.Length; i++)
            //{
            //    C0_2[i] = BeginUnbalanceSensorArr0_2[i] * Math.Cos(BeginBal_gradArr0_2[i] - Lamda) * Math.Cos(MiddleBal_gradArr0_2[i]);
            //}

            //D0_2 = new double[BeginBal_gradArr0_2.Length];
            //for (int i = 0; i < A0_2.Length; i++)
            //{
            //    D0_2[i] = MiddleUnbalanceSensorArr0_2[i] * Math.Cos(MiddleBal_gradArr0_2[i] - Lamda) * Math.Cos(BeginBal_gradArr0_2[i]);
            //}

            ////tg0
            //tg0_2 = new double[A0_2.Length];
            //for (int i = 0; i < tg0_2.Length; i++)
            //{
            //    tg0_2[i] = (A0_2[i] - B0_2[i]) / (C0_2[i] - D0_2[i]);
            //}
            //_____________________________________________________________________

            ////180_2
            //// α1±Δξ
            //for (int i = 0; i < BeginBal_gradArr180_2.Length; i++)
            //{
            //    BeginBal_gradArr180_2[i] = BeginBal_gradArr180_2[i] + _rd.PassportData.DevEpsilon;
            //}

            //for (int i = 0; i < MiddleBal_gradArr180_2.Length; i++)
            //{
            //    MiddleBal_gradArr180_2[i] = MiddleBal_gradArr180_2[i] + _rd.PassportData.DevEpsilon;
            //}

            //// P1±ΔP
            //for (int i = 0; i < BeginUnbalanceSensorArr180_2.Count; i++)
            //{
            //    BeginUnbalanceSensorArr180_2[i] = BeginUnbalanceSensorArr180_2[i] + _rd.PassportData.DevPp;
            //}

            //for (int i = 0; i < MiddleUnbalanceSensorArr180_2.Count; i++)
            //{
            //    MiddleUnbalanceSensorArr180_2[i] = MiddleUnbalanceSensorArr180_2[i] + _rd.PassportData.DevPp;
            //}

            ////A_2, B_2, C_2, D_2
            //A180_2 = new double[BeginBal_gradArr180_2.Length];
            //for (int i = 0; i < A0_2.Length; i++)
            //{
            //    A180_2[i] = BeginUnbalanceSensorArr180_2[i] * Math.Cos(BeginBal_gradArr180_2[i] - Lamda) * Math.Sin(MiddleBal_gradArr180_2[i]);
            //}

            //B180_2 = new double[BeginBal_gradArr180_2.Length];
            //for (int i = 0; i < A0_2.Length; i++)
            //{
            //    B180_2[i] = MiddleUnbalanceSensorArr180_2[i] * Math.Cos(MiddleBal_gradArr180_2[i] - Lamda) * Math.Sin(BeginBal_gradArr180_2[i]);
            //}

            //C180_2 = new double[BeginBal_gradArr180_2.Length];
            //for (int i = 0; i < A0_2.Length; i++)
            //{
            //    C180_2[i] = BeginUnbalanceSensorArr180_2[i] * Math.Cos(BeginBal_gradArr180_2[i] - Lamda) * Math.Cos(MiddleBal_gradArr180_2[i]);
            //}

            //D180_2 = new double[BeginBal_gradArr180_2.Length];
            //for (int i = 0; i < A0_2.Length; i++)
            //{
            //    D180_2[i] = MiddleUnbalanceSensorArr180_2[i] * Math.Cos(MiddleBal_gradArr180_2[i] - Lamda) * Math.Cos(BeginBal_gradArr180_2[i]);
            //}

            ////tg180_2
            //tg180_2 = new double[A0.Length];
            //for (int i = 0; i < tg180_2.Length; i++)
            //{
            //    tg180_2[i] = (A180_2[i] - B180_2[i]) / (C180_2[i] - D180_2[i]);
            //}
            //_____________________________________________________________________
            //_____________________________________________________________________
            //_____________________________________________________________________

            //tg0 
            tg0 = new double[A0.Length];
            for (int i = 0; i < tg0.Length; i++)
            {
                tg0[i] = _tg0[i] + _tg180[i];
            }

            //tg180
            tg180 = new double[A0.Length];
            for (int i = 0; i < tg180.Length; i++)
            {
                tg180[i] = _tg0[i] - _tg180[i];
            }

            //tg90
            tg90 = new double[A90.Length];
            for (int i = 0; i < tg90.Length; i++)
            {
                tg90[i] = _tg90[i] + _tg270[i];
            }

            //tg270
            tg270 = new double[A90.Length];
            for (int i = 0; i < tg270.Length; i++)
            {
                tg270[i] = _tg90[i] - _tg270[i];
            }

            //// tg0_2 - tg180_2
            //Sum_tg_0_180_2 = new double[A0_2.Length];
            //for (int i = 0; i < Sum_tg_0_180_2.Length; i++)
            //{
            //    Sum_tg_0_180_2[i] = tg0_2[i] + tg180_2[i];
            //}
        }
        
        //public double[] kcmSumX1; // - Для расчета локальные значения
        //public double[] kcmSumX2; // - Для расчета локальные значения
        private double[] kcmSumX; // - Для расчета локальные значения
        private double[] kcmSumY; // - Для расчета локальные значения
        private double[] kcmSumZ; // - Для расчета локальные значения

        private double[] kcmDev;

        private double[] kcmXprod; // - Для расчета локальные значения
        private double[] kcmYprod; // - Для расчета локальные значения
        private double[] kcmZprod; // - Для расчета локальные значения
        private double[] kcmMprod; // - МАССА ДЕТАЛИ ИСТИННАЯ ( 10 замеров )

        private double Sum__m, Sum__x, Sum__y, Sum__z, M, X, Y, Z, Mkp, Xkp, Ykp, Zkp; // - Локальные переменные для расчета
        

        /// <summary>
        /// Расчет КЦМ по формулам на стр Раб!
        /// </summary>
        public void WorkList1()
        {
            
            //kcmSumX1 = new double[A0.Length];
            //for (int i = 0; i < kcmSumX1.Length; i++)
            //{
            //    kcmSumX1[i] = (2 * _S * (calcData.Result_ma * (2 * _D + _E * Sum_tg_0_180[i]) - calcData.Result_mm * (2 * _D + _E * Sum_tg_0_180_2[i]))
            //    / (Sum_tg_0_180_2[i] * calcData.Result_ma * (2 * _D + _E * Sum_tg_0_180[i]) - Sum_tg_0_180[i] * calcData.Result_mm * (2 * _D + _E * Sum_tg_0_180_2[i]))) - _H;
            //}

            //kcmSumX2 = new double[A0.Length];
            //for (int i = 0; i < kcmSumX2.Length; i++)
            //{
            //    kcmSumX2[i] = (2 * _S * (calcData.Result_ma * (2 * _D + _E * Sum_tg_90_270[i]) - calcData.Result_mm * (2 * _D + _E * Sum_tg_0_180_2[i]))
            //    / (Sum_tg_0_180_2[i] * calcData.Result_ma * (2 * _D + _E * Sum_tg_90_270[i]) - Sum_tg_0_180[i] * calcData.Result_mm * (2 * _D + _E * Sum_tg_0_180_2[i]))) - _H;
            //}
            //Расчет суммарных
            kcmSumX = new double[A0.Length];
            for (int i = 0; i < kcmSumX.Length; i++)
            {
                kcmSumX[i] = _rd.PassportData.PasS * (1 / (tg0[i] + tg180[i]) + 1 / (tg90[i] + tg270[i])) - _rd.PassportData.PasH;
            }

            ////МАССА ИЗДЕЛИЯ И ПЕРЕХОДНИКА - СТАНКОПРЕСС!!!
            //kcmSum_m = new double[kcmSumX1.Length];
            //for (int i = 0; i < kcmSum_m.Length; i++)
            //{
            //    kcmSum_m[i] = calcData.Result_mm * ((2 * _D + _E * Sum_tg_0_180_2[i]) / (2 * _S - (_H + kcmSumX[i]) * Sum_tg_0_180_2[i]));
            //}

            kcmSumY = new double[kcmSumX.Length];
            for (int i = 0; i < kcmSumY.Length; i++)
            {
                kcmSumY[i] = _rd.PassportData.PasS * (tg0[i] - tg180[i]) / (tg0[i] + tg180[i]);
            }

            kcmSumZ = new double[kcmSumX.Length];
            for (int i = 0; i < kcmSumZ.Length; i++)
            {
                kcmSumZ[i] = _rd.PassportData.PasS * (tg90[i] - tg270[i]) / (tg90[i] + tg270[i]);
            }
            //_________________________________________________________________________________________________________________________
            //_________________________________________________________________________________________________________________________
            //_________________________________________________________________________________________________________________________

            // Номинали на лист СРЕДНИЙ
            kcmDev = new double[3];
            kcmDev[0] = _rd.PassportData.DevX600 + (_rd.RecomValData.ProdMas - m600) * (_rd.PassportData.DevX6000 - _rd.PassportData.DevX600) / (m6000 - m600);
            kcmDev[1] = _rd.PassportData.DevY600 + (_rd.RecomValData.ProdMas - m600) * (_rd.PassportData.DevY6000 - _rd.PassportData.DevY600) / (m6000 - m600);
            kcmDev[2] = _rd.PassportData.DevZ600 + (_rd.RecomValData.ProdMas - m600) * (_rd.PassportData.DevZ6000 - _rd.PassportData.DevZ600) / (m6000 - m600);
            // Даныне пойдут на в средн
            kcmMprod = new double[kcmSumX.Length]; // - МАССА ДЕТАЛИ ИСТИННАЯ ( 10 замеров )
            for (int i = 0; i < kcmMprod.Length; i++)
            {
                kcmMprod[i] = kcmSum_m[i] - _rd.PassportData.PerMas;
            }

            kcmXprod = new double[kcmSumX.Length];
            for (int i = 0; i < kcmXprod.Length; i++)
            {
                kcmXprod[i] = (kcmSum_m[i] * kcmSumX[i] - _rd.PassportData.PerMas * _rd.PassportData.PerX - kcmMprod[i] * _rd.PassportData.PerH) / kcmMprod[i] + kcmDev[0];
            }

            kcmYprod = new double[kcmSumX.Length];
            for (int i = 0; i < kcmYprod.Length; i++)
            {
                kcmYprod[i] = (kcmSum_m[i] * kcmSumY[i] - _rd.PassportData.PerMas * _rd.PassportData.PerY) / kcmMprod[i] + kcmDev[1];
            }

            kcmZprod = new double[kcmSumX.Length];
            for (int i = 0; i < kcmZprod.Length; i++)
            {
                kcmZprod[i] = (kcmSum_m[i] * kcmSumZ[i] - _rd.PassportData.PerMas * _rd.PassportData.PerZ) / kcmMprod[i] + kcmDev[2];
                // Оценка влияния Δφ для у
                kcmZprod[i] = kcmZprod[i] + kcmYprod[i] * _rd.PassportData.PasDevFi;
            }
            // Оценка влияния Δφ для у
            for (int i = 0; i < kcmYprod.Length; i++)
            {
                kcmYprod[i] = kcmYprod[i] - kcmZprod[i] * _rd.PassportData.PasDevFi;
            }
        }


        private double[] DevAver;
        private double[] SumX_CM;
        private double[] SumY_CM;
        private double[] SumZ_CM;
        private double[] Xprod_CM;
        private double[] Yprod_CM;
        private double[] Zprod_CM;
        private double AvVulX1, AvVulY1, AvVulZ1, AvVulM1, AvVulX2, AvVulY2, AvVulZ2; // Средние значения для расчета 
        private bool Gruz;

        public void WorkList2()
        {
            Gruz = false;

            // Расчет суммарных
            if(_rd.RecomValData.Mm != 0)
            { 
                SumX_CM = new double[A0.Length];
                for (int i = 0; i < SumX_CM.Length; i++)
                {
                    SumX_CM[i] = ((2 * kcmSum_m[i] * _rd.PassportData.PasS - _rd.RecomValData.Mm * _rd.PassportData.PasE * (tg0[i] + tg180[i]) - 2 * _rd.RecomValData.Mm * _rd.PassportData.PasD)
                    / kcmSum_m[i] * (tg90[i] + tg180[i]) - _rd.PassportData.PasH + (2 * kcmSum_m[i] * _rd.PassportData.PasS - _rd.RecomValData.Mm * _rd.PassportData.PasE * (tg90[i] + tg270[i]) - 2 * _rd.RecomValData.Mm * _rd.PassportData.PasD)
                    / kcmSum_m[i] * (tg90[i] + tg270[i]) - _rd.PassportData.PasH) / 2;
                }

                SumY_CM = new double[A0.Length];
                for (int i = 0; i < SumY_CM.Length; i++)
                {
                    SumY_CM[i] = (_rd.PassportData.PasS * kcmSum_m[i] - _rd.RecomValData.Mm * _rd.PassportData.PasD) * (tg0[i] - tg180[i]) / kcmSum_m[i] * (tg0[i] + tg180[i]);
                }

                SumZ_CM = new double[A0.Length];
                for (int i = 0; i < SumZ_CM.Length; i++)
                {
                    SumZ_CM[i] = (_rd.PassportData.PasS * kcmSum_m[i] - _rd.RecomValData.Mm * _rd.PassportData.PasD) * (tg90[i] - tg270[i]) / kcmSum_m[i] * (tg90[i] + tg270[i]);
                }

                Xprod_CM = new double[A0.Length];
                for (int i = 0; i < Xprod_CM.Length; i++)
                {
                    Xprod_CM[i] = (Sum_m * SumX_CM[i] - _rd.PassportData.PerMas * _rd.PassportData.PerX - _rd.RecomValData.ProdMas * _rd.PassportData.PerH) / _rd.RecomValData.ProdMas;
                }

                Yprod_CM = new double[A0.Length];
                for (int i = 0; i < Yprod_CM.Length; i++)
                {
                    Yprod_CM[i] = (Sum_m * SumY_CM[i] - _rd.PassportData.PerMas * _rd.PassportData.PerY) / _rd.RecomValData.ProdMas;
                }

                Zprod_CM = new double[A0.Length];
                for (int i = 0; i < Zprod_CM.Length; i++)
                {
                    Zprod_CM[i] = (Sum_m * SumZ_CM[i] - _rd.PassportData.PerMas * _rd.PassportData.PerZ) / _rd.RecomValData.ProdMas;
                }
                Gruz = true;
            }

            //________________________________________________________________________________________________________________________
            //________________________________________________________________________________________________________________________
            //________________________________________________________________________________________________________________________

            // РАСЧЕТ КООРДИНАТ для КЦМ\М и КП-КЦМ\М (ИТОГ)
            // X
            if (_rd.PassportData.KP == true)
            {
                if (Gruz == false)
                {
                    kcmXprod.Average();
                    AvVulX1 = kcmXprod.Average();
                    calcData.RES_Xkp = AvVulX1;
                }
                else
                {
                    Xprod_CM.Average();
                    AvVulX2 = Xprod_CM.Average();
                    calcData.RES_Xkp = AvVulX2;
                }

                //Y
                if (Gruz == false)
                {
                    kcmYprod.Average();
                    AvVulY1 = kcmYprod.Average();
                    calcData.RES_Ykp = AvVulY1;
                }
                else
                {
                    Yprod_CM.Average();
                    AvVulY2 = Yprod_CM.Average();
                    calcData.RES_Ykp = AvVulY2;
                }

                // Z
                if (Gruz == false)
                {
                    kcmZprod.Average();
                    AvVulZ1 = kcmZprod.Average();
                    calcData.RES_Zkp = AvVulZ1;
                }
                else
                {
                    Zprod_CM.Average();
                    AvVulZ2 = Zprod_CM.Average();
                    calcData.RES_Zkp = AvVulZ2;
                }

                kcmMprod.Average();
                AvVulM1 = kcmMprod.Average();
                calcData.RES_Mkp = AvVulM1;
            }
            else
            {
                if (Gruz == false)
                {
                    kcmXprod.Average();
                    AvVulX1 = kcmXprod.Average();
                    calcData.RES_X = AvVulX1;
                }
                else
                {
                    Xprod_CM.Average();
                    AvVulX2 = Xprod_CM.Average();
                    calcData.RES_X = AvVulX2;
                }

                //Y
                if (Gruz == false)
                {
                    kcmYprod.Average();
                    AvVulY1 = kcmYprod.Average();
                    calcData.RES_Y = AvVulY1;
                }
                else
                {
                    Yprod_CM.Average();
                    AvVulY2 = Yprod_CM.Average();
                    calcData.RES_Y = AvVulY2;
                }

               // Z
                if (Gruz == false)
                {
                    kcmZprod.Average();
                    AvVulZ1 = kcmZprod.Average();
                    calcData.RES_Z = AvVulZ1;
                }
                else
                {
                    Zprod_CM.Average();
                    AvVulZ2 = Zprod_CM.Average();
                    calcData.RES_Z = AvVulZ2;
                }

                kcmMprod.Average();
                AvVulM1 = kcmMprod.Average();
                calcData.RES_M = AvVulM1;
            }

            //_______________________________________________________________________________
            //Определение средних значений КМЦ и массы и их отклонений!!!!
             _rd.NSPData.AverProdValMas = kcmMprod.Average();
                for (int i = 0; i < kcmMprod.Length; i++)
                {
                     kcmMprod[i] = kcmMprod[i] - _rd.NSPData.AverProdValMas;
                     kcmMprod[i] = Math.Pow(kcmMprod[i], 2);
                }
            Sum__m = kcmMprod.Sum();
             if (_rd.PassportData.KP == true)
             {
                Mkp = Math.Sqrt(Sum__m / (kcmMprod.Length - 1)) / Math.Sqrt(10);
             }    
             else
             {
                M = Math.Sqrt(Sum__m / (kcmMprod.Length - 1)) / Math.Sqrt(10);
             }
                
            //____________________________________________________

            if (Gruz == false)
            {
                _rd.NSPData.AverProdVal_X = kcmXprod.Average();
                for (int i = 0; i < kcmXprod.Length; i++)
                {
                    kcmXprod[i] = kcmXprod[i] - _rd.NSPData.AverProdVal_X;
                    kcmXprod[i] = Math.Pow(kcmXprod[i], 2);
                }
                Sum__x = kcmXprod.Sum();
                if (_rd.PassportData.KP == true)
                {
                    Xkp = Math.Sqrt(Sum__x / (kcmXprod.Length - 1)) / Math.Sqrt(10);
                }
                else
                {
                    X = Math.Sqrt(Sum__x / (kcmXprod.Length - 1)) / Math.Sqrt(10);
                }
                
            }
            else
            {
                _rd.NSPData.AverProdVal_X = Xprod_CM.Average();
                for (int i = 0; i < Xprod_CM.Length; i++)
                {
                    Xprod_CM[i] = Xprod_CM[i] - _rd.NSPData.AverProdVal_X;
                    Xprod_CM[i] = Math.Pow(kcmXprod[i], 2);
                }
                Sum__x = Xprod_CM.Sum();
                if (_rd.PassportData.KP == true)
                {
                    Xkp = Math.Sqrt(Sum__x / (Xprod_CM.Length - 1)) / Math.Sqrt(10);
                }
                else
                {
                    X = Math.Sqrt(Sum__x / (Xprod_CM.Length - 1)) / Math.Sqrt(10);
                }
                
            }
            //____________________________________________________

            if (Gruz == false)
            {
                _rd.NSPData.AverProdVal_Y = kcmYprod.Average();
                for (int i = 0; i < kcmYprod.Length; i++)
                {
                    kcmYprod[i] = kcmYprod[i] - _rd.NSPData.AverProdVal_Y;
                    kcmYprod[i] = Math.Pow(kcmYprod[i], 2);
                }
                Sum__y = kcmYprod.Sum();
                if (_rd.PassportData.KP == true)
                {
                    Ykp = Math.Sqrt(Sum__y / (kcmYprod.Length - 1)) / Math.Sqrt(10);
                }
                else
                {
                    Y = Math.Sqrt(Sum__y / (kcmYprod.Length - 1)) / Math.Sqrt(10);
                }
                
            }
            else
            {
                _rd.NSPData.AverProdVal_Y = Yprod_CM.Average();
                for (int i = 0; i < Yprod_CM.Length; i++)
                {
                    Yprod_CM[i] = Yprod_CM[i] - _rd.NSPData.AverProdVal_Y;
                    Yprod_CM[i] = Math.Pow(Yprod_CM[i], 2);
                }
                Sum__y = Yprod_CM.Sum();
                if (_rd.PassportData.KP == true)
                {
                    Ykp = Math.Sqrt(Sum__y / (Yprod_CM.Length - 1)) / Math.Sqrt(10);
                }
                else
                {
                    Y = Math.Sqrt(Sum__y / (Yprod_CM.Length - 1)) / Math.Sqrt(10);
                }
                
            }
            //____________________________________________________

            if (Gruz == false)
            {
                _rd.NSPData.AverProdVal_Z = kcmZprod.Average();
                for (int i = 0; i < kcmZprod.Length; i++)
                {
                    kcmZprod[i] = kcmZprod[i] - _rd.NSPData.AverProdVal_Z;
                    kcmZprod[i] = Math.Pow(kcmZprod[i], 2);
                }
                Sum__z = kcmZprod.Sum();
                if (_rd.PassportData.KP == true)
                {
                    Zkp = Math.Sqrt(Sum__z / (kcmZprod.Length - 1)) / Math.Sqrt(10);
                }
                else
                {
                    Z = Math.Sqrt(Sum__z / (kcmZprod.Length - 1)) / Math.Sqrt(10);
                }
                
            }
            else
            {
                _rd.NSPData.AverProdVal_Z = Zprod_CM.Average();
                for (int i = 0; i < Zprod_CM.Length; i++)
                {
                    Zprod_CM[i] = Zprod_CM[i] - _rd.NSPData.AverProdVal_Z;
                    Zprod_CM[i] = Math.Pow(Zprod_CM[i], 2);
                }
                Sum__z = Zprod_CM.Sum();
                if (_rd.PassportData.KP == true)
                {
                    Zkp = Math.Sqrt(Sum__z / (kcmZprod.Length - 1)) / Math.Sqrt(10);
                }
                else
                {
                    Z = Math.Sqrt(Sum__z / (kcmZprod.Length - 1)) / Math.Sqrt(10);
                }
                
            }
            //____________________________________________________________________

            // Среднеквадратичное отклонение средних арифметических 
            DevAver = new double[4] { X, Y, Z, M };
            _rd.NSPData.devXnsp = DevAver[0];
            _rd.NSPData.devYnsp = DevAver[1];
            _rd.NSPData.devZnsp = DevAver[2];
            _rd.NSPData.devMnsp = DevAver[3];
        }


        // NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP  NSP NSP NSP NSP NSP NSP NSP
        // NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP  NSP NSP NSP NSP NSP NSP NSP
        // NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP NSP  NSP NSP NSP NSP NSP NSP NSP

        public double[] devX1, devY1, devZ1, devM1, devX2, devY2, devZ2, devM2;
        public double[] ErLimS, Kves, NSPmax, Sdev_res, gran;
        public const double Kt = 2.262;

        public void NSP()
        {
            // Вносим данные 
            devX1 = new double[17] {_rd.NSPData._devSx, _rd.NSPData._devHx, _rd.NSPData._devLx, _rd.NSPData._devQx, _rd.NSPData._devPx, _rd.NSPData._devEPSILx, _rd.NSPData._devFIx, _rd.NSPData._devXpx, _rd.NSPData._devYpx, _rd.NSPData._devZpx, _rd.NSPData._devMpx, _rd.NSPData._devHpx, _rd.NSPData._devDx, _rd.NSPData._devEx, _rd.NSPData._devMAx, _rd.NSPData._devMMx, _rd.NSPData._devMASSx };
            devY1 = new double[17] { _rd.NSPData._devSy, _rd.NSPData._devHy, _rd.NSPData._devLy, _rd.NSPData._devQy, _rd.NSPData._devPy, _rd.NSPData._devEPSILy, _rd.NSPData._devFIy, _rd.NSPData._devXpy, _rd.NSPData._devYpy, _rd.NSPData._devZpy, _rd.NSPData._devMpy, _rd.NSPData._devHpy, _rd.NSPData._devDy, _rd.NSPData._devEy, _rd.NSPData._devMAy, _rd.NSPData._devMMy, _rd.NSPData._devMASSy };
            devZ1 = new double[17] { _rd.NSPData._devSz, _rd.NSPData._devHz, _rd.NSPData._devLz, _rd.NSPData._devQz, _rd.NSPData._devPz, _rd.NSPData._devEPSILz, _rd.NSPData._devFIz, _rd.NSPData._devXpz, _rd.NSPData._devYpz, _rd.NSPData._devZpz, _rd.NSPData._devMpz, _rd.NSPData._devHpz, _rd.NSPData._devDz, _rd.NSPData._devEz, _rd.NSPData._devMAz, _rd.NSPData._devMMz, _rd.NSPData._devMASSz };
            devM1 = new double[17] { _rd.NSPData._devSm, _rd.NSPData._devHm, _rd.NSPData._devLm, _rd.NSPData._devQm, _rd.NSPData._devPm, _rd.NSPData._devEPSILm, _rd.NSPData._devFIm, _rd.NSPData._devXpm, _rd.NSPData._devYpm, _rd.NSPData._devZpm, _rd.NSPData._devMpm, _rd.NSPData._devHpm, _rd.NSPData._devDm, _rd.NSPData._devEm, _rd.NSPData._devMAm, _rd.NSPData._devMMm, _rd.NSPData._devMASSm };
            devX2 = new double[17] { _rd.NSPData._devSx2, _rd.NSPData._devHx2, _rd.NSPData._devLx2, _rd.NSPData._devQx2, _rd.NSPData._devPx2, _rd.NSPData._devEPSILx2, _rd.NSPData._devFIx2, _rd.NSPData._devXpx2, _rd.NSPData._devYpx2, _rd.NSPData._devZpx2, _rd.NSPData._devMpx2, _rd.NSPData._devHpx2, _rd.NSPData._devDx2, _rd.NSPData._devEx2, _rd.NSPData._devMAx2, _rd.NSPData._devMMx2, _rd.NSPData._devMASSx2 };
            devY2 = new double[17] { _rd.NSPData._devSy2, _rd.NSPData._devHy2, _rd.NSPData._devLy2, _rd.NSPData._devQy2, _rd.NSPData._devPy2, _rd.NSPData._devEPSILy2, _rd.NSPData._devFIy2, _rd.NSPData._devXpy2, _rd.NSPData._devYpy2, _rd.NSPData._devZpy2, _rd.NSPData._devMpy2, _rd.NSPData._devHpy2, _rd.NSPData._devDy2, _rd.NSPData._devEy2, _rd.NSPData._devMAy2, _rd.NSPData._devMMy2, _rd.NSPData._devMASSy2 };
            devZ2 = new double[17] { _rd.NSPData._devSz2, _rd.NSPData._devHz2, _rd.NSPData._devLz2, _rd.NSPData._devQz2, _rd.NSPData._devPz2, _rd.NSPData._devEPSILz2, _rd.NSPData._devFIz2, _rd.NSPData._devXpz2, _rd.NSPData._devYpz2, _rd.NSPData._devZpz2, _rd.NSPData._devMpz2, _rd.NSPData._devHpz2, _rd.NSPData._devDz2, _rd.NSPData._devEz2, _rd.NSPData._devMAz2, _rd.NSPData._devMMz2, _rd.NSPData._devMASSz2 };
            devM2 = new double[17] { _rd.NSPData._devSm2, _rd.NSPData._devHm2, _rd.NSPData._devLm2, _rd.NSPData._devQm2, _rd.NSPData._devPm2, _rd.NSPData._devEPSILm2, _rd.NSPData._devFIm2, _rd.NSPData._devXpm2, _rd.NSPData._devYpm2, _rd.NSPData._devZpm2, _rd.NSPData._devMpm2, _rd.NSPData._devHpm2, _rd.NSPData._devDm2, _rd.NSPData._devEm2, _rd.NSPData._devMAm2, _rd.NSPData._devMMm2, _rd.NSPData._devMASSm2 };

            //Находим границы погрешностей Δθ=1,1√Σ(+Δi)2
            //ErLimX1 
            for (int i = 0; i < 17; i++)
            {
                devX1[i] = Math.Pow(devX1[i], 2);
            }
            _rd.NSPData.ErLimX1 = Math.Abs(Math.Sqrt(devX1.Sum() / 3));

            //ErLimY1 
            for (int i = 0; i < 17; i++)
            {
                devY1[i] = Math.Pow(devY1[i], 2);
            }
            _rd.NSPData.ErLimY1 = Math.Abs(Math.Sqrt(devY1.Sum() / 3));

            //ErLimZ1 
            for (int i = 0; i < 17; i++)
            {
                devZ1[i] = Math.Pow(devZ1[i], 2);

            }
            _rd.NSPData.ErLimZ1 = Math.Abs(Math.Sqrt(devZ1.Sum() / 3));

            //ErLimM1 
            for (int i = 0; i < 17; i++)
            {
                devM1[i] = Math.Pow(devM1[i], 2);
            }
            _rd.NSPData.ErLimM1 = Math.Abs(Math.Sqrt(devM1.Sum() / 3));

            //Находим границы погрешностей  Δθ=1,1√Σ(–Δi)2
            //ErLimX2 
            for (int i = 0; i < 17; i++)
            {
                devX2[i] = Math.Pow(devX2[i], 2);
            }
            _rd.NSPData.ErLimX2 = Math.Abs(Math.Sqrt(devX2.Sum() / 3));

            //ErLimY2 
            for (int i = 0; i < 17; i++)
            {
                devY2[i] = Math.Pow(devY2[i], 2);
            }
            _rd.NSPData.ErLimY2 = Math.Abs(Math.Sqrt(devY2.Sum() / 3));

            //ErLimZ2
            for (int i = 0; i < 17; i++)
            {
                devZ2[i] = Math.Pow(devZ2[i], 2);
            }
            _rd.NSPData.ErLimZ2 = Math.Abs(Math.Sqrt(devZ2.Sum() / 3));

            //ErLimM2
            for (int i = 0; i < 17; i++)
            {
                devM2[i] = Math.Pow(devM2[i], 2);
            }
            _rd.NSPData.ErLimM2 = Math.Abs(Math.Sqrt(devM2.Sum() / 3));

            //NSPmax  (Δθi)
            _rd.NSPData.NSPmaxX = Math.Max(_rd.NSPData.ErLimX1, _rd.NSPData.ErLimX2);
            _rd.NSPData.NSPmaxY = Math.Max(_rd.NSPData.ErLimY1, _rd.NSPData.ErLimY2);
            _rd.NSPData.NSPmaxZ = Math.Max(_rd.NSPData.ErLimZ1, _rd.NSPData.ErLimZ2);
            _rd.NSPData.NSPmaxM = Math.Max(_rd.NSPData.ErLimM1, _rd.NSPData.ErLimM2);
            NSPmax = new double[4] { _rd.NSPData.NSPmaxX, _rd.NSPData.NSPmaxY, _rd.NSPData.NSPmaxZ, _rd.NSPData.NSPmaxM };


            //ErLimS - среднее квадратичное отклоенине суммарных НСП (Sθ)
            ErLimS = new double[NSPmax.Length];
            for (int i = 0; i < NSPmax.Count(); i++)
            {
                ErLimS[i] = NSPmax[i];
            }
            for (int i = 0; i < 4; i++)
            {
                ErLimS[i] = ErLimS[i] / (1.1 * Math.Pow(3, 0.5));
            }
            _rd.NSPData.ErLimSx = ErLimS[0];
            _rd.NSPData.ErLimSy = ErLimS[1];
            _rd.NSPData.ErLimSz = ErLimS[2];
            _rd.NSPData.ErLimSm = ErLimS[3];

            //Kves Весовой Коэффициент  
            Kves = new double[ErLimS.Length];
            for (int i = 0; i < Kves.Length; i++)
            {
                Kves[i] = (Kt * DevAver[i] + NSPmax[i]) / (DevAver[i] + ErLimS[i]);
            }
            _rd.NSPData.KvesX = Kves[0];
            _rd.NSPData.KvesY = Kves[1];
            _rd.NSPData.KvesZ = Kves[2];
            _rd.NSPData.KvesM = Kves[3];

            //(SΣ) Суммарные средние квадратиеское отклонение
            Sdev_res = new double[ErLimS.Length];
            for (int i = 0; i < Sdev_res.Length; i++)
            {
                Sdev_res[i] = Math.Sqrt(Math.Pow(DevAver[i], 2) + Math.Pow(ErLimS[i], 2));
            }
            _rd.NSPData.Sdev_reNsX = Sdev_res[0];
            _rd.NSPData.Sdev_reNsY = Sdev_res[1];
            _rd.NSPData.Sdev_reNsZ = Sdev_res[2];
            _rd.NSPData.Sdev_reNsM = Sdev_res[3];

            //(±Δ) - границы
            gran = new double[ErLimS.Length];
            for (int i = 0; i < gran.Length; i++)
            {
                gran[i] = Sdev_res[i] * Kves[i];
            }
            _rd.NSPData.granX = gran[0];
            _rd.NSPData.granY = gran[1];
            _rd.NSPData.granZ = gran[2];
            _rd.NSPData.granM = gran[3];
        }
        /// <summary>
        /// Поправки
        /// </summary>
        public double[] _p;
        public double[] SystemDev;
        public double[] _kmcKP;
        public double[] SystemEer;
        public double[] GranKP;
        public void KP()
        {
            if (_rd.PassportData.KP == true)
            {
                _p = new double[4];
                _p[0] = calcData.RES_Xkp - _rd.PassportData.KpX;
                _p[1] = calcData.RES_Ykp - _rd.PassportData.KpY;
                _p[2] = calcData.RES_Zkp - _rd.PassportData.KpZ;
                _p[3] = calcData.RES_Mkp- _rd.PassportData.KpMas;
                calcData._pX = _p[0];
                calcData._pY = _p[1];
                calcData._pZ = _p[2];
                calcData._pM = _p[3];


                _kmcKP = new double[4];
                _kmcKP[0] = calcData.RES_X - _p[0];
                _kmcKP[1] = calcData.RES_Y - _p[1];
                _kmcKP[2] = calcData.RES_Z - _p[2];
                _kmcKP[3] = calcData.RES_M - _p[3];
                calcData._kmcKPx = _kmcKP[0];
                calcData._kmcKPy = _kmcKP[1];
                calcData._kmcKPz = _kmcKP[2];
                calcData._kmcKPm = _kmcKP[3];

                //Систем отклоенния после введения поправок
                SystemDev = new double[4];
                SystemDev[0] = _kmcKP[0] - _rd.PassportData.KpX;
                SystemDev[1] = _kmcKP[1] - _rd.PassportData.KpY;
                SystemDev[2] = _kmcKP[2] - _rd.PassportData.KpZ;
                SystemDev[3] = _kmcKP[3] - _rd.PassportData.KpMas;
                calcData.SystemDevX = SystemDev[0];
                calcData.SystemDevY = SystemDev[1];
                calcData.SystemDevZ = SystemDev[2];
                calcData.SystemDevM = SystemDev[3];

                // Систем погрешности
                SystemEer = new double[4];
                SystemEer[0] = _rd.PassportData.KpDevX + SystemDev[0];
                SystemEer[1] = _rd.PassportData.KpDevY + SystemDev[1];
                SystemEer[2] = _rd.PassportData.KpDevZ + SystemDev[2];
                SystemEer[3] = _rd.PassportData.KpDevMas + SystemDev[3];
                calcData.SystemEerX = SystemEer[0];
                calcData.SystemEerY = SystemEer[1];
                calcData.SystemEerZ = SystemEer[2];
                calcData.SystemEerM = SystemEer[3];


                GranKP = new double[4];
                GranKP[0] = SystemEer[0] + Xkp;
                GranKP[1] = SystemEer[1] + Ykp;
                GranKP[2] = SystemEer[2] + Zkp;
                GranKP[3] = SystemEer[3] + Mkp; 
                calcData.GranKPx = GranKP[0];
                calcData.GranKPy = GranKP[1];
                calcData.GranKPz = GranKP[2];
                calcData.GranKPm = GranKP[3];
            }
            else
            {
                Console.WriteLine("КП не выбрано");
            }
        }
    }
}
