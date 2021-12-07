using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using GravityCalc;

namespace GravityData
{
    /// <summary>
    /// Эмулятор для проверки расчетов в GravityCalc
    /// </summary>
    public class Emulator
    {
            //обновление данных
            public int UpdateDataValue { get; set; } = 1; //сек
        //провайдер данных
        private DataProvider _dataProvider = null;
        private ICalculator _mainCalc = null;
        //private CalcDataReporter _calcDataReporter;
        private PassportData _passportData;
        private bool _stop = false;
        private static AutoResetEvent _generateDataEvent = new (true);


        public void SetCalcFunc(ICalculator mainCalc)
        {
            _mainCalc = mainCalc;
        }
        public void SetPassportData(PassportData passportData)
        {
            _passportData = passportData;
        }
        public void SetDataProvider(DataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }


        public void Start()
        {
            Thread thread = new (new ThreadStart(GenerateDataProc));

            thread.Start();

        }
        public void Stop()
        {
            _stop = true;
        }
            void GenerateDataProc()
            {
                if (_dataProvider == null)
                {
                    Console.WriteLine("Ошибка: DataProvider не установлен!");
                    return;
                }

                _generateDataEvent.WaitOne();

                //_calcDataReporter = new();
                //_calcDataReporter.SetCalcFunc(_mainCalc);
                //_calcDataReporter.Subscribe(_dataProvider);

                while (!_stop)
                {
                    switch (_passportData.Fi)
                    {
                          case 0:
                                if (_passportData.Cargo == true)
                                {
                                    _dataProvider.SendData(new ControllerDataOut
                                    {
                                        //BeginBalanceAngle = 8.4 + (new Random().Next(0, 9) / 1000.0),
                                        //MiddleBalanceAngle = 8.4 + (new Random().Next(0, 9) / 1000.0),
                                        //BeginDisbalanceSensor = 350 + (new Random().Next(1, 650)),
                                        //MiddleDisbalanceSensor = 1600 + (new Random().Next(50, 700)),
                                    });
                                }
                                else
                                {
                                    _dataProvider.SendData(new ControllerDataOut
                                    {
                                        //BeginBalanceAngle = 5.9 + (new Random().Next(0, 9) / 1000.0),
                                        //MiddleBalanceAngle = 5.9 + (new Random().Next(0, 9) / 1000.0),
                                        //BeginUnbalanceSensor = 250 + (new Random().Next(1, 650)),
                                        //MiddleUnbalanceSensor = 1600 + (new Random().Next(50, 700)),
                                        //IndicationK = 1,
                                        //BeginPowerSensor = 1,
                                        //MiddlePowerSensor = 1,
                                    });
                                }
                            break;

                      case 90:
                            if (_passportData.Cargo == true)
                            {
                                _dataProvider.SendData(new ControllerData
                                {
                                    BeginBalanceAngle = 8.4 + (new Random().Next(0, 9) / 1000.0),
                                    MiddleBalanceAngle = 8.4 + (new Random().Next(0, 9) / 1000.0),
                                    BeginUnbalanceSensor = 350 + (new Random().Next(1, 650)),
                                    MiddleUnbalanceSensor = 1600 + (new Random().Next(50, 700)),
                                    K1 = 1,
                                    K2 = 1,
                                    P1 = 1,
                                    P2 = 1,
                                });
                            }
                        break;

                    case 180:
                            if (_passportData.Cargo == true)
                            {
                                _dataProvider.SendData(new ControllerData
                                {
                                    BeginBalanceAngle = 8.4 + (new Random().Next(0, 9) / 1000.0),
                                    MiddleBalanceAngle = 8.4 + (new Random().Next(0, 9) / 1000.0),
                                    BeginUnbalanceSensor = 350 + (new Random().Next(1, 650)),
                                    MiddleUnbalanceSensor = 1600 + (new Random().Next(50, 700)),
                                    K1 = 1,
                                    K2 = 1,
                                    P1 = 1,
                                    P2 = 1,
                                });
                                break;
                            }
                            else
                            {
                                _dataProvider.SendData(new ControllerData
                                {
                                    BeginBalanceAngle = 5.9 + (new Random().Next(0, 9) / 1000.0),
                                    MiddleBalanceAngle = 5.9 + (new Random().Next(0, 9) / 1000.0),
                                    BeginUnbalanceSensor = 150 + (new Random().Next(1, 650)),
                                    MiddleUnbalanceSensor = 1600 + (new Random().Next(50, 700)),
                                    K1 = 1,
                                    K2 = 1,
                                    P1 = 1,
                                    P2 = 1,
                                });
                            }
                        break;

                    case 270:
                          if (_passportData.Cargo == true)
                          {
                                _dataProvider.SendData(new ControllerData
                                {
                                    BeginBalanceAngle = 8.4 + (new Random().Next(0, 9) / 1000.0),
                                    MiddleBalanceAngle = 8.4 + (new Random().Next(0, 9) / 1000.0),
                                    BeginUnbalanceSensor = 350 + (new Random().Next(1, 650)),
                                    MiddleUnbalanceSensor = 1600 + (new Random().Next(50, 700)),
                                    K1 = 1,
                                    K2 = 1,
                                    P1 = 1,
                                    P2 = 1,
                                });
                          }
                        break;
                }
                Thread.Sleep(1000 * UpdateDataValue);
            }
            _generateDataEvent.Set();
        }
    }
}
