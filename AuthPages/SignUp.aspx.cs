using System;
using MasterPage1; // Accessing your MySQLHelper

namespace ScopeIt
{
    public partial class SignUp : System.Web.UI.Page
    {
        string dbName = "ScopeItDB.mdf"; // Change this to your actual DB file name

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            // Simple sanitization to prevent breaking the SQL string (replacing single quotes)
            string fullName = txtFullName.Text.Replace("'", "''");
            string userName = txtUserName.Text.Replace("'", "''");
            string birthday = txtBirthday.Text;
            string email = txtEmail.Text.Replace("'", "''");
            string nationalID = txtNationalID.Text.Replace("'", "''");
            string password = txtPassword.Text.Replace("'", "''");

            // Check if user already exists
            string checkSql = $"SELECT * FROM Users WHERE Email = '{email}' OR NationalID = '{nationalID}' OR UserName = '{userName}'";

            if (MySQLHelper.IsExist(dbName, checkSql))
            {
                lblMessage.Text = "Error: Username, Email, or ID is already registered.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Insert new user
            string insertSql = $@"INSERT INTO Users (FullName, UserName, Birthday, Email, NationalID, Password) 
                                  VALUES ('{fullName}', '{userName}', '{birthday}', '{email}', '{nationalID}', '{password}')";

            try
            {
                int rowsAffected = MySQLHelper.DoQuery(dbName, insertSql);
                if (rowsAffected > 0)
                {
                    lblMessage.Text = "Account created successfully!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    // Optional: Response.Redirect("Login.aspx");
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Database error occurred.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}