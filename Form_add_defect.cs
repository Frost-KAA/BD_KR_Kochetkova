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
    public partial class Form_add_defect : Form
    {
        int id;
        int product_id;
        int master_id;
        string desc;
        int cost;
        int status;
        DateTime input;
        DateTime output;
        int quar_time;
        bool quar;

        public Form_add_defect(int id0, int product_id0, int master_id0, string desc0, int status0, DateTime input0, DateTime output0, int cost0, int quar_time0, bool quar0)
        {
            InitializeComponent();
            id = id0;
            product_id = product_id0;
            master_id = master_id0;
            desc = desc0;
            cost = cost0;
            status = status0;
            input = input0;
            output = output0;
            quar_time = quar_time0;
            quar = quar0;

            if (id != -1)
            {
                text_product_id.Text = product_id.ToString();
                text_master_id.Text = master_id.ToString();
                text_desc.Text = desc;
                text_cost.Text = cost.ToString();
                text_status.Text = status.ToString();
                text_input.Text = input.ToString();
                text_output.Text = output.ToString();
                text_quar_time.Text = quar_time.ToString();
                if (quar == true) radio_yes.Checked = true;
                else radio_no.Checked = true;
                button_add.Text = "Редактировать";
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            product_id = Convert.ToInt32(text_product_id.Text);
            master_id = Convert.ToInt32(text_master_id.Text);
            desc = text_desc.Text;
            cost = Convert.ToInt32(text_cost.Text);
            status = Convert.ToInt32(text_status.Text);
            input = Convert.ToDateTime(text_input.Text);
            output = Convert.ToDateTime(text_output.Text);
            quar_time = Convert.ToInt32(text_quar_time.Text);
            if (radio_yes.Checked) quar = true;
            else quar = false;

            var form = Application.OpenForms.OfType<Form2>().Single();
            DataRow row;
            if (id == -1)
            {
                row = form.ds_defect.Tables[0].NewRow();
            }
            else
            {
                row = form.ds_defect.Tables[0].Rows[id];
            }
            row[1] = product_id;
            row[2] = master_id;
            row[3] = desc;
            row[4] = status;
            row[5] = input;
            row[6] = output;
            row[7] = cost;
            row[8] = quar_time;
            row[10] = quar;
            if (id == -1)
            {
                form.ds_defect.Tables[0].Rows.Add(row);
            }
        }
    }
}
