using NewsDaily.Core.Interface;
using System;
using System.Collections.Generic;

namespace NewsDaily.Core.Implementation
{
    public class NewsPaper : INewsPaper<IItem>
    {
        public long Id => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public IList<INewsPage<IItem>> Pages { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(IItem value)
        {
            throw new NotImplementedException();
        }

        public void PrintAllPages()
        {
            throw new NotImplementedException();
        }

        public void Subscribe(INewsFeeder<IItem> provider)
        {
            throw new NotImplementedException();
        }
    }
}
