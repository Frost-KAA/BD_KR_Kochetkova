using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace RepairForms
{
    public partial class Form2 : Form
    {

        public DataSet ds_client;
        public DataSet ds_phone;
        public DataSet ds_master;
        public DataSet ds_product;
        public DataSet ds_defect;
        MySqlDataAdapter adapter_client;
        MySqlDataAdapter adapter_master;
        MySqlDataAdapter adapter_phone;
        MySqlDataAdapter adapter_product;
        MySqlDataAdapter adapter_defect;
        MySqlCommandBuilder commandBuilder;
        string connStr = "server=localhost;user=root;database=repair;password=c9a0t1;";
        
        

        public Form2()
        {
            InitializeComponent();
            loadClients();
            loadDeffects();
            loadMasters();
            loadProducts();
            loadPhones();
        }


        void loadClients()
        {
           grid_client.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
           grid_client.AllowUserToAddRows = false;
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                connection.Open();
                string sql = "SELECT * FROM client;";
                adapter_client = new MySqlDataAdapter(sql, connection);
                ds_client = new DataSet();
                adapter_client.Fill(ds_client);
                ds_client.Tables[0].Columns.Add(new DataColumn("Has card", typeof(bool)));
                grid_client.DataSource = ds_client.Tables[0];

                grid_client.Columns["Card"].Visible = false;

                for (int i = 0; i < grid_client.Rows.Count; i++)
                {
                    this.grid_client.Rows[i].Cells[9].Value = Convert.ToBoolean(grid_client.Rows[i].Cells[8].Value);
                }    
            }
        }
        void loadMasters()
        {
            grid_master.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid_master.AllowUserToAddRows = false;
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                connection.Open();
                string sql = "SELECT * FROM master;";
                adapter_master = new MySqlDataAdapter(sql, connection);
                ds_master = new DataSet();
                adapter_master.Fill(ds_master);
                grid_master.DataSource = ds_master.Tables[0];
            }
        }
        void loadProducts()
        {
            grid_product.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid_product.AllowUserToAddRows = false;
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                connection.Open();
                string sql = "SELECT * FROM product;";
                adapter_product = new MySqlDataAdapter(sql, connection);
                ds_product = new DataSet();
                adapter_product.Fill(ds_product);
                grid_product.DataSource = ds_product.Tables[0];

                /*DataGridViewComboBoxColumn cmbColumn = new DataGridViewComboBoxColumn();
                cmbColumn.DataSource = typeBindingSource;
                cmbColumn.Name = "Type";
                cmbColumn.DataPropertyName = "Type";
                cmbColumn.ValueMember = "ID_Type";           
                cmbColumn.DisplayMember = "Product_Type";
                cmbColumn.FlatStyle = FlatStyle.Flat;
                grid_product.Columns.Add(cmbColumn);
                //grid_product.Rows[0].Cells["Type"].Value = 3;
                combo_type_products();*/

            }
        }


        public void combo_type_products()
        {
            for (int i = 0; i < grid_product.Rows.Count; i++)
            {
                    (grid_product.Rows[i].Cells["Type"] as DataGridViewComboBoxCell).Value = 2;
             }
        }
        void loadDeffects()
        {
            grid_defect.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid_defect.AllowUserToAddRows = false;
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                connection.Open();
                string sql = "SELECT * FROM defect;";
                adapter_defect = new MySqlDataAdapter(sql, connection);
                ds_defect = new DataSet();
                adapter_defect.Fill(ds_defect);
               
                ds_defect.Tables[0].Columns.Add(new DataColumn("Has Quarantee", typeof(bool)));
                grid_defect.DataSource = ds_defect.Tables[0];

                grid_defect.Columns["Quarantee_Repair"].Visible = false;

                for (int i = 0; i < grid_defect.Rows.Count; i++)
                {
                    this.grid_defect.Rows[i].Cells["Has Quarantee"].Value = Convert.ToBoolean(grid_defect.Rows[i].Cells["Quarantee_Repair"].Value);
                }
            }
        }

        void loadPhones()
        {
            grid_phone.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid_phone.AllowUserToAddRows = false;
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                connection.Open();
                string sql = "SELECT * FROM phone;";
                adapter_phone = new MySqlDataAdapter(sql, connection);
                ds_phone = new DataSet();
                adapter_phone.Fill(ds_phone);
                grid_phone.DataSource = ds_phone.Tables[0];
            }
        }

        DataGridView get_current_view()
        {
            int idx = TabControl.SelectedIndex;
            switch (idx)
            {
                case 0:
                    return grid_client;
                case 1:
                    return grid_phone;
                case 2:
                    return grid_product;
                case 3:
                    return grid_defect;
                case 4:
                    return grid_master;
                default:
                    return grid_client;
            }
        }

        DataSet get_current_set()
        {
            int idx = TabControl.SelectedIndex;
            switch (idx)
            {
                case 0:
                    return ds_client;
                case 1:
                    return ds_phone;
                case 2:
                    return ds_product;
                case 3:
                    return ds_defect;
                case 4:
                    return ds_master;
                default:
                    return ds_client;
            }
        }

        MySqlDataAdapter get_current_adapter()
        {
            int idx = TabControl.SelectedIndex;
            switch (idx)
            {
                case 0:
                    return adapter_client;
                case 1:
                    return adapter_phone;
                case 2:
                    return adapter_product;
                case 3:
                    return adapter_defect;
                case 4:
                    return adapter_master;
                default:
                    return adapter_client;
            }
        }

        // удаление строки
        private void button_delete_Click(object sender, EventArgs e)
        {
            DataGridView grid = get_current_view();

            foreach (DataGridViewRow row in grid.SelectedRows)
            {
                grid.Rows.Remove(row);
            }
        }

        //добавление сразу в таблице
        private void button_add_in_table_Click(object sender, EventArgs e)
        {
            DataSet ds = get_current_set();
            DataRow row = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(row);
        }


        //добавление через отдельную форму
        private void button_add_Click(object sender, EventArgs e)
        {

            int idx = TabControl.SelectedIndex;
            switch (idx)
            {
                case 0:
                    Form_add_client form0 = new Form_add_client(-1, "", "", "", false, 0, "", "", "");
                    form0.Show();
                    break;
                case 1:
                    Form_add_number form1 = new Form_add_number(-1, -1, "");
                    form1.Show();
                    break;
                case 2:
                    Form_add_product form2 = new Form_add_product(-1, -1, 1, "", "", "");
                    form2.Show();
                    break;
                case 3:
                    DateTime x = new DateTime(2015, 7, 3);
                    DateTime y = new DateTime(2015, 7, 3);
                    Form_add_defect form3 = new Form_add_defect(-1, -1, -1, "", 0, x, y, 0, 0, false);
                    form3.Show();
                    break;
                case 4:
                    Form_add_master form4 = new Form_add_master(-1, "", "", "", 0, 0, 0);
                    form4.Show();
                    break;
                default:
                    Form_add_client form5 = new Form_add_client(-1, "", "", "", false, 0, "", "", "");
                    form5.Show();
                    break;
            }

            
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            int idx = TabControl.SelectedIndex;
            switch (idx)
            {
                case 0:
                    DataGridViewRow row0 = grid_client.SelectedRows[0];
                    Form_add_client form0 = new Form_add_client(row0.Index, row0.Cells[2].Value.ToString(),
                                               row0.Cells[3].Value.ToString(), row0.Cells[4].Value.ToString(), Convert.ToBoolean(row0.Cells[9].Value),
                                               Convert.ToByte(row0.Cells[1].Value), row0.Cells[5].Value.ToString(), row0.Cells[6].Value.ToString(), row0.Cells[7].Value.ToString());
                    form0.Show();
                    break;
                case 1:
                    DataGridViewRow row1 = grid_phone.SelectedRows[0];
                    Form_add_number form1 = new Form_add_number(row1.Index, Convert.ToInt32(row1.Cells[1].Value), row1.Cells[2].Value.ToString());
                    form1.Show();
                    break;
                case 2:
                    DataGridViewRow row2 = grid_product.SelectedRows[0];
                    Form_add_product form2 = new Form_add_product(row2.Index, Convert.ToInt32(row2.Cells[1].Value),
                                               Convert.ToInt32(row2.Cells[2].Value), row2.Cells[3].Value.ToString(), row2.Cells[4].Value.ToString(), row2.Cells[5].Value.ToString());
                    form2.Show();
                    break;
                case 3:
                    DataGridViewRow row3 = grid_defect.SelectedRows[0];
                    DateTime x; ;
                    if (row3.Cells[6].Value == DBNull.Value) x = new DateTime(2021, 5, 21);
                    else x = Convert.ToDateTime(row3.Cells[6].Value);
                    Form_add_defect form3 = new Form_add_defect(row3.Index, Convert.ToInt32(row3.Cells[1].Value),
                                               Convert.ToInt32(row3.Cells[2].Value), row3.Cells[3].Value.ToString(), Convert.ToInt32(row3.Cells[4].Value),
                                               Convert.ToDateTime(row3.Cells[5].Value), x, Convert.ToInt32(row3.Cells[7].Value), 
                                               Convert.ToInt32(row3.Cells[8].Value), Convert.ToBoolean(row3.Cells[10].Value));
                    form3.Show();
                    break;
                case 4:
                    DataGridViewRow row4 = grid_master.SelectedRows[0];
                    Form_add_master form4 = new Form_add_master(row4.Index, row4.Cells[1].Value.ToString(),
                                               row4.Cells[2].Value.ToString(), row4.Cells[3].Value.ToString(), Convert.ToInt32(row4.Cells[4].Value),
                                               Convert.ToInt32(row4.Cells[5].Value), Convert.ToInt32(row4.Cells[6].Value));
                    form4.Show();
                    break;
                default:
                    Form_add_client form5 = new Form_add_client(-1, "", "", "", false, 0, "", "", "");
                    form5.Show();
                    break;
            }
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            string search = text_search.Text;
            
            DataGridView grid = get_current_view();
            grid.CurrentRow.Selected = false;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                for (int j = 0; j < grid.ColumnCount; j++)
                {
                    string now = grid.Rows[i].Cells[j].Value.ToString();
                    if (now.Contains(search))
                    {
                        grid.Rows[i].Selected = true;
                        break;
                    }
                }
                
            }
        }

        //открытие справочных таблиц
        private void button_info_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.Show();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grid_client.Rows.Count; i++)
            {
                grid_client.Rows[i].Cells[8].Value = Convert.ToByte(grid_client.Rows[i].Cells[9].Value);
            }

            for (int i = 0; i < grid_defect.Rows.Count; i++)
            {
                grid_defect.Rows[i].Cells[9].Value = Convert.ToByte(grid_defect.Rows[i].Cells[10].Value);
            }

            using (MySqlConnection connect = new MySqlConnection(connStr))
            {
                connect.Open();
                MySqlDataAdapter adapter = get_current_adapter();
                DataSet ds = get_current_set();
                commandBuilder = new MySqlCommandBuilder(adapter);
                adapter.Update(ds.Tables[0]);
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "repairDataSet.type". При необходимости она может быть перемещена или удалена.
            this.typeTableAdapter.Fill(this.repairDataSet.type);
            //combo_type_products();
        }
    }

}

