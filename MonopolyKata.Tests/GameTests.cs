using FluentAssertions;

namespace MonopolyKata.Tests;

public class GameTests
{
    [Fact]
    public void Game_GivenHorseAndCar_TwoPlayersNamedHorseAndCar()
    {
        var players = new List<string>() {"Car", "Horse"};
        var game = new Game(players);

        var playersInOrder = game.GetPlayersInOrder();

        playersInOrder.Count().Should().Be(2);
        playersInOrder.Should().Contain("Car");
        playersInOrder.Should().Contain("Horse");
    }

    [Fact]
    public void Game_GivenOnePlayer_ShouldFail()
    {
        var players = new List<string>() {"Car"};

        var exception = Assert.Throws<NumberOfPlayersException>(() => new Game(players));

        exception.Message.Should().Be("Wrong number of players. There should be between 2 and 8 players.");
    }
}