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
    public partial class Expenses : Form
    {
        private readonly MySqlConnection DBConn = Mr_Cashew.DBConn._obj.GetConnection();

        public Expenses()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDesc.Text) && numAmount.Value != 0)
            {
                var cmd = DBConn.CreateCommand();
                cmd.CommandText = "INSERT INTO expenses (description, amount, date) VALUES (@desc, @amount, @date)";
                cmd.Parameters.AddWithValue("@desc", txtDesc.Text);
                cmd.Parameters.AddWithValue("@amount", numAmount.Value);
                cmd.Parameters.AddWithValue("@date", dtp.Value);
                var recs = cmd.ExecuteNonQuery();

                if (recs > 0)
                {
                    initDGV();
                    MessageBox.Show("Expenses recorded", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                    MessageBox.Show("Couldn't enter expenses" + Environment.NewLine + "Please try again", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void initDGV(int searchMode = 0)
        {
            var cmd = DBConn.CreateCommand();
            switch (searchMode)
            {
                case 0:
                    cmd.CommandText = "SELECT ID, Description, Amount, Date FROM expenses ORDER BY date DESC";
                    break;

                case 1:
                    cmd.CommandText = "SELECT ID, Description, Amount, Date FROM expenses WHERE date = @date ORDER BY date DESC";
                    cmd.Parameters.AddWithValue("@date", dtp.Value.ToString("yyyy-MM-dd"));
                    break;
            }

            var da = new MySqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            dgvExpenses.DataSource = dt;
        }

        private void Expenses_Load(object sender, EventArgs e)
        {
            initDGV();
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            initDGV(1);
        }

        private void dgvExpenses_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var rowSelected = e.RowIndex;
                if (e.RowIndex != -1)
                {
                    dgvExpenses.ClearSelection();
                    dgvExpenses.Rows[rowSelected].Selected = true;
                }
            }
        }

        private void deleteRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cmd = DBConn.CreateCommand();
            cmd.CommandText = "DELETE FROM expenses WHERE id=@id";
            cmd.Parameters.AddWithValue("@id", dgvExpenses.SelectedCells[0].Value);
            var recs = cmd.ExecuteNonQuery();

            if (recs > 0)
            {
                initDGV();
                MessageBox.Show("Record deleted", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
                MessageBox.Show("Couldn't delete record" + Environment.NewLine + "Please try again", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void showAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initDGV();
        }
    }
}
