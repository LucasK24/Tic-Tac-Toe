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

        // Keeps track of if  first move has been made. This way, clicking newGame multiple times results in only one move.
        private bool firstMoveMade;

        /// <summary>
        /// Sets up the game board and makes changes for when a player is up against an AI.
        /// </summary>
        public SinglePlayerBoardGUI(string difficultyLevel)
        {
            ai = new AIPlayer(difficultyLevel);
            rand = new Random();

            loserAudio = new System.Media.SoundPlayer(@"..\..\..\Resources\Audio\loss.wav");

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
        protected override void ExecuteMove(int row, int col)
        {
            if (board.IsP1Turn())
            {
                base.ExecuteMove(row, col);

                // Execute AI move after 1-3 seconds if game is not over. Pass false to indicate it's not the first move of a game.
                if (!board.IsGameOver())
                {
                    while (backgroundWorker.IsBusy)
                    {
                        Application.DoEvents();
                    }

                    backgroundWorker.RunWorkerAsync(false);
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
            // Cancel the AI's next move since new game was clicked (if it had a next move being made).
            backgroundWorker.CancelAsync();

            base.newGame_Click(sender, e);
            firstMoveMade = false;

            if (!board.IsP1Turn())
            {
                while (backgroundWorker.IsBusy)
                {
                    Application.DoEvents();
                }

                // BackgroundWorker no longer busy. Can make move now. Pass true to indicate it's the first move of a game.
                backgroundWorker.RunWorkerAsync(true);
            }
        }


        /// <summary>
        /// Waits for 1-3 seconds before making a move.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            bool isNewGameFirstMove = (bool)e.Argument;
            if (isNewGameFirstMove)
            {
                // If this is a new game, check to make sure clicking new game 2 or more times didn't cause the first move to be made already.
                if (firstMoveMade)
                {
                    e.Cancel = true;
                    return;
                }
            }

            int waitTime = rand.Next(1000, 3000);
            Thread.Sleep(waitTime);

            if (backgroundWorker.CancellationPending)
                e.Cancel = true;
        }

        /// <summary>
        /// Performs the AI's move.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Disable the new game button so that a new game can't be started when the move is being made.
            newGame.Enabled = false;

            // Return if the move was cancelled from new game being clicked.
            if (!e.Cancelled)
            {                
                firstMoveMade = true;
                Tuple<int, int> move = ai.MakeMove(board.GetBoard());
                base.ExecuteMove(move.Item1, move.Item2);
            }

            newGame.Enabled = true;
        }
    }
}
