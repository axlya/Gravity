using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GravityCalc;
using GravityWebExt.Controllers;

namespace GravityWebExt.Models
{
    /// <summary>
    /// Получение данных от контроллера
    /// </summary>
    public class WebDataReporter : IObserver<ControllerData>
    {
        private IDisposable _unsubscriber;
        private string _instName;

        public ControllerData Data { get; set; }


        public WebDataReporter(string name)
        {
            _instName = name;
        }

        public WebDataReporter()
        {
            _instName = "Web reporter (Controller Data)";
        }

        public string Name
        { get { return _instName; } }

        public virtual void Subscribe(IObservable<ControllerData> provider)
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
        public virtual void OnNext(ControllerData data)
        {
            Data = data;
        }

        public virtual void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }
            
    }
}
