using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GravityCalc;

namespace GravityData
{
    /// <summary>
    /// Получение данных от Web
    /// </summary>
    public class DataReporter : IObserver<ControllerDataIn>
    {
        private IDisposable _unsubscriber;
        private string _instName;
        IController _controller = null;

        public DataReporter(string name, IController controller)
        {
            _instName = name;
            _controller = controller;
        }

        public DataReporter()
        {
            _instName = "Controller reporter (from Web)";
        }

        public void SetControllerFunc(IController controller)
        {
            _controller = controller;
        }

        public string Name
        { get { return _instName; } }

        public virtual void Subscribe(IObservable<ControllerDataIn> provider)
        {
            if (provider != null)
                _unsubscriber = provider.Subscribe(this);
        }

        public virtual void OnCompleted()
        {
            //onsole.WriteLine("Completed transmitting data to {0}.", Name);
            Unsubscribe();
        }

        public virtual void OnError(Exception e)
        {
            //Console.WriteLine("{0}: The data cannot be determined.", Name);
        }

        // Получены новые данные
        public virtual void OnNext(ControllerDataIn data)
        {
            _controller?.SetData(data);
        }

        public virtual void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }
    }
}
