using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dungeon
{
    public partial class Form3 : Form
    {
        public Form3()
        {   
            InitializeComponent();
            //"C:\Users\User\Desktop\dungeon\dungeon\obj\Debug\database.txt"
            string s = Application.StartupPath + "\\database.txt";
            Database_load(s);
        }
        private void Database_load(string database_name)
        {
            string str;
            StreamReader sr = new StreamReader(Application.StartupPath + "\\database.txt", false);
            str = sr.ReadToEnd();
            sr.Close();
            this.label1.Text = str;
        }
        private void Database_wirte(string wirte_str)
        { 
            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\database.txt", false);
            sw.WriteLine(wirte_str);
            sw.Close();//寫入
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
