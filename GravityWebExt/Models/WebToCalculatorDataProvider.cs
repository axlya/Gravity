using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GravityCalc;

namespace GravityWebExt.Models
{
    /// <summary>
    /// Передача данных MeasurementDataOut подписчикам
    /// </summary>
    public class WebToCalculatorDataProvider :IObservable<MeasurementDataOut>
    {
        public WebToCalculatorDataProvider()
        {
            _observers = new List<IObserver<MeasurementDataOut>>();
        }

        private List<IObserver<MeasurementDataOut>> _observers;

        public IDisposable Subscribe(IObserver<MeasurementDataOut> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            return new Unsubscriber(_observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<MeasurementDataOut>> _observers;
            private IObserver<MeasurementDataOut> _observer;

            public Unsubscriber(List<IObserver<MeasurementDataOut>> observers, IObserver<MeasurementDataOut> observer)
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

        public void SendData(MeasurementDataOut? data)
        {
            foreach (var observer in _observers)
            {
                if (!data.HasValue)
                    observer.OnError(new WebToCalculatorDataUnknownException());
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

    public class WebToCalculatorDataUnknownException : Exception
    {
        internal WebToCalculatorDataUnknownException()
        { }
    }
}
