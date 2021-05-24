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
    public partial class Form_add_master : Form
    {
        string surname;
        string name;
        string patron;
        int experience;
        int bad_repair;
        int repair;
        int id;

        public Form_add_master(int id0, string surname0, string name0, string patron0, int exp0, int bad0, int repair0)
        {
            InitializeComponent();
            surname = surname0;
            name = name0;
            patron = patron0;
            experience = exp0;
            bad_repair = bad0;
            repair = repair0;
            id = id0;
            if (id != -1)
            {
                text_surname.Text = surname;
                text_name.Text = name;
                text_patronymic.Text = patron;
                text_exp.Text = experience.ToString();
                text_bad.Text = bad_repair.ToString();
                text_repair.Text = repair.ToString();
                button_add.Text = "Редактировать";
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            surname = text_surname.Text;
            name = text_name.Text;
            patron = text_patronymic.Text;
            experience = Convert.ToInt32(text_exp.Text);
            bad_repair = Convert.ToInt32(text_bad.Text);
            repair =Convert.ToInt32(text_repair.Text);

            var form = Application.OpenForms.OfType<Form2>().Single();
            DataRow row;
            if (id == -1)
            {
                row = form.ds_master.Tables[0].NewRow();
            }
            else
            {
                row = form.ds_master.Tables[0].Rows[id];
            }
            row[1] = surname;
            row[2] = name;
            row[3] = patron;
            row[4] = experience;
            row[5] = bad_repair;
            row[6] = repair;
            if (id == -1)
            {
                form.ds_master.Tables[0].Rows.Add(row);
            }
        }
    }
}
