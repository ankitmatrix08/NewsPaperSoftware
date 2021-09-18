using NewsDaily.Core.Enums;
using NewsDaily.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsDaily.Core.Implementation
{
    public class NewsPage<IItem> : INewsPage<Interface.IItem>, IComparable<NewsPage<Interface.IItem>>
    {
        public long Id => throw new NotImplementedException();

        public List<Interface.IItem> ItemList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int MaxItemSize => throw new NotImplementedException();

        public double MaxNewsVsAdRatio => throw new NotImplementedException();

        public ApplicationEnums.NewsCategory NewsCategory => throw new NotImplementedException();

        public bool AddItem(Interface.IItem item)
        {
            throw new NotImplementedException();
        }

        public bool CanAddNewAd()
        {
            throw new NotImplementedException();
        }

        public bool CanAddNewItem(Interface.IItem item)
        {
            throw new NotImplementedException();
        }

        public bool CanAddNewNews(Interface.IItem item)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(NewsPage<Interface.IItem> other)
        {
            throw new NotImplementedException();
        }

        public int GetMaxItemSize()
        {
            throw new NotImplementedException();
        }
    }
}
