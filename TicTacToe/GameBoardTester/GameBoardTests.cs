/*
 * Tester for the GameBoard class' methods and constructor. Note - other testing was done through playing the game,
 * as opposed to doing written tests for efficiency reasons.
 * 
 * Author: Lucas Katsanevas
 * 
 * Version 1.0 (1/15/21) - Constructor and basic method tests.
 * Version 1.1 (1/16/21) - All other tests implemented.
 * 
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Model
{
    /// <summary>
    /// Class for testing the model of Tic-Tac-Toe.
    /// </summary>
    [TestClass]  
    public class GameBoardTests          
    {

        [TestMethod]
        public void MultipleBoardsTest()
        {
            GameBoard board1 = new GameBoard();
            board1.MakeMove(1, 1);
            Assert.AreEqual('X', board1.GetBoard()[1,1]);
            GameBoard board2 = new GameBoard();
            board2.MakeMove('\u0000', board2.GetBoard()[1, 1]);
        }

        [TestMethod]
        public void P1WinsTest()
        {
            GameBoard board = new GameBoard();
            board.MakeMove(0, 0);
            board.MakeMove(1, 1);
            board.MakeMove(1, 0);
            board.MakeMove(2, 2);
            board.MakeMove(2, 0);
            Assert.AreEqual(1, board.P1Wins);
        }


        [TestMethod]
        public void P2WinsTest()
        {
            GameBoard board = new GameBoard();
            board.MakeMove(0, 0);
            board.MakeMove(0, 1);
            board.MakeMove(1, 0);
            board.MakeMove(1, 1);
            board.MakeMove(2, 2);
            board.MakeMove(2, 1);
            Assert.AreEqual(1, board.P2Wins);
            Assert.AreEqual(0, board.P1Wins);
        }


        [TestMethod]
        public void CreateTwoGameBoardsTest()
        {
            GameBoard board = new GameBoard();
            Assert.AreEqual(0, board.P1Wins);
            board.MakeMove(0, 0);
            board.MakeMove(1, 1);
            board.MakeMove(1, 0);
            board.MakeMove(2, 2);
            board.MakeMove(2, 0);
            Assert.AreEqual(1, board.P1Wins);
            board = new GameBoard();
            Assert.AreEqual(0, board.P1Wins);
        }


        [TestMethod]
        public void  NewGameTest()
        {
            GameBoard board = new GameBoard();
            board.MakeMove(1, 1);
            board.NewGame();
            Assert.AreEqual('\u0000', board.GetBoard()[1, 1]);
        }

        [TestMethod]
        public void GetBoardTest()
        {
            GameBoard board = new GameBoard();
            board.MakeMove(0, 0);
            board.MakeMove(0, 1);
            board.MakeMove(0, 2);
            board.MakeMove(1, 1);
            board.MakeMove(1, 2);
            board.MakeMove(2, 0);
            board.MakeMove(2, 1);
            board.MakeMove(2, 2);

            char[,] expected = new char[3, 3];
            expected[0, 0] = 'X';
            expected[0, 2] = 'X';
            expected[1, 2] = 'X';
            expected[2, 1] = 'X';
            expected[0, 1] = 'O';
            expected[1, 1] = 'O';
            expected[2, 0] = 'O';
            expected[2, 2] = 'O';
            expected[1, 0] = '\u0000';

            CollectionAssert.AreEqual(expected, board.GetBoard());
        }


        [TestMethod]
        public void TieTest()
        {
            GameBoard board = new GameBoard();
            board.MakeMove(0, 0);
            board.MakeMove(0, 1);
            board.MakeMove(0, 2);
            board.MakeMove(1, 1);
            board.MakeMove(1, 2);
            board.MakeMove(2, 0);
            board.MakeMove(2, 1);
            board.MakeMove(2, 2);
            board.MakeMove(1, 0);
            Assert.AreEqual(true, board.IsGameOver());
            Assert.AreEqual(0, board.P1Wins);
            Assert.AreEqual(0, board.P2Wins);
        }

        [TestMethod]
        public void TurnsAlternateTest()
        {
            GameBoard board = new GameBoard();
            Assert.AreEqual(true, board.IsP1Turn());
            board.MakeMove(1, 1);
            Assert.AreEqual(false, board.IsP1Turn());
            board.MakeMove(2, 1);
            Assert.AreEqual(true, board.IsP1Turn());
        }

        [TestMethod]
        public void NewGameSwitchesTurn()
        {
            GameBoard board = new GameBoard();
            board.NewGame();
            Assert.AreEqual(false, board.IsP1Turn()) ;
        }

        [TestMethod]
        public void DuplicateMoveInvalidTest()
        {
            GameBoard board = new GameBoard();
            board.MakeMove(1, 1);
            board.MakeMove(1, 1);
            Assert.AreEqual(false, board.IsP1Turn());
            Assert.AreEqual(false, board.IsP1Turn());
        }
    }
}
