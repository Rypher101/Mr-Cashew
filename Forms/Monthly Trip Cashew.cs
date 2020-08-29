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
    public partial class Monthly_Trip_Cashew : Form
    {
        private MonthlyTripCashewModel model;
        private MonthlyReportDS ds;

        public Monthly_Trip_Cashew(MonthlyReportDS ds, MonthlyTripCashewModel model)
        {
            this.model = model;
            this.ds = ds;
            InitializeComponent();
        }

        private void Monthly_Trip_Cashew_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();

            ReportParameter[] pram = {
                new ReportParameter("month", model.date.ToString("MMMM - yyyy")),
                new ReportParameter("income", "Rs. " + model.income),
                new ReportParameter("cost", "Rs. " + model.cost),
                new ReportParameter("profit", "Rs. " + model.profit),
                new ReportParameter("expenses", "Rs. " + model.expenses),
                new ReportParameter("rate",  Math.Round(model.rate,2) + "%"),

            };

            var rpt = new ReportDataSource("monthlyDS", ds.Tables["Monthly Trip Cashew"]);
            reportViewer1.LocalReport.DataSources.Add(rpt);
            reportViewer1.LocalReport.SetParameters(pram);
            this.reportViewer1.RefreshReport();
        }
    }
}
