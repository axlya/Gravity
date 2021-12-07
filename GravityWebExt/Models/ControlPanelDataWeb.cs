using GravityCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GravityWebExt.Models
{
    /// <summary>
    /// Данные, получаемые с датчиков контроллера
    /// </summary>
    /// 
    public class ControlPanelDataWeb
    {
        public int Id { get; set; }
        ///// <summary>
        ///// Угол равновесия в начальной зоне
        ///// </summary>
        //public double BeginBalanceAngle { get; set; }
        ///// <summary>
        ///// Угол равновесия в средней зоне
        ///// </summary>
        //public double MiddleBalanceAngle { get; set; }
        ///// <summary>
        ///// Датчик дисбаланса в начальной зоне работы
        ///// </summary>
        //public double BeginUnbalanceSensor { get; set; } 
        ///// <summary>
        /////  Датчик дисбаланса в средней зоне работы
        ///// </summary>
        //public double MiddleUnbalanceSensor { get; set; }
        
        ///// <summary>
        ///// Датчик линейного пережвижения в среднем режиме работы
        ///// </summary
        //public double Kaver { get; set; }
        ///// <summary>
        ///// Датчик силы в начальной зоне работы
        ///// </summary>
        //public double BeginPowerSensor { get; set; }
        ///// <summary
        /////  Датчик силы в средней зоне работы
        ///// </summary>
        //public double MiddlePowerSensor { get; set; }


        public double JackSpeed { get; set; }

        /// <summary>
        /// Положение домкрата
        /// </summary>
        public double JackPos { get; set; }
        /// <summary>
        /// Положение подвижного груза
        /// </summary>
        public double CargoPos { get; set; }
        /// <summary>
        /// Связь с устройством
        /// </summary>
        public double ConnectDevice { get; set; }
        /// <summary>
        /// Включение\ Выключение системы
        /// </summary>
        public double PowerSystem { get; set; }
        /// <summary>
        /// Включение\Выключение двигателя трения №1
        /// </summary>
        public double OutFrictionMotor1 { get; set; }
        /// <summary>
        /// Включение\Выключение двигателя трения №2
        /// </summary>
        public double OutFrictionMotor2 { get; set; }
        /// <summary>
        /// Датчик угловых перемещений
        /// </summary>
        public double SensorAngle { get; set; }
        /// <summary>
        /// Датчик дисбаланса
        /// </summary>
        public double SensorDisbalance { get; set; }
        /// <summary>
        /// Датчик силы измеретильной головки
        /// </summary>
        public double SensorPower { get; set; }
        /// <summary>
        /// Датчик линейного передвижения в начальной зоны работы 
        /// </summary
        public double IndicationK { get; set; }
        /// <summary>
        /// Список ошибок
        /// </summary>
        public Dictionary<double, string> ErrorsList { get; set; }

        public ControlPanelDataWeb()
        {
        }
        public ControlPanelDataWeb(ControllerDataOut controllerData)
        {
            //BeginBalanceAngle = controllerData.BeginBalanceAngle;
            //MiddleBalanceAngle = controllerData.MiddleBalanceAngle;
            //BeginUnbalanceSensor = controllerData.BeginDisbalanceSensor;
            //MiddleUnbalanceSensor = controllerData.MiddleDisbalanceSensor;           
            //BeginPowerSensor = controllerData.BeginPowerSensor;
            //MiddlePowerSensor = controllerData.MiddlePowerSensor;
            
            JackPos = controllerData.JackPos;
            CargoPos = controllerData.CargoPos;
            ConnectDevice = controllerData.ConnectDevice;
            PowerSystem = controllerData.PowerSystem;
            OutFrictionMotor1 = controllerData.OutFrictionMotor1;
            OutFrictionMotor2 = controllerData.OutFrictionMotor2;

            SensorAngle = controllerData.SensorAngle;
            SensorDisbalance = controllerData.SensorDisbalance;
            SensorPower = controllerData.SensorPower;
            IndicationK = controllerData.IndicationK;

           ErrorsList = controllerData.ErrorsList ?? new();

        }
    }
}
