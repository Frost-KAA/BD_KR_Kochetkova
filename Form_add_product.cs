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
    public partial class Form_add_product : Form
    {
        int client_id;
        int type_id;
        string firm;
        string model;
        string note;
        int id;
        public Form_add_product(int id0, int client_id0, int type_id0, string firm0, string model0, string note0)
        {
            InitializeComponent();
            id = id0;
            client_id = client_id0;
            type_id = type_id0;
            firm = firm0;
            model = model0;
            note = note0;

            if (id != -1)
            {
                text_client_id.Text = client_id.ToString();
                text_firm.Text = firm;
                text_model.Text = model;
                text_note.Text = note;
                button_add.Text = "Редактировать";
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            client_id = Convert.ToInt32(text_client_id.Text);
            firm = text_firm.Text;
            model = text_model.Text;
            note = text_note.Text;
            type_id = Convert.ToInt32(combo_type.SelectedValue);

            var form = Application.OpenForms.OfType<Form2>().Single();
            DataRow row;
            if (id == -1)
            {
                row = form.ds_product.Tables[0].NewRow();
            }
            else
            {
                row = form.ds_product.Tables[0].Rows[id];
            }
            row[1] = client_id;
            row[2] = type_id;
            row[3] = firm;
            row[4] = model;
            row[5] = note;
            if (id == -1)
            {
                form.ds_product.Tables[0].Rows.Add(row);
            }
        }

        private void Form_add_product_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "repairDataSet.type". При необходимости она может быть перемещена или удалена.
            this.typeTableAdapter.Fill(this.repairDataSet.type);
            combo_type.SelectedIndex = type_id-1;

        }
    }
}
