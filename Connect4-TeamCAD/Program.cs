using System;

public abstract class Player
{
    //initialize discs
    //big changes
    //get player moves
}

//define HumanPlayer class that inherits from 'Player'
public class HumanPlayer : Player
{

}

public class Connect4Game
{
    private char[,] board;
    private Player[] players;
    private int currentPlayerIndex;
    private bool gameOver;

    //constructor initializes the members
    public Connect4Game()
    {
        board = new char[6, 7];
        players = new Player[2];
        currentPlayerIndex = 0;
        gameOver = false;
        InitializeBoard();
    }

    public void PlayGame()
    {

    }

    //set all positions on the board to empty
    private void InitializeBoard()
    {

    }

    //displays the current state of the board
    private void PrintBoard()
    {

    }

    //drop a disc in the specified column and return the resulting row
    private int DropDisc(int column)
    {

    }

    //check if the player in the current index has won the game
    private bool CheckWin(int row, int col)
    {
        //check horizontally

        //check vertically

        //check diagonally
    }

    //check if the board is full
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
