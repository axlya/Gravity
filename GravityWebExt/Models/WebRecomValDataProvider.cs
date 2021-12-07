using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GravityCalc;

namespace GravityWebExt.Models
{
    public class WebRecomValDataProvider : IObservable<RecomValData>
    {
        public WebRecomValDataProvider()
        {
            _observers = new List<IObserver<RecomValData>>();
        }

        private List<IObserver<RecomValData>> _observers;

        public IDisposable Subscribe(IObserver<RecomValData> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            return new Unsubscriber(_observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<RecomValData>> _observers;
            private IObserver<RecomValData> _observer;

            public Unsubscriber(List<IObserver<RecomValData>> observers, IObserver<RecomValData> observer)
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

        public void SendData(RecomValData? data)
        {
            foreach (var observer in _observers)
            {
                if (!data.HasValue)
                    observer.OnError(new WebRecomValDataUnknownException());
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

    public class WebRecomValDataUnknownException : Exception
    {
        internal WebRecomValDataUnknownException()
        { }
    }
}

