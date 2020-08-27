using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Mr_Cashew.Forms
{
    public partial class Seller : Form
    {
        private readonly MySqlConnection DBConn = Mr_Cashew.DBConn._obj.GetConnection();

        public Seller()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                var cmd = DBConn.CreateCommand();
                cmd.CommandText = "INSERT INTO seller(name, address, contact) VALUES (@name, @add, @contact)";
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@add", txtAddress.Text);
                cmd.Parameters.AddWithValue("@contact", txtContact.Text);
                var recs = cmd.ExecuteNonQuery();

                if (recs > 0)
                    MessageBox.Show("Seller registered!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                else
                    MessageBox.Show("Seller registration failed!" + Environment.NewLine + "Please try again.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                initDGV();
            }
        }

        private void initDGV()
        {
            var cmd = DBConn.CreateCommand();
            cmd.CommandText = "SELECT sellerID AS ID, Name, Address, Contact FROM seller";
            var da = new MySqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            dgvSeller.DataSource = dt;
        }

        private void Seller_Load(object sender, EventArgs e)
        {
            initDGV();
        }

        private void deleteSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this supplier?", "Warning", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var cmd = DBConn.CreateCommand();
                cmd.CommandText = "DELETE FROM seller WHERE sellerID = @sel";
                cmd.Parameters.AddWithValue("@sel", dgvSeller.SelectedCells[0].Value);
                var recs = cmd.ExecuteNonQuery();

                if (recs > 0)
                    MessageBox.Show("Supplier deleted!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                else
                    MessageBox.Show("Supplier deletion failed!" + Environment.NewLine + "Please try again.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                initDGV();
            }
        }

        private void dgvSeller_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var rowSelected = e.RowIndex;
                if (e.RowIndex != -1)
                {
                    dgvSeller.ClearSelection();
                    dgvSeller.Rows[rowSelected].Selected = true;
                }
            }
        }
    }
}