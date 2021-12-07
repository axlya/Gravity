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
    public class CalcWebRecomValDataReporter : IObserver<RecomValData>
    {
        private IDisposable _unsubscriber;
        private string _instName;
        ICalculator _mainCalc = null;

        public CalcWebRecomValDataReporter(string name, ICalculator mainCalc)
        {
            _instName = name;
            _mainCalc = mainCalc;
        }

        public CalcWebRecomValDataReporter()
        {
            _instName = "Calculator reporter (from RecomVal Data)";
        }

        public void SetCalcFunc(ICalculator mainCalc)
        {
            _mainCalc = mainCalc;
        }

        public string Name
        { get { return _instName; } }

        public virtual void Subscribe(IObservable<RecomValData> provider)
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
        public virtual void OnNext(RecomValData data)
        {
            _mainCalc?.SetRecomValData(data);
        }

        public virtual void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }
    }
}
