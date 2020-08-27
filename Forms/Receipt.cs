using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Mr_Cashew.Forms
{
    public partial class Receipt : Form
    {
        private readonly MySqlConnection DBConn = Mr_Cashew.DBConn._obj.GetConnection();
        private readonly AutoCompleteStringCollection dataCollection = new AutoCompleteStringCollection();

        public Receipt()
        {
            InitializeComponent();
            RefreshDGV(9);
            RefreshCashewCmd();
        }

        private void Receipt_Load(object sender, EventArgs e)
        {
            cmbPS.SelectedIndex = 0;
            ReloadAutoCompleteDataCollection();
            txtContact.AutoCompleteCustomSource = dataCollection;
        }

        private void ReloadAutoCompleteDataCollection()
        {
            var cmd = DBConn.CreateCommand();
            cmd.CommandText = "SELECT contact FROM buyer";
            var da = new MySqlDataAdapter(cmd);
            var ds = new DataSet();
            da.Fill(ds);
            dataCollection.Clear();

            foreach (DataRow row in ds.Tables[0].Rows) dataCollection.Add(row[0].ToString());
        }

        private void RefreshCashewCmd()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtReceipt.Text))
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

                    cmd.CommandText = "SELECT * FROM size";
                    var da2 = new MySqlDataAdapter(cmd);
                    da.Fill(ds, "Size");
                    cmbSize.DisplayMember = "name";
                    cmbSize.ValueMember = "size";
                    cmbSize.DataSource = ds.Tables["Size"];

                    cmbSize.SelectedIndex = 1;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public void RefreshDGV(int searchItem = 0, string searchValue = null)
        {
            var cmd = DBConn.CreateCommand();
            switch (searchItem)
            {
                case 0:
                    cmd.CommandText =
                        "SELECT resID AS ID, receipt.contact AS Contact, name AS Name, goodStatus AS GStatus, payStatus AS PStatus, date AS Date FROM receipt INNER JOIN buyer ON receipt.contact = buyer.contact ORDER BY date DESC";
                    break;

                case 1:
                    cmd.CommandText =
                        "SELECT resID AS ID, receipt.contact AS Contact, name AS Name, goodStatus AS GStatus, payStatus AS PStatus, date AS Date FROM receipt INNER JOIN buyer ON receipt.contact = buyer.contact WHERE resID = @resID ORDER BY date DESC";
                    cmd.Parameters.AddWithValue("@resID", searchItem);
                    break;

                case 2:
                    cmd.CommandText =
                        "SELECT resID AS ID, receipt.contact AS Contact, name AS Name, goodStatus AS GStatus, payStatus AS PStatus, date AS Date FROM receipt INNER JOIN buyer ON receipt.contact = buyer.contact WHERE name = @name ORDER BY date DESC";
                    cmd.Parameters.AddWithValue("@name", searchValue);
                    break;

                case 3:
                    cmd.CommandText =
                        "SELECT resID AS ID, receipt.contact AS Contact, name AS Name, goodStatus AS GStatus, payStatus AS PStatus, date AS Date FROM receipt INNER JOIN buyer ON receipt.contact = buyer.contact WHERE receipt.contact = @contact ORDER BY date DESC";
                    cmd.Parameters.AddWithValue("@contact", searchValue);
                    break;

                case 4:
                    cmd.CommandText =
                        "SELECT resID AS ID, receipt.contact AS Contact, name AS Name, goodStatus AS GStatus, payStatus AS PStatus, date AS Date FROM receipt INNER JOIN buyer ON receipt.contact = buyer.contact WHERE receipt.goodStatus = 1 ORDER BY date DESC";
                    break;

                case 5:
                    cmd.CommandText =
                        "SELECT resID AS ID, receipt.contact AS Contact, name AS Name, goodStatus AS GStatus, payStatus AS PStatus, date AS Date FROM receipt INNER JOIN buyer ON receipt.contact = buyer.contact WHERE receipt.goodStatus = 2 ORDER BY date DESC";
                    break;

                case 6:
                    cmd.CommandText =
                        "SELECT resID AS ID, receipt.contact AS Contact, name AS Name, goodStatus AS GStatus, payStatus AS PStatus, date AS Date FROM receipt INNER JOIN buyer ON receipt.contact = buyer.contact WHERE receipt.payStatus = 1 ORDER BY date DESC";
                    break;

                case 7:
                    cmd.CommandText =
                        "SELECT resID AS ID, receipt.contact AS Contact, name AS Name, goodStatus AS GStatus, payStatus AS PStatus, date AS Date FROM receipt INNER JOIN buyer ON receipt.contact = buyer.contact WHERE receipt.payStatus = 2 ORDER BY date DESC";
                    break;

                case 8:
                    cmd.CommandText =
                        "SELECT resID AS ID, receipt.contact AS Contact, name AS Name, goodStatus AS GStatus, payStatus AS PStatus, date AS Date FROM receipt INNER JOIN buyer ON receipt.contact = buyer.contact WHERE receipt.payStatus = 3 ORDER BY date DESC";
                    break;

                case 9:
                    cmd.CommandText =
                        "SELECT resID AS ID, receipt.contact AS Contact, name AS Name, goodStatus AS GStatus, payStatus AS PStatus, date AS Date FROM receipt INNER JOIN buyer ON receipt.contact = buyer.contact WHERE date > (NOW() - INTERVAL 7 DAY) ORDER BY date DESC";
                    break;
            }

            var da = new MySqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var dtClone = dt.Clone();
                dtClone.Columns[3].DataType = typeof(string);
                dtClone.Columns[4].DataType = typeof(string);
                dtClone.Columns[5].DataType = typeof(string);

                foreach (DataRow item in dt.Rows) dtClone.ImportRow(item);

                foreach (DataRow item in dtClone.Rows)
                {
                    item[3] = item[3].ToString() == "1" ? "Pending" : "Delivered";
                    item[4] = item[4].ToString() == "1" ? "Pending" : item[4].ToString() == "2" ? "Online" : "Cash";
                    item[5] = DateTime.Parse(item[5].ToString()).ToString("yyyy MMM dd");
                }

                dgvReceipt.DataSource = dtClone;
            }
            else
            {
                MessageBox.Show("No search result found!", "Search", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) && !string.IsNullOrWhiteSpace(txtContact.Text))
            {
                int ps;

                if (cmbPS.Text == "Pending")
                    ps = 1;
                else if (cmbPS.Text == "Online")
                    ps = 2;
                else
                    ps = 3;

                var cmd = DBConn.CreateCommand();
                cmd.CommandText = "SELECT EXISTS (SELECT * FROM buyer WHERE contact = @con)";
                cmd.Parameters.AddWithValue("@con", txtContact.Text);
                var result = cmd.ExecuteScalar();

                if (result.ToString() != "1")
                {
                    cmd.CommandText = "INSERT INTO buyer VALUES (@con, @name)";
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        MessageBox.Show("Couldn't create/find buyer." + Environment.NewLine + "Please try again",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                cmd.CommandText =
                    "INSERT INTO receipt(contact, goodStatus, payStatus, date) VALUES (@con, @gs, @ps, @date)";
                cmd.Parameters.AddWithValue("@gs", 1);
                cmd.Parameters.AddWithValue("@ps", ps);
                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                var recs = cmd.ExecuteNonQuery();
                RefreshDGV();

                if (recs > 0)
                {
                    cmd.CommandText = "SELECT MAX(resID) FROM receipt";
                    txtReceipt.Text = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    MessageBox.Show("Couldn't create receipt." + Environment.NewLine + "Please try again", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter customer's contact numer and name", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void RefreshCashewDGV()
        {
            if (!string.IsNullOrWhiteSpace(txtReceipt.Text))
            {
                var cmd = DBConn.CreateCommand();
                cmd.CommandText =
                    "SELECT resID AS ID, receipt.contact AS Contact, name AS Name, goodStatus AS GStatus, payStatus AS PStatus, date AS Date FROM receipt INNER JOIN buyer ON receipt.contact = buyer.contact WHERE resID = @resid";
                cmd.Parameters.AddWithValue("@resid", int.Parse(txtReceipt.Text));

                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    var dtClone = dt.Clone();
                    dtClone.Columns[3].DataType = typeof(string);
                    dtClone.Columns[4].DataType = typeof(string);
                    dtClone.Columns[5].DataType = typeof(string);

                    foreach (DataRow item in dt.Rows) dtClone.ImportRow(item);

                    foreach (DataRow item in dtClone.Rows)
                    {
                        item[3] = item[3].ToString() == "1" ? "Pending" : "Delivered";
                        item[4] = item[4].ToString() == "1" ? "Pending" : item[4].ToString() == "2" ? "Online" : "Cash";
                        item[5] = DateTime.Parse(item[5].ToString()).ToString("yyyy MMMM dd");
                    }

                    dgvReceipt.DataSource = dtClone;

                    cmd.CommandText =
                        "SELECT name AS Name, size AS Size, qty AS QTY, price AS Selling, buyingPrice AS Buying FROM resorder INNER JOIN cashew ON resorder.cashID = cashew.cashID WHERE resID = @resid";
                    using (var reader = cmd.ExecuteReader())
                    {
                        decimal tot = 0;
                        while (reader.Read()) tot = tot + reader.GetFieldValue<decimal>(3);

                        lblTotal.Text = "Rs. " + tot;
                    }

                    dt.Reset();
                    da.Fill(dt);
                    dgvCashew.DataSource = dt;

                    RefreshCashewCmd();
                }
            }
            else
            {
                dgvCashew.DataSource = null;
                dgvCashew.Rows.Clear();
                dgvCashew.Refresh();
                RefreshDGV();
                lblTotal.Text = "Rs. 0.00";
            }
        }

        private void txtReveipt_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReceipt.Text))
                btnCshAdd.Enabled = false;
            else
                btnCshAdd.Enabled = true;
            RefreshCashewDGV();
        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            var cmd = DBConn.CreateCommand();
            cmd.CommandText = "SELECT name FROM buyer WHERE contact = @contact";
            cmd.Parameters.AddWithValue("@contact", txtContact.Text);

            var da = new MySqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
                txtName.Text = dt.Rows[0][0].ToString();
            else
                txtName.Text = "";
        }

        private void cmbCashew_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnCshAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtReceipt.Text) && !string.IsNullOrWhiteSpace(txtQTY.Text) &&
                cmbCashew.Items.Count > 0)
            {
                var cmd = DBConn.CreateCommand();
                cmd.CommandText = "SELECT selling FROM cashew WHERE cashID = @cash";
                cmd.Parameters.AddWithValue("@cash", cmbCashew.SelectedValue);
                var price = decimal.Parse(cmd.ExecuteScalar().ToString());

                cmd.CommandText = "SELECT goodStatus FROM receipt WHERE resID = @res";
                cmd.Parameters.AddWithValue("@res", txtReceipt.Text);
                var status = int.Parse(cmd.ExecuteScalar().ToString());

                cmd.CommandText =
                    "SELECT EXISTS (SELECT * FROM resorder WHERE resID = @res AND cashID = @cash AND size = @size)";
                cmd.Parameters.AddWithValue("@size", cmbSize.SelectedValue);
                if (cmd.ExecuteScalar().ToString() != "1")
                {
                    cmd.CommandText =
                        "INSERT INTO resorder(resID,cashID,size,qty,price) VALUES (@res, @cash, @size, @qty, @price)";
                    cmd.Parameters.AddWithValue("@qty", txtQTY.Text);
                    cmd.Parameters.AddWithValue("@price",
                        price * int.Parse(txtQTY.Text) * int.Parse(cmbSize.SelectedValue.ToString()) / 1000);
                    var recs = cmd.ExecuteNonQuery();

                    if (recs > 0)
                    {
                        if (status == 2)
                        {
                            cmd.CommandText =
                                "UPDATE resorder SET buyingPrice = (SELECT buying FROM cashew WHERE cashID = @cash)*qty*size/1000 WHERE resID = @res AND cashID = @cash";
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Data update faild!" + Environment.NewLine + "Please try again.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }

                    RefreshCashewDGV();
                }
                else
                {
                    MessageBox.Show(
                        "That cashew & size already exist in database." + Environment.NewLine +
                        "Remove that value and insert again", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void dgvReceipt_DoubleClick(object sender, EventArgs e)
        {
            txtReceipt.Text = dgvReceipt.SelectedCells[0].Value.ToString();
            txtName.Text = dgvReceipt.SelectedCells[2].Value.ToString();
            txtContact.Text = dgvReceipt.SelectedCells[1].Value.ToString();
            dateTimePicker1.Value = DateTime.Parse(dgvReceipt.SelectedCells[5].Value.ToString());
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
                cmd.CommandText = "SELECT cashID FROM cashew WHERE name = @name";
                cmd.Parameters.AddWithValue("@name", dgvCashew.SelectedCells[0].Value.ToString());
                var cashID = cmd.ExecuteScalar().ToString();

                cmd.CommandText = "DELETE FROM resorder WHERE resID = @rs AND cashID = @cash AND size = @size";
                cmd.Parameters.AddWithValue("@rs", txtReceipt.Text);
                cmd.Parameters.AddWithValue("@cash", cashID);
                cmd.Parameters.AddWithValue("@size", dgvCashew.SelectedCells[1].Value.ToString());
                var recs = cmd.ExecuteNonQuery();
                if (recs > 0)
                    MessageBox.Show("Record Deleted!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Couldn't delete selected record." + Environment.NewLine + "Please try again",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                RefreshCashewDGV();
            }
        }

        private void dgvReceipt_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var rowSelected = e.RowIndex;
                if (e.RowIndex != -1)
                {
                    dgvReceipt.ClearSelection();
                    dgvReceipt.Rows[rowSelected].Selected = true;
                }
            }
        }

        private void Receipt_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshDGV();
            RefreshCashewCmd();
        }

        private void goodStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void deleteThisReceiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Warning", MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                var cmd = DBConn.CreateCommand();
                cmd.CommandText = "DELETE FROM receipt WHERE resID = @res";
                cmd.Parameters.AddWithValue("@res", dgvReceipt.SelectedCells[0].Value.ToString());
                var recs = cmd.ExecuteNonQuery();
                if (recs > 0)
                    MessageBox.Show("Record Deleted!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Couldn't delete selected record." + Environment.NewLine + "Please try again",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                RefreshDGV();
            }
        }

        private void OpenSearchbox(int searchItem)
        {
            Form frm = new ReceiptSearchBox(searchItem, this);

            for (var i = Application.OpenForms.Count - 1; i >= 0; i--)
                if (Application.OpenForms[i].Name == frm.Name)
                {
                    Application.OpenForms[i].Close();
                    break;
                }

            frm.Show();
        }

        private void receiptIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSearchbox(1);
        }

        private void nameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSearchbox(2);
        }

        private void contactNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSearchbox(3);
        }

        private async void pendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to turn goods status to PENDING?", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                var cmd = DBConn.CreateCommand();
                cmd.CommandText = "UPDATE receipt SET goodStatus = 1 WHERE resID = @res";
                cmd.Parameters.AddWithValue("@res", dgvReceipt.SelectedCells[0].Value.ToString());
                var recs = cmd.ExecuteNonQuery();
                if (recs > 0)
                {
                    cmd.CommandText = "SELECT cashID FROM resorder WHERE resID = @res";
                    var da = new MySqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow item in dt.Rows)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = "UPDATE resorder SET buyingPrice = 0 WHERE resID = @res AND cashID = @cash";
                        cmd.Parameters.AddWithValue("@res", dgvReceipt.SelectedCells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@cash", item["cashID"].ToString());
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    MessageBox.Show("Couldn't delete selected record." + Environment.NewLine + "Please try again",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                RefreshDGV();
                RefreshCashewDGV();
            }
        }

        private async void deliverdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to turn goods status to DELIVERED?", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                var cmd = DBConn.CreateCommand();
                cmd.CommandText = "UPDATE receipt SET goodStatus = 2 WHERE resID = @res";
                cmd.Parameters.AddWithValue("@res", dgvReceipt.SelectedCells[0].Value.ToString());
                var recs = cmd.ExecuteNonQuery();
                if (recs > 0)
                {
                    cmd.CommandText = "SELECT cashID FROM resorder WHERE resID = @res";
                    var da = new MySqlDataAdapter(cmd);
                    var dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow item in dt.Rows)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText =
                            "UPDATE resorder SET buyingPrice = (SELECT buying FROM cashew WHERE cashID = @cash)*qty*size/1000 WHERE resID = @res AND cashID = @cash";
                        cmd.Parameters.AddWithValue("@res", dgvReceipt.SelectedCells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@cash", item["cashID"].ToString());
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    MessageBox.Show("Couldn't delete selected record." + Environment.NewLine + "Please try again",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                RefreshDGV();
                RefreshCashewDGV();
            }
        }

        private void pendingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to turn payment status to PENDING?", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                var cmd = DBConn.CreateCommand();
                cmd.CommandText = "UPDATE receipt SET payStatus = 1 WHERE resID = @res";
                cmd.Parameters.AddWithValue("@res", dgvReceipt.SelectedCells[0].Value.ToString());
                var recs = cmd.ExecuteNonQuery();
                if (recs > 0)
                {
                    //MessageBox.Show("Record Deleted!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Couldn't delete selected record." + Environment.NewLine + "Please try again",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                RefreshDGV();
            }
        }

        private void onlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to turn payment status to ONLINE?", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                var cmd = DBConn.CreateCommand();
                cmd.CommandText = "UPDATE receipt SET payStatus = 2 WHERE resID = @res";
                cmd.Parameters.AddWithValue("@res", dgvReceipt.SelectedCells[0].Value.ToString());
                var recs = cmd.ExecuteNonQuery();
                if (recs > 0)
                {
                    //MessageBox.Show("Record Deleted!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Couldn't delete selected record." + Environment.NewLine + "Please try again",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                RefreshDGV();
            }
        }

        private void cashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to turn payment status to CASH?", "Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                var cmd = DBConn.CreateCommand();
                cmd.CommandText = "UPDATE receipt SET payStatus = 3 WHERE resID = @res";
                cmd.Parameters.AddWithValue("@res", dgvReceipt.SelectedCells[0].Value.ToString());
                var recs = cmd.ExecuteNonQuery();
                if (recs > 0)
                {
                    //MessageBox.Show("Record Deleted!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Couldn't delete selected record." + Environment.NewLine + "Please try again",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                RefreshDGV();
            }
        }

        private void pendingToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            RefreshDGV(4);
        }

        private void deliveredToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshDGV(5);
        }

        private void pendingToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            RefreshDGV(6);
        }

        private void onilneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshDGV(7);
        }

        private void cashToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RefreshDGV(8);
        }
    }
}