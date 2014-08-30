<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeePage.aspx.cs" Inherits="PizzaCompany.EmployeePage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:Button ID="mainPage" runat="server" onclick="mainPage_Click" 
        Text="Main Page" />
    <asp:Button ID="addEmp" runat="server" onclick="addEmp_Click" 
        Text="Add Employee" Width="177px" />
    <asp:Button ID="editMenuButton" runat="server" Text="Edit Menu" 
        onclick="editMenuButton_Click" Width="169px" />
    <asp:Button ID="editInvenButton" runat="server" onclick="editInvenButton_Click" 
        Text="Edit Inventory" Width="178px" />
    <br />
    <br />
    <asp:Button ID="showEmpButton" runat="server" onclick="showEmpButton_Click" 
        Text="Show Employee Info" />
    <asp:Button ID="hideEmpInfoButton" runat="server" 
        onclick="hideEmpInfoButton_Click" Text="Hide Employee Info" 
        Visible="False" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="PizzaCompany" Visible="False">
        <Columns>
            <asp:BoundField DataField="employeeSSN" HeaderText="employeeSSN" 
                SortExpression="employeeSSN" />
            <asp:BoundField DataField="employeeFirst" HeaderText="employeeFirst" 
                SortExpression="employeeFirst" />
            <asp:BoundField DataField="employeeLast" HeaderText="employeeLast" 
                SortExpression="employeeLast" />
            <asp:BoundField DataField="employeeAddress" HeaderText="employeeAddress" 
                SortExpression="employeeAddress" />
            <asp:BoundField DataField="employeePhone" HeaderText="employeePhone" 
                SortExpression="employeePhone" />
            <asp:BoundField DataField="employeeBirthDate" HeaderText="employeeBirthDate" 
                SortExpression="employeeBirthDate" />
            <asp:BoundField DataField="employeeHireDate" HeaderText="employeeHireDate" 
                SortExpression="employeeHireDate" />
            <asp:BoundField DataField="employeePayRate" HeaderText="employeePayRate" 
                SortExpression="employeePayRate" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="PizzaCompany" runat="server" 
        ConnectionString="<%$ ConnectionStrings:PizzaCompanyConnectionString %>" 
        SelectCommand="SELECT * FROM [Employee]"></asp:SqlDataSource>
    <p>
        <asp:Label ID="la" runat="server" Text="Remove Employee" Visible="False"></asp:Label>
&nbsp;
        <asp:TextBox ID="removeTB" runat="server" Visible="False"></asp:TextBox>
        <asp:Button ID="removeEMPButton" runat="server" onclick="removeEMPButton_Click" 
            Text="Remove" Visible="False" />
    </p>
    <p>
    <asp:Button ID="showOrderButton" runat="server" Text="Show Orders" 
            onclick="showOrderButton_Click" Width="186px" />
    <asp:Button ID="hideOrderButton" runat="server" Text="Hide Orders" 
            onclick="hideOrderButton_Click" Visible="False" Width="173px" />
    </p>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
        DataSourceID="Orders" Visible="False">
        <Columns>
            <asp:BoundField DataField="orderID" HeaderText="orderID" InsertVisible="False" 
                ReadOnly="True" SortExpression="orderID" />
            <asp:BoundField DataField="userID" HeaderText="userID" 
                SortExpression="userID" InsertVisible="False" ReadOnly="True" />
            <asp:BoundField DataField="menuName" HeaderText="menuName" 
                SortExpression="menuName" />
            <asp:BoundField DataField="sellPrice" HeaderText="sellPrice" 
                SortExpression="sellPrice" />
            <asp:BoundField DataField="quantity" HeaderText="quantity" 
                SortExpression="quantity" />
            <asp:BoundField DataField="userAddress" HeaderText="userAddress" 
                SortExpression="userAddress" />
            <asp:BoundField DataField="orderTime" HeaderText="orderTime" 
                SortExpression="orderTime" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="Orders" runat="server" 
        ConnectionString="<%$ ConnectionStrings:PizzaCompanyConnectionString %>" 
        SelectCommand="SELECT Orders.orderID, UserAccount.userID, Menu.menuName, Menu.sellPrice, OrderDetails.quantity, UserAccount.userAddress, Orders.orderTime FROM Orders INNER JOIN UserAccount ON Orders.userID = UserAccount.userID INNER JOIN OrderDetails ON Orders.orderID = OrderDetails.orderID INNER JOIN Menu ON OrderDetails.menuID = Menu.menuID
ORDER BY Orders.orderTime DESC">
    </asp:SqlDataSource>
    <br />
    <br />
    <br />
    </form>
</body>
</html>
