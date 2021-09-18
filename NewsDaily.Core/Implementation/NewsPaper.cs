using NewsDaily.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsDaily.Core.Implementation
{
    public class NewsPaper : INewsPaper<IItem>
    {
        public IList<IItem> newsInfo = new List<IItem>();

        public string Name { get; }

        public long Id { get; }

        public IList<INewsPage<IItem>> Pages { get; set; }

        private IDisposable cancellation;

        public NewsPaper(long id, string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("The observer must be assigned a name.");
            }
            Id = id;
            Name = name;
            Pages = new List<INewsPage<IItem>>();
        }

        public void Subscribe(INewsFeeder<IItem> provider)
        {
            cancellation = provider.Subscribe(this);
            Console.WriteLine($"News Subscriber Listner Attached for {Name} with Id: {Id} /t Feeder: {Name}");
        }

        public void Unsubscribe()
        {
            cancellation.Dispose();
            newsInfo.Clear();
        }

        public void OnCompleted()
        {
            newsInfo.Clear();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(IItem value)
        {
            //bool? isProcessed = false;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"OnNext fired for NewsPaper: {this.Name}");
            newsInfo.Add(value);
           
            Console.WriteLine($"News Added {Id} /t {value.Headline}");
        }

        public void PrintAllPages()
        {
            throw new NotImplementedException();
        }
    }
}
