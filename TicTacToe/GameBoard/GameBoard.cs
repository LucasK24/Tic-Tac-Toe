/**
 * Represents the board for Tic-Tac-Toe. This is the model of the MVC.
 * 
 * Author: Lucas Katsanevas
 * 
 * Version 1.0 (1/15/21) - Created constructor and code skeleton.
 * Version 1.1 (1/15/21) - Implemented methods and created properties.
 */
using System;

namespace Model
{
    /// <summary>
    /// Represents a tic-tac-toe board.
    /// </summary>
    public class GameBoard
    {
        // Represents the game board, using X's for P1, O's for P2, and null ('\u0000') for empty spaces.
        private char[,] board;

        // Indicates which player's turn it is.
        private bool p1FirstTurn;
        private bool p1Turn;

        // Keeps track of the number of moves played this board.
        private int totalMoves;

        // Indicates who won the previous game. X for P1, O for P2, and null for a tie.
        private char lastResult;

        // Indicates if the game is over and play should be stopped.
        private bool gameOver;

        /// <summary>
        /// Constructs an empty game board where player 1 starts the first game.
        /// </summary>
        public GameBoard()
        {
            // Set up fields. Set p1FirstTurn to false so that it will become true from calling NewGame.
            p1FirstTurn = false;
            NewGame();
            lastResult = '\u0000';
        }

        /// <summary>
        /// Creates a new game board, giving the first move to the player that went second last game.
        /// </summary>
        public void NewGame()
        {
            board = new char[3, 3];
            gameOver = false;
            totalMoves = 0;

            // First turn alternates between games.
            p1FirstTurn = !p1FirstTurn;
            if (p1FirstTurn)
            {
                p1Turn = true;
            }
            else
            {
                p1Turn = false;
            }
        }

        /// <summary>
        /// Checks if a move is valid at the given row and column. If so, makes the move for whichever player is up.
        /// </summary>
        public bool MakeMove(int row, int col)
        {
            // If the move is invalid, do nothing.
            if (gameOver || board[row, col] != '\u0000')
            {
                return false;
            }

            // Place move on the board.
            totalMoves++;
            if (p1Turn)
            {
                board[row, col] = 'X';
            }
            else
            {
                board[row, col] = 'O';
            }

            // Check if there is a winner or a tie.
            if (WinCheck())
            {
                gameOver = true;
                if (p1Turn)
                {
                    lastResult = 'X';
                }
                else
                {
                    lastResult = 'O';
                }
            }
            else if (totalMoves > 8)
            {
                gameOver = true;
                lastResult = '\u0000';
            }

            // It's now the other player's turn.
            p1Turn = !p1Turn;
            return true;
        }

        /// <summary>
        /// Checks if the player who moved just won the game.
        /// </summary>
        /// <returns>True if the player has won, false otherwise.</returns>
        private bool WinCheck()
        {
            // Get the symbol of the player who just went.
            char move;
            if (p1Turn)
                move = 'X';
            else
                move = 'O';

            // Check all 8 rows for wins.
            if ((board[0, 0] == move && board[0, 1] == move && board[0, 2] == move)
                || (board[1, 0] == move && board[1, 1] == move && board[1, 2] == move)
                || (board[2, 0] == move && board[2, 1] == move && board[2, 2] == move)
                || (board[0, 0] == move && board[1, 0] == move && board[2, 0] == move)
                || (board[0, 1] == move && board[1, 1] == move && board[2, 1] == move)
                || (board[0, 2] == move && board[1, 2] == move && board[2, 2] == move)
                || (board[0, 0] == move && board[1, 1] == move && board[2, 2] == move)
                || (board[0, 2] == move && board[1, 1] == move && board[2, 0] == move))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns the game board's underlying matrix so that the view can be updated.
        /// </summary>
        public char[,] GetBoard()
        {
            return board;
        }
        /// <summary>
        /// Indicates who's turn it is next.
        /// </summary>
        /// <returns>True if P1's turn, false if P2's</returns>
        public bool IsP1Turn()
        {
            return p1Turn;
        }

        /// <summary>
        /// Indicates if the game is over.
        /// </summary>
        public bool IsGameOver()
        {
            return gameOver;
        }

        /// <summary>
        /// Returns 'X' if P1 won the last game, 'O' for P2, and null ('\u0000') for a tie.
        /// </summary>
        /// <returns></returns>
        public char GetResult()
        {
            return lastResult;
        }

        /// <summary>
        /// Returns the number of moves made in the current game.
        /// </summary>
        /// <returns></returns>
        public int GetTotalMoves()
        {
            return totalMoves;
        }
    }
}
