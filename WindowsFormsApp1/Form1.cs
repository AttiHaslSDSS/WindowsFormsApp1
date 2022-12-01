using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        Rectangle p1 = new Rectangle(165, 165, 35, 35);
        Rectangle p2 = new Rectangle(265, 265, 35, 35);
        Rectangle yeller = new Rectangle(1, 1, 35, 35);
        Rectangle green = new Rectangle(1, 1, 35, 35);
        Rectangle red = new Rectangle(1, 1, 35, 35);


        SolidBrush yellerBrush = new SolidBrush(Color.Yellow);
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush player1Brush = new SolidBrush(Color.IndianRed);
        SolidBrush player2Brush = new SolidBrush(Color.NavajoWhite);

        int player1Score = 0;
        int player2Score = 0;

        int playerSpeed = 6;

        bool wDown = false;
        bool sDown = false;
        bool aLeft = false;
        bool dRight = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        bool leftArrowLeft = false;
        bool rightArrowRight = false;


        public Form1()
        {
            InitializeComponent();

            yeller.X = random.Next(1, 265);
            yeller.Y = random.Next(1, 265);

            green.X = random.Next(1, 265);
            green.Y = random.Next(1, 265);

            red.X = random.Next(1, 265);
            red.Y = random.Next(1, 265);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(player1Brush, p1);
            e.Graphics.FillRectangle(player2Brush, p2);
            e.Graphics.FillRectangle(redBrush, red);
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
            //move player 1 
            if (wDown == true && p1.Y > 0)
            {
                p1.Y -= playerSpeed;
            }

            if (sDown == true && p1.Y < this.Height - p1.Height)
            {
                p1.Y += playerSpeed;
            }

            if (aLeft == true && p1.Y < this.Width - p1.Width)
            {
                p1.X -= playerSpeed;
            }

            if (dRight == true && p1.Y < this.Width - p1.Width)
            {
                p1.X += playerSpeed;
            }

            //move player 2 
            if (upArrowDown == true && p2.Y > 0)
            {
                p2.Y -= playerSpeed;
            }

            if (downArrowDown == true && p2.Y < this.Height - p2.Height)
            {
                p2.Y += playerSpeed;
            }


            if (leftArrowLeft == true && p2.Y < this.Width - p2.Width)
            {
                p2.X -= playerSpeed;
            }


            if (rightArrowRight == true && p2.Y < this.Width - p2.Width)
            {
                p2.X += playerSpeed;
            }

            if (p1.IntersectsWith(yeller))
            {
                yeller.X = random.Next(1, 265);
                yeller.Y = random.Next(1, 265);
                p1.Y += playerSpeed;
                p1.X += playerSpeed;
            }

            if (p1.IntersectsWith(green))
            {
                green.X = random.Next(1, 265);
                green.Y = random.Next(1, 265);
                ++player1Score;
            }

            if (p1.IntersectsWith(red))
            {
                red.X = random.Next(1, 265);
                red.Y = random.Next(1, 265);
                ++player2Score;
            }

            if (p2.IntersectsWith(yeller))
            {
                yeller.X = random.Next(1, 265);
                yeller.Y = random.Next(1, 265);
                p2.Y += playerSpeed;
                p2.X += playerSpeed;
            }

            if (p2.IntersectsWith(green))
            {
                green.X = random.Next(1, 265);
                green.Y = random.Next(1, 265);
                ++player2Score;
            }

            if (p2.IntersectsWith(red))
            {
                red.X = random.Next(1, 265);
                red.Y = random.Next(1, 265);
                ++player1Score;
            }
                
            if (player1Score == 3)
            {
                timer1.Enabled = false;
            }

             else if (player2Score == 3)
            {
                timer1.Enabled = false;
                winLabel.Text = $"You've Won!";
            }

            label2.Text = {player1Score};
            label3.Text = {player2Score};

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
