using FluentAssertions;

namespace MonopolyKata.Tests;

public class BoardConductorTests
{
    //Player on beginning location (numbered 0), rolls 7, ends up on location 7
    //Player on location numbered 39, rolls 6, ends up on location 5
    [Fact]
    public void Move_StartsAt0_Rolls7_EndsUpOn7()
    {
        var players = new List<string>() {"Car"};
        var boardConductor = new BoardConductor(players);

        boardConductor.Move("Car", 7);

        boardConductor.GetLocation("Car").Should().Be(7);
    }
    
    [Fact]
    public void Move_StartsAt39_Rolls6_EndsUpOn5()
    {
        var players = new List<string>() {"Car"};
        var boardConductor = new BoardConductor(players);

        boardConductor.SetLocation("Car", 39);
        boardConductor.Move("Car", 6);

        boardConductor.GetLocation("Car").Should().Be(5);
    }
    
    [Fact]
    public void Move_StartsAt38_Rolls2_EndsUpOn0()
    {
        var players = new List<string>() {"Car"};
        var boardConductor = new BoardConductor(players);

        boardConductor.SetLocation("Car", 38);
        boardConductor.Move("Car", 2);

        boardConductor.GetLocation("Car").Should().Be(0);
    }
}