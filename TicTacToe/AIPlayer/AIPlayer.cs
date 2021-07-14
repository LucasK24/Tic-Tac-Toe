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

        public Tuple<int,int> MakeMove(char[,] board)
        {
            // Loop until we get a valid move.
            int row;
            int col;
            while(true)
            {
                row = rand.Next(3);
                col = rand.Next(3);

                if (board[row,col] == '\u0000')
                    break;
            }
            Thread.Sleep(1000);
            return new Tuple<int, int>(row, col);
        }
    }
}
