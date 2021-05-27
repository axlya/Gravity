using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravityData
{
    public struct Data
    {
        double _data1;
        double _data2;

        public Data(double data1, double data2)
        {
            _data1 = data1;
            _data2 = data2;
        }

        public double Data1
        {
            get { return this._data1; }
        }
        public double Data2
        {
            get { return this._data2; }
        }
    }
}
