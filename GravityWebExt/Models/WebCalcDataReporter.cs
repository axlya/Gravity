using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GravityWebExt.Controllers;

using GravityCalc;

namespace GravityWebExt.Models
{
    /// <summary>
    /// Получение данных от калькулятора
    /// </summary>
    public class WebCalcDataReporter : IObserver<CalculatedData>
    {
        private IDisposable _unsubscriber;
        private string _instName;

        public CalculatedData Data { get; set; }


        public WebCalcDataReporter(string name)
        {
            _instName = name;
        }

        public WebCalcDataReporter()
        {
            _instName = "Web reporter (Calculator Data)";
        }

        public string Name
        { get { return _instName; } }

        public virtual void Subscribe(IObservable<CalculatedData> provider)
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
        public virtual void OnNext(CalculatedData data)
        {
            Data = data;
        }

        public virtual void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }
            
    }
}
