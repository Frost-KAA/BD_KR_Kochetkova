using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RepairForms
{
    public partial class Form_password : Form
    {
        public Form_password()
        {
            InitializeComponent();
            label_no.Visible = false;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (text_pas.Text == "cat")
            {
                Form2 form = new Form2();
                this.Owner = form;
                this.Hide();
                form.Show();
                
            }
            else
            {
                label_no.Visible = true;
            }
        }
    }
}
