using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GravityCalc;

namespace GravityWebExt.Models
{
    /// <summary>
    /// Передача данных ControllerDataIn подписчикам
    /// </summary>
    public class WebToControllerDataProvider :IObservable<ControllerDataIn>
    {
        public WebToControllerDataProvider()
        {
            _observers = new List<IObserver<ControllerDataIn>>();
        }

        private List<IObserver<ControllerDataIn>> _observers;

        public IDisposable Subscribe(IObserver<ControllerDataIn> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            return new Unsubscriber(_observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<ControllerDataIn>> _observers;
            private IObserver<ControllerDataIn> _observer;

            public Unsubscriber(List<IObserver<ControllerDataIn>> observers, IObserver<ControllerDataIn> observer)
            {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }

        public void SendData(ControllerDataIn? data)
        {
            foreach (var observer in _observers)
            {
                if (!data.HasValue)
                    observer.OnError(new WebToControllerDataUnknownException());
                else
                    observer.OnNext(data.Value);
            }
        }

        public void EndTransmission()
        {
            foreach (var observer in _observers.ToArray())
                if (_observers.Contains(observer))
                    observer.OnCompleted();

            _observers.Clear();
        }
    }

    public class WebToControllerDataUnknownException : Exception
    {
        internal WebToControllerDataUnknownException()
        { }
    }
}
