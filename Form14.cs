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
    public partial class Form14 : Form
    {
        private OleDbConnection conn;
        private OleDbCommand cmd = new OleDbCommand();
        private string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Mydatabase\MyDatabase.mdb";
        public Form14()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new OleDbConnection(ConnectionString);
            conn.Open();
            string IDI = Pin.Text;
            
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Staff_TB WHERE PS_R ='" + IDI + "'";
            OleDbDataAdapter HO = new OleDbDataAdapter(cmd);
            DataSet QryData = new DataSet();
            HO.Fill(QryData);
            if (QryData.Tables[0].Rows.Count > 0)
            {
                this.Hide();
                Form12 H = new Form12();
                H.ShowDialog();
            }
            else {
                MessageBox.Show("ท่านกรอกรหัสไม่ถูกต้อง");
            }
        }
    }
}
