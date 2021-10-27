using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GravityWebExt.Models
{
    public class MeasurementData
    {
        public ControlPanelDataWeb _controlPanel { get; }
        public CalculatedDataWeb _calculatedData { get; }

        public MeasurementData(ControlPanelDataWeb controlPanel, CalculatedDataWeb calculatedData)
        {
            _controlPanel = controlPanel;
            _calculatedData = calculatedData;
        }
       
    }
}
