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
    public partial class Form_add_number : Form
    {

        int client_id;
        string number;
        int id;
        public Form_add_number(int id0, int client_id0, string number0)
        {
            InitializeComponent();
            client_id = client_id0;
            number = number0;
            id = id0;
            if (id != -1)
            {
                text_client_id.Text = client_id.ToString();
                text_number.Text = number;
                button_add.Text = "Редактировать";
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            client_id = Convert.ToInt32(text_client_id.Text);
            number = text_number.Text;

            var form = Application.OpenForms.OfType<Form2>().Single();
            DataRow row;
            if (id == -1)
            {
                row = form.ds_phone.Tables[0].NewRow();
            }
            else
            {
                row = form.ds_phone.Tables[0].Rows[id];
            }
            row[1] = client_id;
            row[2] = number;
            if (id == -1)
            {
                form.ds_client.Tables[0].Rows.Add(row);
            }
        }
    }
}
