using System;
using System.Collections.Generic;

namespace NewsDaily.Core.Interface
{
    public interface INewsPaper<T>: IObserver<IItem>
    {
        long Id { get; }
        string Name { get; }
        IList<INewsPage<T>> Pages { get; set; }
        void PrintAllPages();
        void Subscribe(INewsFeeder<IItem> provider);
    }
}
