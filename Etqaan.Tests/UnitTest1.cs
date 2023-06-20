using Etqaan.Application.Interfaces;
using Etqaan.Application.Test;
using Moq;
using static Etqaan.Application.Test.TestQuery;

namespace Etqaan.Tests
{
    public class UnitTest1
    {



        [Fact]
        public async Task Handle_ShouldReturnExpectedResult()
        {
            // Arrange
            var query = new TestQuery();
            var expectedResult = 10;

            // Mock the application database context
            var dbContextMock = new Mock<IApplicationDbContext>();

            // Configure the mock to return a specific value
            dbContextMock.Setup(c => c.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(expectedResult);

            // Create an instance of the query handler with the mocked database context
            var handler = new TestQueryHandler(dbContextMock.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}