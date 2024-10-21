using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dungeon
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            Form1 f = new Form1();//產生Form2的物件，才可以使用它所提供的Method
            this.Hide();
            f.ShowDialog(this);//設定Form2為Form1的上層，並開啟Form2視窗。由於在Form1的程式碼內使用this，所以this為Form1的物件本身
            this.Close();
            
            }

        private void label1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();//產生Form2的物件，才可以使用它所提供的Method
            this.Hide();
            f.ShowDialog(this);//設定Form2為Form1的上層，並開啟Form2視窗。由於在Form1的程式碼內使用this，所以this為Form1的物件本身
            this.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();//產生Form2的物件，才可以使用它所提供的Method
            this.Hide();
            f.ShowDialog(this);//設定Form2為Form1的上層，並開啟Form2視窗。由於在Form1的程式碼內使用this，所以this為Form1的物件本身
            this.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
    }
    

