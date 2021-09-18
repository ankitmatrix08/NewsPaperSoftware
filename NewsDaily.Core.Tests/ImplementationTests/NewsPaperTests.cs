using FluentAssertions;
using Moq;
using NewsDaily.Core.Implementation;
using NewsDaily.Core.Interface;
using NewsDaily.Core.Tests.PublisherTests;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static NewsDaily.Core.Enums.ApplicationEnums;

namespace NewsDaily.Core.Tests.ImplementationTests
{
    public class NewsPaperTests
    {
        private readonly INewsPaper<IItem> paper;
        private NewsHelper helper;
        public NewsPaperTests()
        {
            paper = new NewsPaper(1, "NY Times");
            helper = new NewsHelper();
        }

        [Fact]
        public void ShouldAddANewPageForTheCategory()
        {
            //Arrange
            var newsList = helper.Generate4PTINews(1, Convert.ToByte(NewsCategory.Business));

            //Act
            paper.OnNext(newsList[0]);

            //Assert
            paper.Pages.Count.Should().Be(1);
            paper.Pages[0].ItemList.Count.Should().Be(1);
            paper.Pages[0].NewsCategory.Should().Be(newsList[0].NewsCategory);
        }

        [Fact]
        public void ShouldUseTheSamePageForTheCategory()
        {
            //Arrange
            var newsList = helper.Generate4PTINews(1, Convert.ToByte(NewsCategory.Business));

            //Act
            paper.OnNext(newsList[0]);
            paper.OnNext(newsList[1]);

            //Assert
            paper.Pages.Count.Should().Be(1);
            paper.Pages[0].ItemList.Count.Should().Be(2);
            paper.Pages[0].NewsCategory.Should().Be(newsList[0].NewsCategory);
        }

        [Fact]
        public void ShouldCreateNewPageForTheSameCategory()
        {
            //Arrange
            var newsList = helper.Generate4PTINews(1, Convert.ToByte(NewsCategory.Political));
            var newsList2 = helper.Generate4PTINews(5, Convert.ToByte(NewsCategory.Political));
            var newsList3 = helper.Generate4PTINews(9, Convert.ToByte(NewsCategory.Political));

            //Act
            paper.OnNext(newsList[0]);
            paper.OnNext(newsList[1]);
            paper.OnNext(newsList[2]);
            paper.OnNext(newsList[3]);
            paper.OnNext(newsList2[0]);
            paper.OnNext(newsList2[1]);
            paper.OnNext(newsList2[2]);
            paper.OnNext(newsList2[3]);

            paper.OnNext(newsList3[0]);

            //Assert
            paper.Pages.Count.Should().Be(2);
            paper.Pages[0].ItemList.Count.Should().Be(8);
            paper.Pages[1].ItemList.Count.Should().Be(1);
            paper.Pages[1].NewsCategory.Should().Be(newsList3[0].NewsCategory);
        }

    }
}
