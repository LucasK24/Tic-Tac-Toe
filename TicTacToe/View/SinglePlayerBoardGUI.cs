using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Model;
using CPUPlayer;

namespace View
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SinglePlayerBoardGUI : BoardGUI
    {
        // Event must be triggered for AI to know it is time to perform turn.
        private AIPlayer ai;
        private Random rand;

        /// <summary>
        /// Sets up the game board and makes changes for when a player is up against an AI.
        /// </summary>
        public SinglePlayerBoardGUI(string difficultyLevel)
        {
            ai = new AIPlayer(difficultyLevel);
            rand = new Random();

            // Change P1 and P2 labels to account for CPU.
            p1Label.Text = "Player";
            p1Label.Location = new Point(120, 37);
            p2Label.Text = "CPU";
            p2Label.Location = new Point(490, 37);

            // Also account for changing turns/end of game for CPU.
            p1TurnMsg = "Your Turn";
            p2TurnMsg = "CPU's Turn";
            p1WinMsg = "You Win!";
            p2WinMsg = "CPU Wins!";
            gameOverMsg = "Game Over!";

            // Set the initial turn indicator now.
            statusIndicator.Text = p1TurnMsg;

            InitializeComponent();
        }


        /// <summary>
        /// NEED TO FINISH
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        protected async override void ExecuteMove(int row, int col)
        {
            if (board.IsP1Turn())
            {
                base.ExecuteMove(row, col);

                // Execute AI move after 1-3 seconds if game is not over.
                if(!board.IsGameOver())
                {
                    int waitTime = rand.Next(1000, 3000);
                    await Task.Delay(waitTime);
                    Tuple<int, int> move = ai.MakeMove(board.GetBoard());
                    base.ExecuteMove(move.Item1, move.Item2);
                }

            }
            // Otherwise it is still the AI's turn. Nothing happens.
        }

        /// <summary>
        /// New game has been clicked. Reset the board and update the GUI. Go with AI if its first.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void newGame_Click(object sender, EventArgs e)
        {
            base.newGame_Click(sender, e);

            if (!board.IsP1Turn())
            {
                AIStart();
            }
        }

        private async void AIStart()
        {
            await Task.Delay(3000);
            Tuple<int, int> move = ai.MakeMove(board.GetBoard());
            base.ExecuteMove(move.Item1, move.Item2);
        }

    }
}
