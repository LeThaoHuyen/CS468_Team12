using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;


namespace Team12
{
    public partial class FormPremain : Form
    {
        public FormPremain()
        {
            InitializeComponent();



            //string sConnectionString = @"Data Source=DESKTOP-41U2CBJ\SQLEXPRESS;Initial Catalog=CS486_Team12_DB;Integrated Security=True";
            string sConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString.ToString();
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = sConnectionString;
            cnn.Open();

            //SELECT column FROM table.
  //          ORDER BY RAND()
//LIMIT 1

            //select top 10 percent * from [yourtable] order by newid()

            SqlDataAdapter da = new SqlDataAdapter("select top 3 songName from Songs ORDER BY newid()", cnn);

            DataSet ds = new DataSet();

            da.Fill(ds);

            if (ds.Tables.Count > 0)
            {
                tableSongs.DataSource = ds.Tables[0];

            }

            // Set table width dynamically
            for (int i = 0; i < tableSongs.ColumnCount; i++)
                tableSongs.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tableSongs.Columns[0].FillWeight = 100;


            // Set table height dynamically
            var height = tableSongs.ColumnHeadersHeight;
            foreach (DataGridViewRow dr in tableSongs.Rows)
            {
                height += dr.Height;
            }
            tableSongs.Height = height;









            SqlDataAdapter da2 = new SqlDataAdapter("select s1.name, s2.name from Singers s1 join SingerPairSongsPreMain s on s1.singerID = s.singer1ID join Singers s2 on s2.singerID = s.singer2ID", cnn);

            DataSet ds2 = new DataSet();

            da2.Fill(ds2);

            if (ds2.Tables.Count > 0)
            {
                tableTeamList.DataSource = ds2.Tables[0];

            }

            // Set table width dynamically
            for (int i = 0; i < tableSongs.ColumnCount; i++)
                tableSongs.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tableTeamList.Columns[0].FillWeight = 100;
            tableTeamList.Columns[1].FillWeight = 100;



            // Set table height dynamically
            var height2 = tableSongs.ColumnHeadersHeight;
            foreach (DataGridViewRow dr in tableSongs.Rows)
            {
                height2 += dr.Height;
            }
            tableSongs.Height = height2;











        }

        private void button2_Click(object sender, EventArgs e)
        {

            string sConnectionString = @"Data Source=DESKTOP-41U2CBJ\SQLEXPRESS;Initial Catalog=CS486_Team12_DB;Integrated Security=True";

            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = sConnectionString;
            cnn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select top 3 songName from Songs ORDER BY newid()", cnn);

            DataSet ds = new DataSet();

            da.Fill(ds);

            if (ds.Tables.Count > 0)
            {
                tableSongs.DataSource = ds.Tables[0];

            }

            // Set table width dynamically
            for (int i = 0; i < tableSongs.ColumnCount; i++)
                tableSongs.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tableSongs.Columns[0].FillWeight = 100;


            // Set table height dynamically
            var height = tableSongs.ColumnHeadersHeight;
            foreach (DataGridViewRow dr in tableSongs.Rows)
            {
                height += dr.Height;
            }
            tableSongs.Height = height;
        }
    }


}
