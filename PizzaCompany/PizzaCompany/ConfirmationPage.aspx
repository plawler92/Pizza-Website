<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmationPage.aspx.cs" Inherits="PizzaCompany.ConfirmationPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="Main Page" />
        <br />
    
    </div>
    <asp:Label ID="Label1" runat="server" Text="Your Order Has Been Placed!"></asp:Label>
    <br />
    <br />
    <br />
    <asp:Image ID="Image1" runat="server" ImageUrl="~/chef.jpg" />
    </form>
</body>
</html>
