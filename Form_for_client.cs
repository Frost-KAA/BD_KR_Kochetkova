using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RepairForms
{
    public partial class Form_for_client : Form
    {

        public DataSet ds;
        MySqlDataAdapter adapter;
        MySqlCommandBuilder commandBuilder;
        string connStr = "server=localhost;user=root;database=repair;password=c9a0t1;";
        string surname;
        string name;
        string patro;

        public Form_for_client()
        {
            InitializeComponent();
            
        }

        void load(string sur, string name, string patr)
        {
            grid_for_client.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid_for_client.AllowUserToAddRows = false;
            string num = "2";
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT ID_Client FROM client WHERE client.Name='" + name + "' AND Surname='" + sur + "' AND Patronymic='" + patr+ "';", connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            num = reader.GetInt32(0).ToString();
                    }
                }

                string sql = "SELECT product.Firm, product.Model, defect.Decription, defect.Status_Id, defect.Input_Date, defect.Output_Date, defect.Cost, defect.Quarantee_Time  FROM product INNER JOIN defect ON product.ID_Product = defect.Product_ID WHERE product.Client_ID = " + num + ";";
                adapter = new MySqlDataAdapter(sql, connection);
                ds = new DataSet();
                adapter.Fill(ds);
                grid_for_client.DataSource = ds.Tables[0];
               
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            surname = text_sur.Text;
            name = text_name.Text;
            patro = text_patr.Text;
            load(surname, name, patro);
        }
    }
}
