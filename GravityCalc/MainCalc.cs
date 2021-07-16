using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GravityCalc
{
    /// <summary>
    /// Основной класс калькулятора
    /// </summary>
    public class MainCalc : ICalculator
    {
        /// <summary>
        /// Полученные данные
        /// </summary>
        private ReceivedData _receivedData;
        private Сalculator _calculator;
        CalculatedData calc;
        private readonly string _name = "Калькулятор";
        private CalcDataProvider _dataProvider = null;
        bool _angel = false;
        bool _nsp = false;
        /// <summary>
        /// Максимальное количество получаемых данных (для расчёта)
        /// </summary>
        private const ushort _maxReceivedData = 10;

        public MainCalc()
        {
            _receivedData = new();
            _calculator = new(_receivedData);
           
        }
        public void SetControllerData(ControllerData controllerData)
        {
            Console.WriteLine("{0} : Получены новые данные от контроллера", _name);
            _receivedData.ControllerData = controllerData;
            
            switch (_receivedData.PassportData.Fi)
            {
                case 0:
                    if(_receivedData.PassportData.Cargo == true)
                    {
                        if (_receivedData.beginBalanceAngleArr0.Count() < _maxReceivedData && _receivedData.MiddleBalanceAngleArr0.Count() < _maxReceivedData &&
                            _receivedData.BeginUnbalanceSensorArr0.Count() < _maxReceivedData && _receivedData.MiddleUnbalanceSensorArr0.Count() < _maxReceivedData)
                        {
                            _receivedData.beginBalanceAngleArr0.Add(controllerData.BeginBalanceAngle);
                            _receivedData.MiddleBalanceAngleArr0.Add(controllerData.MiddleBalanceAngle);
                            _receivedData.BeginUnbalanceSensorArr0.Add(controllerData.BeginUnbalanceSensor);
                            _receivedData.MiddleUnbalanceSensorArr0.Add(controllerData.MiddleUnbalanceSensor);
                        }
                        else
                        {
                            _receivedData.beginBalanceAngleArr0.RemoveAt(0);
                            _receivedData.beginBalanceAngleArr0.Add(controllerData.BeginBalanceAngle);
                            _calculator.BeginBalanceAngleArr0 = _receivedData.beginBalanceAngleArr0;

                            _receivedData.MiddleBalanceAngleArr0.RemoveAt(0);
                            _receivedData.MiddleBalanceAngleArr0.Add(controllerData.MiddleBalanceAngle);
                            _calculator.MiddleBalanceAngleArr0 = _receivedData.MiddleBalanceAngleArr0;

                            _receivedData.BeginUnbalanceSensorArr0.RemoveAt(0);
                            _receivedData.BeginUnbalanceSensorArr0.Add(controllerData.BeginUnbalanceSensor);
                            _calculator.BeginUnbalanceSensorArr0 = _receivedData.BeginUnbalanceSensorArr0;

                            _receivedData.MiddleUnbalanceSensorArr0.RemoveAt(0);
                            _receivedData.MiddleUnbalanceSensorArr0.Add(controllerData.MiddleUnbalanceSensor);
                            _calculator.MiddleUnbalanceSensorArr0 = _receivedData.MiddleUnbalanceSensorArr0;

                            _calculator.ProductAngle(_calculator.BeginBalanceAngleArr0, _calculator.MiddleBalanceAngleArr0, _calculator.BeginUnbalanceSensorArr0, _calculator.MiddleUnbalanceSensorArr0);
                        }
                    }
                    else
                        if (_receivedData.beginBalanceAngleArr0_2.Count() < _maxReceivedData && _receivedData.MiddleBalanceAngleArr0_2.Count() < _maxReceivedData &&
                            _receivedData.BeginUnbalanceSensorArr0_2.Count() < _maxReceivedData && _receivedData.MiddleUnbalanceSensorArr0_2.Count() < _maxReceivedData)
                    {
                        _receivedData.beginBalanceAngleArr0_2.Add(controllerData.BeginBalanceAngle);
                        _receivedData.MiddleBalanceAngleArr0_2.Add(controllerData.MiddleBalanceAngle);
                        _receivedData.BeginUnbalanceSensorArr0_2.Add(controllerData.BeginUnbalanceSensor);
                        _receivedData.MiddleUnbalanceSensorArr0_2.Add(controllerData.MiddleUnbalanceSensor);
                    }
                    else
                    {
                        _receivedData.beginBalanceAngleArr0_2.RemoveAt(0);
                        _receivedData.beginBalanceAngleArr0_2.Add(controllerData.BeginBalanceAngle);
                        _calculator.BeginBalanceAngleArr0_2 = _receivedData.beginBalanceAngleArr0_2;

                        _receivedData.MiddleBalanceAngleArr0_2.RemoveAt(0);
                        _receivedData.MiddleBalanceAngleArr0_2.Add(controllerData.MiddleBalanceAngle);
                        _calculator.MiddleBalanceAngleArr0_2 = _receivedData.MiddleBalanceAngleArr0_2;

                        _receivedData.BeginUnbalanceSensorArr0_2.RemoveAt(0);
                        _receivedData.BeginUnbalanceSensorArr0_2.Add(controllerData.BeginUnbalanceSensor);
                        _calculator.BeginUnbalanceSensorArr0_2 = _receivedData.BeginUnbalanceSensorArr0_2;

                        _receivedData.MiddleUnbalanceSensorArr0_2.RemoveAt(0);
                        _receivedData.MiddleUnbalanceSensorArr0_2.Add(controllerData.MiddleUnbalanceSensor);
                        _calculator.MiddleUnbalanceSensorArr0_2 = _receivedData.MiddleUnbalanceSensorArr0_2;

                        _calculator.ProductAngle(_calculator.BeginBalanceAngleArr0_2, _calculator.MiddleBalanceAngleArr0_2, _calculator.BeginUnbalanceSensorArr0_2, _calculator.MiddleUnbalanceSensorArr0_2);
                    }

                    break;

                case 90:
                    if (_receivedData.beginBalanceAngleArr90.Count() < _maxReceivedData && _receivedData.MiddleBalanceAngleArr90.Count() < _maxReceivedData &&
                       _receivedData.BeginUnbalanceSensorArr90.Count() < _maxReceivedData && _receivedData.MiddleUnbalanceSensorArr90.Count() < _maxReceivedData)
                    {
                        _receivedData.beginBalanceAngleArr90.Add(controllerData.BeginBalanceAngle);
                        _receivedData.MiddleBalanceAngleArr90.Add(controllerData.MiddleBalanceAngle);
                        _receivedData.BeginUnbalanceSensorArr90.Add(controllerData.BeginUnbalanceSensor);
                        _receivedData.MiddleUnbalanceSensorArr90.Add(controllerData.MiddleUnbalanceSensor);
                    }
                    else
                    {
                        _receivedData.beginBalanceAngleArr90.RemoveAt(0);
                        _receivedData.beginBalanceAngleArr90.Add(controllerData.BeginBalanceAngle);
                        _calculator.BeginBalanceAngleArr90 = _receivedData.beginBalanceAngleArr90;

                        _receivedData.MiddleBalanceAngleArr90.RemoveAt(0);
                        _receivedData.MiddleBalanceAngleArr90.Add(controllerData.MiddleBalanceAngle);
                        _calculator.MiddleBalanceAngleArr90 = _receivedData.MiddleBalanceAngleArr90;

                        _receivedData.BeginUnbalanceSensorArr90.RemoveAt(0);
                        _receivedData.BeginUnbalanceSensorArr90.Add(controllerData.BeginUnbalanceSensor);
                        _calculator.BeginUnbalanceSensorArr90 = _receivedData.BeginUnbalanceSensorArr90;

                        _receivedData.MiddleUnbalanceSensorArr90.RemoveAt(0);
                        _receivedData.MiddleUnbalanceSensorArr90.Add(controllerData.MiddleUnbalanceSensor);
                        _calculator.MiddleUnbalanceSensorArr90 = _receivedData.MiddleUnbalanceSensorArr90;

                        _calculator.ProductAngle(_calculator.BeginBalanceAngleArr90, _calculator.MiddleBalanceAngleArr90, _calculator.BeginUnbalanceSensorArr90, _calculator.MiddleUnbalanceSensorArr90);
                    }
                    break;

                case 180:
                    if (_receivedData.PassportData.Cargo == true)
                    { 
                        if (_receivedData.beginBalanceAngleArr180.Count() < _maxReceivedData && _receivedData.MiddleBalanceAngleArr180.Count() < _maxReceivedData &&
                           _receivedData.BeginUnbalanceSensorArr180.Count() < _maxReceivedData && _receivedData.MiddleUnbalanceSensorArr180.Count() < _maxReceivedData)
                        {
                            _receivedData.beginBalanceAngleArr180.Add(controllerData.BeginBalanceAngle);
                            _receivedData.MiddleBalanceAngleArr180.Add(controllerData.MiddleBalanceAngle);
                            _receivedData.BeginUnbalanceSensorArr180.Add(controllerData.BeginUnbalanceSensor);
                            _receivedData.MiddleUnbalanceSensorArr180.Add(controllerData.MiddleUnbalanceSensor);
                        }
                        else
                        {
                            _receivedData.beginBalanceAngleArr180.RemoveAt(0);
                            _receivedData.beginBalanceAngleArr180.Add(controllerData.BeginBalanceAngle);
                            _calculator.BeginBalanceAngleArr180 = _receivedData.beginBalanceAngleArr180;

                            _receivedData.MiddleBalanceAngleArr180.RemoveAt(0);
                            _receivedData.MiddleBalanceAngleArr180.Add(controllerData.MiddleBalanceAngle);
                            _calculator.MiddleBalanceAngleArr180 = _receivedData.MiddleBalanceAngleArr180;

                            _receivedData.BeginUnbalanceSensorArr180.RemoveAt(0);
                            _receivedData.BeginUnbalanceSensorArr180.Add(controllerData.BeginUnbalanceSensor);
                            _calculator.BeginUnbalanceSensorArr180 = _receivedData.BeginUnbalanceSensorArr180;

                            _receivedData.MiddleUnbalanceSensorArr180.RemoveAt(0);
                            _receivedData.MiddleUnbalanceSensorArr180.Add(controllerData.MiddleUnbalanceSensor);
                            _calculator.MiddleUnbalanceSensorArr180 = _receivedData.MiddleUnbalanceSensorArr180;

                            _calculator.ProductAngle(_calculator.BeginBalanceAngleArr180, _calculator.MiddleBalanceAngleArr180, _calculator.BeginUnbalanceSensorArr180, _calculator.MiddleUnbalanceSensorArr180);
                        }
                    }
                    else
                    {
                        if (_receivedData.beginBalanceAngleArr180_2.Count() < _maxReceivedData && _receivedData.MiddleBalanceAngleArr180_2.Count() < _maxReceivedData &&
                           _receivedData.BeginUnbalanceSensorArr180_2.Count() < _maxReceivedData && _receivedData.MiddleUnbalanceSensorArr180_2.Count() < _maxReceivedData)
                        {
                            _receivedData.beginBalanceAngleArr180_2.Add(controllerData.BeginBalanceAngle);
                            _receivedData.MiddleBalanceAngleArr180_2.Add(controllerData.MiddleBalanceAngle);
                            _receivedData.BeginUnbalanceSensorArr180_2.Add(controllerData.BeginUnbalanceSensor);
                            _receivedData.MiddleUnbalanceSensorArr180_2.Add(controllerData.MiddleUnbalanceSensor);
                        }
                        else
                        {
                            _receivedData.beginBalanceAngleArr180_2.RemoveAt(0);
                            _receivedData.beginBalanceAngleArr180_2.Add(controllerData.BeginBalanceAngle);
                            _calculator.BeginBalanceAngleArr180_2 = _receivedData.beginBalanceAngleArr180_2;

                            _receivedData.MiddleBalanceAngleArr180_2.RemoveAt(0);
                            _receivedData.MiddleBalanceAngleArr180_2.Add(controllerData.MiddleBalanceAngle);
                            _calculator.MiddleBalanceAngleArr180_2 = _receivedData.MiddleBalanceAngleArr180_2;

                            _receivedData.BeginUnbalanceSensorArr180_2.RemoveAt(0);
                            _receivedData.BeginUnbalanceSensorArr180_2.Add(controllerData.BeginUnbalanceSensor);
                            _calculator.BeginUnbalanceSensorArr180_2 = _receivedData.BeginUnbalanceSensorArr180_2;

                            _receivedData.MiddleUnbalanceSensorArr180_2.RemoveAt(0);
                            _receivedData.MiddleUnbalanceSensorArr180_2.Add(controllerData.MiddleUnbalanceSensor);
                            _calculator.MiddleUnbalanceSensorArr180_2 = _receivedData.MiddleUnbalanceSensorArr180_2;

                            _calculator.ProductAngle(_calculator.BeginBalanceAngleArr180_2, _calculator.MiddleBalanceAngleArr180_2, _calculator.BeginUnbalanceSensorArr180_2, _calculator.MiddleUnbalanceSensorArr180_2);
                        }
                    }
                    break;

                case 270:
                    if (_receivedData.beginBalanceAngleArr270.Count() < _maxReceivedData && _receivedData.MiddleBalanceAngleArr270.Count() < _maxReceivedData &&
                       _receivedData.BeginUnbalanceSensorArr270.Count() < _maxReceivedData && _receivedData.MiddleUnbalanceSensorArr270.Count() < _maxReceivedData)
                    {
                        _receivedData.beginBalanceAngleArr270.Add(controllerData.BeginBalanceAngle);
                        _receivedData.MiddleBalanceAngleArr270.Add(controllerData.MiddleBalanceAngle);
                        _receivedData.BeginUnbalanceSensorArr270.Add(controllerData.BeginUnbalanceSensor);
                        _receivedData.MiddleUnbalanceSensorArr270.Add(controllerData.MiddleUnbalanceSensor);
                    }
                    else
                    {
                        _receivedData.beginBalanceAngleArr270.RemoveAt(0);
                        _receivedData.beginBalanceAngleArr270.Add(controllerData.BeginBalanceAngle);
                        _calculator.BeginBalanceAngleArr270 = _receivedData.beginBalanceAngleArr270;

                        _receivedData.MiddleBalanceAngleArr270.RemoveAt(0);
                        _receivedData.MiddleBalanceAngleArr270.Add(controllerData.MiddleBalanceAngle);
                        _calculator.MiddleBalanceAngleArr270 = _receivedData.MiddleBalanceAngleArr270;

                        _receivedData.BeginUnbalanceSensorArr270.RemoveAt(0);
                        _receivedData.BeginUnbalanceSensorArr270.Add(controllerData.BeginUnbalanceSensor);
                        _calculator.BeginUnbalanceSensorArr270 = _receivedData.BeginUnbalanceSensorArr270;

                        _receivedData.MiddleUnbalanceSensorArr270.RemoveAt(0);
                        _receivedData.MiddleUnbalanceSensorArr270.Add(controllerData.MiddleUnbalanceSensor);
                        _calculator.MiddleUnbalanceSensorArr270 = _receivedData.MiddleUnbalanceSensorArr270;

                        _calculator.ProductAngle(_calculator.BeginBalanceAngleArr270, _calculator.MiddleBalanceAngleArr270, _calculator.BeginUnbalanceSensorArr270, _calculator.MiddleUnbalanceSensorArr270);
                    }
                    break;
            }

            if(_calculator.BeginBalanceAngleArr0.Count() == 10)
            {
                calc.Angel_0 = true;
            }
            if (_calculator.BeginBalanceAngleArr90.Count() == 10)
            {
                calc.Angel_90 = true;
            }
            if (_calculator.BeginBalanceAngleArr180.Count() == 10)
            {
                calc.Angel_180 = true;
            }
            if (_calculator.BeginBalanceAngleArr270.Count() == 10)
            {
                calc.Angel_270 = true;
            }
            if (_calculator.BeginBalanceAngleArr0_2.Count() == 10)
            {
                calc.Angel_0_2 = true;
            }
            if (_calculator.BeginBalanceAngleArr180_2.Count() == 10)
            {
                calc.Angel_180_2 = true;
            }

            if (calc.Angel_0 == true && calc.Angel_90 == true && calc.Angel_180 == true && calc.Angel_270 == true && 
                calc.Angel_0_2 == true && calc.Angel_180_2 == true)
            {
                _angel = true;
            }

            if(_angel == true && _nsp == true)
            {
                _calculator.SumValue();
                _calculator.AngleNot();
                _calculator.Computation_ma();
                _calculator.Computation_mm();
                _calculator.CalcRefAngle_ma();
                _calculator.CalcRefAngle_mm();
                _calculator.TranslatVal();
                _calculator.Balanse_tg();
                _calculator.WorkList1();
                _calculator.WorkList2();
                _calculator.NSP();
                _dataProvider?.SendData(GetCalculatedData());
            }
            
        }
        public void SetPassportData(PassportData passportData)
        {
            Console.WriteLine("{0} : Получены новые паспортные данные", _name);
            //_receivedData.ClearAllData();
            _receivedData.PassportData = passportData;
            
        }
        public CalculatedData GetCalculatedData()
        {
            Console.WriteLine("{0} : Выданы расчитанные данные", _name);
            return _calculator.calcData;
            
        }
        public void SetNSPData(NSPData nspData)
        {
            Console.WriteLine("{0} : Получены новые НСП данные", _name);
            _nsp = true;
            _receivedData.NSPData = nspData;
        }

        public void SetDataProvider(CalcDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }
    }
}
