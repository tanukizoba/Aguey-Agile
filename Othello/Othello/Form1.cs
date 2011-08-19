using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace Othello
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int mode = 0;
        public int[,] data = new int[8, 8];
        public int[,] AvailableMove = new int[8, 8];
        public bool TurnBlack = false;
        public int OpponentPiece = 1;
        public bool FirstPlayer = false;


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

            AvailableMove = Playing.CheckAvailble(data, TurnBlack);
            if (checkBoxAvailableMove.Checked)
            {
                
                Playing.WriteAvailable(AvailableMove, panelTable);
            }
            Playing.WritePiece(data, panelTable);

            if (TurnBlack)
            {
                labelTurn.Text = "Black";
            }
            else
            {
                labelTurn.Text = "White";
            }

            
            if ((TurnBlack && FirstPlayer || !TurnBlack && !FirstPlayer) && mode ==1)
            {
                Thread.Sleep(400);
                TurnAI();
            }

            if (Playing.CountAvailableMove(AvailableMove) > 0)
            {
                BtPass.Enabled = false;
            }
            else
            {
                BtPass.Enabled = true;
            }
           
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
            //data[7, 7] = 0;
            //data[6, 7] = 0;
            //data[6, 6] = 1;
            //data[7, 6] = 1;
            data[3, 3] = 0;
            data[4, 4] = 0;
            data[3, 4] = 1;
            data[4, 3] = 1;
         
            UpdateScore();

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X / 50;
            int y = e.Y / 50;

            AvailableMove = Playing.CheckAvailble(data, TurnBlack);
            if (mode == 2)
            {
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
            }
            else
            {
                if (TurnBlack && !FirstPlayer)
                {
                    if (data[x, y] == 3 && AvailableMove[x, y] == 1)
                    {
                        data[x, y] = 1;
                        for (int i = 1; i < 9; i++)
                        {
                            Playing.ChangeColor(data, OpponentPiece, x, y, i);
                        }
                        TurnBlack = false;
                        OpponentPiece = 1;
                        

                       
                    }
                }
                else if (!TurnBlack && FirstPlayer)
                {
                    if (data[x, y] == 3 && AvailableMove[x, y] == 1)
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
            }

            PrintPiece();
           
            
            if(mode ==1)
            { 
                Thread.Sleep(500);
                TurnAI();
            }

            CheckWin();
           
        }

        private void PrintPiece()
        {
           panelTable.Refresh();
         
            if (checkBoxAvailableMove.Checked)
            {
                AvailableMove = Playing.CheckAvailble(data, TurnBlack);
                Playing.WriteAvailable(AvailableMove, panelTable);
            }

           
            Playing.WritePiece(data, panelTable);

            UpdateScore();
        }

        private void BtReset_Click(object sender, EventArgs e)
        {            
            TurnBlack = false;
            OpponentPiece = 1;
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
            AvailableMove = Playing.CheckAvailble(data, TurnBlack);
            if (checkBoxAvailableMove.Checked)
            {
                
                Playing.WriteAvailable(AvailableMove, panelTable);
            }
            if (Playing.CountAvailableMove(AvailableMove) == 0)
            {
                int[] score = Playing.CountScore(data);
                if (score[0] > score[1])
                {
                    MessageBox.Show("White the winner!!!");
                }
                else
                {
                    MessageBox.Show("Black the winner!!!");
                }
            }
            BtPass.Enabled = false;
            if (TurnBlack)
            {
                labelTurn.Text = "Black";
            }
            else
            {
                labelTurn.Text = "White";
            }
        }

        private void UpdateScore()
        {
            int[] score = Playing.CountScore(data);
            tbWhiteScore.Text = score[0].ToString();
            tbBlackScore.Text = score[1].ToString();         
        }

        private void CheckWin()
        {
            int[] score = Playing.CountScore(data);
            if (score[0] + score[1] == 64)
            {
                if (score[0] > score[1])
                {
                    MessageBox.Show("White the winner!!!");
                }
                else if (score[0] < score[1])
                {
                    MessageBox.Show("Black the winner!!!");
                }
                else
                {
                    MessageBox.Show("Draw!!!");
                }
            }
        }

        public void TurnAI()
        {
            AvailableMove = Playing.CheckAvailble(data, TurnBlack);
            List<int[]> CanMove = new List<int[]>();
            List<int[]> MoveEdge = new List<int[]>();
            bool hasEdge = false;

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (AvailableMove[x, y] == 1)
                    { 
                        int[] point = { x, y };                        
                        CanMove.Add(point);
                        if (x == 0 || x == 7 || y == 0 || y == 7)
                        {
                            MoveEdge.Add(point);
                            hasEdge = true;
                        }
                    }
                }
            }

            if (CanMove.Count > 0)
            {
                int seed = DateTime.Now.TimeOfDay.Milliseconds;
                Random rand = new Random(seed);
                int[] comMove = new int[2];
                int move;
                if (hasEdge)
                {
                    move = rand.Next(0, MoveEdge.Count);
                    comMove = MoveEdge[move];
                }
                else
                {
                     move = rand.Next(0, CanMove.Count);

                     comMove = CanMove[move];
                }
                

                if (TurnBlack && FirstPlayer)
                {
                    data[comMove[0], comMove[1]] = 1;
                    for (int i = 1; i < 9; i++)
                    {
                        Playing.ChangeColor(data, OpponentPiece, comMove[0], comMove[1], i);
                    }
                    TurnBlack = false;
                    OpponentPiece = 1;
                }
                else if(!TurnBlack && !FirstPlayer)
                {
                    data[comMove[0], comMove[1]] = 0;
                    for (int i = 1; i < 9; i++)
                    {
                        Playing.ChangeColor(data, OpponentPiece, comMove[0], comMove[1], i);
                    }
                    TurnBlack = true;
                    OpponentPiece = 0;
                }
                PrintPiece();
            }
        }       
    }
}
