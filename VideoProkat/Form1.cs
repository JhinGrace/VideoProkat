using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace VideoProkat
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlCommand command = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void procedure(string str)
        {
            command = new SqlCommand(str, sqlConnection);
            if (command.ExecuteNonQuery().ToString() == "-1")
            {
                MessageBox.Show("Ошибка!");
            }
            command.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["vpcS"].ConnectionString);
            sqlConnection.Open();
        }

        private void btProkat_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM vProkat", sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void btClients_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM vClients", sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void btMovies_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM vMovies", sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void btGenres_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM vGenres", sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void btCassette_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM vCasette", sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void btDebt_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM vDebt", sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void btWorkers_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM vWorkers", sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void btProducers_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM vProducers", sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void btActors_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM vActors", sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void btProd_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM vProduction", sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void wrClient_Click(object sender, EventArgs e)
        {
            procedure($"EXECUTE pClients @FIO = N'{tbFIO.Text}', @Doc = N'{tbDoc.Text}', @Address = N'{tbAddress.Text}', @Phone = N'{tbPhone.Text}';");
        }

        private void wrMovie_Click(object sender, EventArgs e)
        {
            procedure($"EXECUTE pMovies @Genre = N'{tbGenre.Text}', @Title = N'{tbTitle.Text}', @ReleaseDate = N'{tbReleaseDate.Text}', @RunningTime = N'{tbRunTime.Text}';");
        }
        private void wrProkat_Click(object sender, EventArgs e)
        {
            procedure($"EXECUTE pProkat @Client = N'{tbClient.Text}', @Worker = N'{tbWorker.Text}', @Casette = N'{tbCasette.Text}', @Price = N'{tbPrice.Text}', @DTout = N'{tbDTout.Text}', @DTin = N'{tbDTin.Text}';");
        }

        private void wrCasette_Click(object sender, EventArgs e)
        {
            procedure($"EXECUTE pCasette @Title = N'{tbTitle2.Text}', @Made = N'{tbMade.Text}', @Maker = N'{tbMaker.Text}';");
        }

        private void wrDebt_Click(object sender, EventArgs e)
        {
            procedure($"EXECUTE pDebt @Client = N'{tbClient2.Text}', @Casette = N'{tbCasette2.Text}', @Time = N'{tbTime.Text}', @Money = N'{tbMoney.Text}';");
        }

        private void wrWorker_Click(object sender, EventArgs e)
        {
            procedure($"EXECUTE pWorkers @FIO = N'{tbFIO2.Text}', @Doc = N'{tbDoc2.Text}', @Address = N'{tbAddress2.Text}', @Phone = N'{tbPhone2.Text}';");
        }

        private void wrActors_Click(object sender, EventArgs e)
        {
            procedure($"EXECUTE pActors @FIO = N'{tbFIO3.Text}', @DOB = N'{tbDOB.Text}';");
        }

        private void wrProducers_Click(object sender, EventArgs e)
        {
            procedure($"EXECUTE pProducers @FIO = N'{tbFIO3.Text}', @DOB = N'{tbDOB.Text}';");
        }

        private void wrProduction_Click(object sender, EventArgs e)
        {
            procedure($"EXECUTE pProduction @Actor = N'{tbActor.Text}', @Producer = N'{tbProducer.Text}', @Movie = N'{tbMovie.Text}';");
        }


    }
}
