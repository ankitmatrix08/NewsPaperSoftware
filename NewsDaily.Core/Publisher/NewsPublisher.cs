using NewsDaily.Core.Interface;
using System;
using System.Collections.Generic;

namespace NewsDaily.Core.Publisher
{
    public class NewsPublishers<IItem> : INewsFeeder<Interface.IItem>
    {
        public IList<IObserver<Interface.IItem>> Observers { get; set; }
        public IList<Interface.IItem> Items { get; set; }

        public long Id { get; }
        public string Name { get; }

        public NewsPublishers(long id, string name)
        {
            Id = id;
            Name = name;

            Observers = new List<IObserver<Interface.IItem>>();
            Items = new List<Interface.IItem>();
        }

        public void PostItems(Interface.IItem item)
        {
            if (item.Id > 0 && !Items.Contains(item))
            {
                Items.Add(item);

                foreach (var observer in Observers)
                {
                    observer.OnNext(item);
                }
            }
        }

        public IDisposable Subscribe(IObserver<Interface.IItem> observer)
        {
            if (!Observers.Contains(observer))
            {
                Observers.Add(observer);
                // Provide observer with existing data.
                foreach (var item in Items)
                {
                    observer.OnNext(item);
                }
            }
            return new NewsUnsubscriber<Interface.IItem>(Observers, observer);
        }
    }
}
