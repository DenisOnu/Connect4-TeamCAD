﻿using System;

public abstract class Player
{
    //initialize discs
    //big changes
    //get player moves
}

//define  HumanPlayer class that inherits from 'Player'
public class HumanPlayer : Player
{

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
