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
        private Сalculator _calculator;
        private readonly string _name = "Калькулятор";
        private CalcDataProvider _dataProvider = null;
        bool _angel = false;
        bool _nsp = false;
        bool _recomVal = false;
        bool _controllerIn = false;
        bool _pd = false;

        /// <summary>
        /// Максимальное количество получаемых данных (для расчёта)
        /// </summary>
        private const ushort _maxReceivedData = 10;
        private bool firstHalfofArrays = false;                     //заполнять первую половину массивов
        private bool startSaveArrays = false;                         //начать заполнять массивы

        public MainCalc()
        {
            _calculator = new();
           
        }

        public void SetRecomValData(RecomValData recomValData)
        {
            // Console.WriteLine("{0} : Получены новые рекмоендуемые данные", _name);
            _recomVal = true;
            _calculator.receivedData.RecomValData = recomValData;
            if (_recomVal == true)
            {
                _calculator.SumValue();
                _calculator.AngleNot();
                _calculator.Computation_mm();
                _calculator.Computation_ma();
                _calculator.CalcRefAngle_mm();
                _calculator.CalcRefAngle_mm();
            }
        }


        public void SetControllerData(ControllerDataOut controllerData)
        {
            if (startSaveArrays)
            {
                switch (_calculator.receivedData.MeasurementData.Fi) 
                {
                    case 0:
                        if (_calculator.receivedData.MeasurementData.findCoordMass == true)
                        {
                            if(firstHalfofArrays) //первая половина массивов
                            {
                                if (_calculator.calcData.BeginBalanceAngleArr0.Count() < _maxReceivedData && //заполняем массивы
                                    _calculator.calcData.BeginDisbalanceSensorArr0.Count() < _maxReceivedData)
                                {
                                    _calculator.calcData.BeginBalanceAngleArr0.Add(controllerData.SensorAngle);
                                    _calculator.calcData.BeginDisbalanceSensorArr0.Add(controllerData.SensorDisbalance);
                                    _calculator.calcData.kcmAngel_0 = 0; // массивы не заполнены
                                    _calculator.calcData.ArraysAreFilling = true;
                                }
                                else
                                {
                                    _calculator.calcData.kcmAngel_0 = 1; //массивы заполнены наполовину
                                    _calculator.calcData.ArraysAreFilling = false;
                                }
                            }
                            else //вторая половина массивов
                            {
                                if (_calculator.calcData.MiddleBalanceAngleArr0.Count() < _maxReceivedData &&
                                    _calculator.calcData.MiddleDisbalanceSensorArr0.Count() < _maxReceivedData)
                                {
                                    _calculator.calcData.MiddleBalanceAngleArr0.Add(controllerData.SensorAngle);
                                    _calculator.calcData.MiddleDisbalanceSensorArr0.Add(controllerData.SensorDisbalance);

                                    _calculator.calcData.ArraysAreFilling = true;
                                }
                                else
                                {
                                    _calculator.calcData.kcmAngel_0 = 2; //массивы заполнены полностью

                                    _calculator.calcData.ArraysAreFilling = false;
                                }
                            }
                        }
                        else
                        {
                             if(firstHalfofArrays) //первая половина массивов
                            {
                                if (_calculator.calcData.BeginPowerSensor0.Count() < _maxReceivedData && //заполняем массивы
                                    _calculator.calcData.BeginIndicationK0.Count() < _maxReceivedData)
                                {
                                    _calculator.calcData.BeginPowerSensor0.Add(controllerData.SensorPower);
                                    _calculator.calcData.BeginIndicationK0.Add(controllerData.IndicationK);
                                    _calculator.calcData.mAngel_0 = 0; // массивы не заполнены
                                    _calculator.calcData.ArraysAreFilling = true;
                                }
                                else
                                {
                                    _calculator.calcData.mAngel_0 = 1; //массивы заполнены наполовину
                                    _calculator.calcData.ArraysAreFilling = false;
                                }
                            }
                            else //вторая половина массивов
                            {
                                if (_calculator.calcData.MiddlePowerSensor0.Count() < _maxReceivedData &&
                                    _calculator.calcData.MiddleIndicationK0.Count() < _maxReceivedData)
                                {
                                    _calculator.calcData.MiddlePowerSensor0.Add(controllerData.SensorPower);
                                    _calculator.calcData.MiddleIndicationK0.Add(controllerData.IndicationK);

                                    _calculator.calcData.ArraysAreFilling = true;
                                }
                                else
                                {
                                    _calculator.calcData.mAngel_0 = 2; //массивы заполнены полностью

                                    _calculator.calcData.ArraysAreFilling = false;
                                }
                            }
                        }

                        break;
                    case 90:
                        if (_calculator.receivedData.MeasurementData.findCoordMass == true)
                        {
                            if (firstHalfofArrays) //первая половина массивов
                            {
                                if (_calculator.calcData.BeginBalanceAngleArr90.Count() < _maxReceivedData && //заполняем массивы
                                    _calculator.calcData.BeginDisbalanceSensorArr90.Count() < _maxReceivedData)
                                {
                                    _calculator.calcData.BeginBalanceAngleArr90.Add(controllerData.SensorAngle);
                                    _calculator.calcData.BeginDisbalanceSensorArr90.Add(controllerData.SensorDisbalance);
                                    _calculator.calcData.kcmAngel_90 = 0; // массивы не заполнены
                                    _calculator.calcData.ArraysAreFilling = true;
                                }
                                else
                                {
                                    _calculator.calcData.kcmAngel_90 = 1; //массивы заполнены наполовину
                                    _calculator.calcData.ArraysAreFilling = false;
                                }
                            }
                            else //вторая половина массивов
                            {
                                if (_calculator.calcData.MiddleBalanceAngleArr90.Count() < _maxReceivedData &&
                                    _calculator.calcData.MiddleDisbalanceSensorArr90.Count() < _maxReceivedData)
                                {
                                    _calculator.calcData.MiddleBalanceAngleArr90.Add(controllerData.SensorAngle);
                                    _calculator.calcData.MiddleDisbalanceSensorArr90.Add(controllerData.SensorDisbalance);

                                    _calculator.calcData.ArraysAreFilling = true;
                                }
                                else
                                {
                                    _calculator.calcData.kcmAngel_90 = 2; //массивы заполнены полностью

                                    _calculator.calcData.ArraysAreFilling = false;
                                }
                            }
                        }
                        break;
                    case 180:
                        if (_calculator.receivedData.MeasurementData.findCoordMass == true)
                        {
                            if (firstHalfofArrays) //первая половина массивов
                            {
                                if (_calculator.calcData.BeginBalanceAngleArr180.Count() < _maxReceivedData && //заполняем массивы
                                    _calculator.calcData.BeginDisbalanceSensorArr180.Count() < _maxReceivedData)
                                {
                                    _calculator.calcData.BeginBalanceAngleArr180.Add(controllerData.SensorAngle);
                                    _calculator.calcData.BeginDisbalanceSensorArr180.Add(controllerData.SensorDisbalance);
                                    _calculator.calcData.kcmAngel_180 = 0; // массивы не заполнены
                                    _calculator.calcData.ArraysAreFilling = true;
                                }
                                else
                                {
                                    _calculator.calcData.kcmAngel_180 = 1; //массивы заполнены наполовину
                                    _calculator.calcData.ArraysAreFilling = false;
                                }
                            }
                            else //вторая половина массивов
                            {
                                if (_calculator.calcData.MiddleBalanceAngleArr180.Count() < _maxReceivedData &&
                                    _calculator.calcData.MiddleDisbalanceSensorArr180.Count() < _maxReceivedData)
                                {
                                    _calculator.calcData.MiddleBalanceAngleArr180.Add(controllerData.SensorAngle);
                                    _calculator.calcData.MiddleDisbalanceSensorArr180.Add(controllerData.SensorDisbalance);

                                    _calculator.calcData.ArraysAreFilling = true;
                                }
                                else
                                {
                                    _calculator.calcData.kcmAngel_180 = 2; //массивы заполнены полностью

                                    _calculator.calcData.ArraysAreFilling = false;
                                }
                            }
                        }
                        else
                        {
                            if (firstHalfofArrays) //первая половина массивов
                            {
                                if (_calculator.calcData.BeginPowerSensor180.Count() < _maxReceivedData && //заполняем массивы
                                    _calculator.calcData.BeginIndicationK180.Count() < _maxReceivedData)
                                {
                                    _calculator.calcData.BeginPowerSensor180.Add(controllerData.SensorPower);
                                    _calculator.calcData.BeginIndicationK180.Add(controllerData.IndicationK);
                                    _calculator.calcData.mAngel_180 = 0; // массивы не заполнены
                                    _calculator.calcData.ArraysAreFilling = true;
                                }
                                else
                                {
                                    _calculator.calcData.mAngel_180 = 1; //массивы заполнены наполовину
                                    _calculator.calcData.ArraysAreFilling = false;
                                }
                            }
                            else //вторая половина массивов
                            {
                                if (_calculator.calcData.MiddlePowerSensor180.Count() < _maxReceivedData &&
                                    _calculator.calcData.MiddleIndicationK180.Count() < _maxReceivedData)
                                {
                                    _calculator.calcData.MiddlePowerSensor180.Add(controllerData.SensorPower);
                                    _calculator.calcData.MiddleIndicationK180.Add(controllerData.IndicationK);

                                    _calculator.calcData.ArraysAreFilling = true;
                                }
                                else
                                {
                                    _calculator.calcData.mAngel_180 = 2; //массивы заполнены полностью

                                    _calculator.calcData.ArraysAreFilling = false;
                                }
                            }
                        }
                        break;
                    case 270:
                        if (_calculator.receivedData.MeasurementData.findCoordMass == true)
                        {
                            if (firstHalfofArrays) //первая половина массивов
                            {
                                if (_calculator.calcData.BeginBalanceAngleArr270.Count() < _maxReceivedData && //заполняем массивы
                                    _calculator.calcData.BeginDisbalanceSensorArr270.Count() < _maxReceivedData)
                                {
                                    _calculator.calcData.BeginBalanceAngleArr270.Add(controllerData.SensorAngle);
                                    _calculator.calcData.BeginDisbalanceSensorArr270.Add(controllerData.SensorDisbalance);
                                    _calculator.calcData.kcmAngel_270 = 0; // массивы не заполнены
                                    _calculator.calcData.ArraysAreFilling = true;
                                }
                                else
                                {
                                    _calculator.calcData.kcmAngel_270 = 1; //массивы заполнены наполовину
                                    _calculator.calcData.ArraysAreFilling = false;
                                }
                            }
                            else //вторая половина массивов
                            {
                                if (_calculator.calcData.MiddleBalanceAngleArr270.Count() < _maxReceivedData &&
                                    _calculator.calcData.MiddleDisbalanceSensorArr270.Count() < _maxReceivedData)
                                {
                                    _calculator.calcData.MiddleBalanceAngleArr270.Add(controllerData.SensorAngle);
                                    _calculator.calcData.MiddleDisbalanceSensorArr270.Add(controllerData.SensorDisbalance);

                                    _calculator.calcData.ArraysAreFilling = true;
                                }
                                else
                                {
                                    _calculator.calcData.kcmAngel_270 = 2; //массивы заполнены полностью

                                    _calculator.calcData.ArraysAreFilling = false;
                                }
                            }
                        }
                        break;
                }
                _dataProvider?.SendData(GetCalculatedData());
                //if (_calculator.calcData.kcmAngel_0 == 2)
                  //  startSaveArrays = false;


            }
            if (_calculator.calcData.kcmAngel_0 == 2 && _calculator.calcData.kcmAngel_90 == 2 && _calculator.calcData.kcmAngel_180 == 2 && _calculator.calcData.kcmAngel_270 == 2
            /*&& _calculator.calcData.mAngel_0 == 2 && _calculator.calcData.mAngel_180 == 2*/)
            {
                _calculator.calcData.AllAngelFilling = true;
            }          
        }


        //расчет, после расчета надо сделать startSaveArrays = false



        //    if(_angel == true && _nsp == true  )
        //    {
        //        if ( _receivedData.PassportData.KP == true)
        //        {
        //            _calculator.SumValue();
        //            _calculator.AngleNot();
        //            _calculator.Computation_ma();
        //            _calculator.Computation_mm();
        //            _calculator.CalcRefAngle_ma();
        //            _calculator.CalcRefAngle_mm();
        //            _calculator.Massa();
        //            _calculator.TranslatVal();
        //            _calculator.Balanse_tg();
        //            _calculator.WorkList1();
        //            _calculator.WorkList2();
        //            _calculator.NSP();
        //            _calculator.KP();
        //            _dataProvider?.SendData(GetCalculatedData());
        //        }
        //        else
        //        {
        //            _calculator.SumValue();
        //            _calculator.AngleNot();
        //            _calculator.Computation_ma();
        //            _calculator.Computation_mm();
        //            _calculator.CalcRefAngle_ma();
        //            _calculator.CalcRefAngle_mm();
        //            _calculator.Massa();
        //            _calculator.TranslatVal();
        //            _calculator.Balanse_tg();
        //            _calculator.WorkList1();
        //            _calculator.WorkList2();
        //            _calculator.NSP();
        //            Console.WriteLine("Контрольное приспособление не используется");
        //            _dataProvider?.SendData(GetCalculatedData());

        //        }
        //    }


        //}
        public void SetPassportData(PassportData passportData)
        {
            // Console.WriteLine("{0} : Получены новые паспортные данные", _name);
            //_receivedData.ClearAllData();
            _calculator.receivedData.PassportData = passportData;
            _pd = true;
            
        }
        public void SetMeasurementData(MeasurementDataOut measurementData)
        {
            _calculator.receivedData.MeasurementData = measurementData;


            if (measurementData.CalculationCalc) //расчет
            {              
                if (_calculator.receivedData.MeasurementData.KP == false)
                {
                    if (_calculator.calcData.AllAngelFilling == true && _nsp == true && _pd == true)
                    {
                        startSaveArrays = false;
                        _calculator.calcData.AllAngelFilling = false;
                        _dataProvider?.SendData(GetCalculatedData());
                    }
                }
                else
                {
                    if (_calculator.calcData.AllAngelFilling == true && _nsp == true && _pd == true)
                    {
                        startSaveArrays = false;
                        _calculator.calcData.AllAngelFilling = false;
                        _dataProvider?.SendData(GetCalculatedData());
                    }
                }
            }
            else //снять измерения
            {
                startSaveArrays = true;

                switch (_calculator.receivedData.MeasurementData.Fi)
                {
                    case 0:
                        if (_calculator.calcData.BeginBalanceAngleArr0.Count() == _maxReceivedData &&
                            _calculator.calcData.MiddleBalanceAngleArr0.Count() == _maxReceivedData &&
                            _calculator.calcData.BeginDisbalanceSensorArr0.Count() == _maxReceivedData &&
                            _calculator.calcData.MiddleDisbalanceSensorArr0.Count() == _maxReceivedData
                            )
                        {
                            _calculator.calcData.BeginBalanceAngleArr0.Clear();
                            _calculator.calcData.MiddleBalanceAngleArr0.Clear();
                            _calculator.calcData.BeginDisbalanceSensorArr0.Clear();
                            _calculator.calcData.MiddleDisbalanceSensorArr0.Clear();

                            firstHalfofArrays = true;
                        }
                        else if (_calculator.calcData.BeginBalanceAngleArr0.Count() == _maxReceivedData &&
                            _calculator.calcData.BeginDisbalanceSensorArr0.Count() == _maxReceivedData
                            )
                        {
                            firstHalfofArrays = false;
                        }
                        else
                            firstHalfofArrays = true;
                        break;
                    case 90:
                        if (_calculator.calcData.BeginBalanceAngleArr90.Count() == _maxReceivedData &&
                            _calculator.calcData.MiddleBalanceAngleArr90.Count() == _maxReceivedData &&
                            _calculator.calcData.BeginDisbalanceSensorArr90.Count() == _maxReceivedData &&
                            _calculator.calcData.MiddleDisbalanceSensorArr90.Count() == _maxReceivedData
                            )
                        {
                            _calculator.calcData.BeginBalanceAngleArr90.Clear();
                            _calculator.calcData.MiddleBalanceAngleArr90.Clear();
                            _calculator.calcData.BeginDisbalanceSensorArr90.Clear();
                            _calculator.calcData.MiddleDisbalanceSensorArr90.Clear();

                            firstHalfofArrays = true;
                        }
                        else if (_calculator.calcData.BeginBalanceAngleArr90.Count() == _maxReceivedData &&
                            _calculator.calcData.BeginDisbalanceSensorArr90.Count() == _maxReceivedData
                            )
                        {
                            firstHalfofArrays = false;
                        }
                        else
                            firstHalfofArrays = true;
                        break;
                    case 180:
                        if (_calculator.calcData.BeginBalanceAngleArr180.Count() == _maxReceivedData &&
                            _calculator.calcData.MiddleBalanceAngleArr180.Count() == _maxReceivedData &&
                            _calculator.calcData.BeginDisbalanceSensorArr180.Count() == _maxReceivedData &&
                            _calculator.calcData.MiddleDisbalanceSensorArr180.Count() == _maxReceivedData
                            )
                        {
                            _calculator.calcData.BeginBalanceAngleArr180.Clear();
                            _calculator.calcData.MiddleBalanceAngleArr180.Clear();
                            _calculator.calcData.BeginDisbalanceSensorArr180.Clear();
                            _calculator.calcData.MiddleDisbalanceSensorArr180.Clear();

                            firstHalfofArrays = true;
                        }
                        else if (_calculator.calcData.BeginBalanceAngleArr180.Count() == _maxReceivedData &&
                                 _calculator.calcData.BeginDisbalanceSensorArr180.Count() == _maxReceivedData
                             )
                        {
                            firstHalfofArrays = false;
                        }
                        else
                            firstHalfofArrays = true;
                        break;
                    case 270:
                        if (_calculator.calcData.BeginBalanceAngleArr270.Count() == _maxReceivedData &&
                            _calculator.calcData.MiddleBalanceAngleArr270.Count() == _maxReceivedData &&
                            _calculator.calcData.BeginDisbalanceSensorArr270.Count() == _maxReceivedData &&
                            _calculator.calcData.MiddleDisbalanceSensorArr270.Count() == _maxReceivedData
                            )
                        {
                            _calculator.calcData.BeginBalanceAngleArr270.Clear();
                            _calculator.calcData.MiddleBalanceAngleArr270.Clear();
                            _calculator.calcData.BeginDisbalanceSensorArr270.Clear();
                            _calculator.calcData.MiddleDisbalanceSensorArr270.Clear();

                            firstHalfofArrays = true;
                        }
                        else if (_calculator.calcData.BeginBalanceAngleArr270.Count() == _maxReceivedData &&
                                 _calculator.calcData.BeginDisbalanceSensorArr270.Count() == _maxReceivedData
                             )
                        {
                            firstHalfofArrays = false;
                        }
                        else
                            firstHalfofArrays = true;
                        break;
                }
            }
            

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
            _calculator.receivedData.NSPData = nspData;
        }
      
        public void SetControllerDataIn(ControllerDataIn сontrollerDataIn)
        {
            //Console.WriteLine("{0} : Получены новые данные с контроллера", _name);
            _controllerIn = true;
            _calculator.receivedData.ControllerDataIn = сontrollerDataIn;
        }

        public void SetDataProvider(CalcDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }
    }
}
