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
using Mr_Cashew.Models;

namespace Mr_Cashew.Forms
{
    public partial class MonthlySummary : Form
    {
        private MonthlySummaryModel model;

        public MonthlySummary(MonthlySummaryModel model)
        {
            this.model = model;
            InitializeComponent();
        }

        private void MonthlySummary_Load(object sender, EventArgs e)
        {

            reportViewer1.LocalReport.DataSources.Clear();

            ReportParameter[] pram = {
                new ReportParameter("month", model.date.ToString("MMMM - yyyy")),
                new ReportParameter("bIncome", "Rs. " + Math.Round(model.bIncome,2)),
                new ReportParameter("bCost", "Rs. " + Math.Round(model.bCost,2)),
                new ReportParameter("bTransport", "Rs. " + Math.Round(model.bTransport,2)),
                new ReportParameter("tIncome", "Rs. " + Math.Round(model.tIncome,2)),
                new ReportParameter("tCost", "Rs. " + Math.Round(model.tCost,2)),
                new ReportParameter("tTransport", "Rs. " + Math.Round(model.tTransport,2)),
                new ReportParameter("buyingTransport", "Rs. " + Math.Round(model.BuyingTransport,2)),
                new ReportParameter("totIncome", "Rs. " + Math.Round(model.totIncome,2)),
                new ReportParameter("totCost", "Rs. " + Math.Round(model.totCost,2)),
                new ReportParameter("totExpenses", "Rs. " + Math.Round(model.totExpenses,2)),
                new ReportParameter("netProfit", "Rs. " + Math.Round(model.netProfit,2)),
            };

            reportViewer1.LocalReport.SetParameters(pram);
            this.reportViewer1.RefreshReport();
        }
    }
}
