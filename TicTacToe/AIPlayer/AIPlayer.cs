/*
 *
 *
 *
 */

using System;
using System.Collections.Generic;
using System.Threading;

namespace CPUPlayer
{
    /// <summary>
    /// 
    /// </summary>
    public class AIPlayer
    {
        // Represents difficulty level ("easy", "hard", or "impossible")
        private string difficulty;

        // Random generator for picking moves.
        private Random rand;

        // Dictionary mapping rowID to tuples of board row/column/diagonal.
        private Dictionary<int, List<Tuple<int, int>>> allRows;

        /// <summary>
        /// Creates an AI player with the input difficulty level. May be "Easy", "Hard", or "Impossible.
        /// </summary>
        public AIPlayer(string difficultyLevel)
        {
            difficulty = difficultyLevel;
            rand = new Random();
            allRows = new Dictionary<int, List<Tuple<int, int>>>();

            // Add the 8 different "rows" to the allRows dictionary.
            allRows[0] = new List<Tuple<int, int>>();
            allRows[0].Add(new Tuple<int, int>(0, 0));
            allRows[0].Add(new Tuple<int, int>(0, 1));
            allRows[0].Add(new Tuple<int, int>(0, 2));

            allRows[1] = new List<Tuple<int, int>>();
            allRows[1].Add(new Tuple<int, int>(1, 0));
            allRows[1].Add(new Tuple<int, int>(1, 1));
            allRows[1].Add(new Tuple<int, int>(1, 2));

            allRows[2] = new List<Tuple<int, int>>();
            allRows[2].Add(new Tuple<int, int>(2, 0));
            allRows[2].Add(new Tuple<int, int>(2, 1));
            allRows[2].Add(new Tuple<int, int>(2, 2));

            allRows[3] = new List<Tuple<int, int>>();
            allRows[3].Add(new Tuple<int, int>(0, 0));
            allRows[3].Add(new Tuple<int, int>(1, 0));
            allRows[3].Add(new Tuple<int, int>(2, 0));

            allRows[4] = new List<Tuple<int, int>>();
            allRows[4].Add(new Tuple<int, int>(0, 1));
            allRows[4].Add(new Tuple<int, int>(1, 1));
            allRows[4].Add(new Tuple<int, int>(2, 1));

            allRows[5] = new List<Tuple<int, int>>();
            allRows[5].Add(new Tuple<int, int>(0, 2));
            allRows[5].Add(new Tuple<int, int>(1, 2));
            allRows[5].Add(new Tuple<int, int>(2, 2));

            allRows[6] = new List<Tuple<int, int>>();
            allRows[6].Add(new Tuple<int, int>(0, 2));
            allRows[6].Add(new Tuple<int, int>(1, 1));
            allRows[6].Add(new Tuple<int, int>(2, 0));

            allRows[7] = new List<Tuple<int, int>>();
            allRows[7].Add(new Tuple<int, int>(0, 0));
            allRows[7].Add(new Tuple<int, int>(1, 1));
            allRows[7].Add(new Tuple<int, int>(2, 2));
        }

        /// <summary>
        /// Make a move based on the difficulty level.
        /// </summary>
        /// <param name="board"></param>
        /// <returns> A tuple of the column, row pair.</returns>
        public Tuple<int, int> MakeMove(char[,] board)
        {
            if (difficulty == "Easy")
                return MakeEasyMove(board);
            if (difficulty == "Hard")
                return MakeHardMove(board);
            return MakeImpossibleMove(board);
        }

        /// <summary>
        /// Makes a random move on the board.
        /// </summary>
        /// <param name="board"></param>
        /// <returns>A tuple of the column-row pair. </returns>
        private Tuple<int, int> MakeEasyMove(char[,] board)
        {
            // Loop until we get a valid move.
            int row;
            int col;
            while (true)
            {
                row = rand.Next(3);
                col = rand.Next(3);

                if (board[row, col] == '\u0000')
                    break;
            }
            return new Tuple<int, int>(row, col);
        }

