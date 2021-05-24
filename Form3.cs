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
    public partial class Form3 : Form
    {
        DataSet ds;
        MySqlDataAdapter adapter;
        MySqlCommandBuilder commandBuilder;
        string connStr = "server=localhost;user=root;database=repair;password=c9a0t1;";

        public Form3()
        {
            InitializeComponent();
            loadStatuses();
            loadTypes();
        }

        void loadStatuses()
        {
            grid_status.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid_status.AllowUserToAddRows = false;
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                connection.Open();
                string sql = "SELECT * FROM status;";
                adapter = new MySqlDataAdapter(sql, connection);
                ds = new DataSet();
                adapter.Fill(ds);
                grid_status.DataSource = ds.Tables[0];
            }
        }
        void loadTypes()
        {
            grid_type.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid_type.AllowUserToAddRows = false;
            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                connection.Open();
                string sql = "SELECT * FROM type;";
                adapter = new MySqlDataAdapter(sql, connection);
                ds = new DataSet();
                adapter.Fill(ds);
                grid_type.DataSource = ds.Tables[0];
            }
        }
    }
}
