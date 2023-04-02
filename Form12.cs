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
    public partial class Form12 : Form
    {
        private OleDbConnection conn;
        private OleDbCommand cmd = new OleDbCommand();
        // private string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Mydatabase\MyDatabase.mdb";
        //string dbpath = AppDomain.CurrentDomain.BaseDirectory + "MyDatabase.mdb";
        //string ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + dbpath + ";Jet OLEDB:Database Password=password;";
        OleDbDataAdapter NB;
        OleDbCommandBuilder TN;
        DataTable TB;

        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            //OleDbConnection conn = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\\Mydatabase\\MyDatabase.mdb");
            string dbpath = AppDomain.CurrentDomain.BaseDirectory + "MyDatabase.mdb";
            string ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + dbpath + ";Jet OLEDB:Database Password=password;";
            conn = new OleDbConnection(ConnectionString);
            conn.Open();
            cmd.Connection = conn;
            NB = new OleDbDataAdapter("SELECT F_Room as ห้อง ,R_Resident_F as ชื่อ ,R_Resident_L as นามสกุล ,R_Resident_cardnumber as บัตรประชาชน ,R_Resident_Email as Email ,R_Resident_TP as เบอร์โทร ,D_R as วัน ,M_R as เดือน ,Y_R as ปี FROM All_TB", conn);

            TB = new DataTable();
            NB.Fill(TB);
            dataGridView1.DataSource = TB;




        }

        private void button1_Click(object sender, EventArgs e)
        {

           // OleDbConnection conn = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\\Mydatabase\\MyDatabase.mdb");
            //NB = new OleDbDataAdapter("SELECT F_Room as ห้อง ,R_Resident_F as ชื่อ ,R_Resident_L as นามสกุล ,R_Resident_cardnumber as บัตรประชาชน ,R_Resident_Email as Email ,R_Resident_TP as เบอร์โทร ,D_R as วัน ,M_R as เดือน ,Y_R as ปี FROM All_TB", conn);
            
            DialogResult mb = new DialogResult();
            mb = MessageBox.Show("You Want?", "sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mb == DialogResult.Yes)
            {
                TN = new OleDbCommandBuilder(NB);
                NB.Update(TB);
               

              
              
                MessageBox.Show("ทำการ UPDATE แล้ว");
            }
            else { }


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Key_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string key = txtKey.Text;

            string dbpath = AppDomain.CurrentDomain.BaseDirectory + "MyDatabase.mdb";
            string ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + dbpath + ";Jet OLEDB:Database Password=password;";

            conn = new OleDbConnection(ConnectionString);
            conn.Open();
            cmd.Connection = conn;
            
            cmd.CommandText = "SELECT * FROM All_TB WHERE R_Resident_F LIKE '%" + key + "%' OR R_Resident_L LIKE '%" + key + "%' OR R_Resident_cardnumber LIKE '%" + key + "%' ";
            

            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
              
            DataSet QryData = new DataSet();
              
            adapter.Fill(QryData);
            
            dataGridView1.DataSource = QryData.Tables[0];


          
       

            dataGridView1.Update();
            
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
           // OleDbConnection conn = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\\Mydatabase\\MyDatabase.mdb");
            string dbpath = AppDomain.CurrentDomain.BaseDirectory + "MyDatabase.mdb";
            string ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + dbpath + ";Jet OLEDB:Database Password=password;";
            NB = new OleDbDataAdapter("SELECT F_Room as ห้อง ,R_Resident_F as ชื่อ ,R_Resident_L as นามสกุล ,R_Resident_cardnumber as บัตรประชาชน ,R_Resident_Email as Email ,R_Resident_TP as เบอร์โทร ,D_R as วัน ,M_R as เดือน ,Y_R as ปี FROM All_TB", conn);
        
            TB = new DataTable();
            NB.Fill(TB);
            dataGridView1.DataSource = TB;
            dataGridView1.Update();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DialogResult N = new DialogResult();
            N = MessageBox.Show("คุณแน่ในหรอว่าทำการแก้ไขข้อมูลถูกต้องและเหมาะกับการใช้งานแล้ว", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (N == DialogResult.Yes)
            {
                this.Close();
            }
            }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
