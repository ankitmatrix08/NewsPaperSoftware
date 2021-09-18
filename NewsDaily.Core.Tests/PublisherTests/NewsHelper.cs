using Bogus;
using NewsDaily.Core.Interface;
using System.Collections.Generic;

namespace NewsDaily.Core.Tests.PublisherTests
{
    public class NewsHelper
    {
        public IList<IItem> GenerateTestNews()
        {
            var ids = 1;

            return new Faker<IItem>()
            .StrictMode(true)
            .RuleFor(n => n.Id, f => ids++)
            .RuleFor(n => n.Headline, f => f.Lorem.Sentence())
            .RuleFor(n => n.Description, f => f.Lorem.Paragraph())
            .RuleFor(n => n.NewsCategory, f => Enums.ApplicationEnums.NewsCategory.Business)
            .RuleFor(n => n.Priority, f => Enums.ApplicationEnums.NewsPriority.Breaking)
            .Generate(3);
        }
    }
}
