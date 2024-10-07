using Moq;
using MyApi.Data;
using MyApi.Models;
using MyApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MyApi.Tests
{
    public class ItemRepositoryTests
    {
        [Fact]
        public async Task GetAllAsync_ReturnsAllItems()
        {
            // Arrange
            var mockContext = new Mock<ItemContext>();
            var mockCollection = new Mock<IMongoCollection<Item>>();
            mockContext.Setup(c => c.Items).Returns(mockCollection.Object);
            var repository = new ItemRepository(mockContext.Object);
            var expectedItems = new List<Item> { new Item { Name = "Item1" }, new Item { Name = "Item2" } };

            mockCollection.Setup(c => c.Find(It.IsAny<FilterDefinition<Item>>(), null))
                .Returns(new Mock<IAsyncCursor<Item>>().Object);

            // Act
            var result = await repository.GetAllAsync();

            // Assert
            Assert.Equal(expectedItems.Count, result.Count);
        }
    }
}
