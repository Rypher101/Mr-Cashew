using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Mr_Cashew.Forms
{
    public partial class ReceiptSearchBox : Form
    {
        private readonly MySqlConnection DBConn = Mr_Cashew.DBConn._obj.GetConnection();
        private readonly AutoCompleteStringCollection dataCollection = new AutoCompleteStringCollection();
        private readonly Receipt mainForm;
        private readonly int searchItem;

        public ReceiptSearchBox(int searchItem, Receipt mainForm)
        {
            this.mainForm = mainForm;
            this.searchItem = searchItem;
            InitializeComponent();
        }

        private void ReceiptSearchBox_Load(object sender, EventArgs e)
        {
            switch (searchItem)
            {
                case 1:
                    lblSearch.Text = "Receipt ID :";
                    break;

                case 2:
                    lblSearch.Text = "Name :";
                    break;

                case 3:
                    lblSearch.Text = "Contact :";
                    break;
            }

            SetAutocompleteDataCollection();
            txtSearch.AutoCompleteCustomSource = dataCollection;
        }

        private void SetAutocompleteDataCollection()
        {
            var cmd = DBConn.CreateCommand();
            switch (searchItem)
            {
                case 1:
                    cmd.CommandText = "SELECT resID FROM receipt";
                    break;

                case 2:
                    cmd.CommandText = "SELECT name FROM buyer";
                    break;

                case 3:
                    cmd.CommandText = "SELECT contact FROM buyer";
                    break;

                default:
                    MessageBox.Show("Can't create autocomplete data collection", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
            }

            var da = new MySqlDataAdapter(cmd);
            var ds = new DataSet();
            da.Fill(ds);
            dataCollection.Clear();

            foreach (DataRow row in ds.Tables[0].Rows) dataCollection.Add(row[0].ToString());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            mainForm.RefreshDGV(searchItem, txtSearch.Text);
            Close();
        }
    }
}