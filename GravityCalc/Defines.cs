using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravityCalc
{
    public class Defines
    {
        public const double UNDEF_DBL_VALUE = -999999;
        public const string UNDEF_STR_VALUE = "NAN";
        public enum angles1 { angle_undef = -1, angle_0 = 0, angle_90 = 90, angle_180 = 180, angle_270 = 270 };
        public enum angles2 { angle_undef = -1, angle_0 = 0, angle_180 = 180 };
    }
}

