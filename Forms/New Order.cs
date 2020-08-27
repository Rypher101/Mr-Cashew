using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Mr_Cashew.Forms
{
    public partial class New_Order : Form
    {
        private readonly MySqlConnection DBConn = Mr_Cashew.DBConn._obj.GetConnection();
        private bool emptyCMB;
        private readonly int orderID;

        public New_Order(int orderID)
        {
            InitializeComponent();
            this.orderID = orderID;
        }

        private void New_Order_Load(object sender, EventArgs e)
        {
            if (orderID == 0)
            {
                MessageBox.Show("Invalid order ID!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Close();
            }

            lblOrder.Text = orderID.ToString();
            initCMB();
        }

        private void initCMB()
        {
            var cmd = DBConn.CreateCommand();
            cmd.CommandText =
                "SELECT cashID, name FROM cashew WHERE cashID NOT IN (SELECT cashID FROM casheworder WHERE orderID = @order)";
            cmd.Parameters.AddWithValue("@order", orderID);

            var da = new MySqlDataAdapter(cmd);
            var ds = new DataSet();
            da.Fill(ds, "Cashew");
            cmbCashew.DisplayMember = "name";
            cmbCashew.ValueMember = "cashID";
            cmbCashew.DataSource = ds.Tables["Cashew"];

            if (ds.Tables["Cashew"].Rows.Count == 0) emptyCMB = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (emptyCMB)
            {
                MessageBox.Show("There are no cashews to add!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (numPrice.Value > 0 && numQTY.Value > 0)
            {
                var cmd = DBConn.CreateCommand();
                cmd.CommandText = "INSERT INTO casheworder VALUES (@order, @cashew, @qty, @price)";
                cmd.Parameters.AddWithValue("@order", orderID);
                cmd.Parameters.AddWithValue("@cashew", cmbCashew.SelectedValue);
                cmd.Parameters.AddWithValue("@qty", numQTY.Value);
                cmd.Parameters.AddWithValue("@price", numPrice.Value);

                cmd.ExecuteNonQuery();

                initDGV();
                initCMB();
            }
        }

        private void initDGV()
        {
            var cmd = DBConn.CreateCommand();
            cmd.CommandText =
                "SELECT orderID AS ID, name AS Name, qty AS QTY, price AS Price FROM casheworder INNER JOIN cashew ON casheworder.cashID = cashew.cashID WHERE orderID = @order";
            cmd.Parameters.AddWithValue("@order", orderID);

            var da = new MySqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            dgvCashew.DataSource = dt;
        }

        private void dgvCashew_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}