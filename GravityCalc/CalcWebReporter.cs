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
    public class CalcWebReporter : IObserver<PassportData>
    {
        private IDisposable _unsubscriber;
        private string _instName;
        ICalculator<ControllerData, PassportData, CalculatedData> _mainCalc = null;

        public CalcWebReporter(string name, ICalculator<ControllerData, PassportData, CalculatedData> mainCalc)
        {
            _instName = name;
            _mainCalc = mainCalc;
        }

        public CalcWebReporter()
        {
            _instName = "Calculator reporter (from Pasport Data)";
        }

        public void SetCalcFunc(ICalculator<ControllerData, PassportData, CalculatedData> mainCalc)
        {
            _mainCalc = mainCalc;
        }

        public string Name
        { get { return _instName; } }

        public virtual void Subscribe(IObservable<PassportData> provider)
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
        public virtual void OnNext(PassportData data)
        {
            _mainCalc?.SetPassportData(data);
        }

        public virtual void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }
    }
}
