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
    public partial class Trip : Form
    {
        private readonly MySqlConnection DBConn = Mr_Cashew.DBConn._obj.GetConnection();
        private readonly AutoCompleteStringCollection dataCollection = new AutoCompleteStringCollection();

        public Trip()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cmd = DBConn.CreateCommand();
            cmd.CommandText = "INSERT INTO trip (date, place) VALUES (@date, @place)";
            cmd.Parameters.AddWithValue("@date", dtp.Value);
            cmd.Parameters.AddWithValue("@place", txtPlace.Text);
            var recs = cmd.ExecuteNonQuery();

            if (recs > 0)
            {
                cmd.CommandText = "SELECT MAX(tripID) FROM trip";
                var tripID = int.Parse(cmd.ExecuteScalar().ToString());

                var frm = new New_Trip(tripID);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Couldn't create new trip." + Environment.NewLine + "Please try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void autoCompleteTXT()
        {
            var cmd = DBConn.CreateCommand();
            cmd.CommandText = "SELECT DISTINCT(place) FROM trip";
            var da = new MySqlDataAdapter(cmd);
            var ds = new DataSet();
            da.Fill(ds);
            dataCollection.Clear();

            foreach (DataRow row in ds.Tables[0].Rows) dataCollection.Add(row[0].ToString());
        }

        private void Trip_Load(object sender, EventArgs e)
        {
            autoCompleteTXT();
            txtPlace.AutoCompleteCustomSource = dataCollection;

            dtp.MaxDate = DateTime.Today;
            initTripDGV();
        }

        private void txtPlace_TextChanged(object sender, EventArgs e)
        {
            initTripDGV(1);
        }

        private void initTripDGV(int search = 0)
        {
            var cmd = DBConn.CreateCommand();
            switch (search)
            {
                case 0:
                    cmd.CommandText = "SELECT * FROM trip ORDER BY tripID DESC";
                    break;

                case 1:
                    cmd.CommandText = "SELECT * FROM trip WHERE place = @place ORDER BY tripID DESC";
                    cmd.Parameters.AddWithValue("@place", txtPlace.Text);
                    break;

                case 2:
                    cmd.CommandText = "SELECT * FROM trip WHERE date = @date ORDER BY tripID DESC";
                    cmd.Parameters.AddWithValue("@date", dtp.Value.ToString("yyyy-MM-dd"));
                    break;
            }

            var da = new MySqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            if (search == 1 && dt.Rows.Count == 0)
            {
                initTripDGV();
                    return;
            }

            dgvTrip.DataSource = dt;
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            initTripDGV(2);
        }

        private void dgvTrip_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            decimal income = 0;
            decimal expenses = 0;
            decimal income2 = 0;
            decimal profit = 0;

            var cmd = DBConn.CreateCommand();
            cmd.CommandText = "SELECT IF(type = 1, 'Income', 'Expenses') AS Type, IF(type = 1, name, description) AS Description, qty AS QTY, tripdetails.selling AS 'Price/Cost', tripdetails.Buying FROM tripdetails LEFT JOIN cashew ON tripdetails.cashID = cashew.cashID WHERE tripID = @trip";
            cmd.Parameters.AddWithValue("@trip", dgvTrip.SelectedCells[0].Value);

            var da = new MySqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                if (item[0].ToString() == "Income")
                {
                    income += decimal.Parse(item[2].ToString()) * decimal.Parse(item[3].ToString());
                    income2 += decimal.Parse(item[2].ToString()) * decimal.Parse(item[4].ToString());
                }
                else
                {
                    expenses += decimal.Parse(item[3].ToString());
                }
            }

            profit = income - (expenses + income2);

            lblID.Text = dgvTrip.SelectedCells[0].Value.ToString();
            lblIncome.Text ="Rs. "+ income;
            lblCost.Text = "Rs. " + income2;
            lblExpenses.Text = "Rs. " + expenses;
            lblProfit.Text = "Rs. " + profit;

            dgvDetail.DataSource = dt;
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

        private void dgvDetail_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var rowSelected = e.RowIndex;
                if (e.RowIndex != -1)
                {
                    dgvDetail.ClearSelection();
                    dgvDetail.Rows[rowSelected].Selected = true;
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblExpenses_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblIncome_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lblID.Text !=null)
            {
                var frm = new New_Trip(int.Parse(lblID.Text));
                frm.Show();
            }
            
        }

        private void deleteRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete this record?", "Warring", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var cmd = DBConn.CreateCommand();
                cmd.CommandText = "DELETE FROM trip WHERE tripID = @trip";
                cmd.Parameters.AddWithValue("@trip", lblID.Text);
                var recs = cmd.ExecuteNonQuery();

                if (recs>0)
                {
                    MessageBox.Show("Record deleted!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    initTripDGV();
                }
                else
                {
                    MessageBox.Show("Couldn't delete resord" + Environment.NewLine + "Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
