<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientWelcome.aspx.cs" Inherits="RealEstate.ClientWelcome" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome, Client</title>
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
            height: 70vh; /* Adjust to cover a large portion of the viewport */
            object-fit: cover; /* Ensures the image covers the container */
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
            <h1>Welcome, <asp:Literal ID="ltlClientName" runat="server"></asp:Literal>!</h1>
            <p class="welcome-message">Explore properties or view the ones you've already bought or rented.</p>
            
            <!-- Big Image -->
            <asp:Image ID="imgClientWelcome" runat="server" CssClass="big-image" ImageUrl="/images/home1.jpg" AlternateText="Client Welcome Image" />

            <!-- Buttons -->
            <div class="button-container">
                <asp:Button ID="btnExploreProperties" runat="server" Text="Explore Properties" CssClass="btn" OnClick="btnExploreProperties_Click" />
                <asp:Button ID="btnOwnedProperties" runat="server" Text="My Owned Properties" CssClass="btn" OnClick="btnOwnedProperties_Click" />
            </div>
        </div>
    </form>
</body>
</html>
