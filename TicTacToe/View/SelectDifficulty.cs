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
        /// <summary>
        /// Initializes the form for to select a difficulty.
        /// </summary>
        public SelectDifficulty()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Starts an easy game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void easyButton_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Starts a hard game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hardButton_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Starts an impossible to win game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void impossibleButton_Click(object sender, EventArgs e)
        {

        }
    }
}
