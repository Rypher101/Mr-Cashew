using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Mr_Cashew.Forms
{
    public partial class Dashboard : Form
    {
        private MySqlConnection DBConn = Mr_Cashew.DBConn._obj.GetConnection();

        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenForm(new Receipt());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenForm(new Cashew());
        }

        private void OpenForm(Form frm)
        {
            for (var i = Application.OpenForms.Count - 1; i >= 0; i--)
                if (Application.OpenForms[i].Name == frm.Name)
                {
                    Application.OpenForms[i].Close();
                    break;
                }

            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenForm(new Order());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenForm(new Seller());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenForm(new Trip());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenForm(new Size());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenForm(new Expenses());
        }
    }
}