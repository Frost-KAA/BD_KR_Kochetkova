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
    public partial class Form_add_client : Form
    {
        string surname;
        string name;
        string patron;
        bool card;
        byte type;
        string org;
        string inn;
        string bank;
        int id;

        public Form_add_client(int id0, string surname0, string name0, string patron0, bool card0, byte type0, string org0, string inn0, string bank0)
        {
            InitializeComponent();
            surname = surname0;
            name = name0;
            patron = patron0;
            card = card0;
            type = type0;
            org = org0;
            inn = inn0; 
            bank = bank0;
            id = id0;

            if (id != -1)
            {
                text_surname.Text = surname;
                text_name.Text = name;
                text_patronymic.Text = patron;
                if (card == true) radio_yes_card.Checked = true;
                else radio_no_card.Checked = true;
                if (type == 1) radio_ur.Checked = true;
                else radio_fiz.Checked = true;
                text_org_name.Text = org;
                text_inn.Text = inn;
                text_bank.Text = bank;
                button_add.Text = "Редактировать";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            surname = text_surname.Text;
            name = text_name.Text;
            patron = text_patronymic.Text;
            card = false;
            if (radio_yes_card.Checked) card = true;
            type = 0;
            if (radio_ur.Checked) type = 1;
            org = text_org_name.Text;
            inn = text_inn.Text;
            bank = text_bank.Text;

            var form = Application.OpenForms.OfType<Form2>().Single();
            DataRow row;
            if (id == -1)
            {
               row = form.ds_client.Tables[0].NewRow();
            }
            else
            {
               row = form.ds_client.Tables[0].Rows[id];
            }
            row[1] = type;
            row[2] = surname;
            row[3] = name;
            row[4] = patron;
            row[5] = org;
            row[6] = inn;
            row[7] = bank;
            row[9] = card;
            if (id == -1)
            {
                form.ds_client.Tables[0].Rows.Add(row);
            }
            
        }
    }
}
