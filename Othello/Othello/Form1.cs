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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int[,] data = new int[8, 8];
        public bool TurnBlack = false;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;         
            Pen myPen = new Pen(Color.Brown,4);


            g.DrawRectangle(myPen, 2, 2, 396, 396);
            g.DrawRectangle(myPen, 52, 2, 300, 396);
            g.DrawRectangle(myPen, 102, 2, 200, 396);
            g.DrawRectangle(myPen, 152, 2, 100, 396);
            g.DrawLine(myPen, 200, 0, 200, 400);
            g.DrawRectangle(myPen, 2, 52, 396, 300);
            g.DrawRectangle(myPen, 2, 102, 396, 200);
            g.DrawRectangle(myPen, 2, 152, 396, 100);
            g.DrawLine(myPen, 0, 200, 400, 200);

            data[3, 3] = 1;
            data[4, 4] = 1;
            data[3, 4] = 0;
            data[4, 3] = 0;
            myPen.Dispose();
            Playing.WritePiece(data, panelTable);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    data[x, y] = 3;
                }
            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X / 50;
            int y = e.Y / 50;

            if (data[x, y] == 3)
            {
                if (TurnBlack)
                {
                    data[x, y] = 1;
                    TurnBlack = false;
                }
                else
                {
                    data[x, y] = 0;
                    TurnBlack = true;
                }
            }

            Playing.WritePiece(data, panelTable);

        }

        private void BtReset_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
            this.panelTable.Refresh();
            
        }
    }
}
