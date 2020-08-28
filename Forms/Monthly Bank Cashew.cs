using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Mr_Cashew.Datasets;
using Mr_Cashew.Models;

namespace Mr_Cashew.Forms
{
    public partial class Monthly_Bank_Cashew : Form
    {
        private MonthlyBankCashewModel model;
        private MonthlyReportDS ds;

        public Monthly_Bank_Cashew(MonthlyReportDS ds, MonthlyBankCashewModel model)
        {
            this.ds = ds;
            this.model = model;
            InitializeComponent();
        }

        private void Monthly_Bank_Cashew_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();

            ReportParameter[] pram = {
                new ReportParameter("month", model.date.ToString("MMMM - yyyy")),
                new ReportParameter("income", "Rs. " + model.income),
                new ReportParameter("cost", "Rs. " + model.cost),
                new ReportParameter("profit", "Rs. " + model.profit),
                new ReportParameter("rate",  Math.Round(model.rate,2) + "%"),
            };

            var rpt = new ReportDataSource("monthlyDS", ds.Tables["Monthly Bank Cashew"]);
            reportViewer1.LocalReport.DataSources.Add(rpt);
            reportViewer1.LocalReport.SetParameters(pram);
            this.reportViewer1.RefreshReport();
        }
    }
}
