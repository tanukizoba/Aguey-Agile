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
        public int[,] AvailableMove = new int[8, 8];
        public bool TurnBlack = false;
        public int OpponentPiece = 1;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

             
            Graphics g = e.Graphics;
            Pen myPen = new Pen(Color.Black, 4);


            g.DrawRectangle(myPen, 2, 2, 396, 396);
            g.DrawRectangle(myPen, 52, 2, 300, 396);
            g.DrawRectangle(myPen, 102, 2, 200, 396);
            g.DrawRectangle(myPen, 152, 2, 100, 396);
            g.DrawLine(myPen, 200, 0, 200, 400);
            g.DrawRectangle(myPen, 2, 52, 396, 300);
            g.DrawRectangle(myPen, 2, 102, 396, 200);
            g.DrawRectangle(myPen, 2, 152, 396, 100);
            g.DrawLine(myPen, 0, 200, 400, 200);
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
            data[6, 6] = 1;
            data[7, 7] = 0;
            data[6, 7] = 1;
            data[7, 6] = 0;
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X / 50;
            int y = e.Y / 50;

            AvailableMove = Playing.CheckAvailble(data, TurnBlack);
            if (data[x, y] == 3 && AvailableMove[x, y] == 1)
            {
                if (TurnBlack)
                {
                    data[x, y] = 1;
                    for (int i = 1; i < 9; i++)
                    {
                        Playing.ChangeColor(data, OpponentPiece, x, y, i);

                    }
                    TurnBlack = false;
                    OpponentPiece = 1;
                }
                else
                {
                    data[x, y] = 0;
                    for (int i = 1; i < 9; i++)
                    {
                        Playing.ChangeColor(data, OpponentPiece, x, y, i);

                    }
                    TurnBlack = true;
                    OpponentPiece = 0;
                }
            }
            panelTable.Refresh();
            if (checkBoxAvailableMove.Checked)
            {
                AvailableMove = Playing.CheckAvailble(data, TurnBlack);
                Playing.WriteAvailable(AvailableMove, panelTable);
            }
           
            if (Playing.CountAvailableMove(AvailableMove) > 0)
            {
                BtPass.Enabled = false;
            }
            else
            {
                BtPass.Enabled = true;
            }
            Playing.WritePiece(data, panelTable);
        }

        private void BtReset_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
            this.panelTable.Refresh();
            if (checkBoxAvailableMove.Checked)
            {
                AvailableMove = Playing.CheckAvailble(data, TurnBlack);
                Playing.WriteAvailable(AvailableMove, panelTable);
            }
        }

        private void checkBoxAvailableMove_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAvailableMove.Checked)
            {
                AvailableMove = Playing.CheckAvailble(data, TurnBlack);
                Playing.WriteAvailable(AvailableMove, panelTable);
            }
            else
            {
                panelTable.Refresh();

            }
        }

        private void BtPass_Click(object sender, EventArgs e)
        {
            TurnBlack = !TurnBlack;
            OpponentPiece = 1 - OpponentPiece;
            if (checkBoxAvailableMove.Checked)
            {
                AvailableMove = Playing.CheckAvailble(data, TurnBlack);
                Playing.WriteAvailable(AvailableMove, panelTable);
            }
            BtPass.Enabled = false;
        }

       
    }
}
