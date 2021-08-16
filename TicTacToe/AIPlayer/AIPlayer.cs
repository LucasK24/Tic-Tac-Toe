/*
 * Represents an AI player for easy, hard, and impossible difficulties.
 * 
 * Author: Lucas Katsanevas
 * 
 * Version 1.0 (July 2021)  - Created constructor and easy mode.
 *                          - Made hard mode and its helper methods.
 * Version 1.1 (August 2021)- Made skeleton code for impossible and its random spot choosing methods.
 *                          - Implemented 1st, 2nd, and 3rd move methods.
 *                          - Created forking and blocking forks logic.
 *                          - Various bug fixes.                         
 */

using System;
using System.Collections.Generic;
using System.Threading;
using Model;

namespace CPUPlayer
{
    /// <summary>
    /// An AI player of one of three difficulties. An "Easy" AI makes random moves,
    /// a "Hard" AI makes winning moves and blocks opponent winning moves from occuring, and
    /// an "Impossible" AI will always win or tie.
    /// </summary>
    public class AIPlayer
    {
        // Represents difficulty level ("Easy", "Hard", or "Impossible")
        private string difficulty;

        // Random generator for picking between moves.
        private Random rand;

        // Dictionary mapping rowID to tuples of board row/column/diagonal.
        private Dictionary<int, List<Tuple<int, int>>> allRows;

        // Lists of corner and side spaces for easy access.
        private List<Tuple<int, int>> corners;
        private List<Tuple<int, int>> sides;
        private readonly Tuple<int, int> center;

