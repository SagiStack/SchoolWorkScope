<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="ScopeIt.ResetPassword" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>Reset Password - ScopeIt</title>
    <link rel="stylesheet" href="MainElement.css" />
    <script src="validation.js" defer></script>
</head>
<body>
    <form id="formReset" runat="server" onsubmit="return validateReset();">
        <div class="auth-page">
            <div class="auth-card">
                <h2>Reset Password</h2>
                <p class="auth-subtitle">Enter your details to change your password.</p>
                
                <div class="form-group">
                    <label>Email or ID</label>
                    <asp:TextBox ID="txtResetIdentifier" runat="server" ClientIDMode="Static"></asp:TextBox>
                    <span id="errResetIdentifier" class="error-text" style="color:var(--color-primary); font-size: 0.8rem;"></span>
                </div>

                <div class="form-group">
                    <label>New Password</label>
                    <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" ClientIDMode="Static"></asp:TextBox>
                    <span id="errNewPassword" class="error-text" style="color:var(--color-primary); font-size: 0.8rem;"></span>
                </div>

                <div class="form-group">
                    <label>Confirm New Password</label>
                    <asp:TextBox ID="txtConfirmNewPassword" runat="server" TextMode="Password" ClientIDMode="Static"></asp:TextBox>
                    <span id="errConfirmNewPassword" class="error-text" style="color:var(--color-primary); font-size: 0.8rem;"></span>
                </div>

                <asp:Button ID="btnReset" runat="server" Text="Update Password" OnClick="btnReset_Click" CssClass="btn-submit" />
                
                <asp:Label ID="lblResetMessage" runat="server" style="display:block; margin-top:1rem; font-weight:bold;"></asp:Label>
                
                <div class="auth-footer">
                    Remember your password? <a href="Login.aspx">Log in</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>