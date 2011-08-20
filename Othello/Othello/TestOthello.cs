using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using NUnit.Framework;

namespace Othello
{
    [TestFixture]
    class TestOthello
    {
        Form1 testForm = new Form1();

        [Test]
        public void Test_table() // Pieces change color correctly
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    testForm.data[x, y] = 3;
                }
            }
            testForm.mode = 2;
            testForm.TurnBlack = false;
            testForm.FirstPlayer = false;
            testForm.OpponentPiece = 1;
            testForm.data[3, 3] = 0;
            testForm.data[4, 4] = 0;
            testForm.data[3, 4] = 1;
            testForm.data[4, 3] = 1;

            testForm.Click_table(2, 4);
            //testForm.Click_table(3, 2);
            Assert.AreEqual(0, testForm.data[3, 4]);
            Assert.AreEqual(0, testForm.data[2, 4]);
            Assert.AreEqual(0, testForm.data[3, 3]);
            Assert.AreEqual(0, testForm.data[4, 4]);
            Assert.AreEqual(1, testForm.data[4, 3]);
            Assert.AreEqual(3, testForm.data[2, 3]);
        }

        [Test]
        public void Test_table_2() // Pieces change color correctly
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    testForm.data[x, y] = 3;
                }
            }
            testForm.mode = 2;
            testForm.TurnBlack = false;
            testForm.FirstPlayer = false;
            testForm.OpponentPiece = 1;
            testForm.data[3, 3] = 0;
            testForm.data[4, 4] = 0;
            testForm.data[3, 4] = 1;
            testForm.data[4, 3] = 1;

            testForm.Click_table(5, 3);
            //testForm.Click_table(3, 2);
            Assert.AreEqual(0, testForm.data[3, 3]);
            Assert.AreEqual(0, testForm.data[4, 4]);
            Assert.AreEqual(1, testForm.data[3, 4]);
            Assert.AreEqual(0, testForm.data[4, 3]);
            Assert.AreEqual(0, testForm.data[5, 3]);
            Assert.AreEqual(3, testForm.data[2, 3]);
        }

        [Test]
        public void Test_AvailableMove()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    testForm.data[x, y] = 3;
                }
            }
            testForm.mode = 2;
            testForm.TurnBlack = false;
            testForm.FirstPlayer = false;
            testForm.OpponentPiece = 1;
            testForm.data[3, 3] = 0;
            testForm.data[4, 4] = 0;
            testForm.data[3, 4] = 1;
            testForm.data[4, 3] = 1;
            testForm.AvailableMove = Playing.CheckAvailble(testForm.data, testForm.TurnBlack);

            Assert.AreEqual(0, testForm.AvailableMove[2, 2]);
            Assert.AreEqual(0, testForm.AvailableMove[3, 2]);
            Assert.AreEqual(1, testForm.AvailableMove[4, 2]);
            Assert.AreEqual(0, testForm.AvailableMove[5, 2]);
            Assert.AreEqual(1, testForm.AvailableMove[5, 3]);
            Assert.AreEqual(0, testForm.AvailableMove[5, 4]);
            Assert.AreEqual(0, testForm.AvailableMove[5, 5]);
            Assert.AreEqual(0, testForm.AvailableMove[4, 5]);
            Assert.AreEqual(1, testForm.AvailableMove[3, 5]);
            Assert.AreEqual(0, testForm.AvailableMove[2, 5]);
            Assert.AreEqual(1, testForm.AvailableMove[2, 4]);
            Assert.AreEqual(0, testForm.AvailableMove[2, 3]);

        }

        [Test]
        public void Test_AvailableMove_2()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    testForm.data[x, y] = 3;
                }
            }
            testForm.mode = 2;
            testForm.TurnBlack = false;
            testForm.FirstPlayer = false;
            testForm.OpponentPiece = 1;
            testForm.data[3, 3] = 0;
            testForm.data[4, 4] = 0;
            testForm.data[3, 4] = 1;
            testForm.data[4, 3] = 1;

            testForm.Click_table(2, 4);
            testForm.AvailableMove = Playing.CheckAvailble(testForm.data, testForm.TurnBlack);

            Assert.AreEqual(0, testForm.AvailableMove[2, 2]);
            Assert.AreEqual(0, testForm.AvailableMove[3, 2]);
            Assert.AreEqual(0, testForm.AvailableMove[4, 2]);
            Assert.AreEqual(0, testForm.AvailableMove[5, 2]);
            Assert.AreEqual(0, testForm.AvailableMove[5, 3]);
            Assert.AreEqual(0, testForm.AvailableMove[5, 4]);
            Assert.AreEqual(0, testForm.AvailableMove[5, 5]);
            Assert.AreEqual(1, testForm.AvailableMove[4, 5]);
            Assert.AreEqual(0, testForm.AvailableMove[3, 5]);
            Assert.AreEqual(1, testForm.AvailableMove[2, 5]);
            Assert.AreEqual(0, testForm.AvailableMove[2, 4]);
            Assert.AreEqual(1, testForm.AvailableMove[2, 3]);

        }

        [Test]
        public void Test_Score()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    testForm.data[x, y] = 3;
                }
            }
            testForm.mode = 2;
            testForm.TurnBlack = false;
            testForm.FirstPlayer = false;
            testForm.OpponentPiece = 1;
            testForm.data[3, 3] = 0;
            testForm.data[4, 4] = 0;
            testForm.data[3, 4] = 1;
            testForm.data[4, 3] = 1;
            testForm.UpdateScore();
            Assert.AreEqual(2, testForm.score[0]);
            Assert.AreEqual(2, testForm.score[1]);
        }


        [Test]
        public void Test_Score_2()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    testForm.data[x, y] = 3;
                }
            }
            testForm.mode = 2;
            testForm.TurnBlack = false;
            testForm.FirstPlayer = false;
            testForm.OpponentPiece = 1;
            testForm.data[3, 3] = 0;
            testForm.data[4, 4] = 0;
            testForm.data[3, 4] = 1;
            testForm.data[4, 3] = 1;

            testForm.Click_table(2, 4);
            testForm.UpdateScore();
            Assert.AreEqual(4, testForm.score[0]);
            Assert.AreEqual(1, testForm.score[1]);
        }

        [Test]
        public void Test_Load()
        {
            Object sender = new Object();
            EventArgs e = new EventArgs();

            testForm.Form1_Load(sender, e);

            testForm.UpdateScore();
            Assert.AreEqual(2, testForm.score[0]);
            Assert.AreEqual(2, testForm.score[1]);
        }


    }

}

