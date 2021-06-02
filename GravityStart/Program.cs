using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GravityData;
using GravityCalc;


namespace GravityStart
{
    class Program
    {
        static void Main(string[] args)
        {
            DataProvider provider = new DataProvider();
            CalcWebReporter calcReporter = new CalcDataReporter("Calculator reporter");
            CalcWebReporter webReporter = new CalcDataReporter("Web repoter");
            calcReporter.Subscribe(provider);
            webReporter.Subscribe(provider);

            provider.SendData(new Data(47.6456, -122.1312));

            calcReporter.Unsubscribe();
            webReporter.Unsubscribe();
            provider.EndTransmission();

            Console.ReadKey();
        }
    }
}
