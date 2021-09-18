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

        public IList<INewsItem> GeneratePTINews()
        {
            IList<INewsItem> listOfNews = new List<INewsItem>
            {
                GetNewsItem(1, "[PTI] Government introduces GST", "Govt of India has introduced GST bill in the parliament", Convert.ToByte(NewsPriority.Breaking), Convert.ToByte(NewsCategory.Political)),
                GetNewsItem(2, "[PTI] Sachin scores double hundred", "Sachin Tendulkal becomes the first cricketer to scroe 200 in ODIs", Convert.ToByte(NewsPriority.Breaking), Convert.ToByte(NewsCategory.Political)),
                GetNewsItem(3, "[PTI] Sushant - Murder or Suicide", "CBI to investigate", Convert.ToByte(NewsPriority.Breaking), Convert.ToByte(NewsCategory.Political)),
                GetNewsItem(4, "[PTI] Reliance takes over Big Basket", "Reliance has bought BB, it could be a game changer", Convert.ToByte(NewsPriority.Breaking), Convert.ToByte(NewsCategory.Business))
            };
            return listOfNews;
        }

        public INewsItem GetNewsItem(long id, string header, string body, short priorty, short catgory)
        {
            INewsItem newsItem = new News(id, header, body, priorty, catgory);
            return newsItem;
        }
        //public IList<News> GenerateTestNews()
        //{
        //    var ids = 1;

        //    var fakeNews = new Faker<News>()
        //    .StrictMode(true)
        //    .RuleFor(n => n.Id, f => ids++)
        //    .RuleFor(n => n.Headline, f => f.Name.FullName())
        //    .RuleFor(n => n.Description, f => f.Lorem.Paragraph())
        //    .RuleFor(n => n.NewsCategory, f => Enums.ApplicationEnums.NewsCategory.Business)
        //    .RuleFor(n => n.Priority, f => Enums.ApplicationEnums.NewsPriority.Breaking);

        //    return fakeNews.Generate(5).ToList();
           
        //}
    }
}
