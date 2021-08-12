using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Team12
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    class Database
    {
        // here query is a command typed text (select)
        // example
        // string query = "select playlistName from Playlists";
        // string columnName = playlistName;
        // loadDataForComboBox(comboBox, query, columnName)
        public static void loadDataForComboBox(ComboBox comboBox, string query, string columnName)
        {
            SqlConnection connection = null;
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString.ToString();

            try
            {
                DataSet data = Database.ExecuteQuery(connection, query, connectionString, CommandType.Text);
                comboBox.DataSource = data.Tables[0];
                comboBox.DisplayMember = columnName;
                comboBox.ValueMember = columnName;
            }
            catch (SqlException sqlex)
            {
                // do sth
            }
            catch (Exception ex)
            {
                // do sth
            }
        }

        /*how to use: example:
         * SqlParameter playlistid = new SqlParameter("@playlistid", SqlDbType.Int);
           playlistid.Value = 1;
           SqlParameter genre = new SqlParameter("@genre", SqlDbType.NVarChar);
           genre.Value = "Pop";
           string query = "sp_selectMoiNhat";
           
           loadDataForGridView(dataGridView, query, playlistid, genre);
         */
        public static void loadDataForGridView(DataGridView dataGridView, string query, params SqlParameter[] parameters)
        {
            clearDataGridView(dataGridView);
            SqlConnection connection = null;
            string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString.ToString();

            try
            {
                DataSet data = ExecuteQuery(connection, query, connectionString, CommandType.StoredProcedure, parameters);
                dataGridView.DataSource = data.Tables[0];
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


        public static void clearDataGridView(DataGridView dataGridView)
        {
            dataGridView.DataSource = null;
            dataGridView.Rows.Clear();
        }

        public static DataSet ExecuteQuery(SqlConnection sqlConnection, string commandText, string connectionString,
        CommandType commandType, params SqlParameter[] parameters)
        {
            using (sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(commandText, sqlConnection))
                {

                    command.CommandType = commandType;
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            if (parameter.Value == null)
                            {
                                parameter.Value = DBNull.Value;
                            }
                        }
                        command.Parameters.AddRange(parameters);
                    }


                    sqlConnection.Open();

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                    DataSet dataset = new DataSet();

                    sqlDataAdapter.Fill(dataset);

                    sqlConnection.Close();
                    return dataset;
                }
            }
        }

        public static Int32 ExecuteNonQuery(String connectionString, String commandText,
          CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(commandText, conn))
                {

                    Int32 rowaffected = -1;
                    command.CommandType = commandType;
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            if (parameter.Value == null)
                            {
                                parameter.Value = DBNull.Value;
                            }
                        }
                        command.Parameters.AddRange(parameters);
                    }

                    conn.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}
