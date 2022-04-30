using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{
    public partial class Form1 : Form
    {
        public int speed_left = 20;
        public int speed_top = 20;
        public int pointCount = 0;
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            Cursor.Hide();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true; //this keeps the playing field up top
            this.Bounds = Screen.PrimaryScreen.Bounds; //this makes the bounds the same as the window
            //Vertical Racket Position
            racket.Top = playground.Bottom - (playground.Bottom / 10);

            gameover_lbl.Left = (playground.Width / 2) - (gameover_lbl.Width / 2);
            gameover_lbl.Top = (playground.Height / 2) - (gameover_lbl.Height / 2);
            gameover_lbl.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            racket.Left = Cursor.Position.X - (racket.Width / 2);
            ball.Left += speed_left;
            ball.Top += speed_top;

            if (ball.Bottom >= racket.Top && ball.Bottom <= racket.Bottom && ball.Left >= racket.Left && ball.Right <= racket.Right)
            {
                speed_left += 2;
                speed_top = -speed_top;
                pointCount++;
                points_lbl.Text = pointCount.ToString();
            }

            if (ball.Left <= playground.Left)
            {
                speed_left = -speed_left;
            }
                
            else if (ball.Right >= playground.Right)
            {
                speed_left = -speed_left;
            }
                
            else if (ball.Top <= playground.Top)
            {
                speed_top = -speed_top;
            }
                
            else if (ball.Bottom >= playground.Bottom)
            {
                timer1.Enabled = false; //you missed
                gameover_lbl.Visible = true;
            }
                
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if(e.KeyCode == Keys.F1)
            {
                ball.Top = 50;
                ball.Left = 50;
                speed_left = 20;
                speed_top = 20;
                pointCount = 0;
                points_lbl.Text = "0";
                timer1.Enabled = true;
                gameover_lbl.Visible = false;
            }
        }

    }
}