        /// <summary>
        /// Will make a winning move if there is one and will block losses from occuring if possible.
        /// Otherwise, makes a random move.
        /// </summary>
        /// <param name="board"></param>
        /// <returns>A tuple of the AI's move (a column-row pair)</returns>
        private Tuple<int, int> MakeHardMove(char[,] board)
        {
            // Lists that keep track of the RowIDs of winning moves to make or losing moves to block.
            List<int> WinningMoves = new List<int>();
            List<int> LosingMoves = new List<int>();

            // Check each possible row/col/diagonal for a win/loss. If there is one, add to winning or losing move list.
            CheckRow(board, 0, WinningMoves, LosingMoves); // RowID: 0
            CheckRow(board, 1, WinningMoves, LosingMoves); // RowID: 1
            CheckRow(board, 2, WinningMoves, LosingMoves); // ....           
            CheckRow(board, 3, WinningMoves, LosingMoves);
            CheckRow(board, 4, WinningMoves, LosingMoves);
            CheckRow(board, 5, WinningMoves, LosingMoves);
            CheckRow(board, 6, WinningMoves, LosingMoves);
            CheckRow(board, 7, WinningMoves, LosingMoves);

            // Get a move from the winning list, if any.
            if (WinningMoves.Count != 0)
            {
                int move = rand.Next(WinningMoves.Count);
                return CompleteRow(board, WinningMoves[move]);
            }

            // If there are no winning moves, block a loss from happening if possible.
            if (LosingMoves.Count != 0)
            {
                int move = rand.Next(LosingMoves.Count);
                return CompleteRow(board, LosingMoves[move]);
            }

            // Otherwise make a random move.
            return MakeEasyMove(board);
        }

        /// <summary>
        /// Uses counters for 'X's and 'O's to see if this row/column/diagonal has a winning move for either player.
        /// Adds to the correct list the rowID if so.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="third"></param>
        /// <param name="rowID"></param>
        /// <param name="WinningMoves"></param>
        /// <param name="LosingMoves"></param>
        private void CheckRow(char[,] board, int rowID, List<int> WinningMoves, List<int> LosingMoves)
        {
            // Based on the rowID, get the current state of each slot in the row.
            char first = board[allRows[rowID][0].Item1, allRows[rowID][0].Item2];
            char second = board[allRows[rowID][1].Item1, allRows[rowID][1].Item2];
            char third = board[allRows[rowID][2].Item1, allRows[rowID][2].Item2];

            // Count the number of 'X's and 'O's in the row.
            int OCounter = 0;
            int XCounter = 0;
            if (first == 'O')
                OCounter++;
            else if (first == 'X')
                XCounter++;

            if (second == 'O')
                OCounter++;
            else if (second == 'X')
                XCounter++;

            if (third == 'O')
                OCounter++;
            else if (third == 'X')
                XCounter++;

            // Add rowID to Winning or LosingMoves list based on if there is a winning move for either player.
            if (OCounter == 2 && XCounter == 0)
                WinningMoves.Add(rowID);
            else if (XCounter == 2 && OCounter == 0)
                LosingMoves.Add(rowID);
        }

        /// <summary>
        /// Returns the open move in this row, if there is one. Returns null otherwise. This is intended to only be used
        /// to complete a row (i.e. when there are two X's or O's and an empty spot).
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="third"></param>
        /// <returns></returns>
        private Tuple<int, int> CompleteRow(char[,] board, int rowID)
        {
            // Get all positions from the rowID.
            Tuple<int, int> first = new Tuple<int, int>(allRows[rowID][0].Item1, allRows[rowID][0].Item2);
            Tuple<int, int> second = new Tuple<int, int>(allRows[rowID][1].Item1, allRows[rowID][1].Item2);
            Tuple<int, int> third = new Tuple<int, int>(allRows[rowID][2].Item1, allRows[rowID][2].Item2);

            // Get the moves from each position.
            char firstChar = board[allRows[rowID][0].Item1, allRows[rowID][0].Item2];
            char secondChar = board[allRows[rowID][1].Item1, allRows[rowID][1].Item2];
            char thirdChar = board[allRows[rowID][2].Item1, allRows[rowID][2].Item2];

            // Return the empty one.
            if (firstChar == '\u0000')
                return first;
            else if (secondChar == '\u0000')
                return second;
            else if (thirdChar == '\u0000')
                return third;
            else
                return null;
        }







        /// <summary>
        /// Performs moves so that it is impossible to lose...... 
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        private Tuple<int, int> MakeImpossibleMove(char[,] board)
        {
            // Check if this is the opening move to be made...
            // i.e. if(....)
            // Similarly, check if this is the second move (opening AI move)


            // Check if there is a winning move possible, then if there is a losing move to be blocked (may need to change CheckRow/MakeHardMove to account for this).
            //CheckRow(..);

            // See if a forking situation can occur. We may be able to do this using a dummy table and calling CheckRow to see if 2 different ways to win pop up.

            // If a forking situation cannot occur, check if we can block a fork from occuring in a similar fashion.

            // Otherwise, play: center, opposite corner, empty corner, empty side.
            




            return null;
        }


    }
}
