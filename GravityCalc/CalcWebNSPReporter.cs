using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GravityCalc
{
    /// <summary>
    /// Получение данных от создателя конфигурации
    /// </summary>
    public class CalcWebNSPReporter : IObserver<NSPData>
    {
        private IDisposable _unsubscriber;
        private string _instName;
        ICalculator _mainCalc = null;

        public CalcWebNSPReporter(string name, ICalculator mainCalc)
        {
            _instName = name;
            _mainCalc = mainCalc;
        }

        public CalcWebNSPReporter()
        {
            _instName = "Calculator reporter (from NSP Data)";
        }

        public void SetCalcFunc(ICalculator mainCalc)
        {
            _mainCalc = mainCalc;
        }

        public string Name
        { get { return _instName; } }

        public virtual void Subscribe(IObservable<NSPData> provider)
        {
            if (provider != null)
                _unsubscriber = provider.Subscribe(this);
        }

        public virtual void OnCompleted()
        {
            Console.WriteLine("Completed transmitting data to {0}.", Name);
            this.Unsubscribe();
        }

        public virtual void OnError(Exception e)
        {
            Console.WriteLine("{0}: The data cannot be determined.", Name);
        }

        // Получены новые данные
        public virtual void OnNext(NSPData data)
        {
            _mainCalc?.SetNSPData(data);
        }

        public virtual void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }
    }
}
