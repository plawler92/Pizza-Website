<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="PizzaCompany.MainPage"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <form id="Title" runat="server">
    
    <div>
    
        <asp:Button ID="OrderOnline" runat="server" Text="Order Online" 
            onclick="OrderOnline_Click" Width="144px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Employee" runat="server" onclick="Employee_Click" 
            Text="Employees Only" />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="EmpPW" runat="server" Text="Enter Password:" Visible="False"></asp:Label>
        <asp:TextBox ID="EmpPWTextBox" runat="server" Visible="False"></asp:TextBox>
        <asp:Button ID="EmpPWButton" runat="server" onclick="EmpPWButton_Click" 
            Text="Submit" Visible="False" />
    
    </div>
    <p>
    <asp:Label ID="WelcomeLabel" runat="server" 
        Text="Welcome To The Pizza Place Delivery Service!"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Image ID="Image1" runat="server" Height="339px" 
            ImageUrl="~/pizza-page.jpg" Width="534px" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
&nbsp;
        </p>
    </form>
</body>
</html>
