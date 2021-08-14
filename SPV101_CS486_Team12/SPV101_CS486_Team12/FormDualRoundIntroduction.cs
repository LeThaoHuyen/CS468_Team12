using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team12
{
    public partial class FormDualRoundIntroduction : Form
    {
        public FormDualRoundIntroduction()
        {
            InitializeComponent();

            string sConnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString.ToString(); 

            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = sConnectionString;
            cnn.Open();



            SqlDataAdapter da = new SqlDataAdapter("select s.name as Singers from Singers s where s.principles = 1", cnn);

            DataSet ds = new DataSet();

            da.Fill(ds);

            if (ds.Tables.Count > 0)
            {
                tableOfficial.DataSource = ds.Tables[0];

            }


            // Set table width dynamically
            for (int i = 0; i < tableOfficial.ColumnCount; i++)
                tableOfficial.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tableOfficial.Columns[0].FillWeight = 100;



            // Set table height dynamically
            var height2 = tableOfficial.ColumnHeadersHeight;
            foreach (DataGridViewRow dr in tableOfficial.Rows)
            {
                height2 += dr.Height;
            }
            tableOfficial.Height = height2;





            SqlDataAdapter da2 = new SqlDataAdapter("select s.name as Singers from Singers s where s.principles = 0", cnn);

            DataSet ds2 = new DataSet();

            da2.Fill(ds2);

            if (ds2.Tables.Count > 0)
            {
                tableReserve.DataSource = ds2.Tables[0];

            }


            // Set table width dynamically
            for (int i = 0; i < tableReserve.ColumnCount; i++)
                tableReserve.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tableReserve.Columns[0].FillWeight = 100;



            // Set table height dynamically
            var height = tableReserve.ColumnHeadersHeight;
            foreach (DataGridViewRow dr in tableReserve.Rows)
            {
                height += dr.Height;
            }
            tableReserve.Height = height;

            string nl = Environment.NewLine; // new line variable
            description.Text = "Six Understudy members were selected to sing duets with the Official members. The best member " + nl +
                               "of the duet became the Principal member.Afterwards, the Understudy members divided into duets " + nl +
                               "to sing one of the three selected songs. The pair with the best performance for each song was " + nl +
                               "chosen." + nl + nl +
                               "The Official members split up into duets to compete against the Understudy duets chosen in " + nl +
                               "S01E03. The winning duet became Official members. Afterwards, the Understudy members divided" + nl +
                               "into duets to sing one of another three selected songs. The pair with the best performance for" + nl +
                               "each song was chosen. The Official members divided into different duet groups.";


        }
    }
}
