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
    public partial class CEO : Form
    {
        private OleDbConnection conn;
        
        private OleDbCommand cmd = new OleDbCommand();
        //private string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Mydatabase\MyDatabase.mdb";

        OleDbDataAdapter NB;
        OleDbCommandBuilder TN;
        DataTable TB;
        OleDbDataAdapter NA;
        DataTable TPA;
        OleDbCommandBuilder HO;


        OleDbDataAdapter NBE;
        OleDbCommandBuilder TNE;
        DataTable TBE;

        public CEO()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // OleDbConnection conn = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\\Mydatabase\\MyDatabase.mdb");
            string dbpath = AppDomain.CurrentDomain.BaseDirectory + "MyDatabase.mdb";
            string ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + dbpath + ";Jet OLEDB:Database Password=password;";
            NB = new OleDbDataAdapter("SELECT F_Room,R_Resident_F,R_Resident_L,R_Resident_cardnumber,R_Resident_Email,R_Resident_TP,R_Thenumberofdaysofstay,PF_Room FROM 101_TB", conn);


            DialogResult mb = new DialogResult();
            mb = MessageBox.Show("You Want?", "sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mb == DialogResult.Yes)
            {
                TN = new OleDbCommandBuilder(NB);
                NB.Update(TB);
                TB = new DataTable();
                NB.Fill(TB);
                dataGridView1.DataSource = TB;
                MessageBox.Show("ทำการ UPDATE แล้ว");
            }
            else { }

        }

        private void Form13_Load(object sender, EventArgs e)
        {
            //OleDbConnection conn = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\\Mydatabase\\MyDatabase.mdb");
            string dbpath = AppDomain.CurrentDomain.BaseDirectory + "MyDatabase.mdb";
            string ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + dbpath + ";Jet OLEDB:Database Password=password;";
            NB = new OleDbDataAdapter("SELECT F_Room,R_Resident_F,R_Resident_L,R_Resident_cardnumber,R_Resident_Email,R_Resident_TP,R_Thenumberofdaysofstay,PF_Room FROM 101_TB", conn);
            NA = new OleDbDataAdapter("SELECT ID_R,PS_R FROM Staff_TB", conn);
            TB = new DataTable();
            TPA = new DataTable();


            NBE = new OleDbDataAdapter("SELECT WhoAdmin_R,ID_R,Ps_R,Ps2_R FROM Admin_TB", conn);
            TBE = new DataTable();
            dataGridView3.DataSource = TBE;
            NBE.Fill(TBE);
            NB.Fill(TB);
            NA.Fill(TPA);
            dataGridView1.DataSource = TB;
            dataGridView2.DataSource = TPA;
            
            timer1.Start();

        }

        private void button2_Click(object sender, EventArgs e)
        {
           // OleDbConnection conn = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\\Mydatabase\\MyDatabase.mdb");
            string dbpath = AppDomain.CurrentDomain.BaseDirectory + "MyDatabase.mdb";
            string ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + dbpath + ";Jet OLEDB:Database Password=password;";
            NB = new OleDbDataAdapter("SELECT F_Room,R_Resident_F,R_Resident_L,R_Resident_cardnumber,R_Resident_Email,R_Resident_TP,R_Thenumberofdaysofstay,PF_Room FROM 101_TB", conn);

            TB = new DataTable();
            NB.Fill(TB);
            dataGridView1.DataSource = TB;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string key = MMO.Text;
            string dbpath = AppDomain.CurrentDomain.BaseDirectory + "MyDatabase.mdb";
            string ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + dbpath + ";Jet OLEDB:Database Password=password;";


            conn = new OleDbConnection(ConnectionString);
            conn.Open();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT * FROM 101_TB WHERE R_Resident_F LIKE '%" + key + "%' ";


            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

            DataSet QryData = new DataSet();

            adapter.Fill(QryData);

            dataGridView1.DataSource = QryData.Tables[0];

            dataGridView1.Update();

            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
            
           // OleDbConnection conn = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\\Mydatabase\\MyDatabase.mdb");
            string dbpath = AppDomain.CurrentDomain.BaseDirectory + "MyDatabase.mdb";
            string ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + dbpath + ";Jet OLEDB:Database Password=password;";
            NA = new OleDbDataAdapter("SELECT ID_R,PS_R FROM Staff_TB", conn);


            DialogResult mb = new DialogResult();
            mb = MessageBox.Show("You Want?", "sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mb == DialogResult.Yes)
            {
                HO = new OleDbCommandBuilder(NA);
                NA.Update(TPA);
                TPA = new DataTable();
                NA.Fill(TPA);
                dataGridView2.DataSource = TPA;
                MessageBox.Show("ทำการ UPDATE แล้ว");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string M = DateTime.Now.ToLongTimeString();
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            DialogResult NNO = new DialogResult();
                NNO = MessageBox.Show("คุณแน่ใจหรอว่าทำการปรับเปลี่ยนข้อมูลอย่างถูกต้องแล้ว?", "ออกจากระบบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (NNO == DialogResult.Yes)
            {
                this.Close();
            }
            else { }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            string dbpath = AppDomain.CurrentDomain.BaseDirectory + "MyDatabase.mdb";
            string ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + dbpath + ";Jet OLEDB:Database Password=password;";
            NA = new OleDbDataAdapter("SELECT ID_R,PS_R FROM Staff_TB", conn);
            TPA = new DataTable();
            NA.Fill(TPA);
            dataGridView2.DataSource=TPA;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string keyU = HOT.Text;
            string dbpath = AppDomain.CurrentDomain.BaseDirectory + "MyDatabase.mdb";
            string ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + dbpath + ";Jet OLEDB:Database Password=password;";


            conn = new OleDbConnection(ConnectionString);
            conn.Open();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT * FROM Staff_TB WHERE ID_R LIKE '%" + keyU + "%' ";


            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

            DataSet QryData = new DataSet();

            adapter.Fill(QryData);

            dataGridView2.DataSource = QryData.Tables[0];

            dataGridView2.Update();

            conn.Close();
        }

        private void ออกจากโปรแกรมToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult N = new DialogResult();
            N = MessageBox.Show("คุณแน่ในหรอว่าทำการแก้ไขข้อมูลถูกต้องและเหมาะกับการใช้งานแล้ว", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (N == DialogResult.Yes)
            {
                this.Close();
            }
            
        }

        private void DN_Click(object sender, EventArgs e)
        {
  
        }

        private void Re_Click(object sender, EventArgs e)
        {
            //OleDbConnection conn = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\\Mydatabase\\MyDatabase.mdb");
            string dbpath = AppDomain.CurrentDomain.BaseDirectory + "MyDatabase.mdb";
            string ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + dbpath + ";Jet OLEDB:Database Password=password;";
            NA = new OleDbDataAdapter("SELECT ID_R,PS_R FROM Staff_TB", conn);
            TPA = new DataTable();
            NA.Fill(TPA);
            dataGridView2.DataSource = TPA;
        }

        private void button9_Click(object sender, EventArgs e)
        {

            
            //OleDbConnection conn = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\\Mydatabase\\MyDatabase.mdb");
            string dbpath = AppDomain.CurrentDomain.BaseDirectory + "MyDatabase.mdb";
            string ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + dbpath + ";Jet OLEDB:Database Password=password;";
            NBE = new OleDbDataAdapter("SELECT WhoAdmin_R,ID_R,Ps_R,Ps2_R FROM Admin_TB", conn);


            DialogResult mb = new DialogResult();
            mb = MessageBox.Show("You Want?", "sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mb == DialogResult.Yes)
            {
                TNE = new OleDbCommandBuilder(NBE);
                NBE.Update(TBE);
                TBE = new DataTable();
                NBE.Fill(TBE);
                dataGridView3.DataSource = TBE;
                MessageBox.Show("ทำการ UPDATE แล้ว");




            }
            else { }

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            string keye =textBox1.Text;

            string dbpath = AppDomain.CurrentDomain.BaseDirectory + "MyDatabase.mdb";
            string ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + dbpath + ";Jet OLEDB:Database Password=password;";

            conn = new OleDbConnection(ConnectionString);
            conn.Open();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT * FROM Admin_TB WHERE WhoAdmin_R LIKE '%" + keye + "%' ";


            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

            DataSet QryData = new DataSet();

            adapter.Fill(QryData);

            dataGridView3.DataSource = QryData.Tables[0];

            dataGridView3.Update();

            conn.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //OleDbConnection conn = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\\Mydatabase\\MyDatabase.mdb");
            string dbpath = AppDomain.CurrentDomain.BaseDirectory + "MyDatabase.mdb";
            string ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + dbpath + ";Jet OLEDB:Database Password=password;";
            NBE = new OleDbDataAdapter("SELECT WhoAdmin_R,ID_R,Ps_R,Ps2_R FROM Admin_TB", conn);

            TNE = new OleDbCommandBuilder(NBE);
            NBE.Update(TBE);
            TBE = new DataTable();
            NBE.Fill(TBE);
            dataGridView3.DataSource = TBE;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
