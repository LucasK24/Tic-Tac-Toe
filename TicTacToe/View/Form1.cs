﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //gridPicture.Image = Image.FromFile(@"..\..\..\Resources\Images\Grid.png");
            GameBoard board = new GameBoard();
        }
    }
}
