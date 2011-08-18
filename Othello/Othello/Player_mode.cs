using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Othello
{
    public partial class Player_mode : Form
    {
        public Player_mode()
        {
            InitializeComponent();
        }

        Form1 othello = new Form1();

        private void SingleButton_Click(object sender, EventArgs e)
        {
            othello.mode = 1;
            othello.ShowDialog();
        }

        private void TwoButton_Click(object sender, EventArgs e)
        {
            othello.mode = 2;
            othello.ShowDialog();
        }

    
    }
}
