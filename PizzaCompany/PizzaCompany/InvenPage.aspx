<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvenPage.aspx.cs" Inherits="PizzaCompany.InvenPage" %>

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
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label2" runat="server" Text="Cost Per Unit:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label3" runat="server" Text="Amount:"></asp:Label>
    <br />
    <asp:TextBox ID="nameTB" runat="server"></asp:TextBox>
    <asp:TextBox ID="costTB" runat="server"></asp:TextBox>
    <asp:TextBox ID="amountTB" runat="server"></asp:TextBox>
    <asp:Button ID="addButton" runat="server" onclick="addButton_Click" 
        Text="Add" />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="invenID" DataSourceID="PizzaCompany">
        <Columns>
            <asp:BoundField DataField="invenID" HeaderText="invenID" InsertVisible="False" 
                ReadOnly="True" SortExpression="invenID" />
            <asp:BoundField DataField="invenName" HeaderText="invenName" 
                SortExpression="invenName" />
            <asp:BoundField DataField="purchaseCost" HeaderText="purchaseCost" 
                SortExpression="purchaseCost" />
            <asp:BoundField DataField="amount" HeaderText="amount" 
                SortExpression="amount" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="PizzaCompany" runat="server" 
        ConnectionString="<%$ ConnectionStrings:PizzaCompanyConnectionString %>" 
        SelectCommand="SELECT [invenID], [invenName], [purchaseCost], [amount] FROM [Inventory]">
    </asp:SqlDataSource>
    <asp:Label ID="Label4" runat="server" 
        Text="Enter Inventory ID to Edit or Delete:"></asp:Label>
&nbsp;<asp:TextBox ID="invenIDTB" runat="server"></asp:TextBox>
    <asp:Button ID="editButton" runat="server" onclick="editButton_Click" 
        Text="Edit" />
    <asp:Button ID="deleteButton" runat="server" onclick="deleteButton_Click" 
        Text="Delete" />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label6" runat="server" Text="Purchase Price:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label7" runat="server" Text="Amount:"></asp:Label>
    <br />
    <asp:TextBox ID="editNameTB" runat="server"></asp:TextBox>
    <asp:TextBox ID="editCostTB" runat="server"></asp:TextBox>
    <asp:TextBox ID="editAmountTB" runat="server"></asp:TextBox>
    <asp:Button ID="updateButton" runat="server" onclick="updateButton_Click" 
        Text="Update" />
    <br />
    <br />
    <br />
    <asp:Button ID="returnButton" runat="server" onclick="returnButton_Click" 
        Text="Return" />
    </form>
</body>
</html>
