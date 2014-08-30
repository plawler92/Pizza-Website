<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuPage.aspx.cs" Inherits="PizzaCompany.MenuPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:Label ID="Label1" runat="server" Text="Item Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label2" runat="server" Text="Cost To Make:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label3" runat="server" Text="Sell Price:"></asp:Label>
    <br />
    <asp:TextBox ID="nameTB" runat="server"></asp:TextBox>
    <asp:TextBox ID="costTB" runat="server"></asp:TextBox>
    <asp:TextBox ID="priceTB" runat="server"></asp:TextBox>
    <asp:Button ID="newItemTB" runat="server" onclick="newItemTB_Click" 
        Text="Add" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="menuID" DataSourceID="PizzaCompany">
        <Columns>
            <asp:BoundField DataField="menuID" HeaderText="menuID" InsertVisible="False" 
                ReadOnly="True" SortExpression="menuID" />
            <asp:BoundField DataField="menuName" HeaderText="menuName" 
                SortExpression="menuName" />
            <asp:BoundField DataField="makeCost" HeaderText="makeCost" 
                SortExpression="makeCost" />
            <asp:BoundField DataField="sellPrice" HeaderText="sellPrice" 
                SortExpression="sellPrice" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="PizzaCompany" runat="server" 
        ConnectionString="<%$ ConnectionStrings:PizzaCompanyConnectionString %>" 
        SelectCommand="SELECT [menuID], [menuName], [makeCost], [sellPrice] FROM [Menu]">
    </asp:SqlDataSource>
    <br />
    <asp:Label ID="Label4" runat="server" 
        Text="Enter Menu ID to Edit or Delete Item:"></asp:Label>
&nbsp;
    <asp:TextBox ID="menuIDTB" runat="server"></asp:TextBox>
    <asp:Button ID="editButton" runat="server" onclick="editButton_Click" 
        Text="Edit" />
    <asp:Button ID="deleteButton" runat="server" onclick="deleteButton_Click" 
        Text="Delete" />
    <br />
    <asp:Label ID="label5" runat="server" Text="Item Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label6" runat="server" Text="Cost To Make:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label7" runat="server" Text="Sell Price:"></asp:Label>
    <br />
    <asp:TextBox ID="editNameTB" runat="server"></asp:TextBox>
    <asp:TextBox ID="editCostTB" runat="server"></asp:TextBox>
    <asp:TextBox ID="editPriceTB" runat="server"></asp:TextBox>
    <asp:Button ID="submitButton" runat="server" onclick="submitButton_Click" 
        Text="Update" />
    <br />
    <br />
    <br />
    <asp:Button ID="returnButton" runat="server" onclick="returnButton_Click" 
        Text="Return" />
    </form>
</body>
</html>
