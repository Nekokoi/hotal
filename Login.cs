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
    public partial class Login : Form
    {
        private OleDbConnection conn;
        private OleDbCommand cmd = new OleDbCommand();
        private string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Mydatabase\MyDatabase.mdb";
        public Login()
        {
            InitializeComponent();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            
            
        }

        private void ออกจากโปนแกรมToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult H = new DialogResult();
            H = MessageBox.Show("คุณต้องการออกหรือไม่", "ออกจากระบบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (H == DialogResult.Yes) { Application.Exit(); }
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();

            Admin form = new Admin();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(form);
            form.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();

            Staff forsms = new Staff();
            forsms.TopLevel = false;
            forsms.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(forsms);
            forsms.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {



        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
