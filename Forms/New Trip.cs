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

namespace Mr_Cashew.Forms
{
    public partial class New_Trip : Form
    {
        private readonly MySqlConnection DBConn = Mr_Cashew.DBConn._obj.GetConnection();
        private int tripID = 0;

        public New_Trip(int tripID)
        {
            InitializeComponent();
            this.tripID = tripID;
        }

        private void New_Trip_Load(object sender, EventArgs e)
        {
            if (tripID == 0)
            {
                MessageBox.Show("Invalid trip ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            initCMB();
            initDGV();
        }

        private void initDGV()
        {
            var cmd = DBConn.CreateCommand();
            cmd.CommandText = "SELECT IF(type = 1, 'Income', 'Expenses') AS Type, IF(type = 1, name, description) AS Description, qty AS QTY, tripdetails.selling AS 'Price/Cost', tripdetails.Buying FROM tripdetails LEFT JOIN cashew ON tripdetails.cashID = cashew.cashID WHERE tripID = @trip";
            cmd.Parameters.AddWithValue("@trip", tripID);

            var da= new MySqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            dgvTrip.DataSource = dt;
        }

        private void initCMB()
        {
            var cmd = DBConn.CreateCommand();
            cmd.CommandText =
                "SELECT cashID, name FROM cashew";

            var da = new MySqlDataAdapter(cmd);
            var ds = new DataSet();
            da.Fill(ds, "Cashew");
            cmbCashew.DisplayMember = "name";
            cmbCashew.ValueMember = "cashID";
            cmbCashew.DataSource = ds.Tables["Cashew"];
        }

        private void btnIncome_Click(object sender, EventArgs e)
        {
            if (numQty.Value != 0 && numPrice.Value != 0)
            {
                var cmd = DBConn.CreateCommand();
                cmd.CommandText = "SELECT buying FROM cashew WHERE cashID = @cash";
                cmd.Parameters.AddWithValue("@cash", cmbCashew.SelectedValue);
                var buying = decimal.Parse(cmd.ExecuteScalar().ToString());

                cmd.CommandText = "INSERT INTO tripdetails (tripID, type, cashId, qty, selling, buying) VALUES (@trip, 1, @cash, @qty, @sel, @buy)";
                cmd.Parameters.AddWithValue("@trip", tripID);
                cmd.Parameters.AddWithValue("@qty", numQty.Value);
                cmd.Parameters.AddWithValue("@sel", numPrice.Value/numQty.Value);
                cmd.Parameters.AddWithValue("@buy", buying);
                var recs = cmd.ExecuteNonQuery();

                if (recs > 0)
                {
                    initDGV();
                }
                else
                {
                    MessageBox.Show("Cannot insert details." + Environment.NewLine + "Please try again.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Add QTY and Price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExpence_Click(object sender, EventArgs e)
        {
            if (numAmount.Value != 0)
            {
                var cmd = DBConn.CreateCommand();
                cmd.CommandText = "INSERT INTO tripdetails (tripID, type, description, selling) VALUES (@trip, 2, @cash, @sel)";
                cmd.Parameters.AddWithValue("@trip", tripID);
                cmd.Parameters.AddWithValue("@cash", txtDesc.Text);
                cmd.Parameters.AddWithValue("@sel", numAmount.Value);
                var recs = cmd.ExecuteNonQuery();

                if (recs > 0)
                {
                    initDGV();
                }
                else
                {
                    MessageBox.Show("Cannot insert details." + Environment.NewLine + "Please try again.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Add amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cmd = DBConn.CreateCommand();
            if (dgvTrip.SelectedCells[0].Value.ToString() == "Expenses")
            {
                cmd.CommandText = "DELETE FROM tripdetails WHERE tripID = @trip AND description = @desc";
                cmd.Parameters.AddWithValue("@trip", tripID);
                cmd.Parameters.AddWithValue("@desc", dgvTrip.SelectedCells[1].Value);
            }
            else
            {
                cmd.CommandText = "SELECT cashID FROM cashew WHERE name = @name";
                cmd.Parameters.AddWithValue("@name", dgvTrip.SelectedCells[1].Value);
                var cashID = cmd.ExecuteScalar();

                cmd.CommandText = "DELETE FROM tripdetails WHERE tripID = @trip AND cashID = @cash";
                cmd.Parameters.AddWithValue("@trip", tripID);
                cmd.Parameters.AddWithValue("@cash", cashID);
            }

            var recs = cmd.ExecuteNonQuery();

            if (recs > 0)
            {
                initDGV();
                MessageBox.Show("Record deleted", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else MessageBox.Show("Couldn't delete record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void dgvTrip_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var rowSelected = e.RowIndex;
                if (e.RowIndex != -1)
                {
                    dgvTrip.ClearSelection();
                    dgvTrip.Rows[rowSelected].Selected = true;
                }
            }
        }
    }
}
