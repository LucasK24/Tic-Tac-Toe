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
        private Dictionary<int, Tuple<Tuple<int,int>, Tuple<int, int>, Tuple<int, int>>> allRows;

        /// <summary>
        /// 
        /// </summary>
        public AIPlayer(string difficultyLevel)
        {
            difficulty = difficultyLevel;
            rand = new Random();

            // Add the 8 different "rows" to win.
            allRows[0] = new Tuple<int, int>;
            allRows[1] = ;
            allRows[2] = ;
            allRows[3] = ;
            allRows[4] = ;
            allRows[5] = ;
            allRows[6] = ;
            allRows[7] = ;
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
        /// Will make a winning move if there is one and will block losses if possible.
        /// Otherwise, makes a random move.
        /// </summary>
        /// <param name="board"></param>
        /// <returns>A tuple of the column-row pair</returns>
        private Tuple<int, int> MakeHardMove(char[,] board)
        {
            // Check all 8 rows/cols/diagonals for ways to win now, returning the winning move if there is one.
            Tuple<int, int> winningMove = PossibleWinCheck(board, 'O');
            if (winningMove != null)
                return winningMove;

            // Check if there is a way to lose when the human player goes next, Making that move if there is one.
            Tuple<int, int> losingMove = PossibleWinCheck(board, 'X');
            if (losingMove != null)
                return losingMove;


            // Otherwise, make a random move.
            return MakeEasyMove(board);
        }

        /// <summary>
        /// Checks if the input letter (X or O) has any possible moves to win. For the AI, 
        /// passing in an 'O' will check for the AI's winning moves, while passing
        /// in an 'X' will check for winning moves of the human player that the AI
        /// can block.
        /// </summary>
        /// <param name="board"></param>
        /// <returns>A Tuple<int,int> of the winning move, null if there isn't one.</returns>
        private Tuple<int, int> PossibleWinCheck(char[,] board, char letter)
        {
            List<Tuple<Tuple<int, int>, Tuple<int, int>, Tuple<int, int>>> WinningMoves = new List<Tuple<Tuple<int, int>, Tuple<int, int>, Tuple<int, int>>>();
            List<Tuple<Tuple<int, int>, Tuple<int, int>, Tuple<int, int>>> LosingMoves = new List<Tuple<Tuple<int, int>, Tuple< int, int>, Tuple<int,int>>> ();
            // Check each possible row/col/diagonal for a win/loss. If there is one, add to winning or losing move list.
            CheckRow(board[0, 0], board[0, 1], board[0, 2], WinningMoves, LosingMoves);


            // CheckRow could now be: CheckRow(*rowID*, board);

            //.....
            return CompleteRow(board[0, 0], board[0, 1], board[0, 2]);
            if (CheckRow(board[2, 0], board[2, 1], board[2, 2]))
                return CompleteRow(board[2, 0], board[2, 1], board[2, 2]);
            if (CheckRow(board[0, 0], board[1, 0], board[2, 0]))
                return CompleteRow(board[0, 0], board[1, 0], board[2, 0]);
            if (CheckRow(board[0, 1], board[1, 1], board[2, 1]))
                return CompleteRow(board[0, 1], board[1, 1], board[2, 1]);
            if (CheckRow(board[0, 1], board[1, 1], board[2, 1]))
                return CompleteRow(board[0, 1], board[1, 1], board[2, 1]);
            if (CheckRow(board[0, 2], board[1, 2], board[2, 2]))
                return CompleteRow(board[0, 2], board[1, 2], board[2, 2]);
            if (CheckRow(board[0, 2], board[1, 1], board[2, 0]))
                return CompleteRow(board[0, 2], board[1, 1], board[2, 0]);
            if (CheckRow(board[0, 0], board[1, 1], board[2, 2]))
                return CompleteRow(board[0, 0], board[1, 1], board[2, 2]);


            // Get a move from the winning list, if any.
            if (WinningMoves.Count != 0)
            {
                int move = rand.Next(WinningMoves.Count);
                return CompleteRow(....);
            }

            // If there are no winning moves, block a loss from happening if possible.
            if (LosingMoves.Count != 0)
            {
                int move = rand.Next(LosingMoves.Count);
                return CompleteRow(....);
            }

            // Otherwise return a random move.
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
        private void CheckRow(char first, char second, char third, int rowID, List<int> WinningMoves, List<int> LosingMoves)
        {
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

            // Instead: return number corresponding to the correct row.
            if (OCounter == 2 && XCounter == 0)
                WinningMoves.Add(rowID);

            if (XCounter == 2 && OCounter == 0)
                LosingMoves.Add(rowID);
        }

        /// <summary>
        /// Returns the open move in this row, if there is one. Returns null otherwise.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="third"></param>
        /// <returns></returns>
        private Tuple<int, int> CompleteRow(char first, char second, char third)
        {
            if (first == '\u0000')
                return first;
            else if
            else if
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
            return null;
        }


    }
}
