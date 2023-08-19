namespace TechShopManagement
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel3 = new System.Windows.Forms.Panel();
            this.empName = new System.Windows.Forms.Label();
            this.empId = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.employeeManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.revenueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelAdmin = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel3.Controls.Add(this.empName);
            this.panel3.Controls.Add(this.empId);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(249, 66);
            this.panel3.TabIndex = 3;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // empName
            // 
            this.empName.AutoSize = true;
            this.empName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empName.Location = new System.Drawing.Point(12, 29);
            this.empName.Name = "empName";
            this.empName.Size = new System.Drawing.Size(49, 20);
            this.empName.TabIndex = 0;
            this.empName.Text = "name";
            // 
            // empId
            // 
            this.empId.AutoSize = true;
            this.empId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empId.Location = new System.Drawing.Point(23, 9);
            this.empId.Name = "empId";
            this.empId.Size = new System.Drawing.Size(21, 20);
            this.empId.TabIndex = 0;
            this.empId.Text = "id";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeeManagementToolStripMenuItem,
            this.productManagementToolStripMenuItem,
            this.customerManagementToolStripMenuItem,
            this.revenueToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1073, 66);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // employeeManagementToolStripMenuItem
            // 
            this.employeeManagementToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeManagementToolStripMenuItem.Name = "employeeManagementToolStripMenuItem";
            this.employeeManagementToolStripMenuItem.Size = new System.Drawing.Size(186, 25);
            this.employeeManagementToolStripMenuItem.Text = "Employee Management";
            this.employeeManagementToolStripMenuItem.Click += new System.EventHandler(this.employeeManagementToolStripMenuItem_Click);
            // 
            // productManagementToolStripMenuItem
            // 
            this.productManagementToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productManagementToolStripMenuItem.Name = "productManagementToolStripMenuItem";
            this.productManagementToolStripMenuItem.Size = new System.Drawing.Size(172, 25);
            this.productManagementToolStripMenuItem.Text = "Product Management";
            this.productManagementToolStripMenuItem.Click += new System.EventHandler(this.productManagementToolStripMenuItem_Click);
            // 
            // customerManagementToolStripMenuItem
            // 
            this.customerManagementToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerManagementToolStripMenuItem.Name = "customerManagementToolStripMenuItem";
            this.customerManagementToolStripMenuItem.Size = new System.Drawing.Size(186, 25);
            this.customerManagementToolStripMenuItem.Text = "Customer Management";
            this.customerManagementToolStripMenuItem.Click += new System.EventHandler(this.customerManagementToolStripMenuItem_Click);
            // 
            // revenueToolStripMenuItem
            // 
            this.revenueToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.revenueToolStripMenuItem.Name = "revenueToolStripMenuItem";
            this.revenueToolStripMenuItem.Size = new System.Drawing.Size(107, 25);
            this.revenueToolStripMenuItem.Text = "Sold History";
            this.revenueToolStripMenuItem.Click += new System.EventHandler(this.revenueToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1322, 66);
            this.panel1.TabIndex = 3;
            // 
            // panelAdmin
            // 
            this.panelAdmin.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAdmin.Location = new System.Drawing.Point(0, 66);
            this.panelAdmin.Name = "panelAdmin";
            this.panelAdmin.Size = new System.Drawing.Size(1322, 717);
            this.panelAdmin.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.BackColor = System.Drawing.Color.Cornsilk;
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(249, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1073, 66);
            this.panel2.TabIndex = 4;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 783);
            this.Controls.Add(this.panelAdmin);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Admin";
            this.Text = "Admin";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Admin_FormClosing);
            this.Load += new System.EventHandler(this.Admin_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem employeeManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem revenueToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label empName;
        private System.Windows.Forms.Label empId;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelAdmin;
        private System.Windows.Forms.Panel panel2;
    }
}