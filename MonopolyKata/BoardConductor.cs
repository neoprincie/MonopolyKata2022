namespace MonopolyKata;

public class BoardConductor
{
    private Dictionary<string, int> _playerLocations;
    
    public BoardConductor(List<string> players)
    {
        _playerLocations = new Dictionary<string, int>();

        foreach (var player in players)
            _playerLocations.Add(player, 0);
    }

    public void Move(string player, int spaces)
    {
        if (_playerLocations[player] + spaces > 39)
            _playerLocations[player] = _playerLocations[player] + spaces - 40;
        else
            _playerLocations[player] += spaces;
    }

    public int GetLocation(string player)
    {
        return _playerLocations[player];
    }

    public void SetLocation(string player, int location)
    {
        _playerLocations[player] = location;
    }
}