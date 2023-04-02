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
    public partial class LoginO : Form
    {
        private OleDbConnection conn;
        
        private OleDbCommand cmd = new OleDbCommand();
        //AppDomain.CurrentDomain.SetData("DataDirectory", @"D:\MyApp");
        //string a = AppDomain.CurrentDomain.BaseDirectory + "MyDatabase.mdb";

       // AppDomain.CurrentDomain.SetData("DataDirectory", @"D:\MyApp");
        //AppDomain.CurrentDomain.SetData("DataDirectory", @"D:\MyApp");
       // string connstring = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=true", Path.Combine(Directory.GetCurrentDirectory(), "MyDatabase01.accdb"));
      //string dbpath = AppDomain.CurrentDomain.BaseDirectory + "MyDatabase.mdb";
//string ConnStr = String.Format(Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Jet OLEDB:Database Password=password;", dbpath)
        public LoginO()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string IDG = ID.Text;
            string PSW = Ps.Text;
            string dbpath = AppDomain.CurrentDomain.BaseDirectory + "MyDatabase.mdb";
            string ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + dbpath + ";Jet OLEDB:Database Password=password;";

            //.Open();
            conn = new OleDbConnection(ConnectionString);
            conn.Open();
            cmd.Connection = conn;
            //cmd.CommandText = "SELECT * FROM AllST_TB WHERE WhoAdmin_R ='" + IDI + "'";
            //OleDbDataAdapter HOE = new OleDbDataAdapter(cmd);
            //DataSet QryDatas = new DataSet();
            //HOE.Fill(QryDatas);
            //cmd.CommandText = "SELECT * FROM AllST_TB WHERE ID_R ='" + PSW + "'";
            //OleDbDataAdapter HO = new OleDbDataAdapter(cmd);
            //DataSet QryData = new DataSet();
            // HO.Fill(QryData);
            cmd.CommandText = "SELECT * FROM Staff_TB WHERE ID_R ='" + IDG + "'";
            OleDbDataAdapter HOE = new OleDbDataAdapter(cmd);
            DataSet QryDatas = new DataSet();
            HOE.Fill(QryDatas);
            cmd.CommandText = "SELECT * FROM Staff_TB WHERE PS_R ='" + PSW + "'";
            OleDbDataAdapter HO = new OleDbDataAdapter(cmd);
            DataSet QryData = new DataSet();
            HO.Fill(QryData);

            //cmd.CommandText = "SELECT * FROM Admin_TB WHERE ID_R ='" + IDG + "'";
            //OleDbDataAdapter HOEE = new OleDbDataAdapter(cmd);
            //DataSet QryDatasE = new DataSet();
            //HOEE.Fill(QryDatasE);
            //cmd.CommandText = "SELECT * FROM Admin_TB WHERE PS_R ='" + PSW + "'";
            //OleDbDataAdapter HOW = new OleDbDataAdapter(cmd);
            //DataSet QryDataW = new DataSet();
            //HOW.Fill(QryDataW);
            if (QryData.Tables[0].Rows.Count > 0 & QryDatas.Tables[0].Rows.Count > 0)
            {
                this.panel1.Controls.Clear();
                Staff formRHJ = new Staff();
                formRHJ.TopLevel = false;
                formRHJ.Dock = DockStyle.Fill;
                this.panel1.Controls.Add(formRHJ);
                formRHJ.Show();
                ID.Visible = false;
                Ps.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                button1.Visible = false;

            }
            else
            {
                cmd.CommandText = "SELECT * FROM Admin_TB WHERE ID_R ='" + IDG + "'";
                OleDbDataAdapter HOEE = new OleDbDataAdapter(cmd);
                DataSet QryDatasE = new DataSet();
                HOEE.Fill(QryDatasE);
                cmd.CommandText = "SELECT * FROM Admin_TB WHERE PS_R ='" + PSW + "'";
                OleDbDataAdapter HOW = new OleDbDataAdapter(cmd);
                DataSet QryDataW = new DataSet();
                HOW.Fill(QryDataW);
                if (QryDatasE.Tables[0].Rows.Count > 0 & QryDataW.Tables[0].Rows.Count > 0)
                {
                    this.panel1.Controls.Clear();
                    Form13 formRHJG = new Form13();
                    formRHJG.TopLevel = false;
                    formRHJG.Dock = DockStyle.Fill;
                    this.panel1.Controls.Add(formRHJG);
                    formRHJG.Show();
                    ID.Visible = false;
                    Ps.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                    button1.Visible = false;



                }


                else
                {
                    MessageBox.Show("กรุณารอง อีก ครั้ง");
                }

            }
        }

        private void ID_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(AppDomain.CurrentDomain.BaseDirectory.ToString());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Ps_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
