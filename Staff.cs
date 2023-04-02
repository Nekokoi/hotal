using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace HOH
{
    public partial class Staff : Form
    {
        private OleDbConnection conn;
        private OleDbCommand cmd = new OleDbCommand();
        private string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Mydatabase\MyDatabase.mdb";
        public Staff()
        {
            InitializeComponent();
        }

        private void button21_Click(object sender, EventArgs e)
        {
        }
          

        private void Ps_TextChanged(object sender, EventArgs e)
        {

        }

        private void ID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {



        }

        private void Staff_Load(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            Form1 formRHJ = new Form1();
            formRHJ.TopLevel = false;
            formRHJ.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(formRHJ);
            formRHJ.Show();
          


           
            this.panel2.Controls.Clear();
            Form12 formRHJS = new Form12();
            formRHJS.TopLevel = false;
            formRHJS.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(formRHJS);
            formRHJS.Show();
        }
    }
    }


