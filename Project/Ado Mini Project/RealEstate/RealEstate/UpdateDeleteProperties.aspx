<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateDeleteProperties.aspx.cs" Inherits="RealEstate._UpdateDeleteProperties" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update/Delete Properties</title>
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
            margin: 50px auto;
            background-color: #fff;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
        }
        h1 {
            text-align: center;
            color: #333;
            margin-bottom: 20px;
        }
        .message {
            display: block;
            margin-bottom: 20px;
            color: #28a745;
            text-align: center;
            font-weight: bold;
        }
        .table-container {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }
        .table-container th, .table-container td {
            padding: 12px 15px;
            text-align: left;
            border-bottom: 1px solid #ddd;
        }
        .table-container th {
            background-color: #800404;
            color: #fff;
        }
        .table-container tr:hover {
            background-color: #f1f1f1;
        }
        .table-container td img {
            display: block;
            max-width: 100px;
            height: auto;
            border-radius: 5px;
        }
        .btn-group {
            display: flex;
            gap: 10px;
        }
        .edit-button {
            background-color: #28a745;
            color: white;
            border: none;
            padding: 8px 16px;
            margin: 5px 0;
            border-radius: 4px;
            cursor: pointer;
            font-size: 14px;
        }
        .edit-button:hover {
            background-color: #218838;
        }
        .delete-button {
            background-color: #dc3545;
            color: white;
            border: none;
            padding: 8px 16px;
            margin: 5px 0;
            border-radius: 4px;
            cursor: pointer;
            font-size: 14px;
        }
        .delete-button:hover {
            background-color: #c82333;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Update/Delete Properties</h1>
            <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>
            <asp:GridView ID="gvProperties" runat="server" AutoGenerateColumns="False" CssClass="table-container" OnRowCommand="gvProperties_RowCommand">
                <Columns>
                    <asp:BoundField DataField="PropertyID" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:BoundField DataField="City" HeaderText="City" />
                    <asp:BoundField DataField="State" HeaderText="State" />
                    <asp:BoundField DataField="ZipCode" HeaderText="Zip Code" />
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                            <asp:Image ID="imgProperty" runat="server" ImageUrl='<%# Eval("ImagePath") %>' Width="100px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <div class="btn-group">
                                <asp:Button ID="btnEdit" runat="server" CommandName="Edit" CommandArgument='<%# Eval("PropertyID") %>' Text="Edit" CssClass="edit-button" />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btndelete" CommandArgument='<%# Eval("PropertyID") %>' CssClass="btn" />

                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
