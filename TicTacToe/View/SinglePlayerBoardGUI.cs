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
    /// 
    /// </summary>
    public partial class SinglePlayerBoardGUI : BoardGUI
    {

        /// <summary>
        /// 
        /// </summary>
        public SinglePlayerBoardGUI()
        {
            InitializeComponent();

        }

        /// <summary>
        /// NEED TO FINISH
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        private void ExecuteMove(int row, int col)
        {
            if(board.IsP1Turn())
            {
                base.ExecuteMove(row, col);
            }
            else
            {
                // It is still the AI's turn. Nothing happens.
            }


        }

    }
}
