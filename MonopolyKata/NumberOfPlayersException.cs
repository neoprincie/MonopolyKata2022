namespace MonopolyKata;

public class NumberOfPlayersException : Exception
{
    public NumberOfPlayersException() 
        : base("Wrong number of players. There should be between 2 and 8 players.")
    {
    }
}