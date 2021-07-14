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
        /// <returns></returns>
        public Tuple<int,int> MakeMove(char[,] board)
        {
            if (difficulty == "Easy")
                return MakeEasyMove(board);
            if (difficulty == "Hard")
                return MakeHardMove(board);
            MakeImpossibleMove(board);
        }

        /// <summary>
        /// Makes a random move on the board.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
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
        /// <returns></returns>
        private Tuple<int, int> MakeHardMove(char[,] board)
        {
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
