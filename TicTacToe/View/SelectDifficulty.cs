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
    public partial class SelectDifficulty : Form
    {

        public delegate void DifficultySelectedHandler(string diff);
        public event DifficultySelectedHandler DifficultySelected;

        // Keeps track of if a button was clicked (to differentiate between closing with 'X' and clicking buttons)
        private bool buttonClicked;

        /// <summary>
        /// Initializes the form for to select a difficulty.
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

        private void ExitProgram(object sender, EventArgs e)
        {
            if (buttonClicked == false)
                DifficultySelected("Exit");
        }
    }
}
