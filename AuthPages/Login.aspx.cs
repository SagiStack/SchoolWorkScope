using System;
using System.Data;
using MasterPage1;

namespace ScopeIt
{
    public partial class Login : System.Web.UI.Page
    {
        string dbName = "ScopeItDB.mdf";

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string idOrEmail = txtIdOrEmail.Text.Replace("'", "''");
            string password = txtLoginPassword.Text.Replace("'", "''");

            string sql = $@"SELECT * FROM Users 
                            WHERE (Email = '{idOrEmail}' OR NationalID = '{idOrEmail}') 
                            AND Password = '{password}'";

            DataTable dt = MySQLHelper.ExecuteDataTable(dbName, sql);

            if (dt.Rows.Count > 0)
            {
                // Successful login
                Session["UserID"] = dt.Rows[0]["Id"]; // Adjust column name based on your DB
                Session["FullName"] = dt.Rows[0]["FullName"];
                Session["UserName"] = dt.Rows[0]["UserName"];

                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                lblLoginMessage.Text = "Invalid credentials.";
                lblLoginMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}