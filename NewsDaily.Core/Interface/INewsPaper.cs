using System.Collections.Generic;

namespace NewsDaily.Core.Interface
{
    public interface INewsPaper<T>
    {
        long Id { get; }
        string Name { get; }
        IList<INewsPage<T>> Pages { get; set; }
        void PrintAllPages();
    }
}
