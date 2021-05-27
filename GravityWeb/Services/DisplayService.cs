using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GravityWeb
{
    public class DisplayService
    {
        IDisplay _display;
        public DisplayService(IDisplay display)
        {
            _display = display;
        }

        public string Display() => _display.Display();
    }
}