        /// <summary>
        /// Creates an AI player with the input difficulty level. May be "Easy", "Hard", or "Impossible".
        /// </summary>
        public AIPlayer(string difficultyLevel)
        {
            difficulty = difficultyLevel;
            rand = new Random();
            allRows = new Dictionary<int, List<Tuple<int, int>>>();

            // Put all corner and side lists into the correct lists.
            corners = new List<Tuple<int, int>>();
            corners.Add(new Tuple<int, int>(0, 0));
            corners.Add(new Tuple<int, int>(0, 2));
            corners.Add(new Tuple<int, int>(2, 0));
            corners.Add(new Tuple<int, int>(2, 2));

            sides = new List<Tuple<int, int>>();
            sides.Add(new Tuple<int, int>(0, 1));
            sides.Add(new Tuple<int, int>(1, 0));
            sides.Add(new Tuple<int, int>(1, 2));
            sides.Add(new Tuple<int, int>(2, 1));
            sides[1] = new Tuple<int, int>(33, 3);

            center = new Tuple<int, int>(1, 1);

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
        public Tuple<int, int> MakeMove(GameBoard gameBoard)
        {
            if (difficulty == "Easy")
                return MakeEasyMove(gameBoard.BoardMatrix);
            if (difficulty == "Hard")
                return MakeHardMove(gameBoard.BoardMatrix);
            return MakeImpossibleMove(gameBoard);
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
        /// <returns>A tuple of the AI's move (column-row pair)</returns>
        private Tuple<int, int> MakeHardMove(char[,] board)
        {
            Tuple<int, int> result = GetWinningOrLosingMove(board);
            if (result != null)
                return result;
            return MakeEasyMove(board);
        }



        /// <summary>
        /// Helper for making a winning move if there is one or blocking a loss from occuring if possible. Returns
        /// a tuple of the move or null if neither such move exists.
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        private Tuple<int, int> GetWinningOrLosingMove(char[,] board)
        {
            // Lists that keep track of the RowIDs of winning moves to make or losing moves to block.
            List<int> WinningMoves = new List<int>();
            List<int> LosingMoves = new List<int>();

            // Check each possible row/col/diagonal for a win/loss. If there is one, add to winning or losing move list.
            for (int rowID = 0; rowID < 8; rowID++)
                CheckRow(board, rowID, WinningMoves, LosingMoves);

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

            return null;
        }

        /// <summary>
        /// Uses counters for 'X's and 'O's to see if this row/column/diagonal has a winning move for either player.
        /// Adds the rowID to the correct list if so.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="third"></param>
        /// <param name="rowID"></param>
        /// <param name="AIWinningRows"></param>
        /// <param name="HumanWinningRows"></param>
        private void CheckRow(char[,] board, int rowID, List<int> AIWinningRows, List<int> HumanWinningRows)
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

            // Add rowID to a list based on if there is a winning move for either player.
            if (OCounter == 2 && XCounter == 0)
                AIWinningRows.Add(rowID);
            else if (XCounter == 2 && OCounter == 0)
                HumanWinningRows.Add(rowID);
        }

        /// <summary>
        /// Returns the open move in this row if there is one, null otherwise. This is intended to only be used
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
        /// Performs an "impossible" to beat move. If the AI uses this for all of its moves, it will be guaranteed
        /// to tie. 
        /// </summary>
        /// <param name="board"></param>
        /// <returns>A Tuple of the best move available move. Returns null if board is full.</returns>
        private Tuple<int, int> MakeImpossibleMove(GameBoard gameBoard)
        {
            char[,] board = gameBoard.BoardMatrix;

            // Check if this is the AI's opening move.
            if (gameBoard.GetTotalMoves() == 0)
                return MakeFirstMove(board);
            if (gameBoard.GetTotalMoves() == 1)
                return MakeSecondMove(board);

            // In certain situations, the third move will need to be made in a specific spot to set a fork up.
            Tuple<int, int> move = null;
            if (gameBoard.GetTotalMoves() == 2)
                move = MakeThirdMove(board);
            if (move != null)
                return move;

            // Check if there is a winning move, then if there is a losing move to block.
            move = GetWinningOrLosingMove(board);
            if (move != null)
                return move;


            // See if we can create a fork (two ways to win next turn).
            move = GetForkingMove(board);
            if (move != null)
                return move;

            // Check if we can block an opponent from creating a fork on their next turn (this may involve forcing opponent to block us from getting 3 in a row).
            move = BlockForkingMove(board);
            if (move != null)
                return move;

            // Otherwise, play (in this order): center, opposite corner (if opponent in a corner), empty corner, or empty side.
            if (board[1, 1] == '\u0000')
                return center;

            move = GetRandomOppositeCorner(board);
            if (move != null)
                return move;

            if (board[0, 0] == '\u0000' || board[0, 2] == '\u0000' || board[2, 0] == '\u0000' || board[2, 2] == '\u0000')
                return PickRandomCorner(board);

            return PickRandomSide(board);
        }

        /// <summary>
        /// Makes the opening move. It should either be a corner or the middle.
        /// </summary>
        /// <param name="board"></param>
        /// <returns>A tuple of the row-column pair</returns>
        private Tuple<int, int> MakeFirstMove(char[,] board)
        {
            // Randomly choose a corner or the middle spot with equal probability for each spot.
            int nextMove = rand.Next(5);
            if (nextMove == 0)
                return center;
            else
                return PickRandomCorner(board);
        }

        /// <summary>
        /// Makes the second move of the game for the AI.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        private Tuple<int, int> MakeSecondMove(char[,] board)
        {
            // If the player is in the center, play a corner
            if (board[1, 1] == 'X')
                return PickRandomCorner(board);

            // If the player is in a corner, play center.
            if (board[0, 0] == 'X' || board[0, 2] == 'X' || board[2, 0] == 'X' || board[2, 2] == 'X')
                return center;

            // If the player chose a side: play the center, a corner beside it, or the side across from it.
            return SecondMoveFollowingSide(board);
        }

        /// <summary>
        /// Helper method to make a move after the first move is a side move.
        /// With equal probabilities, this will choose between the side across from
        /// it, the center, or one of the corners beside it.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        private Tuple<int, int> SecondMoveFollowingSide(char[,] board)
        {
            int randNum = rand.Next(4);

            // Let 0 represent the center.
            if (randNum == 0)
                return center;

            // Let 1 be for the side across from it.
            if (randNum == 1)
            {
                if (board[1, 0] == 'X')
                    return new Tuple<int, int>(1, 2);
                else if (board[0, 1] == 'X')
                    return new Tuple<int, int>(2, 1);
                else if (board[2, 1] == 'X')
                    return new Tuple<int, int>(0, 1);
                else
                    return new Tuple<int, int>(1, 0);
            }

            // Let 2 and 3 represent the corners beside it. First, store the correct side.
            Tuple<int, int> spot = null;
            if (board[1, 0] == 'X')
                spot = new Tuple<int, int>(1, 0);
            else if (board[0, 1] == 'X')
                spot = new Tuple<int, int>(0, 1);
            else if (board[2, 1] == 'X')
                spot = new Tuple<int, int>(2, 1);
            else
                spot = new Tuple<int, int>(1, 2);

            // Now, adjust 1 space from spot to get one of the correct corners.
            if (randNum == 2)
            {
                if (spot.Item1 == 1)
                    return new Tuple<int, int>(2, spot.Item2);
                else
                    return new Tuple<int, int>(spot.Item1, 2);
            }
            else
            {
                if (spot.Item1 == 1)
                    return new Tuple<int, int>(0, spot.Item2);
                else
                    return new Tuple<int, int>(spot.Item1, 0);
            }


        }

        /// <summary>
        /// Makes a specific third move for the AI if it needed. Otherwise, returns null.
        /// </summary>
        /// <param name="board"></param>
        /// <returns>A Tuple of the move.</returns>
        private Tuple<int, int> MakeThirdMove(char[,] board)
        {
            // If we're in a corner and opponent is in middle, play the opposite corner.
            if (board[1, 1] == 'X')
            {
                if (board[0, 0] == 'O')
                    return new Tuple<int, int>(2, 2);
                if (board[0, 2] == 'O')
                    return new Tuple<int, int>(2, 0);
                if (board[2, 0] == 'O')
                    return new Tuple<int, int>(0, 2);
                if (board[2, 2] == 'O')
                    return new Tuple<int, int>(0, 0);
                return null;
            }

            // Play any corner if both moves are in corners.
            if (board[0, 0] == 'X' || board[0, 2] == 'X' || board[2, 0] == 'X' || board[2, 2] == 'X')
                if (board[0, 0] == 'O' || board[0, 2] == 'O' || board[2, 0] == 'O' || board[2, 2] == 'O')
                    return PickRandomCorner(board);

            // Continue the algorithm otherwise.
            return null;
        }

        /// <summary>
        /// Returns one of the available forking moves, if any exist.
        /// In other words, returns a move that allows there to be two
        /// ways to win for the AI.
        /// </summary>
        /// <param name="board"></param>
        /// <returns>A Tuple of the move (null is returned if no forking move exists).</returns>
        private Tuple<int, int> GetForkingMove(char[,] board)
        {
            List<Tuple<int, int>> allForkMoves = new List<Tuple<int, int>>();

            // Look through all possible moves for forks.
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] != '\u0000')
                        continue;

