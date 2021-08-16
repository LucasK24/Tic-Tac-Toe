/*
 * Represents the home screen for the game.
 * 
 * Author: Lucas Katsanevas
 * 
 * Version 1.0 (July 2021) - Created everything for the screen and how it will look.
 * Version 1.1 (August 2021) - Added button-clicking events to link to other parts of GUI.
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

namespace View
{
    /// <summary>
    /// This is the first screen brought up when the application opens. The user may select
    /// "Single Player", "Local Multiplayer", or exit the game.
    /// </summary>
    public partial class HomeScreen : Form
    {
        public delegate void ModeSelectedHandler(string mode);
        public event ModeSelectedHandler ModeSelected;

        // Keeps track of if a button was clicked (to differentiate between closing with 'X' and clicking buttons)
        private bool buttonClicked;

        /// <summary>
        /// Initializes the HomeScreen.
        /// </summary>
        public HomeScreen()
        {
            FormClosing += ExitProgram;
            buttonClicked = false;

            InitializeComponent();
        }

        /// <summary>
        /// Closes this form and sets up for a single-player game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void singlePlayerButton_Click(object sender, EventArgs e)
        {
            buttonClicked = true;
            ModeSelected("Single");
            this.Close();
        }

        /// <summary>
        /// Closes this form and sets up for a multiplayer game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void localMultiplayerButton_Click(object sender, EventArgs e)
        {
            buttonClicked = true;
            ModeSelected("Multiplayer");
            this.Close();
        }

        /// <summary>
        /// Closes the form and sets up the program for termination.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitButton_Click(object sender, EventArgs e)
        {
            buttonClicked = true;
            ModeSelected("Exit");
            this.Close();
        }

        /// <summary>
        /// Triggered from the FormClosed event. If the top-right "X" was clicked,
        /// sets up the program for termination.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitProgram(object sender, EventArgs e)
        {
            if (buttonClicked == false)
                ModeSelected("Exit");
        }
    }
}
