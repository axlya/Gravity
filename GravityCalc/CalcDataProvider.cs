using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GravityCalc;

namespace GravityWebExt.Models
{
    /// <summary>
    /// Передача данных PasportData подписчикам
    /// </summary>
    public class CalcDataProvider :IObservable<PassportData>
    {
        public CalcDataProvider()
        {
            _observers = new List<IObserver<PassportData>>();
        }

        private List<IObserver<PassportData>> _observers;

        public IDisposable Subscribe(IObserver<PassportData> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            return new Unsubscriber(_observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<PassportData>> _observers;
            private IObserver<PassportData> _observer;

            public Unsubscriber(List<IObserver<PassportData>> observers, IObserver<PassportData> observer)
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

        public void SendData(PassportData? data)
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
