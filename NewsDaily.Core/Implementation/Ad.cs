using NewsDaily.Core.Enums;
using NewsDaily.Core.Interface;
using System;

namespace NewsDaily.Core.Implementation
{
    public class Ad : IAdItem
    {
        public long Id { get; }
        public string Headline { get; }
        public string Description { get; }
        public ApplicationEnums.NewsPriority Priority { get; }

        public ApplicationEnums.NewsCategory NewsCategory { get; }

        public Ad(long id, string headline, string desc, short newsCategory)
        {
            Id = id;
            Headline = headline;
            Description = desc;
            Priority = ApplicationEnums.NewsPriority.Ad;
            NewsCategory = (ApplicationEnums.NewsCategory)newsCategory; ;
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
    }
}
