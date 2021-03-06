﻿using Mr_Cashew.Datasets;
using Mr_Cashew.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.ReportingServices.Interfaces;

namespace Mr_Cashew.Forms
{
    public partial class Daily_Report_Manager : Form
    {
        private readonly MySqlConnection DBConn = Mr_Cashew.DBConn._obj.GetConnection();

        public Daily_Report_Manager()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var ds = new Daily_DS();
            var cmd = DBConn.CreateCommand();
            var i = 1;
            decimal income = 0;
            decimal expense = 0;
            decimal profit = 0;

            cmd.CommandText = "SELECT SUM(price*size/1000), SUM((price-buyingPrice)*size/1000) FROM resorder INNER JOIN receipt ON resorder.resID = receipt.resID WHERE date = @date AND goodStatus = 2";
            cmd.Parameters.AddWithValue("@date", dtpDate.Value.ToString("yyyy-MM-dd"));
            var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                if (reader.GetValue(0) is DBNull)
                {
                    reader.Dispose();
                    break;
                }
                var tempIncome = "Rs. " + Math.Round(reader.GetFieldValue<decimal>(0), 2);
                var tempProfit = "Rs. " + Math.Round(reader.GetFieldValue<decimal>(1), 2);

                DataRow dr = ds.Tables["Daily Report"].NewRow();
                dr["Index"] = i++;
                dr["Description"] = "Receipt balance";
                dr["Income"] = tempIncome;
                dr["Expenses"] = "";
                dr["Profit"] = tempProfit;
                ds.Tables["Daily Report"].Rows.Add(dr);

                income += reader.GetFieldValue<decimal>(0);
                profit += reader.GetFieldValue<decimal>(1);
            }

            reader.Dispose();

            cmd.CommandText =
                "SELECT place, SUM(IF(type = 1, qty * selling, 0)), SUM(IF(type = 1, (selling - buying) * qty, 0)), SUM(IF(type = 2, selling, 0))  FROM tripdetails INNER JOIN trip ON tripdetails.tripID = trip.tripID WHERE date = @date GROUP BY place";
            reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                if (reader.GetValue(1) is DBNull && reader.GetValue(2) is DBNull && reader.GetValue(3) is DBNull)
                {
                    reader.Dispose();
                    break;
                }

                string tempIncome = "Rs. " + Math.Round(reader.GetFieldValue<decimal>(1), 2);
                string tempProfit = "Rs. " + (Math.Round(reader.GetFieldValue<decimal>(2), 2) - Math.Round(reader.GetFieldValue<decimal>(3), 2));
                string tempExpense = "Rs. " + Math.Round(reader.GetFieldValue<decimal>(3), 2);

                DataRow dr = ds.Tables["Daily Report"].NewRow();
                dr["Index"] = i++;
                dr["Description"] = "Trip - " + reader.GetFieldValue<string>(0);
                dr["Income"] = tempIncome;
                dr["Expenses"] = tempExpense;
                dr["Profit"] = tempProfit;
                ds.Tables["Daily Report"].Rows.Add(dr);

