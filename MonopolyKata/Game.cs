namespace MonopolyKata;

public class Game
{
    private List<string> _players;
    private readonly IDice _dice;
    
    public Game(IDice dice)
    {
        _players = new List<string>();
        
        // if (players.Count is < 2 or > 8)
        //     throw new NumberOfPlayersException();
        
        //_players = players;
        _dice = dice;
    }

    public void AddPlayer(string player)
    {
        _players.Add(player);
        
        ShufflePlayers();
    }

    public void Start()
    {
        if (_players.Count is < 2 or > 8)
            throw new NumberOfPlayersException();
    }

    public List<string> GetPlayersInOrder()
    {
        return _players;
    }
    
    private void ShufflePlayers()
    {
        var playerRolls = new List<(string, int)>();
        foreach (var p in _players)
            playerRolls.Add((p, _dice.Roll()));

        playerRolls = playerRolls.OrderByDescending(p => p.Item2).ToList();
        _players = new List<string>();

        foreach (var playerRoll in playerRolls)
            _players.Add(playerRoll.Item1);
    }
}