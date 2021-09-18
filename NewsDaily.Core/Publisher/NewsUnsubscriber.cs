using NewsDaily.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsDaily.Core.Publisher
{
    public class NewsUnsubscriber<IItem> : IUnsubscriber<Interface.IItem>
    {
        private readonly IList<IObserver<IItem>> _observers;
        private readonly IObserver<IItem> _observer;
        internal NewsUnsubscriber(IList<IObserver<IItem>> observers, IObserver<IItem> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }
        public void Dispose()
        {
            if (_observers.Contains(_observer))
            {
                _observers.Remove(_observer);
            }
        }
    }
}
