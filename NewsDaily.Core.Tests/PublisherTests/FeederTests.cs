using Xunit;
using NewsDaily.Core.Interface;
using Moq;
using FluentAssertions;
using NewsDaily.Core.Publisher;

namespace NewsDaily.Core.Tests.PublisherTests
{
    public class FeederTests
    {
        private readonly INewsFeeder<IItem> feeder; 
        private readonly Mock<INewsPaper<IItem>> paper;
        private NewsHelper helper;
        public FeederTests()
        {
            feeder = new NewsPublishers<IItem>(1, "PTI");
            paper = new Mock<INewsPaper<IItem>>();
            helper = new NewsHelper();
        }
        [Fact]
        public void ShouldFeedToAllSubscribers()
        {
            //Arrange
            var newsList = helper.GeneratePTINews();
            feeder.Subscribe(paper.Object);

            //Act
            feeder.PostItems(newsList[0]);
            //Assert
            paper.Verify(_ => _.OnNext(newsList[0]), Times.Once);
        }
    }
}
