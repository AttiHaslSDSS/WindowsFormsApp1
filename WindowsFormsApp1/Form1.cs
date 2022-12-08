using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        Rectangle p1 = new Rectangle(165, 165, 35, 35);
        Rectangle p2 = new Rectangle(265, 265, 35, 35);
        Rectangle yeller = new Rectangle(1, 1, 35, 35);
        Rectangle green = new Rectangle(1, 1, 35, 35);
        


        SolidBrush yellerBrush = new SolidBrush(Color.Yellow);
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush player1Brush = new SolidBrush(Color.IndianRed);
        SolidBrush player2Brush = new SolidBrush(Color.NavajoWhite);

        int player1Score = 0;
        int player2Score = 0;

        int playerSpeed1 = 6;
        int playerSpeed2 = 6;

        bool wDown = false;
        bool sDown = false;
        bool aLeft = false;
        bool dRight = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowLeft = false;
        bool rightArrowRight = false;

        int counter1 = 0;
        int counter2 = 0;


        public Form1()
        {
            InitializeComponent();

            yeller.X = random.Next(1, 700);
            yeller.Y = random.Next(1, 400);

            green.X = random.Next(1, 700);
            green.Y = random.Next(1, 400); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(player1Brush, p1);
            e.Graphics.FillRectangle(player2Brush, p2);
            e.Graphics.FillRectangle(greenBrush, green);
            e.Graphics.FillRectangle(yellerBrush, yeller);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.A:
                    aLeft = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.D:
                    dRight = true;
                    break;

                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowLeft = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowRight = true;
                    break;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (p1.IntersectsWith(p2))
            {

                p1.X = random.Next(1, 750);
                p1.Y = random.Next(1, 400);

                p2.X = random.Next(1, 750);
                p2.Y = random.Next(1, 400);

            }

            if (p1.IntersectsWith(green))
            {
                green.X = random.Next(1, 750);
                green.Y = random.Next(1, 400);
                ++player1Score;
            }

            if (p1.IntersectsWith(green))
            {
                green.X = random.Next(1, 750);
                green.Y = random.Next(1, 400);
                ++player1Score;
            }

            if (counter1 == 200)
            {
                playerSpeed1 = 6;
            }

            if (counter2 == 200)
            {
                playerSpeed2 = 6;
            }

            //move player 1 
            if (wDown == true && p1.Y > 0)
            {
                p1.Y -= playerSpeed1;
            }

            if (sDown == true && p1.Y < this.Height - p1.Height)
            {
                p1.Y += playerSpeed1;
            }

            if (aLeft == true && p1.Y < this.Width - p1.Width)
            {
                p1.X -= playerSpeed1;
            }

            if (dRight == true && p1.Y < this.Width - p1.Width)
            {
                p1.X += playerSpeed1;
            }

            //move player 2 
            if (upArrowDown == true && p2.Y > 0)
            {
                p2.Y -= playerSpeed2;
            }

            if (downArrowDown == true && p2.Y < this.Height - p2.Height)
            {
                p2.Y += playerSpeed2;
            }


            if (leftArrowLeft == true && p2.Y < this.Width - p2.Width)
            {
                p2.X -= playerSpeed2;
            }


            if (rightArrowRight == true && p2.Y < this.Width - p2.Width)
            {
                p2.X += playerSpeed2;
            }

            if (p1.IntersectsWith(yeller))
            {
                yeller.X = random.Next(1, 750);
                yeller.Y = random.Next(1, 400);
                p1.Y += playerSpeed1;
                p1.X += playerSpeed1;
                playerSpeed1 = 12;
            }

            if (p1.IntersectsWith(green))
            {
                green.X = random.Next(1, 750);
                green.Y = random.Next(1, 400);
                ++player1Score;
            }

            if (p2.IntersectsWith(yeller))
            {
                yeller.X = random.Next(1, 750);
                yeller.Y = random.Next(1, 400);
                p2.Y += playerSpeed2;
                p2.X += playerSpeed2;
                playerSpeed2 = 12;
            }

            if (p2.IntersectsWith(green))
            {
                green.X = random.Next(1, 750);
                green.Y = random.Next(1, 400);
                ++player2Score;
            }
                
            if (player1Score == 3)
            {
                timer1.Enabled = false;
                winLabel.ForeColor = Color.White;
                winLabel.Text = $"Player 1 Won!";
            }

             else if (player2Score == 3)
            {
                timer1.Enabled = false;
                winLabel.ForeColor = Color.White;
                winLabel.Text = $"Player 2 Won!";
            }

            label2.Text = $"{player1Score}";
            label3.Text = $"{player2Score}";

             if (playerSpeed1 == 12)
            {
                counter1++;
            }

            if (playerSpeed2 == 12)
            {
                counter2++;
            }

            Refresh();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.A:
                    aLeft = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.D:
                    dRight = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowLeft = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowRight = false;
                    break;
            }
        }
    }
}
