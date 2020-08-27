using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Mr_Cashew.Forms
{
    public partial class Cashew : Form
    {
        private readonly MySqlConnection DBConn = Mr_Cashew.DBConn._obj.GetConnection();
        private AutoCompleteStringCollection dataCollection = new AutoCompleteStringCollection();
        private bool fromDGV;

        public Cashew()
        {
            InitializeComponent();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtBuy.Focus();
        }

        private void txtBuy_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtSell.Focus();
        }

        private void initDGV(string name = null)
        {
            var cmd = DBConn.CreateCommand();
            if (name == null)
            {
                cmd.CommandText = "SELECT cashID AS ID, name AS Name, buying AS Buying, selling AS Selling FROM cashew";
            }
            else
            {
                cmd.CommandText =
                    "SELECT cashID AS ID, name AS Name, buying AS Buying, selling AS Selling FROM cashew WHERE name = @name";
                cmd.Parameters.AddWithValue("@name", name);
            }

            var da = new MySqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            dgvCashew.DataSource = dt;
        }

        private void Cashew_Load(object sender, EventArgs e)
        {
            initDGV();
        }

        private void dgvCashew_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = dgvCashew.SelectedCells[1].Value.ToString();
            txtBuy.Value = decimal.Parse(dgvCashew.SelectedCells[2].Value.ToString());
            txtSell.Value = decimal.Parse(dgvCashew.SelectedCells[3].Value.ToString());
            fromDGV = true;
            btnRefresh();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            fromDGV = false;
            btnRefresh();
        }

        private void btnRefresh()
        {
            if (fromDGV)
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
                btnAdd.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                var cmd = DBConn.CreateCommand();
                cmd.CommandText = "INSERT INTO cashew (name, buying, selling) VALUES (@name, @buying, @selling)";
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@buying", txtBuy.Value);
                cmd.Parameters.AddWithValue("@selling", txtSell.Value);
                var recs = cmd.ExecuteNonQuery();

                if (recs == 0)
                    MessageBox.Show("Couldn't enter new cashew. Please try again", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                initDGV();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var cmd = DBConn.CreateCommand();
            cmd.CommandText = "UPDATE cashew SET buying = @buying, selling = @selling WHERE name = @name";
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@buying", txtBuy.Value);
            cmd.Parameters.AddWithValue("@selling", txtSell.Value);

            var recs = cmd.ExecuteNonQuery();

            if (recs == 0)
                MessageBox.Show("Couldn't update cashew. Please try again", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

            initDGV();
        }

        private void dgvCashew_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var rowSelected = e.RowIndex;
                if (e.RowIndex != -1)
                {
                    dgvCashew.ClearSelection();
                    dgvCashew.Rows[rowSelected].Selected = true;
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Warning", MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                var cmd = DBConn.CreateCommand();
                cmd.CommandText = "DELETE FROM cashew WHERE name = @name";
                cmd.Parameters.AddWithValue("@name", dgvCashew.SelectedCells[1].Value.ToString());

                var recs = cmd.ExecuteNonQuery();
                if (recs > 0)
                    MessageBox.Show("Record Deleted!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Couldn't delete selected record." + Environment.NewLine + "Please try again",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                initDGV();
            }
        }
    }
}