                    char[,] dummyBoard = SetUpDummyBoard(board);
                    dummyBoard[i, j] = 'O';

                    // Check if there are at least two ways to win as a result.
                    List<int> WinningMoves = new List<int>();
                    for (int rowID = 0; rowID < 8; rowID++)
                        CheckRow(dummyBoard, rowID, WinningMoves, new List<int>());
                    if (WinningMoves.Count > 1)
                        allForkMoves.Add(new Tuple<int, int>(i, j));
                }
            }

            // Randomly select one of the fork moves.
            if (allForkMoves.Count == 0)
                return null;
            return allForkMoves[rand.Next(allForkMoves.Count)];
        }

        /// <summary>
        ///  Blocks an opponent from creating a fork on their next turn if possible.
        ///  This may involve forcing the opponent to block the AI from getting 3 in a row
        ///  on the next turn.
        /// </summary>
        /// <param name="board">A Tuple of the move, null otherwise.</param>
        /// <returns></returns>
        private Tuple<int, int> BlockForkingMove(char[,] board)
        {
            // If there are no forks to block, do nothing.
            if (!DoesOpponentForkExist(board))
                return null;

            // Find all AI moves that result in 0 forks for the opponent.
            List<Tuple<int, int>> blockingMoves = new List<Tuple<int, int>>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] != '\u0000')
                        continue;

                    // Simulate AI move.
                    char[,] dummyBoard = SetUpDummyBoard(board);
                    dummyBoard[i, j] = 'O';

                    // Simulate opponent move. Opponent will first need to block an AI 3 in a row from occuring.
                    List<int> AIWinningRows = new List<int>();
                    for (int rowID = 0; rowID < 8; rowID++)
                        CheckRow(dummyBoard, rowID, AIWinningRows, new List<int>());

                    if (AIWinningRows.Count > 0)
                    {
                        // Have the human move block the win from occuring.
                        Tuple<int, int> move = CompleteRow(dummyBoard, AIWinningRows[0]);
                        dummyBoard[move.Item1, move.Item2] = 'X';

                        // Now check if the human's block caused a fork to occur for the human. If not, add (i,j) to blocking moves.
                        List<int> HumanWinningMoves = new List<int>();
                        for (int rowID = 0; rowID < 8; rowID++)
                            CheckRow(dummyBoard, rowID, new List<int>(), HumanWinningMoves);
                        if (HumanWinningMoves.Count < 2)
                            blockingMoves.Add(new Tuple<int, int>(i, j));
                        continue;
                    }

                    // If there are no 3 in a rows to block for the human, Check if any forking moves can be made by them. If there aren't any, (i,j) is a blocking move.
                    bool forksExist = false;
                    for (int row = 0; i < 3; i++)
                    {
                        for (int col = 0; j < 3; j++)
                        {
                            if (dummyBoard[row, col] != '\u0000')
                                continue;

                            char[,] dummyOfDummyBoard = SetUpDummyBoard(dummyBoard);
                            dummyOfDummyBoard[row, col] = 'X';

                            // Now check if the human's move made a fork for them. If not, add (i,j) to blocking moves.
                            List<int> HumanWinningMoves = new List<int>();
                            for (int rowID = 0; rowID < 8; rowID++)
                                CheckRow(dummyOfDummyBoard, rowID, new List<int>(), HumanWinningMoves);
                            if (HumanWinningMoves.Count > 1)
                            {
                                forksExist = true;
                            }
                        }
                    }
                    if (!forksExist)
                        blockingMoves.Add(new Tuple<int, int>(i, j));
                }
            }
            // Randomly select one of these moves.
            return blockingMoves[rand.Next(blockingMoves.Count)];
        }

        /// <summary>
        /// Returns true if the opponent can make a forking move, false otherwise.
        /// This is intended to be used as a helper for the BlockForkingMove method.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        private bool DoesOpponentForkExist(char[,] board)
        {
            // Look through all possible opponent moves for forks. If none exist, return null.
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] != '\u0000')
                        continue;

                    char[,] dummyBoard = SetUpDummyBoard(board);
                    dummyBoard[i, j] = 'X';

                    // Check if there are at least two ways for the opponent to win.
                    List<int> OpponentWinningMoves = new List<int>();
                    for (int rowID = 0; rowID < 8; rowID++)
                        CheckRow(dummyBoard, rowID, new List<int>(), OpponentWinningMoves);
                    if (OpponentWinningMoves.Count > 1)
                    {
                        return true;
                    }
                }
            }
            return false;

        }

        /// <summary>
        /// Returns a deep copy 3x3 char matrix of the board.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        private char[,] SetUpDummyBoard(char[,] board)
        {
            char[,] dummyBoard = new char[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    dummyBoard[i, j] = board[i, j];
            return dummyBoard;
        }


        /// <summary>
        /// Randomly selects an open corner space opposite of an opponent corner move.
        /// If no such moves exist, returns null.
        /// </summary>
        /// <param name="board"></param>
        /// <returns>A tuple of the row-column pair.</returns>
        private Tuple<int, int> GetRandomOppositeCorner(char[,] board)
        {
            // Add all open opposing corner spaces to a list.
            List<Tuple<int, int>> oppositeCorners = new List<Tuple<int, int>>();
            if (board[0, 0] == 'X' && board[2, 2] == '\u0000')
                oppositeCorners.Add(new Tuple<int, int>(2, 2));
            if (board[2, 2] == 'X' && board[0, 0] == '\u0000')
                oppositeCorners.Add(new Tuple<int, int>(0, 0));
            if (board[2, 0] == 'X' && board[0, 2] == '\u0000')
                oppositeCorners.Add(new Tuple<int, int>(0, 2));
            if (board[0, 2] == 'X' && board[2, 0] == '\u0000')
                oppositeCorners.Add(new Tuple<int, int>(2, 0));

            if (oppositeCorners.Count == 0)
                return null;
            return oppositeCorners[rand.Next(oppositeCorners.Count)];
        }



        /// <summary>
        /// Randomly selects an open corner space.
        /// </summary>
        /// <param name="board"></param>
        /// <returns>A tuple of the row-column pair.</returns>
        private Tuple<int, int> PickRandomCorner(char[,] board)
        {
            // Go until we get an empty spot.
            while (true)
            {
                int nextMove = rand.Next(4);
                if (nextMove == 0)
                {
                    //Check if the spot is empty, otherwise continue looping.
                    if (board[0, 0] == '\u0000')
                        return corners[0];
                }
                else if (nextMove == 1)
                {
                    if (board[0, 2] == '\u0000')
                        return corners[1];
                }
                else if (nextMove == 2)
                {
                    if (board[2, 0] == '\u0000')
                        return corners[2];
                }
                else if (board[2, 2] == '\u0000')
                    return corners[3];
            }
        }

        /// <summary>
        /// Randomly selects an open side space.
        /// </summary>
        /// <param name="board"></param>
        /// <returns>A tuple of the row-column pair.</returns>
        private Tuple<int, int> PickRandomSide(char[,] board)
        {
            // Loop until we get an empty side.
            while (true)
            {
                int nextMove = rand.Next(4);
                if (nextMove == 0)
                {
                    if (board[0, 1] == '\u0000')
                        return sides[0];
                }
                else if (nextMove == 1)
                {
                    if (board[1, 0] == '\u0000')
                        return sides[1];
                }
                else if (nextMove == 2)
                {
                    if (board[1, 2] == '\u0000')
                        return sides[2];
                }
                else if (board[2, 1] == '\u0000')
                    return sides[3];
            }
        }


    }
}
