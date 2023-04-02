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
    public partial class KO : Form
    {
        private OleDbConnection conn;

        private OleDbCommand cmd = new OleDbCommand();
        public KO()
        {
            InitializeComponent();
        }

        private void KO_Load(object sender, EventArgs e)
        {
            timer1.Start();


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
                Staff formRHJE = new Staff();
                formRHJE.TopLevel = false;
                formRHJE.Dock = DockStyle.Fill;
                this.panel1.Controls.Add(formRHJE);
                formRHJE.Show();
                ID.Text = "";
                Ps.Text = "";
                ID.Visible = false;
                Ps.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                button1.Visible = false;
                toolStripMenuItem4.Visible = true;

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
                    ID.Text = "";
                    Ps.Text = "";
                    ID.Visible = false;
                    Ps.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    button1.Visible = false;
                    toolStripMenuItem4.Visible = true;



                }


                else
                {
                    MessageBox.Show("กรุณารอง อีก ครั้ง");
                }

            }




           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            Admin HI = new Admin();
            HI.TopLevel = false;
            HI.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(HI);
            HI.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string timeText = DateTime.Now.ToLongTimeString();  //เวลา

            //Time.Text = timeText;
            // String MO = DateTime.Now.ToLongDateString();
            // da.Text = MO;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CH HC = new CH();
            HC.Show();
        }

        private void optionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            CEOlog HIE = new CEOlog();
            HIE.TopLevel = false;
            HIE.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(HIE);
            HIE.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            Chang HIEE = new Chang();
            HIEE.TopLevel = false;
            HIEE.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(HIEE);
            HIEE.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            DialogResult HOH = new DialogResult();
            HOH = MessageBox.Show("Yousure?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (HOH == DialogResult.Yes)
            {
                this.panel1.Controls.Clear();
                ID.Text = "";
                Ps.Text = "";
                ID.Visible = true;
                Ps.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                button1.Visible = true;
                toolStripMenuItem4.Visible = false;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            LoginO HIEE = new LoginO();
            HIEE.TopLevel = false;
            HIEE.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(HIEE);
            HIEE.Show();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
    

