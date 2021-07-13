/*
 * A Windows Form Application that represents the view and controller of Tic-Tac-Toe.
 * 
 * Author: Lucas Katsanevas
 * 
 * Version 1.0 (1/16/21) - Created button click events.
 * Version 1.1 (1/16/21) - Implemented ExecuteMove and UpdateBoard.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using System.Media;
using System.Threading;

namespace View
{
    /// <summary>
    /// Represents the GUI of Tic-Tac-Toe.
    /// </summary>
    public partial class BoardGUI : Form
    {
        protected GameBoard board;
        private SoundPlayer moveAudio;
        private SoundPlayer winnerAudio;

        // Messages for who is up/who won the game.
        protected string p1TurnMsg = "Player 1's Turn";
        protected string p2TurnMsg = "Player 2's Turn";
        protected string p1WinMsg = "Player 1 Wins!";
        protected string p2WinMsg = "Player 2 Wins!";
        protected string gameOverMsg = "Game Over!";

        /// <summary>
        /// Constructs the view.
        /// </summary>
        public BoardGUI()
        {
            InitializeComponent();
            board = new GameBoard();
            moveAudio = new System.Media.SoundPlayer(@"..\..\..\Resources\Audio\moveNoise.wav");
            winnerAudio = new System.Media.SoundPlayer(@"..\..\..\Resources\Audio\cheering.wav");
        }

        /// <summary>
        /// Move made in top-left cell.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void topLeft_Click(object sender, EventArgs e)
        {
            ExecuteMove(0, 0);
        }

        /// <summary>
        /// Move made in top-middle cell.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void topMiddle_Click(object sender, EventArgs e)
        {
            ExecuteMove(0, 1);
        }

        /// <summary>
        /// Move made in top-right cell.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void topRight_Click(object sender, EventArgs e)
        {
            ExecuteMove(0, 2);
        }

        /// <summary>
        /// Move made in center-left cell.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void centerLeft_Click(object sender, EventArgs e)
        {
            ExecuteMove(1, 0);
        }

        /// <summary>
        /// Move made in center-middle cell.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void centerMiddle_Click(object sender, EventArgs e)
        {
            ExecuteMove(1, 1);
        }

        /// <summary>
        /// Move mode in center-right cell.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void centerRight_Click(object sender, EventArgs e)
        {
            ExecuteMove(1, 2);
        }

        /// <summary>
        /// Move made in bottom-left cell.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bottomLeft_Click(object sender, EventArgs e)
        {
            ExecuteMove(2, 0);
        }

        /// <summary>
        /// Move made in bottom-middle cell.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bottomMiddle_Click(object sender, EventArgs e)
        {
            ExecuteMove(2, 1);
        }

        /// <summary>
        /// Move made in bottom-right cell.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bottomRight_Click(object sender, EventArgs e)
        {
            ExecuteMove(2, 2);
        }

        /// <summary>
        /// Makes the move, then updates everything on the view and plays audio if needed.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        protected virtual void ExecuteMove(int row, int col)
        {
            if (board.MakeMove(row, col))
            {
                moveAudio.Play();
                UpdateBoard();
            }

            
        }
        /// <summary>
        /// Updates the view to represent the current state of the game.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        private void UpdateBoard()
        {
            // Get the updated board matrix and update each button.
            char[,] updatedBoard = board.GetBoard();
            topLeft.Text = updatedBoard[0, 0].ToString();
            topMiddle.Text = updatedBoard[0, 1].ToString();
            topRight.Text = updatedBoard[0, 2].ToString();
            centerLeft.Text = updatedBoard[1, 0].ToString();
            centerMiddle.Text = updatedBoard[1, 1].ToString();
            centerRight.Text = updatedBoard[1, 2].ToString();
            bottomLeft.Text = updatedBoard[2, 0].ToString();
            bottomMiddle.Text = updatedBoard[2, 1].ToString();
            bottomRight.Text = updatedBoard[2, 2].ToString();

            // Update the rest of the board.
            if (board.IsGameOver())
            {
                if(board.GetResult() == 'X')
                {

                    int wins = int.Parse(p1Wins.Text) + 1;
                    p1Wins.Text = wins + "";
                    statusIndicator.Text = p1WinMsg;
                }
                else if(board.GetResult() == 'O')
                {
                    int wins = int.Parse(p2Wins.Text) + 1;
                    p2Wins.Text = wins + "";
                    statusIndicator.Text = p2WinMsg;
                }
                else
                {
                    statusIndicator.Text = gameOverMsg;
                }
                

                // FIX THIS????
                //Thread.Sleep(2000);
                winnerAudio.Play();
            }
            else
            {
                // See which player is up.
                if (board.IsP1Turn())
                {
                    statusIndicator.Text = p1TurnMsg;
                }
                else
                {
                    statusIndicator.Text = p2TurnMsg;
                }
            }
        }

        /// <summary>
        /// New game has been clicked. Reset the board and update the GUI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newGame_Click(object sender, EventArgs e)
        {
            board.NewGame();
            UpdateBoard();
        }
    }
}
