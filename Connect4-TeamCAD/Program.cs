using System;

//setup base class for the players
public abstract class Player
{
    //disc representing game pieces of 'X' or 'O'
    protected internal char disc { get; }

    //constructor sets value of 'disc'
    public Player(char disc)
    {
        this.disc = disc;
    }
    //declare abstract method GetMove() to be implemented by derived classes
    public abstract int GetMove();
}

//define HumanPlayer class that inherits from 'Player'
public class HumanPlayer : Player
{
    //constructor calls the base class constructor and passes the 'disc' argument
    public HumanPlayer(char disc) : base(disc)
    {
    }

    //overrides the GetMove() method prompting player to enter number or quit
    public override int GetMove()
    {
        Console.Write("Enter column number (1-7) or 'q' to quit the game: ");
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

//define ComputerPlayer inheriting from 'Player' class
public class ComputerPlayer : Player
{
    private Random random;
    //intialize Random to generate random moves for AI player
    //constructor initializes this random object
    public ComputerPlayer(char disc) : base(disc)
    {
        random = new Random();
    }

    //GetMove() method returns a random column number between 0 and 6
    public override int GetMove()
    {
        return random.Next(0, 7);
    }
}

//defining game logic
public class Connect4Game
{
    //define private members
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
        Console.WriteLine("Team CAD welcomes you play Connect 4!");
        Console.WriteLine("Player 1: X");
        Console.WriteLine("Player 2: O");
        Console.WriteLine();

        SelectPlayers();
        
        //loops until 'gameOver' is true
        while (!gameOver)
        {
            PrintBoard();
            Player currentPlayer = players[currentPlayerIndex];
            Console.WriteLine($"Player {currentPlayerIndex + 1}'s turn:");
            int column = currentPlayer.GetMove();

            if (column == -1)
                continue;

            int row = DropDisc(column);
            if (row == -1)
            {
                Console.WriteLine("Invalid move. Please try again.");
                continue;
            }

            if (CheckWin(row, column))
            {
                PrintBoard();
                Console.WriteLine($"Player {currentPlayerIndex + 1} wins! Congratulations!!!");
                gameOver = true;
            }
            else if (IsBoardFull())
            {
                PrintBoard();
                Console.WriteLine("It's a draw!");
                gameOver = true;
            }
            else
            {
                currentPlayerIndex = (currentPlayerIndex == 0) ? 1 : 0;
            }
        }

        Console.WriteLine("Game Over!");
    }

    //set all positions on the board to empty
    private void InitializeBoard()
    {
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                board[row, col] = ' ';
            }
        }
    }

    //displays the current state of the board
    private void PrintBoard()
    {
        for (int row = 5; row >= 0; row--)
        {
            for (int col = 0; col < 7; col++)
            {
                Console.Write($"| {board[row, col]} ");
            }
            Console.WriteLine("|");
        }
        Console.WriteLine("-----------------------------");
        Console.WriteLine("  1   2   3   4   5   6   7  ");
    }

    //drop a disc in the specified column and return the resulting row
    private int DropDisc(int column)
    {
        for (int row = 0; row < 6; row++)
        {
            if (board[row, column] == ' ')
            {
                board[row, column] = players[currentPlayerIndex].disc;
                return row;
            }
        }

        return -1;
    }

    //check if the player in the current index has won the game
    private bool CheckWin(int row, int col)
    {
        char playerSymbol = players[currentPlayerIndex].disc;

        // Check horizontally
        int count = 0;
        for (int c = 0; c < 7; c++)
        {
            if (board[row, c] == playerSymbol)
            {
                count++;
                if (count == 4)
                    return true;
            }
            else
            {
                count = 0;
            }
        }

        // Check vertically
        count = 0;
        for (int r = 0; r < 6; r++)
        {
            if (board[r, col] == playerSymbol)
            {
                count++;
                if (count == 4)
                    return true;
            }
            else
            {
                count = 0;
            }
        }

        // Check diagonally (from top-left to bottom-right)
        int startRow = row - Math.Min(row, col);
        int startCol = col - Math.Min(row, col);
        count = 0;
        for (int i = 0; i < 6; i++)
        {
            if (startRow + i < 6 && startCol + i < 7 && board[startRow + i, startCol + i] == playerSymbol)
            {
                count++;
                if (count == 4)
                    return true;
            }
            else
            {
                count = 0;
            }
        }

        // Check diagonally (from top-right to bottom-left)
        startRow = row + Math.Min(5 - row, col);
        startCol = col - Math.Min(5 - row, col);
        count = 0;
        for (int i = 0; i < 6; i++)
        {
            if (startRow - i >= 0 && startCol + i < 7 && board[startRow - i, startCol + i] == playerSymbol)
            {
                count++;
                if (count == 4)
                    return true;
            }
            else
            {
                count = 0;
            }
        }

        return false;
    }

    //check if the board is full
    private bool IsBoardFull()
    {
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                if (board[row, col] == ' ')
                    return false;
            }
        }

        return true;
    }

    //sets the player discs
    private void SelectPlayers()
    {
        Console.WriteLine("Select an opponent:");
        Console.WriteLine("1. Play against another human");
        Console.WriteLine("2. Play against AI");
        Console.Write("Enter your choice (1-2): ");

        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
        {
            Console.WriteLine("Invalid choice. Please try again.");
            Console.Write("Enter your choice (1-2): ");
        }

        if (choice == 1)
        {
            players[0] = new HumanPlayer('X');
            players[1] = new HumanPlayer('O');
        }
        else
        {
            players[0] = new HumanPlayer('X');
            players[1] = new ComputerPlayer('O');
        }
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
