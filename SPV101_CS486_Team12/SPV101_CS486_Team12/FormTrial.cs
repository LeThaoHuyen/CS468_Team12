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
        private bool[] result = new bool[6];
        private string[] songs = new string[] { "I Dreamed a Dream", "A Poets Journey", "Perhaps & Wavering Moon", "Grande Amore", "She is So Pretty", "Happy"};

        public void loadSong()
        {
            
        }
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
                dataGridView1.Rows.Add(officials[i], reverses[i], songs[i]);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i<6; i++)
            {
                string query = "sp_inserttrial";
                SqlParameter singer1 = new SqlParameter("@singer1", SqlDbType.NVarChar);
                singer1.Value = officials[i];
                SqlParameter singer2 = new SqlParameter("singer2", SqlDbType.NVarChar);
                singer1.Value = reverses[i];
                SqlParameter song = new SqlParameter("@song", SqlDbType.NVarChar);
                song.Value = songs[i];
                SqlParameter resultt = new SqlParameter("@result", SqlDbType.Bit);
                resultt.Value = result[i] == true ? 1 : 0;
                
                SqlConnection connection = null;
                string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString.ToString();
                //string query = "select s.name from Singers s where s.principles = 1";
                try
                {
                    Database.ExecuteNonQuery(connectionString, query, CommandType.StoredProcedure, singer1, singer2, song, resultt) ;
                    MessageBox.Show("Successfully");
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

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (result[0] == true)
            {
                result[0] = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (result[1] == true)
            {
                result[1] = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (result[2] == true)
            {
                result[2] = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (result[3] == true)
            {
                result[3] = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (result[4] == true)
            {
                result[4] = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (result[5] == true)
            {
                result[5] = false;
            }
        }
    }
}



