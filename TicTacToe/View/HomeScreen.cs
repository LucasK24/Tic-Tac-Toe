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
    public partial class HomeScreen : Form
    {
        public delegate void ModeSelectedHandler(string mode);
        public event ModeSelectedHandler ModeSelected;

        // Keeps track of if a button was clicked (to differentiate between closing with 'X' and clicking buttons)
        private bool buttonClicked;


        public HomeScreen()
        {
            FormClosing += ExitProgram;
            buttonClicked = false;

            InitializeComponent();
        }

        private void singlePlayerButton_Click(object sender, EventArgs e)
        {
            buttonClicked = true;
            ModeSelected("Single");
            this.Close();
        }

        private void localMultiplayerButton_Click(object sender, EventArgs e)
        {
            buttonClicked = true;
            ModeSelected("Multiplayer");
            this.Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            buttonClicked = true;
            ModeSelected("Exit");
            this.Close();
        }

        private void ExitProgram(object sender, FormClosingEventArgs e)
        {
            if (buttonClicked == false)
                ModeSelected("Exit");
        }
    }
}
