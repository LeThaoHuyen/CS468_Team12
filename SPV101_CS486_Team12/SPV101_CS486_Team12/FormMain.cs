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
        }
        
        private void FormMain_Load(object sender, EventArgs e)
        {
            activeOptionButton = buttonHome;
            activeOptionButton.BackColor = Color.Goldenrod;
            openChildForm(buttonHome, new FormHomepage());
        }

        Form activeForm = null;
        Button activeOptionButton = null;
        private void openChildForm(object btsender, Form childForm)
        {
            
            if (activeOptionButton != (Button) btsender)
            {
                activeOptionButton.BackColor = panelLeftMenu.BackColor; // Default background color
                activeOptionButton = (Button) btsender;
                activeOptionButton.BackColor = Color.Goldenrod; // Highlight background color
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
            labelChildFormName.Text = ((Button)btsender).Text;


        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            openChildForm(sender, new FormHomepage());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(sender, new FormAboutUs());
        }

    }
}
