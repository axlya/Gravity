using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GravityCalc
{
    /// <summary>
    /// Передача данных CalculatedData подписчикам
    /// </summary>
    public class CalcDataProvider :IObservable<CalculatedData>
    {
        public CalcDataProvider()
        {
            _observers = new List<IObserver<CalculatedData>>();
        }

        private List<IObserver<CalculatedData>> _observers;

        public IDisposable Subscribe(IObserver<CalculatedData> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            return new Unsubscriber(_observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<CalculatedData>> _observers;
            private IObserver<CalculatedData> _observer;

            public Unsubscriber(List<IObserver<CalculatedData>> observers, IObserver<CalculatedData> observer)
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

        public void SendData(CalculatedData? data)
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
