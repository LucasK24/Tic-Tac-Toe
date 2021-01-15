/**
 * Represents the board for Tic-Tac-Toe. This is the model of the MVC.
 * 
 * Author: Lucas Katsanevas
 * 
 * Version 1.0 (1/15/20) - Created constructor and code skeleton.
 */
using System;




namespace GameBoard
{
    /// <summary>
    /// Represents a tic-tac-toe board.
    /// </summary>
    public class GameBoard
    {
        // Represents the game board, using X's for P1, O's for P2, and null ('\u0000') for empty spaces.
        private char[,] board;

        // Indicates which player's turn it is.
        private bool p1Turn;

        // Win totals of each player. 
        private int p1Wins;
        private int p2Wins;

        // Indicates if the game is over and play should be stopped.
        private bool gameOver;

        /// <summary>
        /// Constructs an empty game board where player 1 starts the first game.
        /// </summary>
        public GameBoard()
        {
            p1Turn = true;
            p1Wins = 0;
            p2Wins = 0;
            board = new char[3,3];
            gameOver = false;
        }

        /// <summary>
        /// Creates a new game board, giving the first move to the player that went second last game.
        /// </summary>
        public void NewGame()
        {

        }

        /// <summary>
        /// Checks if a move is valid. If so, makes the move for whichever player is up.
        /// </summary>
        public void MakeMove()
        {

        }

        /// <summary>
        /// Checks if the player who just moved won the game.
        /// </summary>
        /// <returns>True if the player has won, false otherwise.</returns>
        private bool WinCheck()
        {
            return true;
        }

        /// <summary>
        /// Checks if the board is full, meaning a tie occurs.
        /// </summary>
        /// <returns></returns>
        private bool BoardFullCheck()
        {
            return true;
        }
        










    }
}
