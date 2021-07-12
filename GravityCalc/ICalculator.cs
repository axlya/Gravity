using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravityCalc
{
    /// <summary>
    /// Калькуляторы реализуют этот интерфейс
    /// </summary>
    public interface ICalculator<in ControllerData, in PassportData, out CalculatedData>
    {
        /// <summary>
        /// Получены данные от контроллера
        /// </summary>
        /// <param name="controllerData"></param>
        public void SetControllerData(ControllerData controllerData);
        /// <summary>
        /// Получены паспортные данные
        /// </summary>
        /// <param name="passportData"></param>
        public void SetPassportData(PassportData passportData);
        /// <summary>
        /// Выдать расчитанные данные
        /// </summary>
        /// <returns></returns>
        public CalculatedData GetCalculatedData();
    }
}
