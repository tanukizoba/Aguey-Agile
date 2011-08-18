using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Othello
{
    class Playing
    {
        public static void WritePiece(int[,] data, System.Windows.Forms.Panel panel)
        {
            System.Drawing.Graphics g = panel.CreateGraphics();
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (data[x, y] == 1)
                    {
                        myBrush.Color = Color.Black;
                        g.FillEllipse(myBrush, x * 50 + 2, y * 50 + 2, 45, 45);
                    }
                    else if (data[x, y] == 0)
                    {
                        myBrush.Color = Color.WhiteSmoke;
                        g.FillEllipse(myBrush, x * 50 + 2, y * 50 + 2, 45, 45);
                    }

                }
            }

            myBrush.Dispose();

        }
        public static void WriteAvailable(int[,] data, System.Windows.Forms.Panel panel)
        {
            System.Drawing.Graphics g = panel.CreateGraphics();
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (data[x, y] == 1)
                    {
                        g.FillEllipse(myBrush, x * 50 + 25, y * 50 + 25, 5, 5);
                    }

                }
            }

            myBrush.Dispose();

        }

        public static bool[,] FindPossibleMove(int[,] data, int OpponentPiece)
        {
            bool[,] PossibleMove = new bool[8, 8];
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (data[x, y] == 3)
                    {

                        if ((x - 1 >= 0 && y - 1 >= 0) && (x - 1 < 8 && y - 1 < 8))
                        {
                            if (data[x - 1, y - 1] == OpponentPiece)
                            {
                                PossibleMove[x, y] = true;
                                continue;
                            }
                        }
                        if ((x >= 0 && y - 1 >= 0) && (x < 8 && y - 1 < 8))
                        {
                            if (data[x, y - 1] == OpponentPiece)
                            {
                                PossibleMove[x, y] = true;
                                continue;
                            }
                        }
                        if ((x + 1 >= 0 && y - 1 >= 0) && (x + 1 < 8 && y - 1 < 8))
                        {
                            if (data[x + 1, y - 1] == OpponentPiece)
                            {
                                PossibleMove[x, y] = true;
                                continue;
                            }
                        }
                        if ((x + 1 >= 0 && y >= 0) && (x + 1 < 8 && y < 8))
                        {
                            if (data[x + 1, y] == OpponentPiece)
                            {
                                PossibleMove[x, y] = true;
                                continue;
                            }
                        }
                        if ((x + 1 >= 0 && y + 1 >= 0) && (x + 1 < 8 && y + 1 < 8))
                        {
                            if (data[x + 1, y + 1] == OpponentPiece)
                            {
                                PossibleMove[x, y] = true;
                                continue;
                            }
                        }
                        if ((x >= 0 && y + 1 >= 0) && (x < 8 && y + 1 < 8))
                        {
                            if (data[x, y + 1] == OpponentPiece)
                            {
                                PossibleMove[x, y] = true;
                                continue;
                            }
                        }
                        if ((x - 1 >= 0 && y + 1 >= 0) && (x - 1 < 8 && y + 1 < 8))
                        {
                            if (data[x - 1, y + 1] == OpponentPiece)
                            {
                                PossibleMove[x, y] = true;
                                continue;
                            }
                        }
                        if ((x - 1 >= 0 && y >= 0) && (x - 1 < 8 && y < 8))
                        {
                            if (data[x - 1, y] == OpponentPiece)
                            {
                                PossibleMove[x, y] = true;
                                continue;
                            }
                        }
                    }
                }
            }
            return PossibleMove;

        }

        /*  public static int[,] FindAvailable(int[,] data,int Opponent,int x,int y)
          {

              if (data[x - 1, y - 1] == Opponent)
              {
                  FindAvailableHelper(data,Opponent,x-1,y-1,8);
              }
            

          }*/

        public static bool FindAvailable(int[,] data, int Opponent, int x, int y, int direction)
        {
            switch (direction)
            {
                case 1:
                    y--;
                    break;
                case 2:
                    x++;
                    y--;
                    break;
                case 3:
                    x++;
                    break;
                case 4:
                    x++;
                    y++;
                    break;
                case 5:
                    y++;
                    break;
                case 6:
                    x--;
                    y++;
                    break;
                case 7:
                    x--;
                    break;
                case 8:
                    x--;
                    y--;
                    break;
            }
            if (x >= 0 && y >= 0 && y < 8 && x < 8)
            {
                if (data[x, y] == Opponent)
                {
                    while (x >= 0 && y >= 0 && y < 8 && x < 8)
                    {

                        if (data[x, y] == 1 - Opponent)
                        {
                            return true;
                        }
                        switch (direction)
                        {
                            case 1:
                                y--;
                                break;
                            case 2:
                                x++;
                                y--;
                                break;
                            case 3:
                                x++;
                                break;
                            case 4:
                                x++;
                                y++;
                                break;
                            case 5:
                                y++;
                                break;
                            case 6:
                                x--;
                                y++;
                                break;
                            case 7:
                                x--;
                                break;
                            case 8:
                                x--;
                                y--;
                                break;
                        }

                    }
                }
            }
            return false;
        }

        public static int[,] CheckAvailble(int[,] data, bool turnBlack)
        {
            int[,] AvailableMove = new int[8, 8];
            bool[,] PossibleMove = new bool[8, 8];
            int OpponentPiece;
            bool Checkdirection = false;

            if (turnBlack)
            {
                OpponentPiece = 0;
            }
            else
            {
                OpponentPiece = 1;
            }


            PossibleMove = FindPossibleMove(data, OpponentPiece);

            /*    for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        if (PossibleMove[x, y])
                        {
                            AvailableMove[x, y] = 1;

                        }
                        else
                        {
                            AvailableMove[x, y] = 0;
                        }
                    }

                }
                return AvailableMove;*/


            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (PossibleMove[x, y])
                    {
                        for (int i = 1; i < 9; i++)
                        {
                            Checkdirection |= FindAvailable(data, OpponentPiece, x, y, i);
                        }

                        if (Checkdirection)
                        {
                            AvailableMove[x, y] = 1;
                        }
                        else
                        {
                            AvailableMove[x, y] = 0;
                        }
                        Checkdirection = false;

                    }
                }

            }
            return AvailableMove;
        }

        public static void ChangeColor(int[,] data, int Opponent, int x, int y, int direction)
        {
            switch (direction)
            {
                case 1:
                    y--;
                    break;
                case 2:
                    x++;
                    y--;
                    break;
                case 3:
                    x++;
                    break;
                case 4:
                    x++;
                    y++;
                    break;
                case 5:
                    y++;
                    break;
                case 6:
                    x--;
                    y++;
                    break;
                case 7:
                    x--;
                    break;
                case 8:
                    x--;
                    y--;
                    break;
            }
            if (x >= 0 && y >= 0 && y < 8 && x < 8)
            {
                if (data[x, y] == Opponent)
                {
                    while (x >= 0 && y >= 0 && y < 8 && x < 8)
                    {

                        if (data[x, y] == 1 - Opponent)
                        {

                            ChangeColorHelper(data, Opponent, x, y, direction);


                        }
                        switch (direction)
                        {
                            case 1:
                                y--;
                                break;
                            case 2:
                                x++;
                                y--;
                                break;
                            case 3:
                                x++;
                                break;
                            case 4:
                                x++;
                                y++;
                                break;
                            case 5:
                                y++;
                                break;
                            case 6:
                                x--;
                                y++;
                                break;
                            case 7:
                                x--;
                                break;
                            case 8:
                                x--;
                                y--;
                                break;
                        }

                    }
                }
            }


        }

        public static void ChangeColorHelper(int[,] data, int Opponent, int x, int y, int direction)
        {
            switch (direction)
            {
                case 5:
                    y--;
                    break;
                case 6:
                    x++;
                    y--;
                    break;
                case 7:
                    x++;
                    break;
                case 8:
                    x++;
                    y++;
                    break;
                case 1:
                    y++;
                    break;
                case 2:
                    x--;
                    y++;
                    break;
                case 3:
                    x--;
                    break;
                case 4:
                    x--;
                    y--;
                    break;
            }
            while (data[x, y] == Opponent)
            {
                data[x, y] = 1 - Opponent;
                switch (direction)
                {
                    case 5:
                        y--;
                        break;
                    case 6:
                        x++;
                        y--;
                        break;
                    case 7:
                        x++;
                        break;
                    case 8:
                        x++;
                        y++;
                        break;
                    case 1:
                        y++;
                        break;
                    case 2:
                        x--;
                        y++;
                        break;
                    case 3:
                        x--;
                        break;
                    case 4:
                        x--;
                        y--;
                        break;
                }

            }

        }

        public static int CountAvailableMove(int[,] AvailableMove)
        {
            int count = 0;
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (AvailableMove[x, y] == 1)
                    {
                        count++;
                    }
                }
            }
            return count;
        }



    }
}



