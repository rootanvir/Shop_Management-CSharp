using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TechShopManagement
{
    public partial class ControlAdminEmployee : UserControl
    {
        private string GenerateEmployee()
        {
            try
            {
                string autoid;
                var sql = "SELECT EmployeeId FROM EmployeeList ORDER BY EmployeeId DESC;";
                DataSet ds = this.dba.ExecuteQuery(sql);
                int count = ds.Tables[0].Rows.Count;

                if (count == 0)
                {
                    return "e-001";
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
                        autoid = "e-" + n.ToString("D3");
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
            this.txtPassword.Text = "";
            this.txtEmployeelName.Text = "";
            this.cmbEmployeeRole.Text = "";
            this.txtJobExperience.Text = "";
            this.ddpJoiningDate.Text = "";
            this.ddpDateOfBirth.Text = "";
            this.cmbEmployeeBloodGroup.Text = "";
            this.txtEmployeePhoneNumber.Text = "";
            this.txtEmployeeSalary.Text = "";
            this.txtEmployeeAddress.Text = "";

            rbFemale.Checked = false;
            rbMale.Checked = false;
            this.GenerateEmployee();
        }
        private DataBaseAccess dba { get; set; }
        private string gender;
        private  void show()
        {
            try
            {
                var sql = "select * from EmployeeList";
                DataSet ds = this.dba.ExecuteQuery(sql);
                this.dgvAdminEmployee.DataSource = ds.Tables[0];
                this.dgvAdminEmployee.ClearSelection();

            }
            catch(Exception ex)
            {
                MessageBox.Show("error " + ex.Message);
            }
        }
        public ControlAdminEmployee()
        {
            InitializeComponent();
            this.dba=new DataBaseAccess();
            this.cmbSearch.SelectedIndex = 1;
            this.txtEmployeeId.Text = GenerateEmployee();
        }


        private void ControlAdminEmployee_Load(object sender, EventArgs e)
        {
            show();
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
                var quer = "select * from EmployeeList where EmployeeId='" + this.txtEmployeeId.Text + "';";

                var dt = this.dba.ExecuteQueryTable(quer);
                //MessageBox.Show("Run" + this.ddpDateOfBirth.Text);
                
                if (dt.Rows.Count == 1)
                {
                    var sql = @"update EmployeeList set
                                        EmployeeId='" + this.txtEmployeeId.Text + @"',
                                        EmployeePassword='" + this.txtPassword.Text + @"',
                                        EmployeeName='" + this.txtEmployeelName.Text + @"',
                                        EmployeeRole='" + this.cmbEmployeeRole.Text + @"',
                                        JobExperience='" + this.txtJobExperience.Text + @"',
                                        JoiningDate='" + this.ddpJoiningDate.Text + @"',
                                        EmployeeDOB='" + this.ddpDateOfBirth.Text + @"',
                                        EmployeeGender='" + this.gender + @"',
                                        EmployeeBloodGroup='" + this.cmbEmployeeBloodGroup.Text + @"',
                                        EmployeePhoneNumber='" + this.txtEmployeePhoneNumber.Text + @"',
                                        EmployeeSalary='" + this.txtEmployeeSalary.Text + @"',
                                        EmployeeAddress='" + this.txtEmployeeAddress.Text + @"'	                      
                                        where EmployeeId ='" + this.txtEmployeeId.Text + "';";
                    var count = this.dba.ExecuteDMLQuery(sql);
                    if (count == 1)
                    {
                        MessageBox.Show("Updated Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Updated Unsuccessfull");
                    }
                    this.show();
                }
                else
                {
                    //insert
                    var sql = "insert into EmployeeList values('" + this.txtEmployeeId.Text + "','" + this.txtPassword.Text + "','" + this.txtEmployeelName.Text + "','" + this.cmbEmployeeRole.Text + "'," + this.txtJobExperience.Text + ",'" + this.ddpJoiningDate.Text + "','" + this.ddpDateOfBirth.Text+ "','" + this.gender + "','" + this.cmbEmployeeBloodGroup.Text + "','" + this.txtEmployeePhoneNumber.Text + "'," + Convert.ToDouble(this.txtEmployeeSalary.Text) + ",'" + this.txtEmployeeAddress.Text + "');";
                    var count = this.dba.ExecuteDMLQuery(sql);

                    if (count == 1)
                        MessageBox.Show("Data saved properly.");
                    else
                        MessageBox.Show("Failure While saving the data");

                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message + exc.StackTrace);
            }
            this.show();
            GenerateEmployee();
            ClearField();


        }

        private bool IsValidToSave()
        {
            if (String.IsNullOrEmpty(this.txtEmployeeId.Text) || String.IsNullOrEmpty(this.txtPassword.Text) ||
               String.IsNullOrEmpty(this.txtEmployeelName.Text) || String.IsNullOrEmpty(this.cmbEmployeeRole.Text) ||
               String.IsNullOrEmpty(this.txtJobExperience.Text) ||
               String.IsNullOrEmpty(this.ddpJoiningDate.Text) ||
               String.IsNullOrEmpty(this.ddpDateOfBirth.Text) ||
               String.IsNullOrEmpty(this.gender) ||
               String.IsNullOrEmpty(this.cmbEmployeeBloodGroup.Text) ||
               String.IsNullOrEmpty(this.txtEmployeePhoneNumber.Text) ||
               String.IsNullOrEmpty(this.txtEmployeeSalary.Text) ||
               String.IsNullOrEmpty(this.txtEmployeeAddress.Text))
            {
                return false;
            }
            else
                return true;
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            this.gender = "Male";
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            this.gender = "Female";
        }

        private void dgvAdminEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtEmployeeId.Text = this.dgvAdminEmployee.CurrentRow.Cells["EmployeeId"].Value.ToString();
                this.txtPassword.Text = this.dgvAdminEmployee.CurrentRow.Cells["EmployeePassword"].Value.ToString();
                this.txtEmployeelName.Text = this.dgvAdminEmployee.CurrentRow.Cells["EmployeeName"].Value.ToString();
                this.cmbEmployeeRole.Text = this.dgvAdminEmployee.CurrentRow.Cells["EmployeeRole"].Value.ToString();
                this.txtJobExperience.Text = this.dgvAdminEmployee.CurrentRow.Cells["JobExperience"].Value.ToString();
                this.ddpJoiningDate.Text = this.dgvAdminEmployee.CurrentRow.Cells["JoiningDate"].Value.ToString();
                string gender=this.dgvAdminEmployee.CurrentRow.Cells["EmployeeGender"].Value.ToString(); ;
                if(gender=="Male") { rbMale.Checked = true;  } 
                else if(gender=="Female") { rbFemale.Checked = true; ; }

                this.ddpDateOfBirth.Text = this.dgvAdminEmployee.CurrentRow.Cells["EmployeeDOB"].Value.ToString();
                this.cmbEmployeeBloodGroup.Text = this.dgvAdminEmployee.CurrentRow.Cells["EmployeeBloodGroup"].Value.ToString();
                this.txtEmployeePhoneNumber.Text = this.dgvAdminEmployee.CurrentRow.Cells["EmployeePhoneNumber"].Value.ToString();
                this.txtEmployeeSalary.Text = this.dgvAdminEmployee.CurrentRow.Cells["EmployeeSalary"].Value.ToString();
                this.txtEmployeeAddress.Text = this.dgvAdminEmployee.CurrentRow.Cells["EmployeeAddress"].Value.ToString();


            }
            catch (Exception ex) { MessageBox.Show("error: " + ex.Message); }
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            this.txtEmployeeId.Text = "";
            this.txtPassword.Text = "";
            this.txtEmployeelName.Text = "";
            this.cmbEmployeeRole.Text = "";
            this.txtJobExperience.Text = "";
            this.ddpJoiningDate.Text = "";
            this.ddpDateOfBirth.Text = "";
            this.cmbEmployeeBloodGroup.Text = "";
            this.txtEmployeePhoneNumber.Text = "";
            this.txtEmployeeSalary.Text = "";
            this.txtEmployeeAddress.Text = "";

            rbFemale.Checked = false;
            rbMale.Checked = false;
            this.txtEmployeeId.Text=this.GenerateEmployee();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvAdminEmployee.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a Row first to delete the data", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string id = this.dgvAdminEmployee.CurrentRow.Cells["EmployeeId"].Value.ToString();

                if (id.Length != 0)
                {
                    this.dba.ExecuteQuery("DELETE FROM EmployeeList WHERE EmployeeId='" + id + "';");
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
            show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            var sql = @"select * from EmployeeList where EmployeeName like '%" + this.txtSearchEmployee.Text + "%';";
            DataSet ds = this.dba.ExecuteQuery(sql);
            this.dgvAdminEmployee.DataSource = ds.Tables[0];
        }
    }
}
