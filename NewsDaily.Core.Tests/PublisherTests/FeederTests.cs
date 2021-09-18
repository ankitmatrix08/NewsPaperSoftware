using Xunit;
using NewsDaily.Core.Interface;
using Moq;
using FluentAssertions;

namespace NewsDaily.Core.Tests.PublisherTests
{
    public class FeederTests
    {
        private readonly Mock<Interface.INewsFeeder<IItem>> feeder; 
        private readonly Mock<Interface.INewsPaper<IItem>> paper;
        private NewsHelper helper;
        public FeederTests()
        {
            feeder = new Mock<INewsFeeder<IItem>>();
            paper = new Mock<INewsPaper<IItem>>();
            helper = new NewsHelper();
        }
        [Fact]
        public void ShouldFeedToAllSubscribers()
        {
            //Arrange
            var newsList = helper.GenerateTestNews();
            paper.Setup(_ => _.Subscribe(feeder.Object));

            //Act
            feeder.Object.PostItems(newsList[0]);
            //Assert
           paper.Object.Pages[0].ItemList.Count.Should().Be(1);
        }
    }
}
