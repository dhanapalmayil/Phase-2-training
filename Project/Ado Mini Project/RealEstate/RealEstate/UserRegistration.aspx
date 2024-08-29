<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="RealEstate.UserRegistration" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Registration</title>
    <link rel="stylesheet" type="text/css" href="Content/styles.css" />
    <style>
        body {
            background-image: url('https://images7.alphacoders.com/401/401027.jpg'); /* Path to your background image */
            background-size: cover;
            background-position: center;
            background-repeat: no-repeat;
            height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
            margin: 0;
        }
        .radio-group {
            margin-bottom: 15px;
        }
        .radio-group label {
            margin-right: 20px;
        }
        .message {
            color: #d44;
            font-size: 16px;
            margin-top: 10px;
        }
        .login-link {
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Register</h1>
            <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>
            
            <asp:TextBox ID="txtUsername" runat="server" CssClass="input-field" Placeholder="Username" />
            <asp:TextBox ID="txtPassword" runat="server" CssClass="input-field" TextMode="Password" Placeholder="Password" />
            
            <div class="radio-group">
                <asp:RadioButton ID="rbAgent" runat="server" GroupName="UserType" Text="Agent" />
                <asp:RadioButton ID="rbClient" runat="server" GroupName="UserType" Text="Client" />
            </div>
            
            <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="submit-button" OnClick="btnRegister_Click" />

            <div class="login-link">
                <p>Already registered? <a href="Login.aspx">Login here</a></p>
            </div>
        </div>
    </form>
</body>
</html>
