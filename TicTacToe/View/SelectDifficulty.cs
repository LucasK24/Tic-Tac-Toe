/*
 * Represents the Select Difficulty screen for the game.
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
    /// This is the form brought up when the Single-Player" button is clicked. 
    /// It allows the user to click buttons for easy, hard, and impossible mode.
    /// </summary>
    public partial class SelectDifficulty : Form
    {

        public delegate void DifficultySelectedHandler(string diff);
        public event DifficultySelectedHandler DifficultySelected;

        // Keeps track of if a button was clicked (to differentiate between closing with 'X' and clicking buttons)
        private bool buttonClicked;

        /// <summary>
        /// Initializes the form.
        /// </summary>
        public SelectDifficulty()
        {
            FormClosing += ExitProgram;
            buttonClicked = false;
            InitializeComponent();
        }

        /// <summary>
        /// Starts an easy game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void easyButton_Click(object sender, EventArgs e)
        {
            buttonClicked = true;
            DifficultySelected("Easy");
            this.Close();
        }

        /// <summary>
        /// Starts a hard game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hardButton_Click(object sender, EventArgs e)
        {
            buttonClicked = true;
            DifficultySelected("Hard");
            this.Close();
        }

        /// <summary>
        /// Starts an impossible to win game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void impossibleButton_Click(object sender, EventArgs e)
        {
            buttonClicked = true;
            DifficultySelected("Impossible");
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
                DifficultySelected("Exit");
        }
    }
}
