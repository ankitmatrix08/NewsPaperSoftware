using FluentAssertions;
using NewsDaily.Core.Implementation;
using NewsDaily.Core.Interface;
using NewsDaily.Core.Tests.PublisherTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using static NewsDaily.Core.Enums.ApplicationEnums;

namespace NewsDaily.Core.Tests.ImplementationTests
{
  public class NewsPageTests
    {
        private readonly INewsPage<IItem> newsPage;
        private NewsHelper helper;
        public NewsPageTests()
        {
            newsPage = new NewsPage<IItem>(1, Enums.ApplicationEnums.NewsCategory.Political);
            helper = new NewsHelper();
        }

        [Fact]
        public void ShouldNotLetAnAdToBeAddedIfRatioIsLessThanNewsCount()
        {
            //Arrange
            var newsList = helper.Generate4PTINews(1, Convert.ToByte(NewsCategory.Political));
            var adList = helper.Generate4PTIAds(1, Convert.ToByte(NewsCategory.Political));
            //Act
            newsPage.AddItem(newsList[0]);
            newsPage.AddItem(newsList[1]);

            var hasSucceeded = newsPage.AddItem(adList[0]);
            //Assert
            Assert.False(hasSucceeded);
        }

        [Fact]
        public void ShouldLetAnAdToBeAddedIfRatioIsEqualThanNewsCount()
        {
            //Arrange
            var newsList = helper.Generate4PTINews(1, Convert.ToByte(NewsCategory.Political));
            var adList = helper.Generate4PTIAds(1, Convert.ToByte(NewsCategory.Political));
            //Act
            newsPage.AddItem(newsList[0]);
            newsPage.AddItem(newsList[1]);
            newsPage.AddItem(newsList[2]);

            var hasSucceeded = newsPage.AddItem(adList[0]);
            //Assert
            Assert.True(hasSucceeded);
        }

        [Fact]
        public void ShouldNotLet2AdsToBeAddedIfRatioIsGreaterThanNewsCountButLessThanTheMaxCount()
        {
            //Arrange
            var newsList = helper.Generate4PTINews(1, Convert.ToByte(NewsCategory.Political));
            var adList = helper.Generate4PTIAds(1, Convert.ToByte(NewsCategory.Political));
            //Act
            newsPage.AddItem(newsList[0]);
            newsPage.AddItem(newsList[1]);
            newsPage.AddItem(newsList[2]);
            newsPage.AddItem(newsList[3]);

            newsPage.AddItem(adList[0]);
            var hasSucceeded = newsPage.AddItem(adList[1]);
            //Assert
            Assert.False(hasSucceeded);
            newsPage.ItemList.Count(_ => _.GetType() == typeof(Ad)).Should().Be(1);
        }

        [Fact]
        public void ShouldLet2AdsToBeAddedIfRatioMatchesTheMaxCount()
        {
            //Arrange
            var newsList = helper.Generate4PTINews(1, Convert.ToByte(NewsCategory.Political));
            var newsList2 = helper.Generate4PTINews(5, Convert.ToByte(NewsCategory.Political));
            var adList = helper.Generate4PTIAds(1, Convert.ToByte(NewsCategory.Political));
            //Act
            newsPage.AddItem(newsList[0]);
            newsPage.AddItem(newsList[1]);
            newsPage.AddItem(newsList[2]);
            newsPage.AddItem(newsList[3]);
            newsPage.AddItem(newsList2[0]);
            newsPage.AddItem(newsList2[1]);

            newsPage.AddItem(adList[0]);
            var hasSucceeded = newsPage.AddItem(adList[1]);
            //Assert
            Assert.True(hasSucceeded);
            newsPage.ItemList.Count(_ => _.GetType() == typeof(Ad)).Should().Be(2);
        }

        [Fact]
        public void ShouldNotLetMoreThan2AdsToBeAddedEvenIfThereIsSomeSpace()
        {
            //Arrange
            var newsList = helper.Generate4PTINews(1, Convert.ToByte(NewsCategory.Political));
            var newsList2 = helper.Generate4PTINews(5, Convert.ToByte(NewsCategory.Political));
            var adList = helper.Generate4PTIAds(1, Convert.ToByte(NewsCategory.Political));
            //Act
            newsPage.AddItem(newsList[0]);
            newsPage.AddItem(newsList[1]);
            newsPage.AddItem(newsList[2]);
            newsPage.AddItem(newsList[3]);
            newsPage.AddItem(newsList2[0]);

            newsPage.AddItem(adList[0]);
            var hasSucceeded = newsPage.AddItem(adList[2]);
            //Assert
            Assert.False(hasSucceeded);
            newsPage.ItemList.Count(_ => _.GetType() == typeof(Ad)).Should().Be(1);
        }

        [Fact]
        public void ShouldNotLetMoreThan8ItemsToBeAddedInANewsPage()
        {
            //Arrange
            var newsList = helper.Generate4PTINews(1, Convert.ToByte(NewsCategory.Political));
            var newsList2 = helper.Generate4PTINews(5, Convert.ToByte(NewsCategory.Political));
            var adList = helper.Generate4PTIAds(1, Convert.ToByte(NewsCategory.Political));
            //Act
            newsPage.AddItem(newsList[0]);
            newsPage.AddItem(newsList[1]);
            newsPage.AddItem(newsList[2]);
            newsPage.AddItem(newsList[3]);
            newsPage.AddItem(newsList2[0]);
            newsPage.AddItem(newsList2[1]);
            newsPage.AddItem(newsList2[2]);
            newsPage.AddItem(newsList2[3]);

            var hasSucceeded = newsPage.AddItem(adList[0]);
            //Assert
            Assert.False(hasSucceeded);
            newsPage.ItemList.Count().Should().Be(8);
        }

        [Fact]
        public void ShouldReplaceAnAdWithAHighPriorityNewsItem()
        {
            //Arrange
            var newsList = helper.Generate4PTINews(1, Convert.ToByte(NewsCategory.Political));
            var newsList2 = helper.Generate4PTINews(5, Convert.ToByte(NewsCategory.Political));
            var adList = helper.Generate4PTIAds(1, Convert.ToByte(NewsCategory.Political));
            //Act
            newsPage.AddItem(newsList[0]);
            newsPage.AddItem(newsList[1]);
            newsPage.AddItem(newsList[2]);
            newsPage.AddItem(newsList[3]);
            newsPage.AddItem(newsList2[0]);
            newsPage.AddItem(newsList2[1]);

            newsPage.AddItem(adList[0]);
            newsPage.AddItem(adList[1]);

            var hasSucceeded = newsPage.AddItem(newsList2[2]);
            //Assert
            Assert.True(hasSucceeded);
            newsPage.ItemList.Count().Should().Be(8);
            newsPage.ItemList.Count(_ => _.GetType() == typeof(Ad)).Should().Be(1);
        }
    }
}
