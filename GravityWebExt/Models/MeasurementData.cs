using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GravityWebExt.Models
{
    public class MeasurementData
    {
        public ControlPanelDataWeb _controlPanel;
        public CalculatedDataWeb _calculatedData;

        /// <summary>
        /// Запуск расчета
        /// </summary>
        public bool CalculationCalc { get; set; }
        /// <summary>
        /// Угол поворота платформы
        /// </summary>
        public int Fi { get; set; }
        public List<SelectListItem> Angles { set; get; }
        /// <summary>
        /// Показание для КЦМ \ Массы 
        /// </summary>
        public int CoordMass { get; set; }
        /// <summary>
        /// Контрольное приспособление
        /// </summary>
        public bool KP { get; set; }

        

        public MeasurementData(ControlPanelDataWeb controlPanel, CalculatedDataWeb calculatedData)
        {
            _controlPanel = controlPanel;
            _calculatedData = calculatedData;
            

            InitArrays();
        }
        public MeasurementData()
        {
            _controlPanel = null;
            _calculatedData = null;

            InitArrays();
        }
        private void InitArrays()
        {
            Angles = new List<SelectListItem>
            {
                new SelectListItem {Text = "0", Value = "0"},
                new SelectListItem {Text = "90", Value = "1"},
                new SelectListItem {Text = "180", Value = "2"},
                new SelectListItem {Text = "270", Value = "3"}
            };
        }
        public GravityCalc.MeasurementDataOut SetDataForCalculate()
        {
            GravityCalc.MeasurementDataOut data = new();
            data.Fi = Fi switch
            {
                0 => 0,
                1 => 90,
                2 => 180,
                3 => 270,
                _ => -1,//error
            };
            if (CoordMass == 0)
                data.findCoordMass = true;
            else
                data.findCoordMass = false;

            data.CalculationCalc = CalculationCalc;
            data.KP = KP;
            
            return data;
        }
    }
}
