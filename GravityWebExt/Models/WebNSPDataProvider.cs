using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GravityCalc;

namespace GravityWebExt.Models
{
    /// <summary>
    /// Передача данных NSPData подписчикам
    /// </summary>
    public class WebNSPDataProvider :IObservable<NSPData>
    {
        public WebNSPDataProvider()
        {
            _observers = new List<IObserver<NSPData>>();
        }

        private List<IObserver<NSPData>> _observers;

        public IDisposable Subscribe(IObserver<NSPData> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            return new Unsubscriber(_observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<NSPData>> _observers;
            private IObserver<NSPData> _observer;

            public Unsubscriber(List<IObserver<NSPData>> observers, IObserver<NSPData> observer)
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

        public void SendData(NSPData? data)
        {
            foreach (var observer in _observers)
            {
                if (!data.HasValue)
                    observer.OnError(new WebNSPDataUnknownException());
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

    public class WebNSPDataUnknownException : Exception
    {
        internal WebNSPDataUnknownException()
        { }
    }
}
