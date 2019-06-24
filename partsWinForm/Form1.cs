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
using System.Data.Odbc;


namespace partsWinForm
{
    public partial class Form1 : Form
    {
        private static string connstr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=repairDB.mdb;";
        //repairDB.mdb
        private OleDbConnection myConn;

        public Form1()
        {
            InitializeComponent();
            myConn = new OleDbConnection(connstr);
            myConn.Open();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConn.Close();
        }

        private void selectTest()
        {
            string query = "SELECT ID_Pair FROM Pairs WHERE id = 1";
            OleDbCommand command = new OleDbCommand(query, myConn);
            textBox1.Text = command.ExecuteScalar().ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            selectTest();
            LoadData();
        }

        private void LoadData()
        {
            string qury = "SELECT id as '№', IndexPair as 'Парт №' FROM Pairs";
            OleDbDataAdapter da = new OleDbDataAdapter(qury, myConn);
            DataSet ds = new DataSet();
            da.Fill(ds, qury);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddDetatil addDetatil = new AddDetatil();
            addDetatil.Show();
        }
    }
}
