using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team12
{
    public partial class FormAboutUs : Form
    {
        public FormAboutUs()
        {
            InitializeComponent();
        }

        private void FormAboutUs_Load(object sender, EventArgs e)
        {
            // Add data
            string nl = Environment.NewLine; // new line variable
            this.dataGridViewIntroduction.Rows.Add("18125146", "Nguyễn Minh Thư", "Vẽ sơ đồ ER" + nl + "Phụ viết query (insert, select, procedure...)");
            this.dataGridViewIntroduction.Rows.Add("19125007", "Lê Thảo Huyền", "Design UI, nghĩ các query cần có" + nl + "Viết function nạp data vào UI");
            this.dataGridViewIntroduction.Rows.Add("19125034", "Cao Thiên Trí", "Relational DatabaseSQL, (create tables, constraints), Insert 1 - 2 sample tuple");
            this.dataGridViewIntroduction.Rows.Add("19125074", "Hà Phương Uyên", "Design UI + nghĩ các query cần có" + nl + "Report");
            this.dataGridViewIntroduction.Rows.Add("19125094", "Nguyễn Cung Hoàng Huy", "Vẽ ER model" + nl + "Report");
            this.dataGridViewIntroduction.Rows.Add("19125106", "Huỳnh Tuấn Lực", "Relational DatabaseSQL, (create tables, constraints), Insert 1 - 2 sample tuple" + nl + "Viết function nạp data vào UI");

            // Set table width dynamically
            for (int i = 0; i < dataGridViewIntroduction.ColumnCount; i++)
                dataGridViewIntroduction.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewIntroduction.Columns[0].FillWeight = 120;
            dataGridViewIntroduction.Columns[1].FillWeight = 200;
            dataGridViewIntroduction.Columns[2].FillWeight = 400;

            // Set table height dynamically
            var height = dataGridViewIntroduction.ColumnHeadersHeight;
            foreach (DataGridViewRow dr in dataGridViewIntroduction.Rows)
            {
                height += dr.Height;
            }
            dataGridViewIntroduction.Height = height;
        }
    }
}
