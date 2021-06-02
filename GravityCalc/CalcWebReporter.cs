using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GravityCalc
{
    /// <summary>
    /// Получение данных от создателя конфигурации
    /// </summary>
    public class CalcWebReporter : IObserver<PasportData>
    {
        private IDisposable unsubscriber;
        private string instName;

        public CalcWebReporter(string name)
        {
            this.instName = name;
        }

        public string Name
        { get { return this.instName; } }

        public virtual void Subscribe(IObservable<PasportData> provider)
        {
            if (provider != null)
                unsubscriber = provider.Subscribe(this);
        }

        public virtual void OnCompleted()
        {
            Console.WriteLine("Completed transmitting data to {0}.", this.Name);
            this.Unsubscribe();
        }

        public virtual void OnError(Exception e)
        {
            Console.WriteLine("{0}: The data cannot be determined.", this.Name);
        }

        // Получены новые данные
        public virtual void OnNext(PasportData data)
        {
            //Console.WriteLine("{2}: The current data is {0}, {1}", data.Data1, data.Data2, this.Name);
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }
    }
}
