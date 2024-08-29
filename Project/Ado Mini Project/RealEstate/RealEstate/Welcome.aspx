<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="RealEstate.Welcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome</title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }
        .container {
            width: 80%;
            margin: 0 auto;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
            text-align: center;
        }
        h1 {
            color: #333;
            margin-bottom: 10px;
        }
        .welcome-message {
            color: #666;
            margin-bottom: 20px;
        }
        .big-image {
            display: block;
            width: 100%;
            height: 70vh; /* 70% of the viewport height */
            object-fit: cover; /* Ensure the image covers the container while maintaining aspect ratio */
            margin-bottom: 20px;
        }
        .button-container {
            display: flex;
            justify-content: center;
            gap: 20px;
            margin-top: 20px;
        }
        .btn {
            padding: 10px 20px;
            background-color: #800404;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
        .btn:hover {
            background-color: #a10000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <!-- Welcome Text and Message -->
            <h1>Welcome, <asp:Label ID="lblUsername" runat="server"></asp:Label>!</h1>
            <p class="welcome-message">Add new properties or manage existing ones.</p>
            
            <!-- Big Image -->
            <asp:Image ID="imgWelcome" runat="server" CssClass="big-image" ImageUrl="/images/home.jpg" AlternateText="Welcome Image" />
            
            <!-- Buttons -->
            <div class="button-container">
                <asp:Button ID="btnAddProperty" runat="server" Text="Add Property" CssClass="btn" OnClick="btnAddProperty_Click" />
                <asp:Button ID="btnUpdateDeleteProperties" runat="server" Text="Manage Properties" CssClass="btn" OnClick="btnUpdateDeleteProperties_Click" />
                <asp:Button ID="btnShowClientProperties" runat="server" Text="Show Client Properties" CssClass="btn" OnClick="btnShowClientProperties_Click" />
            </div>
        </div>
    </form>
</body>
</html>
