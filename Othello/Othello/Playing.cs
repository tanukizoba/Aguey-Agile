using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Othello
{
    class Playing
    {
        public static void WritePiece(int[,] data,System.Windows.Forms.Panel panel)
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
    }
}
