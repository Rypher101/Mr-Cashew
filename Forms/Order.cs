using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Mr_Cashew.Forms
{
    public partial class Order : Form
    {
        private readonly MySqlConnection DBConn = Mr_Cashew.DBConn._obj.GetConnection();
        private bool cmbInit;
        private bool dtpInit;

        public Order()
        {
            InitializeComponent();
        }

        private void Order_Load(object sender, EventArgs e)
        {
            initCMB();
            initOrderDGV();
            initDTP();
        }

        private void initCMB()
        {
            var cmd = DBConn.CreateCommand();
            cmd.CommandText = "SELECT sellerID, name FROM seller";
            var da = new MySqlDataAdapter(cmd);
            var ds = new DataSet();
            da.Fill(ds, "Seller");
            cmbSeller.DisplayMember = "name";
            cmbSeller.ValueMember = "sellerID";
            cmbSeller.DataSource = ds.Tables["Seller"];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                var cmd = DBConn.CreateCommand();
                cmd.CommandText = "INSERT INTO orders (sellerID, date) VALUES (@seller, @date)";
                cmd.Parameters.AddWithValue("@seller", cmbSeller.SelectedValue);
                cmd.Parameters.AddWithValue("@date", dtp.Value);

                var recs = cmd.ExecuteNonQuery();

                if (recs > 0)
                {
                    cmd.CommandText = "SELECT MAX(orderID) FROM orders";
                    var orderID = int.Parse(cmd.ExecuteScalar().ToString());

                    cmd.CommandText = "UPDATE orders SET status = 0 WHERE orderID <> @order";
                    cmd.Parameters.AddWithValue("@order", orderID);
                    cmd.ExecuteNonQuery();

                    var frm = new New_Order(orderID);
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Unable to create new order!" + Environment.NewLine + "Please try again.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                MessageBox.Show(
                    "Unable to create new order!" + Environment.NewLine + "Please try again." + Environment.NewLine +
                    exception, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void initOrderDGV(int value = 0)
        {
            var cmd = DBConn.CreateCommand();
            switch (value)
            {
                case 0:
                    cmd.CommandText =
                        "SELECT orderID, Name, Date  FROM orders INNER JOIN seller ON orders.sellerID = seller.sellerID ORDER BY date";
                    break;

                case 1:
                    cmd.CommandText =
                        "SELECT orderID, Name, Date FROM orders INNER JOIN seller ON orders.sellerID = seller.sellerID WHERE orders.sellerID = @seller ORDER BY date";
                    cmd.Parameters.AddWithValue("@seller", cmbSeller.SelectedValue);
                    break;

                case 2:
                    cmd.CommandText =
                        "SELECT orderID, Name, Date FROM orders INNER JOIN seller ON orders.sellerID = seller.sellerID WHERE date = @date ORDER BY date";
                    cmd.Parameters.AddWithValue("@date", dtp.Value.ToString("yyyy-MM-dd"));
                    break;
            }

            var da = new MySqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            dgvOrder.DataSource = dt;
        }

        private async void initDTP()
        {
            dtp.MaxDate = DateTime.Today;
        }

        private void dgvOrder_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var rowSelected = e.RowIndex;
                if (e.RowIndex != -1)
                {
                    dgvOrder.ClearSelection();
                    dgvOrder.Rows[rowSelected].Selected = true;
                }
            }
        }

        private void dataCashew_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
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

        private void dgvOrder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void cmbSeller_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbInit) initOrderDGV(1);

            cmbInit = true;
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            if (dtpInit) initOrderDGV(2);

            dtpInit = true;
        }

        private void showAllOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initOrderDGV();
        }

        private void deleteOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Warning", MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                var cmd = DBConn.CreateCommand();
                cmd.CommandText = "DELETE FROM orders WHERE orderID = @order";
                cmd.Parameters.AddWithValue("@order", dgvOrder.SelectedCells[0].Value.ToString());

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Order Deleted", "Successful",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    initOrderDGV();
                }
                else
                {
                    MessageBox.Show("Unable to delete order!" + Environment.NewLine + "Please try again.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvOrder_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var cmd = DBConn.CreateCommand();
            cmd.CommandText =
                "SELECT orderID AS ID, name AS Name, qty AS QTY, price AS Price FROM casheworder INNER JOIN cashew ON casheworder.cashID = cashew.cashID WHERE orderID = @order";
            cmd.Parameters.AddWithValue("@order", dgvOrder.SelectedCells[0].Value.ToString());

            var da = new MySqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            dgvCashew.DataSource = dt;
        }

        private void setAsActiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cmd = DBConn.CreateCommand();

            cmd.CommandText = "UPDATE orders SET status = 0";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "UPDATE orders SET status = 1 WHERE orderID = @order";
            cmd.Parameters.AddWithValue("@order", dgvOrder.SelectedCells[0].Value.ToString());
            cmd.ExecuteNonQuery();

            initOrderDGV();
        }
    }
}