                income += reader.GetFieldValue<decimal>(1);
                profit += reader.GetFieldValue<decimal>(2) - reader.GetFieldValue<decimal>(3);
                expense += reader.GetFieldValue<decimal>(3);
            }
            reader.Dispose();

            cmd.CommandText = "SELECT description, amount FROM expenses WHERE date = @date";
            reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                string tempExpense = "Rs. " + Math.Round(reader.GetFieldValue<decimal>(1), 2);

                DataRow dr = ds.Tables["Daily Report"].NewRow();
                dr["Index"] = i++;
                dr["Description"] = reader.GetFieldValue<string>(0);
                dr["Income"] = "";
                dr["Expenses"] = tempExpense;
                dr["Profit"] = "";
                ds.Tables["Daily Report"].Rows.Add(dr);

                profit -= reader.GetFieldValue<decimal>(1);
                expense += reader.GetFieldValue<decimal>(1);
            }

            reader.Dispose();

            if (income == 0 && profit == 0 && expense == 0)
            {
                MessageBox.Show("No data to show in this day", "No data", MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
                return;
            }

            var model = new DailyReportModel()
            {
                date = dtpDate.Value,
                income = Math.Round(income, 2),
                expenses = Math.Round(expense, 2),
                profit = Math.Round(profit, 2)
            };

            dataGridView1.DataSource = ds.Tables["Daily Report"];
            var frm = new Daily_Report(model, ds);
            frm.Show();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var ds = new MonthlyReportDS();
            var cmd = DBConn.CreateCommand();
            var i = 1;
            decimal income = 0;
            decimal cost = 0;
            decimal rate = 0;

            cmd.CommandText = "SELECT date, name, SUM(size*qty/1000), SUM(size*qty*price/1000), SUM(size*qty*buyingPrice/1000) FROM (receipt INNER JOIN resorder ON receipt.resID = resorder.resID) INNER JOIN cashew ON resorder.cashID = cashew.cashID WHERE MONTH(date) = @month AND YEAR(date) = @year AND goodStatus = 2 GROUP BY date, name";
            cmd.Parameters.AddWithValue("@month", dtpMonth.Value.Month);
            cmd.Parameters.AddWithValue("@year", dtpMonth.Value.Year);
            var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                if (reader.GetValue(2) is DBNull)
                {
                    MessageBox.Show("No records found for this month", "No data", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    reader.Dispose();
                    return;
                }

                DataRow dr = ds.Tables["Monthly Bank Cashew"].NewRow();
                dr["Index"] = i++;
                dr["Date"] = reader.GetFieldValue<DateTime>(0).ToString("dd dddd");
                dr["Cashew"] = reader.GetFieldValue<string>(1);
                dr["QTY"] = Math.Round(reader.GetFieldValue<decimal>(2),2) + "Kg";
                dr["Income"] = "Rs. " + Math.Round(reader.GetFieldValue<decimal>(3),2);
                dr["Cost"] = "Rs. " + Math.Round(reader.GetFieldValue<decimal>(4), 2);
                dr["Profit_Rate"] = Math.Round(((reader.GetFieldValue<decimal>(3)-reader.GetFieldValue<decimal>(4))/ reader.GetFieldValue<decimal>(3))*100) + "%";
                ds.Tables["Monthly Bank Cashew"].Rows.Add(dr);

                income += reader.GetFieldValue<decimal>(3);
                cost += reader.GetFieldValue<decimal>(4);
            }

            rate = ((income - cost) / income) * 100;

            var model = new MonthlyBankCashewModel()
            {
                date = dtpDate.Value,
                income = Math.Round(income, 2),
                cost = Math.Round(cost, 2),
                profit = Math.Round(income - cost, 2),
                rate = Math.Round(rate, 2)
            };

            reader.Dispose();

            dataGridView1.DataSource = ds.Tables["Monthly Bank Cashew"];
            var frm = new Monthly_Bank_Cashew(ds, model);
            frm.Show();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var ds = new MonthlyReportDS();
            var cmd = DBConn.CreateCommand();
            var i = 1;
            decimal income = 0;
            decimal cost = 0;
            decimal rate = 0;
            decimal expenses = 0;

            cmd.CommandText = "SELECT date, place, IF(type = 2, description, name) AS name, SUM(qty), SUM(IF(type=1,qty*tripdetails.selling,0)), SUM(IF(type = 2, tripdetails.selling,qty*tripdetails.buying)), type FROM (trip INNER JOIN tripdetails ON trip.tripID = tripdetails.tripID) LEFT JOIN cashew ON tripdetails.cashID = cashew.cashID WHERE MONTH(date) = @month AND YEAR(date) = @year GROUP BY date, place, name ORDER BY type, date";
            cmd.Parameters.AddWithValue("@month", dtpMonth.Value.Month);
            cmd.Parameters.AddWithValue("@year", dtpMonth.Value.Year);
            var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                if (reader.GetValue(2) is DBNull)
                {
                    MessageBox.Show("No records found for this month", "No data", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    reader.Dispose();
                    return;
                }

                DataRow dr = ds.Tables["Monthly Trip Cashew"].NewRow();
                dr["Index"] = i++;
                dr["Date"] = reader.GetFieldValue<DateTime>(0).ToString("dd dddd");
                dr["Trip"] = reader.GetFieldValue<string>(1);
                dr["Cashew"] = reader.GetFieldValue<string>(2);
                dr["QTY"] = reader.GetFieldValue<int>(6) == 1 ? Math.Round(reader.GetFieldValue<decimal>(3), 2) + "Kg" : "-";
                dr["Income"] = reader.GetFieldValue<int>(6) == 1 ? "Rs. " + Math.Round(reader.GetFieldValue<decimal>(4), 2) : "-";
                dr["Cost"] = "Rs. " + Math.Round(reader.GetFieldValue<decimal>(5), 2);
                dr["Profit_Rate"] = reader.GetFieldValue<int>(6) == 1 ? Math.Round(((reader.GetFieldValue<decimal>(4) - reader.GetFieldValue<decimal>(5)) / reader.GetFieldValue<decimal>(4)) * 100) + "%" : "-";
                ds.Tables["Monthly Trip Cashew"].Rows.Add(dr);

                income += reader.GetFieldValue<decimal>(4);
                cost += reader.GetFieldValue<int>(6) == 1 ? reader.GetFieldValue<decimal>(5) : 0;
                expenses += reader.GetFieldValue<int>(6) == 2 ? reader.GetFieldValue<decimal>(5) : 0;
            }

            rate = ((income - (cost+expenses)) / income) * 100;

            var model = new MonthlyTripCashewModel()
            {
                date = dtpDate.Value,
                income = Math.Round(income, 2),
                cost = Math.Round(cost, 2),
                profit = Math.Round(income - (cost + expenses), 2),
                expenses = Math.Round(expenses,2),
                rate = Math.Round(rate, 2)
            };

            reader.Dispose();

            dataGridView1.DataSource = ds.Tables["Monthly Trip Cashew"];
            var frm = new Monthly_Trip_Cashew(ds, model);
            frm.Show();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            var model = new MonthlySummaryModel();
            var cmd = DBConn.CreateCommand();

            cmd.CommandText =
                "SELECT SUM(qty*size*price/1000), SUM(qty*size*buyingPrice/1000) FROM receipt INNER JOIN resorder WHERE MONTH(date) = @month AND YEAR(date) = @year";
            cmd.Parameters.AddWithValue("@month", dtpMonth.Value.Month);
            cmd.Parameters.AddWithValue("@year", dtpMonth.Value.Year);
            var reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                if (!(reader.GetValue(0) is DBNull && reader.GetValue(1) is DBNull))
                {
                    model.bIncome = reader.GetFieldValue<decimal>(0);
                    model.bCost = reader.GetFieldValue<decimal>(1);
                }
            }
            reader.Dispose();

            cmd.CommandText = "SELECT SUM(IF(type = 1, selling*qty, 0)), SUM(IF(description = 'Transport', selling, 0)), SUM(buying*qty), SUM(IF(type = 2, selling, 0)) FROM tripdetails INNER JOIN trip ON tripdetails.tripID = trip.tripID WHERE MONTH(date) = @month AND YEAR(date) = @year";
            reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                if (!(reader.GetValue(0) is DBNull && reader.GetValue(1) is DBNull && reader.GetValue(2) is DBNull))
                {
                    model.tIncome = reader.GetFieldValue<decimal>(0);
                    model.tTransport = reader.GetFieldValue<decimal>(1);
                    model.tCost = reader.GetFieldValue<decimal>(2);
                    model.totExpenses = reader.GetFieldValue<decimal>(3);
                }
            }
            reader.Dispose();

            cmd.CommandText = "SELECT SUM(amount), SUM(IF(description = 'Bank Transport', amount, 0)), SUM(IF(description = 'Buying Transport', amount, 0)) FROM expenses WHERE MONTH(date) = @month AND YEAR(date) = @year";
            reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                if (!(reader.GetValue(0) is DBNull && reader.GetValue(1) is DBNull && reader.GetValue(2) is DBNull))
                {
                    model.totExpenses += reader.GetFieldValue<decimal>(0);
                    model.bTransport = reader.GetFieldValue<decimal>(1);
                    model.BuyingTransport = reader.GetFieldValue<decimal>(2);
                }
            }
            reader.Dispose();

            model.date = dtpMonth.Value;
            model.totCost = model.bCost + model.tCost;
            model.totIncome = model.bIncome + model.tIncome;
            model.netProfit = model.totIncome - (model.totCost + model.totExpenses);

            reader.Dispose();

            var frm = new MonthlySummary(model);
            frm.Show();
        }
    }
}
