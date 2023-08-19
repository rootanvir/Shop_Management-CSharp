using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopManagement
{
    internal class DataBaseAccess
    {

        private SqlConnection sqlcon;
        public SqlConnection Sqlcon
        {
            get { return this.sqlcon; }
            set { this.sqlcon = value; }
        }
        private SqlCommand sqlcmd;
        public SqlCommand Sqlcmd
        {
            get { return this.sqlcmd; }
            set { this.sqlcmd = value; }
        }
        private SqlDataAdapter sda;
        public SqlDataAdapter Sda
        { 
            get { return this.sda; }
            set { this.sda = value; }
        }
        public DataSet ds;
        public DataSet Ds
        { 
            get { return this.ds; }
            set { this.ds = value; }
        }
        public DataBaseAccess() 
        {
            this.Sqlcon =new SqlConnection(@"Data Source=DESKTOP-2O79K10;Initial Catalog=TechShopManagement;Persist Security Info=True;User ID=sa;Password=p@$$w0rd");
            Sqlcon.Open();
        }
        private void QueryText(string query)
        {
            this.Sqlcmd= new SqlCommand(query, this.Sqlcon);
        }
        public DataSet ExecuteQuery(string sql)
        {
            this.Sqlcmd=new SqlCommand(sql, this.Sqlcon);
            this.sda = new SqlDataAdapter(this.Sqlcmd);
            this.Ds = new DataSet();
            this.sda.Fill(this.Ds);
            return Ds;
        }
        public DataTable ExecuteQueryTable(string sql)
        {
            this.Sqlcmd = new SqlCommand(sql, this.Sqlcon);//this.QueryText(sql);
            this.Sda = new SqlDataAdapter(this.Sqlcmd);
            this.Ds = new DataSet();
            this.Sda.Fill(this.Ds);
            return Ds.Tables[0];
        }
        public int ExecuteDMLQuery(string sql)
        {
            this.Sqlcmd = new SqlCommand(sql, this.Sqlcon);
            int u=this.Sqlcmd.ExecuteNonQuery();
            return u;
        }




    }
}
