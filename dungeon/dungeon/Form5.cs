using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dungeon
{
    public partial class Form5 : Form
    {
        int flag = 0;
        int pass = 0;
        int shord = 0;
        Bitmap imga, imgs, imgd, imgw;

        public Form5()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            Reset();

        }
        private void Reset()
        {
            imga = Properties.Resources._003;
            imgs = Properties.Resources._000;
            imgd = Properties.Resources._006;
            imgw = Properties.Resources._009;
            pictureBox14.Location = new System.Drawing.Point(653, 28);
            pictureBox14.Size = new System.Drawing.Size(40, 43);
            this.Size = new System.Drawing.Size(739, 676);
            pictureBox1.Location = new System.Drawing.Point(72, 28);
            pictureBox1.Size = new System.Drawing.Size(575, 75);
            pictureBox2.Location = new System.Drawing.Point(618, 91);
            pictureBox2.Size = new System.Drawing.Size(100, 443);
            pictureBox4.Location = new System.Drawing.Point(83, 532);
            pictureBox4.Size = new System.Drawing.Size(547, 50);
            pictureBox3.Location = new System.Drawing.Point(22, 93);
            pictureBox3.Size = new System.Drawing.Size(63, 411);
            ball.Location = new System.Drawing.Point(170,387);
            ball.Size = new System.Drawing.Size(26, 34);
            key.Location = new System.Drawing.Point(572, 487);
            key.Size = new System.Drawing.Size(35, 33);
            pictureBox10.Location = new System.Drawing.Point(513, 54);
            pictureBox10.Size = new System.Drawing.Size(35, 75);
            pictureBox9.Location = new System.Drawing.Point(341, 143);
            pictureBox9.Size = new System.Drawing.Size(36, 33);
            pictureBox6.Location = new System.Drawing.Point(396, 288);
            pictureBox6.Size = new System.Drawing.Size(30, 26);
            pictureBox8.Location = new System.Drawing.Point(287, 339);
            pictureBox8.Size = new System.Drawing.Size(30, 29);
            pictureBox7.Location = new System.Drawing.Point(400, 443);
            pictureBox7.Size = new System.Drawing.Size(30, 16);
            pictureBox5.Location = new System.Drawing.Point(450, 391);
            pictureBox5.Size = new System.Drawing.Size(45, 75);
            pictureBox11.Location = new System.Drawing.Point(570, 193);
            pictureBox11.Size = new System.Drawing.Size(36, 33);
            pictureBox12.Location = new System.Drawing.Point(512, 339);
            pictureBox12.Size = new System.Drawing.Size(36, 33);
            pictureBox13.Location = new System.Drawing.Point(281, 487);
            pictureBox13.Size = new System.Drawing.Size(36, 33);
            toyz1.Location = new System.Drawing.Point(532,244);
            toyz1.Size = new System.Drawing.Size(16, 22);
            toyz2.Location = new System.Drawing.Point(580, 291);
            toyz2.Size = new System.Drawing.Size(19, 26);
            mon1.Location = new System.Drawing.Point(225, 194);
            mon1.Size = new System.Drawing.Size(33, 32);
            mon2.Location = new System.Drawing.Point(461, 247);
            mon2.Size = new System.Drawing.Size(34, 19);
            mon1.Visible= true;
            mon2.Visible= true;
            key.Visible= true;
            pictureBox10.Visible= true;
            textBox1.Visible= false;
            button1.Visible= false;
        }
        private void Toyz_reset()
        {
            Thread.Sleep(1);
            toyz1.Location = new System.Drawing.Point(532, 244);
            toyz2.Location = new System.Drawing.Point(580, 291);
            
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
        private void things_bound(PictureBox a,int k)
        {
            if (a.Bounds.IntersectsWith(pictureBox6.Bounds) || a.Bounds.IntersectsWith(pictureBox8.Bounds) || a.Bounds.IntersectsWith(pictureBox9.Bounds) || a.Bounds.IntersectsWith(pictureBox5.Bounds) || a.Bounds.IntersectsWith(pictureBox7.Bounds))
                flag = 1;
            if (a.Bounds.IntersectsWith(pictureBox11.Bounds) || a.Bounds.IntersectsWith(pictureBox12.Bounds) || a.Bounds.IntersectsWith(pictureBox13.Bounds))
            {
                flag = 1;
                Reset();
                if (k == 1) a.Top -= 30;
                if (k == 2) a.Top += 20;
                if (k == 3) a.Left -= 40;
                if (k == 4) a.Left += 22;
            }
            if (a.Bounds.IntersectsWith(mon2.Bounds))
            {
                flag = 1;
                if (shord == 1)
                {
                    ball.BackgroundImage = Properties.Resources.up_hit;
                    Thread.Sleep(1);
                    ball.Refresh();
                    Thread.Sleep(150);
                    mon2.Visible = false;
                    mon2.Location = new Point(0, 0);
                }
            }
            if (a.Bounds.IntersectsWith(mon1.Bounds))
            {
                flag = 1;
                if (shord == 1)
                {
                    pass = 1;
                    ball.BackgroundImage = Properties.Resources.left_hit;
                    Thread.Sleep(1);
                    ball.Refresh();
                    Thread.Sleep(150);
                    pictureBox10.Visible = false;
                    mon1.Visible = false;
                    mon1.Location = new Point(0, 0);
                }
            }
            if (a.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                Toyz_reset();
                flag = 1;
            }
            if (a.Bounds.IntersectsWith(pictureBox3.Bounds))
            {
                Toyz_reset();
                flag = 1; 
            }
            if (a.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                flag = 1;
                Toyz_reset();
            }
            if (a.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                flag = 1;
                Toyz_reset();
            }
            if (a.Bounds.IntersectsWith(pictureBox10.Bounds))
            {
                if (pass == 1)
                {
                   
                    textBox1.Location= new Point(739/2, 676/2);
                    textBox1.Visible= true;
                    button1.Location = new Point(739 / 2, 676 / 2-50);
                    button1.Visible = true;
                }
            }
            if (a.Bounds.IntersectsWith(key.Bounds))
            {
                flag = 1;
                shord = 1;
                a.Left +=40;
                key.Visible = false;
                key.Location = new Point(0, 0);
                imga = Properties.Resources.leftward;
                imgs = Properties.Resources.downward_;
                imgd = Properties.Resources.rightward;
                imgw = Properties.Resources.upward;
            }
            if (a.Bounds.IntersectsWith(toyz1.Bounds))
            {
                ball.Location = toyz1.Location;
                toyz1.Location = new Point(0, 0);
                flag = 1;
            }
            if (a.Bounds.IntersectsWith(toyz2.Bounds))
            {
                ball.Location = toyz2.Location;
                if (k == 1) a.Top -= 30;
                if (k == 2) a.Top += 20;
                if (k == 3) a.Left -= 40;
                if (k == 4) a.Left += 22;
                toyz2.Location = new Point(0, 0);
                
                flag = 1;
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str;
            StreamReader sr = new StreamReader(Application.StartupPath + "\\database.txt", false);
            str = sr.ReadToEnd();
            sr.Close();
            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\database.txt", false);
            string Date = DateTime.Now.ToString("dd-MM-yyyy");
            string wirte_str = textBox1.Text+" "+Date;
            sw.WriteLine(str);
            sw.WriteLine(wirte_str);
            sw.Close();//寫入
            this.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void Form5_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    while (flag == 0)
                    {
                        things_bound(ball,3);
                        Walk(ball,imga , 3);
                        
                    }
                    flag = 0;
                    ball.Left += 40;
                    break;
                case Keys.S:
                    while (flag == 0)
                    {
                        things_bound(ball,2);
                        Walk(ball, Properties.Resources._000, 2);
                        
                    }
                    flag = 0;
                    ball.Top -= 20;
                    break;
                case Keys.D:
                    while (flag == 0)
                    {
                        things_bound(ball,4);
                        Walk(ball, Properties.Resources._006, 4);
                    }
                    flag = 0;
                    ball.Left -= 22;
                    break;
                case Keys.W:
                    while (flag == 0)

                    {
                        things_bound(ball,1);
                        Walk(ball, Properties.Resources._009, 1);
                    }
                    flag = 0;
                    ball.Top += 30;
                    break;
                case Keys.Enter:
                    Console.WriteLine(this.Size);
                    break;

            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }
    }
}
