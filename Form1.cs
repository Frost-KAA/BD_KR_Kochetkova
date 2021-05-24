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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Application.EnableVisualStyles(); 
            
        }

        private void button1_Click(object sender, EventArgs e)
        {  
            Form_password pas = new Form_password();
            this.Owner = pas;
            this.Hide();
            pas.Show();
        }

        private void button_client_Click(object sender, EventArgs e)
        {
            Form_for_client pas = new Form_for_client();
            this.Owner = pas;
            pas.Show();
            this.Hide();
        }
    }
}
