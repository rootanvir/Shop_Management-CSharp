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
        public Revenue()
        {
            InitializeComponent();
            this.dba= new DataBaseAccess();
            ShowRevenue();
            showIncomeDay();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
