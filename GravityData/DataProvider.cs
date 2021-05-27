using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravityData
{
    /// <summary>
    /// Передача данных Data подписчикам
    /// </summary>
    public class DataProvider :IObservable<Data>
    {
        public DataProvider()
        {
            observers = new List<IObserver<Data>>();
        }

        private List<IObserver<Data>> observers;

        public IDisposable Subscribe(IObserver<Data> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<Data>> _observers;
            private IObserver<Data> _observer;

            public Unsubscriber(List<IObserver<Data>> observers, IObserver<Data> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }

        public void SendData(Data? data)
        {
            foreach (var observer in observers)
            {
                if (!data.HasValue)
                    observer.OnError(new DataUnknownException());
                else
                    observer.OnNext(data.Value);
            }
        }

        public void EndTransmission()
        {
            foreach (var observer in observers.ToArray())
                if (observers.Contains(observer))
                    observer.OnCompleted();

            observers.Clear();
        }
    }

    public class DataUnknownException : Exception
    {
        internal DataUnknownException()
        { }
    }
}
