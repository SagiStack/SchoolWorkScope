using System;
using MasterPage1;

namespace ScopeIt
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        string dbName = "ScopeItDB.mdf";

        protected void btnReset_Click(object sender, EventArgs e)
        {
            string identifier = txtResetIdentifier.Text.Replace("'", "''");
            string newPassword = txtNewPassword.Text.Replace("'", "''");

            // First, check if the user actually exists
            string checkSql = $"SELECT * FROM Users WHERE Email = '{identifier}' OR NationalID = '{identifier}'";

            if (MySQLHelper.IsExist(dbName, checkSql))
            {
                // User exists, update password
                string updateSql = $@"UPDATE Users SET Password = '{newPassword}' 
                                      WHERE Email = '{identifier}' OR NationalID = '{identifier}'";

                int rowsAffected = MySQLHelper.DoQuery(dbName, updateSql);

                if (rowsAffected > 0)
                {
                    lblResetMessage.Text = "Password successfully updated!";
                    lblResetMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblResetMessage.Text = "An error occurred while updating.";
                    lblResetMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblResetMessage.Text = "User not found.";
                lblResetMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}