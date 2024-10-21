using System;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Configuration;

namespace dungeon
{
    //1188, 710
    public partial class Form1 : Form
    {
        int rectangle = 1;
        int flag= 0;
        int pass = 0;
        public Form1()
        {
            InitializeComponent();
            Reset();
        }
        private void Reset()
        {
            this.Size = new System.Drawing.Size(793, 475);
            pictureBox1.Location = new System.Drawing.Point(220, -10);
            pictureBox1.Size = new System.Drawing.Size(338, 76);
            pictureBox2.Location = new System.Drawing.Point(554, 47);
            pictureBox2.Size = new System.Drawing.Size(66, 349);
            pictureBox4.Location = new System.Drawing.Point(220, 369);
            pictureBox4.Size = new System.Drawing.Size(338, 52);
            pictureBox3.Location = new System.Drawing.Point(127, 38);
            pictureBox3.Size = new System.Drawing.Size(95, 358);
            ball.Location = new System.Drawing.Point(226, 327);
            ball.Size = new System.Drawing.Size(31, 38);
            key.Location = new System.Drawing.Point(487, 327);
            key.Size = new System.Drawing.Size(26, 38);
            pictureBox5.Location = new System.Drawing.Point(487, 47);
            pictureBox5.Size = new System.Drawing.Size(24, 33);
            key.Visible = true;
            pictureBox5.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Walk(PictureBox a , Bitmap s,int k)
        {
            a.BackgroundImage = null;
            a.Refresh();
            if(k == 1)a.Top -= 5;
            if (k == 2) a.Top += 5;
            if (k == 3) a.Left -= 5;
            if (k == 4) a.Left += 5;
            a.BackgroundImage = s;
            a.Refresh();
            Thread.Sleep(1);
        }
        private void things_bound(PictureBox a)
        {
            if (a.Bounds.IntersectsWith(pictureBox1.Bounds))
                flag = 1;
            if (a.Bounds.IntersectsWith(pictureBox3.Bounds))
                flag = 1;
            if (a.Bounds.IntersectsWith(pictureBox4.Bounds))
                flag = 1;
            if (a.Bounds.IntersectsWith(pictureBox2.Bounds))
                flag = 1;
            if (a.Bounds.IntersectsWith(pictureBox5.Bounds))
            {
                if (pass == 1)
                {
                    flag = 1;
                    Form4 f4 = new Form4();//產生Form2的物件，才可以使用它所提供的Method
                    this.Hide();
                    f4.ShowDialog(this);//設定Form2為Form1的上層，並開啟Form2視窗。由於在Form1的程式碼內使用this，所以this為Form1的物件本身
                    this.Close();
                }
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    while (flag==0)
                    {
                        things_bound(ball);
                        Walk(ball, Properties.Resources._003, 3);
                        if (ball.Bounds.IntersectsWith(key.Bounds))
                        {
                            pass = 1;
                            pictureBox5.Visible = false;
                            ball.Location = key.Location;
                            key.Visible = false;
                            key.Location = new Point(0, 0);
                            ball.Refresh();
                            break;
                        }
                    }
                    flag = 0;
                    ball.Left += 10;
                    break;
                case Keys.S:
                    while (flag == 0)
                    {
                        things_bound(ball);
                        Walk(ball, Properties.Resources._000, 2);
                        if (ball.Bounds.IntersectsWith(key.Bounds))
                        {
                            pass = 1;
                            pictureBox5.Visible = false;
                            ball.Top -= 10;
                            key.Visible = false;
                            key.Location = new Point(0, 0);
                            ball.Refresh();
                            break;
                        }
                    }
                    flag = 0;
                    ball.Top -= 10;
                    break;
                case Keys.D:
                    while (flag==0)
                    {
                        things_bound(ball);
                        Walk(ball, Properties.Resources._006,4);
                        if (ball.Bounds.IntersectsWith(key.Bounds))
                        {
                            pass = 1;
                            pictureBox5.Visible = false;
                            ball.Location =key.Location;
                            key.Visible = false;
                            key.Location = new Point(0, 0);
                            ball.Refresh();
                            break;
                        }
                    }
                    flag = 0;
                    ball.Left -= 10;
                    break;
                case Keys.W:
                    while (flag == 0) 

                    {
                        things_bound(ball);
                        Walk(ball, Properties.Resources._009,1);
                        if (ball.Bounds.IntersectsWith(key.Bounds))
                        {
                            pass = 1;
                            pictureBox5.Visible= false;
                            ball.Top -= 10;
                            key.Visible = false;
                            key.Location =new Point(0, 0);
                            ball.Refresh();
                            break;
                        }
                    }
                    flag = 0;
                    ball.Top += 10;
                    break;
                case Keys.Enter:
                    Console.WriteLine(this.Size);
                    break;

            }
        }



        private void ball_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
