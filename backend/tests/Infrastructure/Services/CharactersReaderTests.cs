using FluentAssertions;
using Moq;
using StarWars_Cyclopedia.Application.Interfaces;
using StarWars_Cyclopedia.Infrastructure.Services;

namespace StarWars_Cyclopedia.Tests.Infrastructure.Services
{
    public class CharactersReaderTests
    {
        [Fact]
        public async Task GetCharactersByNameAsync_WhenSwapiHasNoCharacters_ReturnsEmptyList()
        {
            // Arrange
            var characterName = "Luke";
            var httpClientWrapperMock = new Mock<IHttpClientWrapper>();
            httpClientWrapperMock.Setup(hcw => hcw.GetCharactersAsync(characterName, It.IsAny<CancellationToken>())).ReturnsAsync([]);
            var sut = new CharactersReader(httpClientWrapperMock.Object);

            // Act
            var characters = await sut.GetCharactersByNameAsync(characterName, CancellationToken.None);

            // Assert
            characters.Should().BeEmpty();
        }

        [Fact]
        public async Task GetCharactersByNameAsync_WhenCharacterNameIsNotFound_ReturnsEmptyList()
        {
            // Arrange
            var characterName = "Luke";
            var httpClientWrapperMock = new Mock<IHttpClientWrapper>();
            httpClientWrapperMock.Setup(hcw => hcw.GetCharactersAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(
            [
                new() {Name = "Chewaka"}
            ]);
            var sut = new CharactersReader(httpClientWrapperMock.Object);

            // Act
            var characters = await sut.GetCharactersByNameAsync(characterName, CancellationToken.None);

            // Assert
            characters.Should().BeEmpty();
        }

        [Theory]
        [InlineData("Luke")]
        [InlineData("luke")]
        public async Task GetCharactersByNameAsync_WhenCharacterNameIsFound_ReturnsCharacter(string characterName)
        {
            // Arrange
            var httpClientWrapperMock = new Mock<IHttpClientWrapper>();
            httpClientWrapperMock.Setup(hcw => hcw.GetCharactersAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(
            [
                new() {Name = "Luke"}
            ]);
            var sut = new CharactersReader(httpClientWrapperMock.Object);

            // Act
            var characters = await sut.GetCharactersByNameAsync(characterName, CancellationToken.None);

            // Assert
            characters.Should().NotBeEmpty();
        }
    }
}
