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


        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            labelChildFormName.Text = "Home";
            openChildForm(sender, new FormHomepage());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            labelChildFormName.Text = "About us";

            openChildForm(sender, new FormAboutUs());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            labelChildFormName.Text = "Dual Round - Introduction";

            openChildForm(sender, new FormDualRoundIntroduction());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            labelChildFormName.Text = "Dual Round - Premain";

            openChildForm(sender, new FormPremain());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            labelChildFormName.Text = "Dual Round - Trial";

            openChildForm(sender, new FormTrial());
        }
    }
}
