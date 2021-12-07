using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GravityCalc;

namespace GravityData
{
    /// <summary>
    /// Контроллеры реализуют этот интерфейс
    /// </summary>
    public interface IController
    {
        /// <summary>
        /// Получены данные от системы управления
        /// </summary>
        public void SetData(ControllerDataIn dataIn);
    }
}
