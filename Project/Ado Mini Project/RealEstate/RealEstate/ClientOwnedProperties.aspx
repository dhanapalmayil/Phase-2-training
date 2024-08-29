<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientOwnedProperties.aspx.cs" Inherits="RealEstate.ClientOwnedProperties" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Properties</title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>My Properties (Bought or Rented)</h1>
                <asp:GridView ID="gvOwnedProperties" runat="server" AutoGenerateColumns="False" CssClass="property-table">
                    <Columns>
                        <asp:BoundField DataField="Title" HeaderText="Title" />
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                        <asp:BoundField DataField="Price" HeaderText="Price" />
                        <asp:BoundField DataField="Address" HeaderText="Address" />
                        <asp:BoundField DataField="City" HeaderText="City" />
                        <asp:BoundField DataField="State" HeaderText="State" />
                        <asp:BoundField DataField="ZipCode" HeaderText="Zip Code" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>

            <div class="table-container">