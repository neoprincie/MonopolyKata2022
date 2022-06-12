using FluentAssertions;
using NSubstitute;

namespace MonopolyKata.Tests;

public class GameTests
{
    private Game _game;
    private IDice _mockDice;
    
    public GameTests()
    {
        _mockDice = Substitute.For<IDice>();
        _game = new Game(_mockDice);
    }
    
    [Fact]
    public void Game_GivenHorseAndCar_TwoPlayersNamedHorseAndCar()
    {
        _game.AddPlayer("Car");
        _game.AddPlayer("Horse");

        var playersInOrder = _game.GetPlayersInOrder();

        playersInOrder.Count().Should().Be(2);
        playersInOrder.Should().Contain("Car");
        playersInOrder.Should().Contain("Horse");
    }

    [Fact]
    public void Game_GivenOnePlayer_ShouldFail()
    {
        _game.AddPlayer("Car");
    
        var exception = Assert.Throws<NumberOfPlayersException>(() => _game.Start());
    
        exception.Message.Should().Be("Wrong number of players. There should be between 2 and 8 players.");
    }
    
    [Fact]
    public void Game_GivenNinePlayers_ShouldFail()
    {
        for(var i = 0 ; i < 9; i++)
            _game.AddPlayer($"Car{i}");
    
        var exception = Assert.Throws<NumberOfPlayersException>(() => _game.Start());
    
        exception.Message.Should().Be("Wrong number of players. There should be between 2 and 8 players.");
    }

    [Fact]
    public void Game_GivenCarAndHorse_ShouldAllowForHorseAndCarOrdering()
    {
        _game.AddPlayer("Car");
        
        _mockDice.Roll().Returns(2, 3);
        _game.AddPlayer("Horse");
    
        var playersInOrder = _game.GetPlayersInOrder();
    
        playersInOrder.Count().Should().Be(2);
        playersInOrder[0].Should().Be("Horse");
        playersInOrder[1].Should().Be("Car");
    }
}