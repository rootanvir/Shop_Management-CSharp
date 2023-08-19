using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Lifetime;
using System.Windows.Forms;

namespace TechShopManagement
{
    public partial class Seller : Form
    {
        private string id, name;
        Login log {  get; set; }    
        private string GenerateCustomer()
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

                    string prefix = parts[0]; 
                    string number = parts[1]; 

                    if (int.TryParse(number, out int n))
                    {
                        n = n + 1;
                        autoid = "c-" + n.ToString("D3");
                        return autoid;
                    }
                    else
                    {
                        MessageBox.Show("Invalid numeric part in ProductId.");
                        return ""; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }
        private string GeneratePurchasedId()
        {
            try
            {
                string autoid;
                var sql = "SELECT PurchasedId FROM SoldProductList ORDER BY PurchasedId DESC;";
                DataSet ds = this.dba.ExecuteQuery(sql);
                int count = ds.Tables[0].Rows.Count;

                if (count == 0)
                {
                    return "b-001";
                }
                else
                {
                    string prekey = ds.Tables[0].Rows[0][0].ToString();
                    string[] parts = prekey.Split('-');

                    string prefix = parts[0]; 
                    string number = parts[1]; 

                    if (int.TryParse(number, out int n))
                    {
                        n = n + 1;
                        autoid = "b-" + n.ToString("D3");
                        return autoid;
                    }
                    else
                    {
                        MessageBox.Show("Invalid numeric part in ProductId.");
                        return "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }



        private DataSet ds;
        private DataBaseAccess dba { set; get; }
        private void ShowBill()
        {
            Double total = 0;
            DataSet ds = this.dba.ExecuteQuery("select TotalPrice from ProductCartList;");
            int row = ds.Tables[0].Rows.Count;
            int l = 0;
            while (l < row)
            {
                total += Convert.ToDouble(ds.Tables[0].Rows[l][0]);
                l++;
            }
            this.txtPayTotal.Text = total.ToString();
        }
        private  void  show()
        {
            try
            {
                var sql = "select * from ProductList";
                DataSet ds = this.dba.ExecuteQuery(sql);
                this.dvgAvailableProduct.DataSource = ds.Tables[0];               

            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
            
        }
        private  void  ShowCart()
        {
            try
            {
                var sql = "select * from ProductCartList";
                this.ds = this.dba.ExecuteQuery(sql);
                this.dvgProductCartList.DataSource = ds.Tables[0];
 

            }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
            
        }
        


        private void start()
        {
            cmbCategory.SelectedIndex = 3; 
        }
        private void watch()
        {
            timer1.Start();
            this.labelTime.Text = "Time: " + DateTime.Now.ToLongTimeString();
            this.labelDate.Text = "Date: " + DateTime.Now.ToLongDateString();
        }


        public Seller(string id,string name, Login log)
        {
            InitializeComponent();
            this.dba = new DataBaseAccess();
            show();
            ShowCart();
            start();
            watch();
            this.txtCustomerId.Text = this.GenerateCustomer();
            this.txtPurchasedId.Text = this.GeneratePurchasedId();
            this.id = id;
            this.name = name;
            this.empId.Text = "Employee Id : " + id;
            this.empName.Text = "Employee Name : " + name;
            this.log = log;
        }




        /*        private void button3_Click_1(object sender, EventArgs e)
                {


                }*/



        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            var sql = @"select * from ProductList where ProductName like '%"+this.txtSearchProduct.Text+"%';";
            DataSet ds = this.dba.ExecuteQuery(sql);
            this.dvgAvailableProduct.DataSource = ds.Tables[0];
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            this.dvgAvailableProduct.ClearSelection();
        }



        private void timer1_Tick_1(object sender, EventArgs e)
        {
            this.labelTime.Text = "Time: " + DateTime.Now.ToLongTimeString();
            this.labelDate.Text = "Date:  " + DateTime.Now.ToLongDateString();
            timer1.Start();
        }

/*        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }*/

        private void dgvAvailableProduct_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtProductId.Text = this.dvgAvailableProduct.CurrentRow.Cells["ProductId"].Value.ToString();
                this.txtBrandName.Text = this.dvgAvailableProduct.CurrentRow.Cells["BrandName"].Value.ToString();
                this.txtProductCategory.Text = this.dvgAvailableProduct.CurrentRow.Cells["ProductCategory"].Value.ToString();
                this.txtProductName.Text = this.dvgAvailableProduct.CurrentRow.Cells["ProductName"].Value.ToString();
                this.txtWarranty.Text = this.dvgAvailableProduct.CurrentRow.Cells["Warranty"].Value.ToString();
                this.txtProductPrice.Text = this.dvgAvailableProduct.CurrentRow.Cells["Price"].Value.ToString();
                this.txtProductQuantity.Text ="1";
                this.txtDescription.Text = this.dvgAvailableProduct.CurrentRow.Cells["Description"].Value.ToString();
            }
            catch(Exception ex) { MessageBox.Show("error: " + ex.Message); }
            

        }

        private void btnProductClear_Click(object sender, EventArgs e)
        {
            this.txtProductId.Text = "";
            this.txtBrandName.Text = "";
            this.txtProductCategory.Text = "";
            this.txtProductName.Text = " ";
            this.txtWarranty.Text = "";
            this.txtProductPrice.Text = "";
            this.txtProductQuantity.Text = "";
            this.txtDescription.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.txtCustomerId.Text = "";
            this.txtCustomerName.Text = "";
            this.txtCustomerPhoneNumber.Text = "";
            this.txtCustomerAddress.Text = "";
            this.txtCustomerId.Text = this.GenerateCustomer();

        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {


            try
            {
                var sql = "select * from ProductCartList";
                DataSet ds = this.dba.ExecuteQuery(sql);

                string id = this.dvgAvailableProduct.CurrentRow.Cells["ProductId"].Value.ToString();

                var sqlCart = "select * from ProductCartList where ProductId='" + id + "'";
                DataSet dsCart = this.dba.ExecuteQuery(sqlCart);
                int row = dsCart.Tables[0].Rows.Count;

                string quantity = this.dvgAvailableProduct.CurrentRow.Cells["Quantity"].Value.ToString();
                int quan = Convert.ToInt32(quantity);
                if (quan < Convert.ToInt32(this.txtProductQuantity.Text)) { MessageBox.Show("Not Enough Product "); return; }
                if (quan > 0) { this.dba.ExecuteDMLQuery("UPDATE ProductList SET Quantity = " + ((quan) - Convert.ToInt32(this.txtProductQuantity.Text)) + " WHERE ProductId='" + id + "';"); }
                else { MessageBox.Show("No product avaible for current selection"); return; }

                if (row == 1)
                {
                    double dtp = (Convert.ToDouble(this.txtProductPrice.Text)) * (Convert.ToDouble(this.txtProductQuantity.Text));
                    DataSet preQ = this.dba.ExecuteQuery("select Quantity from ProductCartList where ProductId='" + id + "'");
                    DataSet preT = this.dba.ExecuteQuery("select TotalPrice from ProductCartList where ProductId='" + id + "'");
                    string str = preQ.Tables[0].Rows[0][0].ToString();
                    string pretotal = preT.Tables[0].Rows[0][0].ToString();
                    double TotalPrice = Convert.ToDouble(pretotal);

                    int q = Convert.ToInt32(str) + Convert.ToInt32(this.txtProductQuantity.Text);
                    sql = "UPDATE ProductCartList SET Quantity =" + q + ",TotalPrice = " + (TotalPrice + dtp) + "  WHERE ProductId = '" + id + "'; ";
                    this.dba.ExecuteDMLQuery(sql);

                }
                else
                {

                    double d = (Convert.ToDouble(this.txtProductPrice.Text)) * (Convert.ToDouble(this.txtProductQuantity.Text));
                    sql = "insert into ProductCartList values('" + this.txtProductId.Text + "','" + this.txtProductName.Text + "'," + this.txtProductPrice.Text + "," + this.txtProductQuantity.Text + "," + d + ");";

                    this.dba.ExecuteDMLQuery(sql);


                }
            }
            catch (Exception ex) { MessageBox.Show("First Select a Product " + ex.Message); }
            this.ShowCart();
            this.show();
            this.ShowBill();


        }

        private void btnShowCartProduct_Click(object sender, EventArgs e)
        {
            this.ShowCart();
        }

        private void btnDeleteCart_Click(object sender, EventArgs e)
        {
            this.dba.ExecuteQuery("delete from ProductCartList;");
            this.ShowCart();
        }



        private void ckQuantity_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.ckQuantity.Checked) { this.txtProductQuantity.Enabled = true; }
            else { this.txtProductQuantity.Enabled = false; }
        }





        private void dvgProductCartList_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.ds.Tables[0].Rows.Count > 0)
                {

                }
                else
                {
                    MessageBox.Show("No data available in ProductCartList.");
                }
            }
            catch (Exception ex)
            {
                // Log the error or handle it appropriately
                MessageBox.Show("Error: " + ex.Message);
            }
        }





        private void Seller_Load(object sender, EventArgs e)
        {
            this.dvgProductCartList.ClearSelection();
            this.dvgAvailableProduct.ClearSelection();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ShowBill();
            
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dvgProductCartList.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a Row first to delete the data", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string id = this.dvgProductCartList.CurrentRow.Cells[0].Value.ToString();
                string quan = this.dvgProductCartList.CurrentRow.Cells[3].Value.ToString();
                string pquan = this.dvgAvailableProduct.CurrentRow.Cells[6].Value.ToString();
                
                int newquantity = (Convert.ToInt32(quan))+ (Convert.ToInt32(pquan));
                MessageBox.Show("" + newquantity);
                if (id.Length==0)
                {
                    MessageBox.Show("No data Found");
                }
                else
                {
                    int aff = this.dba.ExecuteDMLQuery("delete from ProductCartList where ProductId = '" + id + "';");                    
                    int aff2 = this.dba.ExecuteDMLQuery("UPDATE ProductList SET Quantity=" + newquantity + " WHERE ProductId='" + id + "';");
                    
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nothing to Delete (" + ex.Message + ")");
            }
            this.ShowCart();
            this.show();
            
        }

        private void btnPaid_Click(object sender, EventArgs e)
        {
            if(this.txtCustomerId.Text==""|| this.txtCustomerName.Text == ""|| this.txtCustomerPhoneNumber.Text == ""|| this.txtCustomerAddress.Text == "")
            {
                MessageBox.Show("Fill the customer info");return;
            }
            if(rbcash.Checked||rbCredit.Checked) 
            {
                try
                {
                    var sql2 = @"select CustomerId from CustomerList where CustomerPhoneNumber='" + this.txtCustomerPhoneNumber.Text + "';";
                    DataSet ds = this.dba.ExecuteQuery(sql2);
                    if (ds.Tables[0].Rows.Count != 1)
                    {
                        var sql = "insert into CustomerList (CustomerId,CustomerName,CustomerAddress,CustomerPhoneNumber) values('" + this.txtCustomerId.Text + "','" + this.txtCustomerName.Text + "','" + this.txtCustomerAddress.Text + "','" + this.txtCustomerPhoneNumber.Text + "');";
                        var count = this.dba.ExecuteDMLQuery(sql);
                        if (count > 0) { MessageBox.Show("Customer data inserted"); }
                    }
                    MessageBox.Show("Paid successfully");
                }catch(Exception ex) { MessageBox.Show(ex.Message);}
                try
                {
                    var sql3 = "insert into SoldProductList values('" + this.txtPurchasedId.Text + "'," + Convert.ToInt32(this.txtPayTotal.Text) + ",'" + this.txtCustomerId.Text + "','" + this.ddpPurchasedDate.Text + "');";
                    var count3 = this.dba.ExecuteDMLQuery(sql3);
                    if (count3 == 1) { MessageBox.Show("Insert to SoldList");
                        this.dba.ExecuteQuery("delete from ProductCartList;");
                        this.ShowCart();
                    }

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

            }
            else
            {
                MessageBox.Show("Select a payment Method"); return;
            }

            

            

        }

        private void Seller_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to Log out?", "Confirm", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                this.Dispose();
                this.log.Show();

            }
            else
            {
                e.Cancel = true;
            }

        }

        private void txtCustomerPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            var sql = @"select * from CustomerList where CustomerPhoneNumber='" + this.txtCustomerPhoneNumber.Text + "';";
            DataSet ds = this.dba.ExecuteQuery(sql);
            if (ds.Tables[0].Rows.Count==1)
            {
                this.txtCustomerId.Text = ds.Tables[0].Rows[0]["CustomerId"].ToString();
                this.txtCustomerName.Text= ds.Tables[0].Rows[0]["CustomerName"].ToString();
                this.txtCustomerPhoneNumber.Text= ds.Tables[0].Rows[0]["CustomerPhoneNumber"].ToString();
                this.txtCustomerAddress.Text= ds.Tables[0].Rows[0]["CustomerAddress"].ToString();
            }
        }
    }
}

