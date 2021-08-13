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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            activeOptionButton = buttonHome;
        }
        Form activeForm = null;
        Button activeOptionButton;

        private void openChildForm(object btsender, Form childForm)
        {
            if (activeOptionButton != (Button) btsender)
            {
                activeOptionButton.BackColor = SystemColors.ControlDarkDark;
                activeOptionButton = (Button) btsender;
                activeOptionButton.BackColor = Color.Moccasin;
            }

            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;

            childForm.TopLevel = false;
            childForm.AutoScroll = true;
            this.panelForm.Controls.Add(childForm);
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Show();
        }

        private void buttonAboutUs_Click(object sender, EventArgs e)
        {
            openChildForm(sender, new Form1());
        }

        private void buttonHome_Click_1(object sender, EventArgs e)
        {
            openChildForm(sender, new Form1());
        }
    }
}
