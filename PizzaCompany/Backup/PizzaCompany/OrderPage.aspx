<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderPage.aspx.cs" Inherits="PizzaCompany.OrderPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label8" runat="server" Text="Fill In your Information"></asp:Label>
        <br />
        <br />
    
    </div>
    <asp:Label ID="Label" runat="server" Text="First Name:"></asp:Label>
&nbsp;
    <asp:TextBox ID="firstNameTB" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
    <asp:Label ID="Label4" runat="server" Text="Last Name:"></asp:Label>
&nbsp;
    <asp:TextBox ID="lastNameTB" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Address:"></asp:Label>
&nbsp;
    <asp:TextBox ID="addressTB" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label6" runat="server" Text="Zip:"></asp:Label>
&nbsp;
    <asp:TextBox ID="zipTB" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label7" runat="server" Text="Phone:"></asp:Label>
&nbsp;
    <asp:TextBox ID="phoneTB" runat="server"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Button ID="proceedButton" runat="server" onclick="proceedButton_Click" 
        Text="Proceed" Width="85px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="errorLabel" runat="server" 
        Text="Please fill in all the required information." Visible="False"></asp:Label>
    <br />
    <br />
    <br />
    <asp:Label ID="OrderLabel" runat="server" Text="Choose what to order below" 
        Visible="False"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="menuID" DataSourceID="PizzaCompany" style="margin-top: 15px" 
        Visible="False">
        <Columns>
            <asp:BoundField DataField="menuID" HeaderText="menuID" InsertVisible="False" 
                ReadOnly="True" SortExpression="menuID" />
            <asp:BoundField DataField="menuName" HeaderText="menuName" 
                SortExpression="menuName" />
            <asp:BoundField DataField="sellPrice" HeaderText="sellPrice" 
                SortExpression="sellPrice" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="PizzaCompany" runat="server" 
        ConnectionString="<%$ ConnectionStrings:PizzaCompanyConnectionString %>" 
        SelectCommand="SELECT [menuName], [sellPrice], [menuID] FROM [Menu]">
    </asp:SqlDataSource>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Enter Id: " ToolTip=" " 
        Visible="False"></asp:Label>
    <asp:TextBox ID="menuNameTB" runat="server" Visible="False" 
        ontextchanged="menuNameTB_TextChanged"></asp:TextBox>
    <asp:Label ID="Label2" runat="server" Text="Quantity: " Visible="False"></asp:Label>
    <asp:TextBox ID="quantityTB" runat="server" Visible="False"></asp:TextBox>
    <asp:Button ID="addOrderButton" runat="server" Text="Add To Order" 
        Visible="False" onclick="addOrderButton_Click" />
    <asp:Button ID="updateButton" runat="server" onclick="updateButton_Click" 
        Text="Update Order" Visible="False" Width="105px" />
    <asp:Button ID="resetButton" runat="server" onclick="resetButton_Click" 
        Text="Reset Order" Visible="False" />
    <br />
    <br />
    <asp:Label ID="order" runat="server"></asp:Label>
    <asp:Label ID="totalLabel" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Button ID="mitButton" runat="server" Text="Submit Order" Width="104px" 
        onclick="mitButton_Click" Visible="False" />
    <br />
    <br />
    </form>
</body>
</html>
