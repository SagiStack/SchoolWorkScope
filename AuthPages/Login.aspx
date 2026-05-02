<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ScopeIt.Login" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>Login - ScopeIt</title>
    <link rel="stylesheet" href="MainElement.css" />
    <script src="validation.js" defer></script>
</head>
<body>
    <form id="formLogin" runat="server" onsubmit="return validateLogin();">
        <div class="auth-page">
            <div class="auth-card">
                <h2>Welcome Back</h2>
                <p class="auth-subtitle">Log in to your ScopeIt account.</p>
                
                <div class="form-group">
                    <label>Email or ID</label>
                    <asp:TextBox ID="txtIdOrEmail" runat="server" ClientIDMode="Static"></asp:TextBox>
                    <span id="errIdOrEmail" class="error-text" style="color:var(--color-primary); font-size: 0.8rem;"></span>
                </div>

                <div class="form-group">
                    <label>Password</label>
                    <asp:TextBox ID="txtLoginPassword" runat="server" TextMode="Password" ClientIDMode="Static"></asp:TextBox>
                    <span id="errLoginPassword" class="error-text" style="color:var(--color-primary); font-size: 0.8rem;"></span>
                </div>

                <asp:Button ID="btnLogin" runat="server" Text="Log In" OnClick="btnLogin_Click" CssClass="btn-submit" />
                
                <asp:Label ID="lblLoginMessage" runat="server" style="display:block; margin-top:1rem; font-weight:bold;"></asp:Label>
                
                <div class="auth-footer">
                    <a href="ResetPassword.aspx">Forgot Password?</a>
                    <br /><br />
                    New to ScopeIt? <a href="SignUp.aspx">Sign up now</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>