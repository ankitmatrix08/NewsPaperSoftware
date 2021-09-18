using NewsDaily.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsDaily.Core.Implementation
{
    public class NewsPaper : INewsPaper<IItem>
    {
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
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(IItem value)
        {
            bool? isProcessed = false;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"OnNext fired for NewsPaper: {this.Name}");

            if (Pages.Count == 0)
            {
                //Adds a new Page with the given category
                Pages.Add(new NewsPage<IItem>(1, value.GetNewsCategory()));
            }

            // Step 1: Find if exist, a Page for the given NewsCategory
            //      - If Found, use the latest page of the given category for adding the item
            if (Pages?.Any(_ => _.NewsCategory == value.GetNewsCategory()) == true)
            {
                if (Pages?.LastOrDefault(_ => _.NewsCategory == value.GetNewsCategory())?.CanAddNewItem(value) == true)
                    isProcessed = Pages?.LastOrDefault(_ => _.NewsCategory == value.GetNewsCategory())?.AddItem(value);
                else
                {
                    Pages.Add(new NewsPage<IItem>(Pages.Count + 1, value.GetNewsCategory()));
                    isProcessed = Pages?.LastOrDefault(_ => _.NewsCategory == value.GetNewsCategory())?.AddItem(value);
                }
            }
            else
            {
                // Step 2: If there's exist no Page for the given NewsCategory
                //      - Add a new page for the said category
                //      - Add the item into it
                Pages.Add(new NewsPage<IItem>(Pages.Count + 1, value.GetNewsCategory()));
                isProcessed = Pages?.FirstOrDefault(_ => _.NewsCategory == value.GetNewsCategory())?.AddItem(value);
            }
            if (isProcessed == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Item failed to be Added: Id -  {Id} /t Headline - {value.Headline}");
                return;
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"News Added {Id} /t {value.Headline}");
        }

        public void PrintAllPages()
        {
            throw new NotImplementedException();
        }
    }
}
