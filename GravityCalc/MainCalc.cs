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
        private CalculatedData _calculatedData;                     //рассчитанные данные
        private readonly string _name = "Калькулятор";
        private CalcDataProvider _dataProvider = null;
        bool _angel = false;
        bool _nsp = false;
        bool _recomVal = false;
        bool _controllerIn = false;
        /// <summary>
        /// Максимальное количество получаемых данных (для расчёта)
        /// </summary>
        private const ushort _maxReceivedData = 10;

        public MainCalc()
        {
            _receivedData = new();
            _calculator = new(_receivedData);
           
        }
        public void SetControllerData(ControllerDataOut controllerData)
        {
            //Console.WriteLine("{0} : Получены новые данные от контроллера", _name);
            _receivedData.ControllerDataOut = controllerData;

            //if ( кнопка Снять показания == true) - в конце выполнения - кнопка Снять показания == false (отключает себя )
            switch (_receivedData.PassportData.Fi)
            {
                case 0:
                    if(_receivedData.PassportData.Cargo == true)
                    {
                        if (_receivedData.BeginBalanceAngleArr0.Count() < _maxReceivedData && _receivedData.MiddleBalanceAngleArr0.Count() < _maxReceivedData &&
                            _receivedData.BeginUnbalanceSensorArr0.Count() < _maxReceivedData && _receivedData.MiddleUnbalanceSensorArr0.Count() < _maxReceivedData)
                        {
                            _receivedData.BeginBalanceAngleArr0.Add(controllerData.BeginBalanceAngle);
                            _receivedData.MiddleBalanceAngleArr0.Add(controllerData.MiddleBalanceAngle);
                            _receivedData.BeginUnbalanceSensorArr0.Add(controllerData.BeginUnbalanceSensor);
                            _receivedData.MiddleUnbalanceSensorArr0.Add(controllerData.MiddleUnbalanceSensor);
                        }
                        else
                        {
                            _receivedData.BeginBalanceAngleArr0.RemoveAt(0);
                            _receivedData.BeginBalanceAngleArr0.Add(controllerData.BeginBalanceAngle);
                            _calculator.BeginBalanceAngleArr0 = _receivedData.BeginBalanceAngleArr0;

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
                        if (_receivedData.Pnom0.Count() < _maxReceivedData && _receivedData.Paver0.Count() < _maxReceivedData &&
                            _receivedData.Knom0.Count() < _maxReceivedData && _receivedData.Kaver0.Count() < _maxReceivedData)
                    {
                        _receivedData.Pnom0.Add(controllerData.BeginPowerSensor);
                        _receivedData.Paver0.Add(controllerData.MiddlePowerSensor);
                        _receivedData.Knom0.Add(controllerData.Knom);
                        _receivedData.Kaver0.Add(controllerData.Kaver);
                    }
                    else
                    {
                        _receivedData.Pnom0.RemoveAt(0);
                        _receivedData.Pnom0.Add(controllerData.BeginPowerSensor);
                        _calculator.Pnom0 = _receivedData.Pnom0;

                        _receivedData.Paver0.RemoveAt(0);
                        _receivedData.Paver0.Add(controllerData.MiddlePowerSensor);
                        _calculator.Paver0 = _receivedData.Paver0;

                        _receivedData.Knom0.RemoveAt(0);
                        _receivedData.Knom0.Add(controllerData.Knom);
                        _calculator.Knom0 = _receivedData.Knom0;

                        _receivedData.Kaver0.RemoveAt(0);
                        _receivedData.Kaver0.Add(controllerData.Kaver);
                        _calculator.Kaver0 = _receivedData.Kaver0;

                    }

                    break;

                case 90:
                    if (_receivedData.BeginBalanceAngleArr90.Count() < _maxReceivedData && _receivedData.MiddleBalanceAngleArr90.Count() < _maxReceivedData &&
                       _receivedData.BeginUnbalanceSensorArr90.Count() < _maxReceivedData && _receivedData.MiddleUnbalanceSensorArr90.Count() < _maxReceivedData)
                    {
                        _receivedData.BeginBalanceAngleArr90.Add(controllerData.BeginBalanceAngle);
                        _receivedData.MiddleBalanceAngleArr90.Add(controllerData.MiddleBalanceAngle);
                        _receivedData.BeginUnbalanceSensorArr90.Add(controllerData.BeginUnbalanceSensor);
                        _receivedData.MiddleUnbalanceSensorArr90.Add(controllerData.MiddleUnbalanceSensor);
                    }
                    else
                    {
                        _receivedData.BeginBalanceAngleArr90.RemoveAt(0);
                        _receivedData.BeginBalanceAngleArr90.Add(controllerData.BeginBalanceAngle);
                        _calculator.BeginBalanceAngleArr90 = _receivedData.BeginBalanceAngleArr90;

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
                        if (_receivedData.BeginBalanceAngleArr180.Count() < _maxReceivedData && _receivedData.MiddleBalanceAngleArr180.Count() < _maxReceivedData &&
                           _receivedData.BeginUnbalanceSensorArr180.Count() < _maxReceivedData && _receivedData.MiddleUnbalanceSensorArr180.Count() < _maxReceivedData)
                        {
                            _receivedData.BeginBalanceAngleArr180.Add(controllerData.BeginBalanceAngle);
                            _receivedData.MiddleBalanceAngleArr180.Add(controllerData.MiddleBalanceAngle);
                            _receivedData.BeginUnbalanceSensorArr180.Add(controllerData.BeginUnbalanceSensor);
                            _receivedData.MiddleUnbalanceSensorArr180.Add(controllerData.MiddleUnbalanceSensor);
                        }
                        else
                        {
                            _receivedData.BeginBalanceAngleArr180.RemoveAt(0);
                            _receivedData.BeginBalanceAngleArr180.Add(controllerData.BeginBalanceAngle);
                            _calculator.BeginBalanceAngleArr180 = _receivedData.BeginBalanceAngleArr180;

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
                        if (_receivedData.Pnom180.Count() < _maxReceivedData && _receivedData.Paver180.Count() < _maxReceivedData &&
                           _receivedData.Knom180.Count() < _maxReceivedData && _receivedData.Kaver180.Count() < _maxReceivedData)
                        {
                            _receivedData.Pnom180.Add(controllerData.BeginPowerSensor);
                            _receivedData.Paver180.Add(controllerData.MiddlePowerSensor);
                            _receivedData.Knom180.Add(controllerData.Knom);
                            _receivedData.Kaver180.Add(controllerData.Kaver);
                        }
                        else
                        {
                            _receivedData.Pnom180.RemoveAt(0);
                            _receivedData.Pnom180.Add(controllerData.BeginPowerSensor);
                            _calculator.Pnom180 = _receivedData.Pnom180;

                            _receivedData.Paver180.RemoveAt(0);
                            _receivedData.Paver180.Add(controllerData.MiddlePowerSensor);
                            _calculator.Paver180 = _receivedData.Paver180;

                            _receivedData.Knom180.RemoveAt(0);
                            _receivedData.Knom180.Add(controllerData.Knom);
                            _calculator.Knom180 = _receivedData.Knom180;

                            _receivedData.Kaver180.RemoveAt(0);
                            _receivedData.Kaver180.Add(controllerData.Kaver);
                            _calculator.Kaver180 = _receivedData.Kaver180;

                        }
                    }
                    break;

                case 270:
                    if (_receivedData.BeginBalanceAngleArr270.Count() < _maxReceivedData && _receivedData.MiddleBalanceAngleArr270.Count() < _maxReceivedData &&
                       _receivedData.BeginUnbalanceSensorArr270.Count() < _maxReceivedData && _receivedData.MiddleUnbalanceSensorArr270.Count() < _maxReceivedData)
                    {
                        _receivedData.BeginBalanceAngleArr270.Add(controllerData.BeginBalanceAngle);
                        _receivedData.MiddleBalanceAngleArr270.Add(controllerData.MiddleBalanceAngle);
                        _receivedData.BeginUnbalanceSensorArr270.Add(controllerData.BeginUnbalanceSensor);
                        _receivedData.MiddleUnbalanceSensorArr270.Add(controllerData.MiddleUnbalanceSensor);
                    }
                    else
                    {
                        _receivedData.BeginBalanceAngleArr270.RemoveAt(0);
                        _receivedData.BeginBalanceAngleArr270.Add(controllerData.BeginBalanceAngle);
                        _calculator.BeginBalanceAngleArr270 = _receivedData.BeginBalanceAngleArr270;

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
                _calculatedData.Angel_0 = true;
            }
            if (_calculator.BeginBalanceAngleArr90.Count() == 10)
            {
                _calculatedData.Angel_90 = true;
            }
            if (_calculator.BeginBalanceAngleArr180.Count() == 10)
            {
                _calculatedData.Angel_180 = true;
            }
            if (_calculator.BeginBalanceAngleArr270.Count() == 10)
            {
                _calculatedData.Angel_270 = true;
            }
            if (_calculator.Knom0.Count() == 10)
            {
                _calculatedData.Angel_0_2 = true;
            }
            if (_calculator.Knom180.Count() == 10)
            {
                _calculatedData.Angel_180_2 = true;
            }

            if (_calculatedData.Angel_0 == true && _calculatedData.Angel_90 == true && _calculatedData.Angel_180 == true && _calculatedData.Angel_270 == true && 
                _calculatedData.Angel_0_2 == true && _calculatedData.Angel_180_2 == true)
            {
                _angel = true;
            }

            if(_angel == true && _nsp == true  )
            {
                if ( _receivedData.PassportData.KP == true)
                {
                    _calculator.SumValue();
                    _calculator.AngleNot();
                    _calculator.Computation_ma();
                    _calculator.Computation_mm();
                    _calculator.CalcRefAngle_ma();
                    _calculator.CalcRefAngle_mm();
                    _calculator.Massa();
                    _calculator.TranslatVal();
                    _calculator.Balanse_tg();
                    _calculator.WorkList1();
                    _calculator.WorkList2();
                    _calculator.NSP();
                    _calculator.KP();
                    _dataProvider?.SendData(GetCalculatedData());
                }
                else
                {
                    _calculator.SumValue();
                    _calculator.AngleNot();
                    _calculator.Computation_ma();
                    _calculator.Computation_mm();
                    _calculator.CalcRefAngle_ma();
                    _calculator.CalcRefAngle_mm();
                    _calculator.Massa();
                    _calculator.TranslatVal();
                    _calculator.Balanse_tg();
                    _calculator.WorkList1();
                    _calculator.WorkList2();
                    _calculator.NSP();
                    Console.WriteLine("Контрольное приспособление не используется");
                    _dataProvider?.SendData(GetCalculatedData());

                }
            }


        }
        public void SetPassportData(PassportData passportData)
        {
           // Console.WriteLine("{0} : Получены новые паспортные данные", _name);
            //_receivedData.ClearAllData();
            _receivedData.PassportData = passportData;
            
        }
        public CalculatedData GetCalculatedData()
        {
           // Console.WriteLine("{0} : Выданы расчитанные данные", _name);
            return _calculator.calcData;
            
        }
        public void SetNSPData(NSPData nspData)
        {
            //Console.WriteLine("{0} : Получены новые НСП данные", _name);
            _nsp = true;
            _receivedData.NSPData = nspData;
        }

        public void SetRecomValData(RecomValData recomValData)
        {
           // Console.WriteLine("{0} : Получены новые рекмоендуемые данные", _name);
            _recomVal = true;
            _receivedData.RecomValData = recomValData;
        }
        public void SetControllerDataIn(ControllerDataIn сontrollerDataIn)
        {
            //Console.WriteLine("{0} : Получены новые данные с контроллера", _name);
            _controllerIn = true;
            _receivedData.ControllerDataIn = сontrollerDataIn;
        }

        public void SetDataProvider(CalcDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }
    }
}
