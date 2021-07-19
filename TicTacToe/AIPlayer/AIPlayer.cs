/*
 *
 *
 *
 */

using System;
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
        private Random rand;

        /// <summary>
        /// 
        /// </summary>
        public AIPlayer(string difficultyLevel)
        {
            difficulty = difficultyLevel;
            rand = new Random();
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
            // If winning move....
            // Check all 8 rows for ways to win now.
            PossibleWinCheck(board);
            if ((board[0, 0] == 'O' && board[0, 1] == 'O' && board[0, 2] == '\u0000')
                || (board[1, 0] == 'O' && board[1, 1] == 'O' && board[1, 2] == 'O')
                || (board[2, 0] == 'O' && board[2, 1] == 'O' && board[2, 2] == 'O')
                || (board[0, 0] == 'O' && board[1, 0] == 'O' && board[2, 0] == 'O')
                || (board[0, 1] == 'O' && board[1, 1] == 'O' && board[2, 1] == 'O')
                || (board[0, 2] == 'O' && board[1, 2] == 'O' && board[2, 2] == 'O')
                || (board[0, 0] == 'O' && board[1, 1] == 'O' && board[2, 2] == 'O')
                || (board[0, 2] == 'O' && board[1, 1] == 'O' && board[2, 0] == 'O'))
            {
                return new Tupple<int, int>(0, 0);
            }

            // If losing move to block....

            return MakeEasyMove(board);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        private Tuple<int, int> PossibleWinCheck(char[,] board)
        {

            int OCounter = 0;
            int XCounter = 0;

            CheckRow(board[0, 0], board[0, 1], board[0, 2]);
            // Do CheckRow for the rest.....
            if ((board[0, 0] == 'O' && board[0, 1] == 'O' && board[0, 2] == '\u0000')

                || (board[1, 0] == 'O' && board[1, 1] == 'O' && board[1, 2] == 'O')
                || (board[2, 0] == 'O' && board[2, 1] == 'O' && board[2, 2] == 'O')
                || (board[0, 0] == 'O' && board[1, 0] == 'O' && board[2, 0] == 'O')
                || (board[0, 1] == 'O' && board[1, 1] == 'O' && board[2, 1] == 'O')
                || (board[0, 2] == 'O' && board[1, 2] == 'O' && board[2, 2] == 'O')
                || (board[0, 0] == 'O' && board[1, 1] == 'O' && board[2, 2] == 'O')
                || (board[0, 2] == 'O' && board[1, 1] == 'O' && board[2, 0] == 'O'))
            {
                return new Tuple<int, int>(0, 0);
            }
            {
                return new Tuple<int, int>(0, 0);
            }
            return null;
        }

        /// <summary>
        /// Fill in!!!!
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private bool CheckRow(char first, char second, char third)
        {
            int OCounter = 0;
            int XCounter = 0;
            if (a == 'O')
                OCounter++;
            else if (a == 'X')
                XCounter++;

            if (b == 'O')
                OCounter++;
            else if (b == 'X')
                XCounter++;

            if (c == 'O')
                OCounter++;
            else if (c == 'X')
                XCounter++;

            // Find the empty space if O Counter is 2 and X counter is 0.
            if (OCounter == 2 && XCounter == 0)
                return 

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
