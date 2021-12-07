using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GravityCalc;

namespace GravityData
{
    /// <summary>
    /// Передача данных Data подписчикам
    /// </summary>
    public class DataProvider :IObservable<ControllerDataOut>
    {
        public DataProvider()
        {
            _observers = new List<IObserver<ControllerDataOut>>();
        }

        private List<IObserver<ControllerDataOut>> _observers;

        public IDisposable Subscribe(IObserver<ControllerDataOut> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            return new Unsubscriber(_observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<ControllerDataOut>> _observers;
            private IObserver<ControllerDataOut> _observer;

            public Unsubscriber(List<IObserver<ControllerDataOut>> observers, IObserver<ControllerDataOut> observer)
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

        public void SendData(ControllerDataOut? data)
        {
            foreach (var observer in _observers)
            {
                if (!data.HasValue)
                    observer.OnError(new DataUnknownException());
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

    public class DataUnknownException : Exception
    {
        internal DataUnknownException()
        { }
    }
}
