﻿/*
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

namespace View
{
    /// <summary>
    /// Represents the GUI of Tic-Tac-Toe.
    /// </summary>
    public partial class Form1 : Form
    {
        private GameBoard board;

        /// <summary>
        /// Constructs the view.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            board = new GameBoard();
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
        /// Makes the move, then updates everything on the view.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        private void ExecuteMove(int row, int col)
        {
            board.MakeMove(row, col);
            UpdateBoard();
            
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
                p1Wins.Text = board.P1Wins.ToString();
                p2Wins.Text = board.P2Wins.ToString();
                statusIndicator.Text = "Game Over";
            }
            else
            {
                // See which player is up.
                if (board.IsP1Turn())
                {
                    statusIndicator.Text = "Player 1's Turn";
                }
                else
                {
                    statusIndicator.Text = "Player 2's Turn";
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
