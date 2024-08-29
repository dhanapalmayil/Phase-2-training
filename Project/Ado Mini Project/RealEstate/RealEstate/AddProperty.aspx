<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProperty.aspx.cs" Inherits="RealEstate.AddProperty" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Property</title>
     <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body>
     <form id="form1" runat="server">
        <div class="container">
            <h1>Add Property</h1>
            <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>
            <asp:TextBox ID="txtTitle" runat="server" CssClass="input-field" Placeholder="Title"></asp:TextBox>
            <asp:TextBox ID="txtDescription" runat="server" CssClass="input-field" TextMode="MultiLine" Placeholder="Description" Rows="4"></asp:TextBox>
            <asp:TextBox ID="txtPrice" runat="server" CssClass="input-field" Placeholder="Price" AutoPostBack="True"></asp:TextBox>
            <asp:TextBox ID="txtAddress" runat="server" CssClass="input-field" Placeholder="Address"></asp:TextBox>
            <asp:TextBox ID="txtCity" runat="server" CssClass="input-field" Placeholder="City"></asp:TextBox>
            <asp:TextBox ID="txtState" runat="server" CssClass="input-field" Placeholder="State"></asp:TextBox>
            <asp:TextBox ID="txtZipCode" runat="server" CssClass="input-field" Placeholder="Zip Code"></asp:TextBox>
            <asp:FileUpload ID="fuImage" runat="server" CssClass="input-field" />
            <asp:Button ID="btnAdd" runat="server" Text="Add Property" CssClass="submit-button" OnClick="btnAdd_Click" />
        </div>
    </form>
</body>
</html>
