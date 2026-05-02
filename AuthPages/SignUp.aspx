<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="ScopeIt.SignUp" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>Sign Up - ScopeIt</title>
    <!-- Link to your CSS file here -->
    <link rel="stylesheet" href="MainElement.css" />
    <script src="validation.js" defer></script>
</head>
<body>
    <form id="formSignUp" runat="server" onsubmit="return validateSignUp();">
        <div class="auth-page">
            <div class="auth-card">
                <h2>Join ScopeIt</h2>
                <p class="auth-subtitle">Create your account to get started.</p>
                
                <div class="form-group">
                    <label>Full Name</label>
                    <asp:TextBox ID="txtFullName" runat="server" ClientIDMode="Static"></asp:TextBox>
                    <span id="errFullName" class="error-text" style="color:var(--color-primary); font-size: 0.8rem;"></span>
                </div>

                <div class="form-group">
                    <label>User Name</label>
                    <asp:TextBox ID="txtUserName" runat="server" ClientIDMode="Static"></asp:TextBox>
                    <span id="errUserName" class="error-text" style="color:var(--color-primary); font-size: 0.8rem;"></span>
                </div>

                <div class="form-group">
                    <label>Birthday</label>
                    <asp:TextBox ID="txtBirthday" runat="server" TextMode="Date" ClientIDMode="Static"></asp:TextBox>
                    <span id="errBirthday" class="error-text" style="color:var(--color-primary); font-size: 0.8rem;"></span>
                </div>

                <div class="form-group">
                    <label>Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" ClientIDMode="Static"></asp:TextBox>
                    <span id="errEmail" class="error-text" style="color:var(--color-primary); font-size: 0.8rem;"></span>
                </div>

                <div class="form-group">
                    <label>ID (9 Digits)</label>
                    <asp:TextBox ID="txtNationalID" runat="server" ClientIDMode="Static"></asp:TextBox>
                    <span id="errNationalID" class="error-text" style="color:var(--color-primary); font-size: 0.8rem;"></span>
                </div>

                <div class="form-group">
                    <label>Password</label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ClientIDMode="Static"></asp:TextBox>
                    <span id="errPassword" class="error-text" style="color:var(--color-primary); font-size: 0.8rem;"></span>
                </div>

                <div class="form-group">
                    <label>Confirm Password</label>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" ClientIDMode="Static"></asp:TextBox>
                    <span id="errConfirmPassword" class="error-text" style="color:var(--color-primary); font-size: 0.8rem;"></span>
                </div>

                <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" OnClick="btnSignUp_Click" CssClass="btn-submit" />
                
                <asp:Label ID="lblMessage" runat="server" style="display:block; margin-top:1rem; font-weight:bold;"></asp:Label>

                <div class="auth-footer">
                    Already have an account? <a href="Login.aspx">Log in</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>