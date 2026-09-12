using FluentAssertions;
using Moq;
using StarWars_Cyclopedia.Application.UseCases.GetCharacters;
using StarWars_Cyclopedia.Domain.Entities;
using StarWars_Cyclopedia.Domain.Interfaces;

namespace StarWars_Cyclopedia.Tests.Application.UseCases.GetCharacters
{
    public class GetCharactersHandlerTests
    {
        [Fact]
        public async Task HandleAsync_WhenReaderReturnsData_ReturnsCorrespondingDto()
        {
            // Arrange
            var charactersReaderMock = new Mock<ICharactersReader>();
            charactersReaderMock.Setup(crm => crm.GetCharactersByNameAsync("Luke", It.IsAny<CancellationToken>())).ReturnsAsync(new List<Character>
            {
                new() { Name = "Luke" }
            });
            var sut = new GetCharactersHandler(charactersReaderMock.Object);

            // Act
            var dtos = await sut.HandleAsync("Luke", CancellationToken.None);

            // Assert
            dtos.Should().NotBeEmpty();
            dtos.Should().HaveCount(1);
            dtos.First().Name.Should().Be("Luke");
        }
    }
}
