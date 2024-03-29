﻿/**
 * Represents the board for Tic-Tac-Toe.
 * 
 * Author: Lucas Katsanevas
 * 
 * Version 1.0 (January 2021) - Created constructor and code skeleton.
 *                            - Implemented methods and created properties.
 * Version 1.1 (August 2021)  - Added GetTotalMoves method and made a BoardMatrix property.           
 */
using System;

namespace Model
{
    /// <summary>
    /// Represents a tic-tac-toe board and is the model of the project.
    /// </summary>
    public class GameBoard
    {
        /// <summary>
        /// Property representing the game board, using X's for P1,
        /// O's for P2, and null ('\u0000') for empty spaces.
        /// </summary>
        public char[,] BoardMatrix
        {
            get; private set;
        }

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
            BoardMatrix = new char[3, 3];
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
            if (gameOver || BoardMatrix[row, col] != '\u0000')
            {
                return false;
            }

            // Place move on the board.
            totalMoves++;
            if (p1Turn)
            {
                BoardMatrix[row, col] = 'X';
            }
            else
            {
                BoardMatrix[row, col] = 'O';
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
            if ((BoardMatrix[0, 0] == move && BoardMatrix[0, 1] == move && BoardMatrix[0, 2] == move)
                || (BoardMatrix[1, 0] == move && BoardMatrix[1, 1] == move && BoardMatrix[1, 2] == move)
                || (BoardMatrix[2, 0] == move && BoardMatrix[2, 1] == move && BoardMatrix[2, 2] == move)
                || (BoardMatrix[0, 0] == move && BoardMatrix[1, 0] == move && BoardMatrix[2, 0] == move)
                || (BoardMatrix[0, 1] == move && BoardMatrix[1, 1] == move && BoardMatrix[2, 1] == move)
                || (BoardMatrix[0, 2] == move && BoardMatrix[1, 2] == move && BoardMatrix[2, 2] == move)
                || (BoardMatrix[0, 0] == move && BoardMatrix[1, 1] == move && BoardMatrix[2, 2] == move)
                || (BoardMatrix[0, 2] == move && BoardMatrix[1, 1] == move && BoardMatrix[2, 0] == move))
            {
                return true;
            }
            return false;
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
