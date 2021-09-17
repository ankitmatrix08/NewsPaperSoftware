using System;
using System.Collections.Generic;

namespace NewsDaily.Core.Interface
{
    public interface INewsFeeder<T>: IObservable<T>
    {
        long Id { get; }
        string Name { get; }
        IList<IObserver<T>> Observers { get; set; }
        IList<T> Items { get; set; }
        void PostItems(T item);
    }
}
