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
    
    public partial class Admin : Form
    {
        private string id, name;
        Login log { get; set; }
        private DataBaseAccess DBA { get; set; }
        public Admin(string id,string name,Login preObj)
        {

            InitializeComponent();
            this.id = id;
            this.name = name;
            this.empId.Text = "Employee Id : " + id;
            this.empName.Text = "Employee Name : " + name;
            this.log= preObj;
        }

        private void employeeManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlAdminEmployee emp=new ControlAdminEmployee();
            panelAdmin.Controls.Add(emp);
            emp.Dock = DockStyle.Fill;
            emp.BringToFront();
            emp.Show();
            
           

        }

        private void productManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlAdminProduct productManager = new ControlAdminProduct();
            panelAdmin.Controls.Add(productManager);
            productManager.Dock = DockStyle.Fill;
            productManager.BringToFront();
            productManager.Show();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            ControlAdminEmployee emp = new ControlAdminEmployee();
            panelAdmin.Controls.Add(emp);
            emp.Dock = DockStyle.Fill;
            emp.BringToFront();
            emp.Show();
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
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

        private void revenueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Revenue rev = new Revenue();
            panelAdmin.Controls.Add(rev);
            rev.Dock = DockStyle.Fill;
            rev.BringToFront();
            rev.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void customerManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ControlAdminCustomer customer = new ControlAdminCustomer();
            panelAdmin.Controls.Add(customer);
            customer.Dock = DockStyle.Fill;
            customer.BringToFront();
            customer.Show();
        }

        public static implicit operator Admin(Login v)
        {
            throw new NotImplementedException();
        }
    }
}
