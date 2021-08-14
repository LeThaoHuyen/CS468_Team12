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


namespace Team12
{
    public partial class FormTrial : Form
    {
        public FormTrial()
        {
            InitializeComponent();
            loadOfficial();
            loadReverse();
            loadDataForGridView();
        }


        private string[] officials = new string[6];
        private string[] reverses = new string[6];

        public void loadOfficial()
        {
            //string query = "sp_selectprincipal";
            SqlConnection connection = null;
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString.ToString();
            string query = "select s.name from Singers s where s.principles = 1";

            try
            {
                DataSet data = Database.ExecuteQuery(connection, query, connectionString, CommandType.Text);
                //dataGridViewTrial.Columns["Official"].Add = data.Tables[0];
                for (int i = 0; i < 6; i++)
                {
                   officials[i] = data.Tables[0].Rows[i].Field<string>("name");
                }
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void loadReverse()
        {
            string query = "sp_selectRandomReserved";
            SqlConnection connection = null;
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString.ToString();
            //string query = "select s.name from Singers s where s.principles = 1";

            try
            {
                DataSet data = Database.ExecuteQuery(connection, query, connectionString, CommandType.StoredProcedure);
                //dataGridViewTrial.Columns["Official"].Add = data.Tables[0];
                for (int i = 0; i < 6; i++)
                {
                    reverses[i] = data.Tables[0].Rows[i].Field<string>("name");
                }
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void loadDataForGridView()
        {
            for (int i = 0; i < 6; i++)
            {
                dataGridView1.Rows.Add(officials[i], reverses[i]);
            }
        }

    }
}



