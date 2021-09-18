using Xunit;
using NewsDaily.Core.Interface;
using Moq;
using NewsDaily.Core.Publisher;
using static NewsDaily.Core.Enums.ApplicationEnums;
using System;

namespace NewsDaily.Core.Tests.PublisherTests
{
    public class FeederTests
    {
        private readonly INewsFeeder<IItem> feeder; 
        private readonly Mock<INewsPaper<IItem>> paper1;
        private readonly Mock<INewsPaper<IItem>> paper2;
        private readonly Mock<INewsPaper<IItem>> paper3;
        private NewsHelper helper;
        public FeederTests()
        {
            feeder = new NewsPublishers<IItem>(1, "PTI");
            paper1 = new Mock<INewsPaper<IItem>>();
            paper2 = new Mock<INewsPaper<IItem>>();
            paper3 = new Mock<INewsPaper<IItem>>();
            helper = new NewsHelper();
        }
        [Fact]
        public void ShouldFeedToAllSubscribers()
        {
            //Arrange
            var newsList = helper.Generate4PTINews(1, Convert.ToByte(NewsCategory.Business));
            feeder.Subscribe(paper1.Object);
            feeder.Subscribe(paper2.Object);
            feeder.Subscribe(paper3.Object);

            //Act
            feeder.PostItems(newsList[0]);
            feeder.PostItems(newsList[1]);
            //Assert
            paper1.Verify(_ => _.OnNext(newsList[0]), Times.Once);
            paper1.Verify(_ => _.OnNext(newsList[1]), Times.Once);
            paper2.Verify(_ => _.OnNext(newsList[0]), Times.Once);
            paper2.Verify(_ => _.OnNext(newsList[1]), Times.Once);
            paper3.Verify(_ => _.OnNext(newsList[0]), Times.Once);
            paper3.Verify(_ => _.OnNext(newsList[1]), Times.Once);
        }
    }
}
