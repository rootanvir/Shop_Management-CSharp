using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechShopManagement
{
    
    public partial class ProductManager : Form
    {
        private string id, name;
        Login log { get; set; }
        private DataBaseAccess dba { set; get; }
        private string Generate()
        {
            try
            {
                string autoid;
                var sql = "SELECT ProductId FROM ProductList ORDER BY ProductId DESC;";
                DataSet ds = this.dba.ExecuteQuery(sql);
                int count = ds.Tables[0].Rows.Count;

                if (count == 0)
                {
                    return "p-001";
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
                        autoid = "p-" + n.ToString("D3");
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
        private void ClearField()
        {
            this.txtProductId.Text = "";
            this.txtBrandName.Text = "";
            this.txtProductCategory.Text = "";
            this.txtProductName.Text = "";
            this.txtWarranty.Text = "";
            this.txtPrice.Text = "";
            this.txtQuantity.Text = "";
            this.txtDescription.Text = "";
            this.txtProductId.Text=this.Generate();
        }

        private void setDefault()
        {
            this.cmbCategory.SelectedIndex= 3;
            
        }
        private  void print()
        {
            try
            {
                var sql = "select * from ProductList";
                DataSet ds = this.dba.ExecuteQuery(sql);
                this.dgvAddingProduct.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("The error Exception is: " + ex.Message);
            }
            this.dgvAddingProduct.ClearSelection();
        }

        public ProductManager(string id,string name, Login log)
        {
            InitializeComponent();
            setDefault();
            watch2();
            dba = new DataBaseAccess();
            print();
            this.txtProductId.Text = this.Generate();
            this.id = id;
            this.name = name;
            this.empId.Text = "Employee Id : " + id;
            this.empName.Text = "Employee Name : " + name;
            this.log = log;
        }
        private void watch2()
        {
            timer2.Start();
            this.labelTime.Text = "Time: " + DateTime.Now.ToLongTimeString();
            this.labelDate.Text = "Date: " + DateTime.Now.ToLongDateString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.labelTime.Text = "Time: " + DateTime.Now.ToLongTimeString();
            this.labelDate.Text = "Date:  " + DateTime.Now.ToLongDateString();
            timer2.Start();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            try
            {
                var quer = "select * from ProductList where ProductId ='"+this.txtProductId.Text + "';";
                var dt = this.dba.ExecuteQueryTable(quer);
                if (dt.Rows.Count == 1)
                {
                    var sql = @"update ProductList set
	                        BrandName='" + this.txtBrandName.Text + @"',
	                        ProductCategory='" + this.txtProductCategory.Text + @"',
	                        ProductName='" + this.txtProductName.Text + @"',
	                        Warranty='" + this.txtWarranty.Text + @"',
	                        Price='" + this.txtPrice.Text + @"',
	                        Quantity='" + this.txtQuantity.Text + @"',
	                        Description='" + this.txtDescription.Text + @"'
                            where ProductId ='" + this.txtProductId.Text + "';";
                    var count = this.dba.ExecuteDMLQuery(sql);
                    if (count == 1)
                    {
                        MessageBox.Show("Updated Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Updated Unsuccessfull");
                    }
                    this.print();
                }
                else
                {
                    //insert
                    var sql = "insert into ProductList values('" + this.txtProductId.Text + "','" + this.txtBrandName.Text + "','" + this.txtProductCategory.Text + "','" + this.txtProductName.Text + "'," + Convert.ToInt32(this.txtWarranty.Text) + "," + Convert.ToDouble(this.txtPrice.Text) + "," + Convert.ToInt32(this.txtQuantity.Text)+ ",'" + this.txtDescription.Text + "');";
                    var count = this.dba.ExecuteDMLQuery(sql);

                    if (count == 1)
                        MessageBox.Show("Data saved properly.");
                    else
                        MessageBox.Show("Failure While saving the data");

                }
                this.print();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Fill All the text box properly  " + exc.Message);
            }
            Generate();
            ClearField();
        }



        private void dgvAddingProduct_Click(object sender, EventArgs e)
        {
            
            try
            {
                //this.txtProductId.Text = this.dgvAddingProduct.CurrentRow.Cells["ProductId"].Value.ToString();
                this.txtBrandName.Text = this.dgvAddingProduct.CurrentRow.Cells["BrandName"].Value.ToString();
                this.txtProductCategory.Text = this.dgvAddingProduct.CurrentRow.Cells["ProductCategory"].Value.ToString();
                this.txtProductName.Text = this.dgvAddingProduct.CurrentRow.Cells["ProductName"].Value.ToString();
                this.txtWarranty.Text = this.dgvAddingProduct.CurrentRow.Cells["Warranty"].Value.ToString();
                this.txtPrice.Text = this.dgvAddingProduct.CurrentRow.Cells["Price"].Value.ToString();
                this.txtQuantity.Text = this.dgvAddingProduct.CurrentRow.Cells["Quantity"].Value.ToString(); ;
                this.txtDescription.Text = this.dgvAddingProduct.CurrentRow.Cells["Description"].Value.ToString();

            }
            catch (Exception ex) { MessageBox.Show("error: " + ex.Message); }


           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string id = this.dgvAddingProduct.CurrentRow.Cells["ProductId"].Value.ToString();
                
                if (id.Length != 0)
                {
                    this.dba.ExecuteQuery("DELETE FROM ProductList WHERE ProductId='" + id + "';");
                    MessageBox.Show("Deleted");
                }
                else
                {
                    MessageBox.Show("First Select a row");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            print();

        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            var sql = @"select * from ProductList where ProductName like '%" + this.txtSearchProduct.Text + "%';";
            DataSet ds = this.dba.ExecuteQuery(sql);
            this.dgvAddingProduct.DataSource = ds.Tables[0];
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            this.dgvAddingProduct.ClearSelection();
        }

        private void ProductManager_Load(object sender, EventArgs e)
        {

        }

        private void ProductManager_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtProductId.Text = "";
            this.txtBrandName.Text = "";
            this.txtProductCategory.Text = "";
            this.txtProductName.Text = "";
            this.txtWarranty.Text = "";
            this.txtPrice.Text = "";
            this.txtQuantity.Text = "";
            this.txtDescription.Text = "";
            this.txtProductId.Text = this.Generate();
        }
    }
}
