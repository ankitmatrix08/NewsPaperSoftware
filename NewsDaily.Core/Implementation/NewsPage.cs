using NewsDaily.Core.Enums;
using NewsDaily.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsDaily.Core.Implementation
{
    public class NewsPage<IItem> : INewsPage<Interface.IItem>, IComparable<NewsPage<Interface.IItem>>
    {
        public long Id { get; }

        public List<Interface.IItem> ItemList { get; set; }

        public int MaxItemSize { get; }

        public int MaxNewsVsAdRatio { get; }

        public ApplicationEnums.NewsCategory NewsCategory { get; }

        public NewsPage(long id, ApplicationEnums.NewsCategory newsCategory)
        {
            Id = id;
            ItemList = new List<Interface.IItem>();
            NewsCategory = newsCategory;
            MaxItemSize = 8;
            MaxNewsVsAdRatio = 6 / 2;
        }

        //ToDo: Need to look at the GCD logic for Ratios
        public bool CanAddNewAd()
        {
            if (ItemList.Count() < MaxItemSize)
            {
                var newsCount = ItemList.Count(_ => _.GetType() == typeof(News));
                var adCount = ItemList.Count(_ => _.GetType() == typeof(Ad));
                int ratio = (newsCount / MaxNewsVsAdRatio);
                return ratio > adCount;
            }
            return false;
        }

        public bool CanAddNewItem(Interface.IItem item)
        {
            return ItemList.Count() < MaxItemSize;
        }

        //Logic
        // 1. Check if the Page has space to add an Item
        // 2. If the item can be added directly Add, Else if by replacing an Ad item then Add
        // 3. Otherwise return false
        public bool CanAddNewNews(Interface.IItem item)
        {
            bool returnVal = false;
            if (ItemList.Count() < MaxItemSize)
                returnVal = true;
            else if (ItemList.Any(_ => _.GetType() == typeof(Ad)) && item.GetPriority() == ApplicationEnums.NewsPriority.Breaking)
            {
                ItemList.Remove(ItemList.First(_ => _.GetType() == typeof(Ad)));
                returnVal = true;
            }

            return returnVal;
        }

        public int GetMaxItemSize()
        {
            return MaxItemSize;
        }

        public int CompareTo(NewsPage<Interface.IItem> other)
        {
            if (other == null) return 1;
            var otherPage = other;
            return Id.CompareTo(otherPage.Id);
        }

        public bool AddItem(Interface.IItem item)
        {
            bool hasSucceed = false;
            if (item is INewsItem && CanAddNewNews(item))
            {
                hasSucceed = true;
                ItemList.Add(item);
            }
            else if (item is IAdItem && CanAddNewAd())
            {
                hasSucceed = true;
                ItemList.Add(item);
            }

            return hasSucceed;
        }
    }
}
