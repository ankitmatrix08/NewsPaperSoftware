using NewsDaily.Core.Enums;
using System.Collections.Generic;

namespace NewsDaily.Core.Interface
{
    public interface INewsPage<T>
    {
        long Id { get; }
        List<T> ItemList { get; set; }
        int MaxItemSize { get; }
        int MaxNewsVsAdRatio { get; }
        ApplicationEnums.NewsCategory NewsCategory { get; } 
        int GetMaxItemSize();
        bool CanAddNewItem(T item);
        bool CanAddNewNews(T item);
        bool CanAddNewAd();
        bool AddItem(T item);


    }
}
