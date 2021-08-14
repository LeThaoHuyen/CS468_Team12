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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        string[] officials = new string[6];
        string[] reverses = new string[6];

        public void loadOfficial()
        {
            string query = "sp_selectprincipal";
            SqlConnection connection = null;
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString.ToString();
           
            try
            {
                DataSet data = Database.ExecuteQuery(connection, query, connectionString, CommandType.StoredProcedure);
                //dataGridViewTrial.Columns["Official"].Add = data.Tables[0];
                for (int i = 0; i < 6; i++)
                {
                    officials[0] = data.Tables[0].Rows[0].ToString();
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
            string query = "sp_selectprincipal";
            SqlConnection connection = null;
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString.ToString();

            try
            {
                DataSet data = Database.ExecuteQuery(connection, query, connectionString, CommandType.StoredProcedure);
                //dataGridViewTrial.Columns["Official"].Add = data.Tables[0];
                for (int i = 0; i < 6; i++)
                {
                    reverses[0] = data.Tables[0].Rows[0].ToString();
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
    }
}
