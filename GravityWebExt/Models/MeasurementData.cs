using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GravityWebExt.Models
{
    public class MeasurementData
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
        public double BeginUnbalanceSensor { get; set; } // Получаем 6 раз, по 10 значений – с ma 0⁰/90⁰/180⁰/270⁰ и с mm 0⁰/90⁰
        /// <summary>
        ///  Датчик дисбаланса в средней зоне работы
        /// </summary>
        public double MiddleUnbalanceSensor { get; set; } // Получаем 6 раз, по 10 значений – с ma 0⁰/90⁰/180⁰/270⁰ и с mm 0⁰/90⁰
        /// <summary>
        /// Расстояния от оси поворота стола до известных координат центра тяжести груза
        /// </summary>
        public double K1 { get; set; }
        /// <summary>
        /// Расстояния от оси поворота стола до известных координат центра тяжести груза
        /// </summary>
        public double K2 { get; set; }
        public double P1 { get; set; } // Какие-то датчики
        public double P2 { get; set; } // Какие-то датчики

        public MeasurementData()
        {
        }
        public MeasurementData(ControllerData controllerData)
        {
            Id = 1;
            BeginBalanceAngle = controllerData.BeginBalanceAngle;
            MiddleBalanceAngle = controllerData.MiddleBalanceAngle;
            BeginUnbalanceSensor = controllerData.BeginUnbalanceSensor;
            MiddleUnbalanceSensor = controllerData.MiddleUnbalanceSensor;
            K1 = controllerData.K1;
            K2 = controllerData.K2;
            P1 = controllerData.P1;
            P2 = controllerData.P2;
        }
       
    }
}
