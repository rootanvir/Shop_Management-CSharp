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
    public partial class ControlAdminCustomer : UserControl
    {
        private string GenerateAdminCustomer()
        {
            try
            {
                string autoid;
                var sql = "SELECT CustomerId FROM CustomerList ORDER BY CustomerId DESC;";
                DataSet ds = this.dba.ExecuteQuery(sql);
                int count = ds.Tables[0].Rows.Count;

                if (count == 0)
                {
                    return "c-001";
                }
                else
                {
                    string prekey = ds.Tables[0].Rows[0][0].ToString();
                    string[] parts = prekey.Split('-');

                    string prefix = parts[0]; // "p"
                    string number = parts[1]; // "001"

                    if (int.TryParse(number, out int n))
                    {
                        n = n + 1;
                        autoid = "c-" + n.ToString("D3");
                        return autoid;
                    }
                    else
                    {
                        MessageBox.Show("Invalid numeric part in ProductId.");
                        return ""; // Return some default value or handle the error accordingly
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return ""; // Return some default value or handle the error accordingly
            }
        }
        private DataBaseAccess dba { get; set; }
        private new void Show()
        {
            try
            {
                var sql = "select * from CustomerList";
                DataSet ds = this.dba.ExecuteQuery(sql);
                this.dgvAdminCustomer.DataSource = ds.Tables[0];
                this.dgvAdminCustomer.ClearSelection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }
    
        public ControlAdminCustomer()
        {
            InitializeComponent();
            this.cbmSearchCustomerBy.SelectedIndex = 1;
            this.dba = new DataBaseAccess();
            this.txtCustomerId.Text = GenerateAdminCustomer();
        }

        private void ControlAdminCustomer_Load(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (!this.IsValidToSave())
                {
                    MessageBox.Show("no data this row");
                    return;
                }
                var quer = "select * from CustomerList where CustomerId ='" + this.txtCustomerId.Text + "';";
                var dt = this.dba.ExecuteQueryTable(quer);
                if (dt.Rows.Count == 1)
                {
                    var sql = @"update CustomerList set
	                        CustomerName='" + this.txtCustomerName.Text + @"',
	                        CustomerAddress='" + this.txtCustomerAddress.Text + @"',
	                        CustomerPhoneNumber='" + this.txtPhoneNumber.Text + @"',
	                        CustomerTotalExpense='" + this.txtTotalExpense.Text + @"'
                            where CustomerId ='" + this.txtCustomerId.Text + "';";
                    var count = this.dba.ExecuteDMLQuery(sql);
                    if (count == 1)
                    {
                        MessageBox.Show("Updated Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Updated Unsuccessfull");
                    }
                    this.Show();
                }
                else
                {
                    //insert
                    var sql = "insert into CustomerList values('" + this.txtCustomerId.Text + "','" + this.txtCustomerName.Text + "','" + this.txtCustomerAddress.Text + "','" + this.txtPhoneNumber.Text + "','" + Convert.ToDouble(this.txtTotalExpense.Text) + "');";
                    var count = this.dba.ExecuteDMLQuery(sql);
                    if (count == 1)
                    {
                        MessageBox.Show("Inserted Properly");
                    }
                    else
                    {
                        MessageBox.Show("Inserted Failed");
                    }
                }
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private bool IsValidToSave()
        {
            if (String.IsNullOrEmpty(this.txtCustomerId.Text) || String.IsNullOrEmpty(this.txtPhoneNumber.Text) ||
               String.IsNullOrEmpty(this.txtCustomerName.Text) || String.IsNullOrEmpty(this.txtCustomerAddress.Text) ||
               String.IsNullOrEmpty(this.txtTotalExpense.Text))
            {
                return false;
            }
            else
                return true;
        }


        private void dgvAdminCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtCustomerId.Text = this.dgvAdminCustomer.CurrentRow.Cells["CustomerId"].Value.ToString();
                this.txtCustomerName.Text = this.dgvAdminCustomer.CurrentRow.Cells["CustomerName"].Value.ToString();
                this.txtCustomerAddress.Text = this.dgvAdminCustomer.CurrentRow.Cells["Address"].Value.ToString();
                this.txtPhoneNumber.Text = this.dgvAdminCustomer.CurrentRow.Cells["PhoneNumber"].Value.ToString();
                this.txtTotalExpense.Text = this.dgvAdminCustomer.CurrentRow.Cells["TotalExpense"].Value.ToString();
            }
            catch (Exception ex) { MessageBox.Show("error: " + ex.Message); }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtCustomerId.Text = "";
            this.txtCustomerName.Text = "";
            this.txtCustomerAddress.Text = "";
            this.txtPhoneNumber.Text = "";
            this.txtTotalExpense.Text = "";
            this.txtCustomerId.Text=this.GenerateAdminCustomer();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvAdminCustomer.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a Row first to delete the data", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string id = this.dgvAdminCustomer.CurrentRow.Cells["CustomerId"].Value.ToString();

                if (id.Length != 0)
                {
                    this.dba.ExecuteQuery("DELETE FROM CustomerList WHERE CustomerId='" + id + "';");
                    MessageBox.Show("Deleted");
                }
                else
                {
                    MessageBox.Show("First Select a row");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Show();
        }

        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            var sql = @"select * from CustomerList where CustomerPhoneNumber like '%" + this.txtSearchCustomer.Text + "%';";
            DataSet ds = this.dba.ExecuteQuery(sql);
            this.dgvAdminCustomer.DataSource = ds.Tables[0];
        }

        private void dgvAdminCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtCustomerId.Text = this.dgvAdminCustomer.CurrentRow.Cells["CustomerId"].Value.ToString();
                this.txtCustomerName.Text = this.dgvAdminCustomer.CurrentRow.Cells["CustomerName"].Value.ToString();
                this.txtCustomerAddress.Text = this.dgvAdminCustomer.CurrentRow.Cells["Address"].Value.ToString();
                this.txtPhoneNumber.Text = this.dgvAdminCustomer.CurrentRow.Cells["PhoneNumber"].Value.ToString();
                this.txtTotalExpense.Text = this.dgvAdminCustomer.CurrentRow.Cells["TotalExpense"].Value.ToString();
            }
            catch (Exception ex) { MessageBox.Show("error: " + ex.Message); }
        }
    }
}
