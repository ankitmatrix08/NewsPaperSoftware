using NewsDaily.Core.Enums;
using NewsDaily.Core.Interface;
using System;

namespace NewsDaily.Core.Implementation
{
    public class News : INewsItem, IComparable
    {
        public long Id { get; }
        public string Headline { get; }
        public string Description { get; }
        public ApplicationEnums.NewsPriority Priority { get; }
        public ApplicationEnums.NewsCategory NewsCategory { get; set; }

        public News(long id, string headline, string desc, short priority, short newsCategory)
        {
            Id = id;
            Headline = headline;
            Description = desc;
            Priority = (ApplicationEnums.NewsPriority)priority;
            NewsCategory = (ApplicationEnums.NewsCategory)newsCategory;

        }
        public string GetDescription()
        {
            return Description;
        }

        public string GetHeadLine()
        {
            return Headline;
        }

        public long GetId()
        {
            return Id;
        }

        public ApplicationEnums.NewsPriority GetPriority()
        {
            return Priority;
        }

        public ApplicationEnums.NewsCategory GetNewsCategory()
        {
            return NewsCategory;
        }

        public override string ToString()
        {
            return string.Join(";", new[] { Id.ToString(), Headline, Description, Priority.ToString(), NewsCategory.ToString() });
        }

        public int CompareTo(object other)
        {
            if (other == null) return 1;
            var otherNews = other as News;
            return Id.CompareTo(otherNews.Id);
        }
    }
}
