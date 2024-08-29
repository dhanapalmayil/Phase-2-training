<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProperty.aspx.cs" Inherits="RealEstate.EditProperty" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Edit Property</title>
     <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" CssClass="message"/>

            <h2>Edit Property</h2>
            <asp:TextBox ID="txtTitle" runat="server" Placeholder="Title" CssClass="input-field" />
            <asp:TextBox ID="txtDescription" runat="server" Placeholder="Description" TextMode="MultiLine" CssClass="input-field" />
            <asp:TextBox ID="txtPrice" runat="server" Placeholder="Price" CssClass="input-field" />
            <asp:TextBox ID="txtAddress" runat="server" Placeholder="Address" CssClass="input-field" />
            <asp:TextBox ID="txtCity" runat="server" Placeholder="City" CssClass="input-field" />
            <asp:TextBox ID="txtState" runat="server" Placeholder="State" CssClass="input-field" />
            <asp:TextBox ID="txtZipCode" runat="server" Placeholder="Zip Code" CssClass="input-field" />
            <asp:FileUpload ID="fuImage" runat="server" CssClass="input-field" />
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="submit-button" />
        </div>
    </form>

</body>
</html>
