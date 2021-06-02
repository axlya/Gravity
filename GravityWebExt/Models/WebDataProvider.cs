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
    public class WebDataProvider :IObservable<PasportData>
    {
        public WebDataProvider()
        {
            observers = new List<IObserver<PasportData>>();
        }

        private List<IObserver<PasportData>> observers;

        public IDisposable Subscribe(IObserver<PasportData> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<PasportData>> _observers;
            private IObserver<PasportData> _observer;

            public Unsubscriber(List<IObserver<PasportData>> observers, IObserver<PasportData> observer)
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

        public void SendData(PasportData? data)
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
