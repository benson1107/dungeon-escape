using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dungeon
{
    public partial class Form4 : Form
    {
        int flag = 0;
        int pass = 0;
        int shord = 0;
        Bitmap imga, imgs, imgd, imgw;
        public Form4()
        {
            InitializeComponent();
            Reset();
        }
        private void Reset()
        {   imga= Properties.Resources._003; 
            imgs = Properties.Resources._000;
            imgd = Properties.Resources._006;
            imgw = Properties.Resources._009;
            this.Size = new System.Drawing.Size(793, 475);
            ball.Location = new System.Drawing.Point(480,118);
            ball.Size = new System.Drawing.Size(24, 35);
            key.Location = new System.Drawing.Point(366, 169);
            key.Size = new System.Drawing.Size(22, 28);
            mon1.Location = new System.Drawing.Point(259, 261);
            mon1.Size = new System.Drawing.Size(50, 27);
            mon2.Location = new System.Drawing.Point(422, 207);
            mon2.Size = new System.Drawing.Size(42, 45);
            pictureBox5.Location = new System.Drawing.Point(265, 75);
            pictureBox5.Size = new System.Drawing.Size(36, 58);
            pictureBox1.Location = new System.Drawing.Point(230, 50);
            pictureBox1.Size = new System.Drawing.Size(317, 50);
            pictureBox2.Location = new System.Drawing.Point(520, 57);
            pictureBox2.Size = new System.Drawing.Size(36, 311);
            pictureBox3.Location = new System.Drawing.Point(217, 50);
            pictureBox3.Size = new System.Drawing.Size(40, 341);
            pictureBox4.Location = new System.Drawing.Point(231, 345);
            pictureBox4.Size = new System.Drawing.Size(317, 50);

        }
        private void Walk(PictureBox a, Bitmap s, int k)
        {
            a.BackgroundImage = null;
            a.Refresh();
            if (k == 1) a.Top -= 5;
            if (k == 2) a.Top += 5;
            if (k == 3) a.Left -= 5;
            if (k == 4) a.Left += 5;
            a.BackgroundImage = s;
            a.Refresh();
            Thread.Sleep(1);
        }
        private void things_bound(PictureBox a)
        {
            if (a.Bounds.IntersectsWith(mon1.Bounds))
            {
                flag = 1;
                if (shord == 1)
                {
                    ball.BackgroundImage = Properties.Resources.down_hit;
                    Thread.Sleep(1);
                    ball.Refresh();
                    Thread.Sleep(150);
                    mon1.Visible = false;
                    mon1.Location= new Point(0, 0);
                }
            }
            if (a.Bounds.IntersectsWith(mon2.Bounds))
            { 
                flag = 1;
                if (shord == 1)
                {
                    pass = 1;
                    ball.BackgroundImage = Properties.Resources.right_hit;
                    Thread.Sleep(1);
                    ball.Refresh();
                    Thread.Sleep(150);
                    pictureBox5.BackgroundImage = null;
                    mon2.Visible = false;
                    mon2.Location = new Point(0, 0);
                }
            }
            if (a.Bounds.IntersectsWith(pictureBox1.Bounds))
                flag = 1;
            if (a.Bounds.IntersectsWith(pictureBox2.Bounds))
                flag = 1;
            if (a.Bounds.IntersectsWith(pictureBox3.Bounds))
                flag = 1;
            if (a.Bounds.IntersectsWith(pictureBox4.Bounds))
                flag = 1;
            if (a.Bounds.IntersectsWith(key.Bounds))
            {
                flag = 1;
                shord = 1;
                a.Top -= 40;
                key.Visible = false;    
                key.Location = new Point(0, 0);
                imga = Properties.Resources.leftward;
                imgs = Properties.Resources.downward_;
                imgd = Properties.Resources.rightward;
                imgw = Properties.Resources.upward;
            }

            if (a.Bounds.IntersectsWith(pictureBox5.Bounds))
            {
                if (pass == 1)
                {   
                    flag = 1;
                    Form5 f = new Form5();//產生Form2的物件，才可以使用它所提供的Method
                    this.Hide();
                    f.ShowDialog(this);//設定Form2為Form1的上層，並開啟Form2視窗。由於在Form1的程式碼內使用this，所以this為Form1的物件本身
                    this.Close();
                }
            }
        }
        private void Form4_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    while (flag == 0)
                    {
                        things_bound(ball);
                        Walk(ball, imga, 3);
                    }
                    flag = 0;
                    ball.Left += 10;
                    break;
                case Keys.S:
                    while (flag == 0)
                    {
                        things_bound(ball);
                        Walk(ball, imgs, 2);
                       
                    }
                    flag = 0;
                    ball.Top -= 20;
                    break;
                case Keys.D:
                    while (flag == 0)
                    {
                        things_bound(ball);
                        Walk(ball, imgd, 4);
                    }
                    flag = 0;
                    ball.Left -= 20;
                    break;
                case Keys.W:
                    while (flag == 0)

                    {
                        things_bound(ball);
                        Walk(ball, imgw, 1);
                    }
                    flag = 0;
                    ball.Top += 10;
                    break;
                case Keys.Enter:
                    Console.WriteLine(this.Size);
                    break;

            }
        }
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
