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
    public partial class Daily_Report : Form
    {
        private DailyReportModel model;
        private Daily_DS ds;

        public Daily_Report(DailyReportModel model,Daily_DS ds)
        {
            this.model = model;
            this.ds = ds;
            InitializeComponent();
        }

        private void Daily_Report_Load(object sender, EventArgs e)
        {
            reportViewer.LocalReport.DataSources.Clear();

            ReportParameter[] pram = {
                new ReportParameter("date", model.date.ToString("D")),
                new ReportParameter("income", "Rs. " +model.income),
                new ReportParameter("expenses", "Rs. " + model.expenses),
                new ReportParameter("profit", "Rs. " + model.profit), 
            };

            var rpt = new ReportDataSource("DailyDS", ds.Tables["Daily Report"]);
            reportViewer.LocalReport.DataSources.Add(rpt);
            reportViewer.LocalReport.SetParameters(pram);
            this.reportViewer.RefreshReport();
        }
    }
}
