using System;

public abstract class Player
{
    //initialize discs
    //disc representing game pieces of 'X' or 'O'
    protected internal char disc { get; }
    //constructor sets value of 'disc'
    public Player(char disc)
    {
        this.disc = disc;
    }
    //get player moves
    //declare abstract method GetMove() to be implemented by derived classes
    public abstract int GetMove();
}

//define  HumanPlayer class that inherits from 'Player'
public class HumanPlayer : Player
{
    //constructor calls the base class constructor and passes the 'disc' argument
    public HumanPlayer(char disc) : base(disc)
    {
    }

    //overrides the GetMove() method prompting player to enter number or quit
    public override int GetMove()
    {
        Console.Write("Player {0}, enter column number (1-7) or 'q' to quit the game: ", disc);
        string input = Console.ReadLine();

        if (input.ToLower() == "q")
            Environment.Exit(0);

        if (int.TryParse(input, out int column))
        {
            if (column >= 1 && column <= 7)
                return column - 1;
        }

        Console.WriteLine("Invalid move input. Please try again.");
        return GetMove(); // Recursive call to get a valid move
    }
}

public class Connect4Game
{
    public Connect4Game()
    {
        InitializeBoard();
    }

    public void PlayGame()
    {

    }

    //set all positions on the board to empty
    private void InitializeBoard()
    {

    }

    //displays current state of board
    private void PrintBoard()
    {

    }

    //drop disc in specified column and return resulting row
    private int DropDisc(int column)
    {

    }

    //check if player in the current index has won the game
    private bool CheckWin(int row, int col)
    {
        //check horizontally

        //check vertically

        //check diagonally
    }

    //checks if board is full
    private bool IsBoardFull()
    {

    }

    //sets the player discs
    private void SelectPlayers()
    {

    }
}

//instantiates the game
public class Program
{
    public static void Main(string[] args)
    {
        Connect4Game game = new Connect4Game();
        game.PlayGame();
    }
}
