namespace MonopolyKata;

public class Game
{
    private List<string> _players;
    
    public Game(List<string> players)
    {
        _players = players;
    }

    public List<string> GetPlayersInOrder()
    {
        return _players;
    }
}