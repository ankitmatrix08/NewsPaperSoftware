using Bogus;
using NewsDaily.Core.Implementation;
using NewsDaily.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using static NewsDaily.Core.Enums.ApplicationEnums;

namespace NewsDaily.Core.Tests.PublisherTests
{
    public class NewsHelper
    {

        public IList<INewsItem> Generate4PTINews(long startId, short newsCategory)
        {
            IList<INewsItem> listOfNews = new List<INewsItem>
            {
                GetNewsItem(startId++, "[PTI] Government introduces GST", "Govt of India has introduced GST bill in the parliament", Convert.ToByte(NewsPriority.Breaking), newsCategory),
                GetNewsItem(startId++, "[PTI] Sachin scores double hundred", "Sachin Tendulkal becomes the first cricketer to scroe 200 in ODIs", Convert.ToByte(NewsPriority.Breaking), newsCategory),
                GetNewsItem(startId++, "[PTI] Sushant - Murder or Suicide", "CBI to investigate", Convert.ToByte(NewsPriority.Breaking), newsCategory),
                GetNewsItem(startId++, "[PTI] Reliance takes over Big Basket", "Reliance has bought BB, it could be a game changer", Convert.ToByte(NewsPriority.Breaking), newsCategory)
            };
            return listOfNews;
        }

        public INewsItem GetNewsItem(long id, string header, string body, short priorty, short catgory)
        {
            INewsItem newsItem = new News(id, header, body, priorty, catgory);
            return newsItem;
        }

        public IList<IAdItem> Generate4PTIAds(long startId, short newsCategory)
        {
            IList<IAdItem> listOfNews = new List<IAdItem>
            {
                GetAdItem(startId++, "[PTI Ad] Ambuja Cement", "India's top selling Cement", newsCategory),
                GetAdItem(startId++, "[PTI Ad] Tata Motors", "New Tata Safari Launched!", newsCategory),
                GetAdItem(startId++, "[PTI Ad] ManKind Pharma", "India's leading Pharma company", newsCategory),
                GetAdItem(startId++, "[PTI Ad] Amazon Diwali Sale", "Big billion sale around the corner", newsCategory)
            };
            return listOfNews;
        }

        public IAdItem GetAdItem(long id, string header, string body, short catgory)
        {
            IAdItem adItem = new Ad(id, header, body, catgory);
            return adItem;
        }
    }
}
