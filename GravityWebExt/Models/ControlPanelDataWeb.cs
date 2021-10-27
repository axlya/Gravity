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
        /// <summary>
        /// Угол равновесия в начальной зоне
        /// </summary>
        public double BeginBalanceAngle { get; set; }
        /// <summary>
        /// Угол равновесия в средней зоне
        /// </summary>
        public double MiddleBalanceAngle { get; set; }
        /// <summary>
        /// Датчик дисбаланса в начальной зоне работы
        /// </summary>
        public double BeginUnbalanceSensor { get; set; } 
        /// <summary>
        ///  Датчик дисбаланса в средней зоне работы
        /// </summary>
        public double MiddleUnbalanceSensor { get; set; }
        /// <summary>
        /// Датчик линейного передвижения в начальной зоны работы 
        /// </summary
        public double Knom { get; set; }
        /// <summary>
        /// Датчик линейного пережвижения в среднем режиме работы
        /// </summary
        public double Kaver { get; set; }
        /// <summary>
        /// Датчик силы в начальной зоне работы
        /// </summary>
        public double BeginPowerSensor { get; set; }
        /// <summary
        ///  Датчик силы в средней зоне работы
        /// </summary>
        public double MiddlePowerSensor { get; set; }


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
        

        public ControlPanelDataWeb()
        {
        }
        public ControlPanelDataWeb(ControllerDataOut controllerData)
        {
            BeginBalanceAngle = controllerData.BeginBalanceAngle;
            MiddleBalanceAngle = controllerData.MiddleBalanceAngle;
            BeginUnbalanceSensor = controllerData.BeginUnbalanceSensor;
            MiddleUnbalanceSensor = controllerData.MiddleUnbalanceSensor;
            Knom = controllerData.Knom;
            Kaver = controllerData.Kaver;
            BeginPowerSensor = controllerData.BeginPowerSensor;
            MiddlePowerSensor = controllerData.MiddlePowerSensor;

            SensorAngle = controllerData.SensorAngle;
            SensorDisbalance = controllerData.SensorDisbalance;
            SensorPower = controllerData.SensorPower;
            
        }
    }
}
