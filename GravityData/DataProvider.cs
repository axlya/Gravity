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
    public class DataProvider :IObservable<ControllerData>
    {
        public DataProvider()
        {
            _observers = new List<IObserver<ControllerData>>();
        }

        private List<IObserver<ControllerData>> _observers;

        public IDisposable Subscribe(IObserver<ControllerData> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            return new Unsubscriber(_observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<ControllerData>> _observers;
            private IObserver<ControllerData> _observer;

            public Unsubscriber(List<IObserver<ControllerData>> observers, IObserver<ControllerData> observer)
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

        public void SendData(ControllerData? data)
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
