<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientViewProperties.aspx.cs" Inherits="RealEstate.ClientViewProperties" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Properties</title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
    <style>
        .search-container {
            display: flex;
            justify-content: space-between;
            margin-bottom: 20px;
            gap: 10px;
        }

        .search-container input[type="text"], .search-container input[type="submit"] {
            padding: 10px;
            border-radius: 5px;
            border: 1px solid #ddd;
            font-size: 14px;
            width: 30%;
            box-sizing: border-box;
        }

        .search-container input[type="submit"] {
            background-color: #800404;
            color: #fff;
            border: none;
            cursor: pointer;
        }

        .search-container input[type="submit"]:hover {
            background-color: #a80000;
        }

        .container {
            width: 80%;
            margin: 0 auto;
        }

        .properties-container {
            display: flex;
            flex-wrap: wrap;
            gap: 20px;
            justify-content: space-between;
        }

        .property-card {
            width: calc(33.333% - 20px); /* Adjust width to fit 3 cards per row, minus the gap */
            background-color: #fff;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            padding: 20px;
            text-align: center;
            box-sizing: border-box;
        }

        .property-card img {
            width: 100%;
            height: 200px;
            object-fit: cover;
            border-radius: 5px;
        }

        .property-card h3 {
            font-size: 18px;
            margin: 15px 0;
        }

        .property-card p {
            margin: 5px 0;
            font-size: 14px;
        }

        .property-card .price {
            font-weight: bold;
            color: #800404;
            margin: 10px 0;
        }

        .property-card .action-buttons {
            margin-top: 10px;
        }

        .property-card .action-buttons button {
            background-color: #800404;
            color: #fff;
            border: none;
            padding: 10px 20px;
            border-radius: 5px;
            cursor: pointer;
            margin: 5px;
        }

        .property-card .action-buttons button:hover {
            background-color: #a80000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

            <h2>Search Properties</h2>

            <div class="search-container">
                <asp:TextBox ID="txtTitle" runat="server" placeholder="Title"></asp:TextBox>
                <asp:TextBox ID="txtCity" runat="server" placeholder="City"></asp:TextBox>
                <asp:TextBox ID="txtState" runat="server" placeholder="State"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            </div>

            <h2>Available Properties</h2>

            <div class="properties-container">
                <asp:Repeater ID="rptProperties" runat="server" OnItemCommand="rptProperties_ItemCommand">
                    <ItemTemplate>
                        <div class="property-card">
                            <asp:Image ID="imgProperty" runat="server" ImageUrl='<%# Eval("ImagePath") %>' />
                            <h3><%# Eval("Title") %></h3>
                            <p><strong>Description:</strong> <%# Eval("Description") %></p>
                            <p><strong>Address:</strong> <%# Eval("Address") %></p>
                            <p><strong>City:</strong> <%# Eval("City") %></p>
                            <p><strong>State:</strong> <%# Eval("State") %></p>
                           <p class="price">₹<%# String.Format("{0:N0}", Eval("Price")) %></p>

                            <div class="action-buttons">
                                <asp:Button ID="btnBuy" runat="server" Text="Buy" CommandArgument='<%# Eval("PropertyID") %>' CommandName="Buy" />
                                <asp:Button ID="btnRent" runat="server" Text="Rent" CommandArgument='<%# Eval("PropertyID") %>' CommandName="Rent" />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</body>
</html>
