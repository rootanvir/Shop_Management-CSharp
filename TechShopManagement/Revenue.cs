using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechShopManagement
{
    public partial class Revenue : UserControl
    {
        private DataBaseAccess dba { get; set; }
        private void ShowRevenue()
        {
            try
            {
                var sql = "select * from SoldProductList";
                DataSet ds = this.dba.ExecuteQuery(sql);
                this.dgvRevenue.DataSource = ds.Tables[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }
        private void showIncomeDay()
        {
            try
            {
                var sql = "select Totalprice from SoldProductList where PurchasedDate='" + DateTime.Now.ToShortDateString() + "';";
                DataSet ds = this.dba.ExecuteQuery(sql);
                int count = ds.Tables[0].Rows.Count;

                int k = 0;
                double total = 0;
                while (k < count)
                {
                    total = total + Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
                    k++;
                }
                this.txtTotalDay.Text = total.ToString();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void showIncomeMonth()
        {
            try
            {
                DateTime now = DateTime.Now;
                DateTime firstDayOfMonth = new DateTime(now.Year, now.Month, 1);

                var sql = "SELECT SUM(Totalprice) AS TotalIncome FROM SoldProductList WHERE PurchasedDate >= '" + firstDayOfMonth.ToShortDateString() + "'";

                DataSet ds = this.dba.ExecuteQuery(sql);
                double total = 0;

                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["TotalIncome"] != DBNull.Value)
                {
                    total = Convert.ToDouble(ds.Tables[0].Rows[0]["TotalIncome"]);
                }

                this.txtMonth.Text = total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void showIncomeYear()
        {
            try
            {
                DateTime now = DateTime.Now;
                DateTime firstDayOfMonth = new DateTime(now.Year, now.Month, 1);

                var sqlMonthly = "SELECT SUM(Totalprice) AS TotalIncome FROM SoldProductList WHERE PurchasedDate >= '" + firstDayOfMonth.ToShortDateString() + "'";

                DataSet dsMonthly = this.dba.ExecuteQuery(sqlMonthly);
                double totalMonthly = 0;

                if (dsMonthly.Tables[0].Rows.Count > 0 && dsMonthly.Tables[0].Rows[0]["TotalIncome"] != DBNull.Value)
                {
                    totalMonthly = Convert.ToDouble(dsMonthly.Tables[0].Rows[0]["TotalIncome"]);
                }

                this.txtYear.Text = totalMonthly.ToString();

                DateTime firstDayOfYear = new DateTime(now.Year, 1, 1);

                var sqlYearly = "SELECT SUM(Totalprice) AS TotalIncome FROM SoldProductList WHERE PurchasedDate >= '" + firstDayOfYear.ToShortDateString() + "'";

                DataSet dsYearly = this.dba.ExecuteQuery(sqlYearly);
                double totalYearly = 0;

                if (dsYearly.Tables[0].Rows.Count > 0 && dsYearly.Tables[0].Rows[0]["TotalIncome"] != DBNull.Value)
                {
                    totalYearly = Convert.ToDouble(dsYearly.Tables[0].Rows[0]["TotalIncome"]);
                }

                this.txtYear.Text = totalYearly.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public Revenue()
        {
            InitializeComponent();
            this.dba= new DataBaseAccess();
            ShowRevenue();
            showIncomeDay();
            showIncomeMonth();
            showIncomeYear();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTotalDay_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
