<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEmployeePage.aspx.cs" Inherits="PizzaCompany.AddEmployeePAge" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="returnButton" runat="server" onclick="returnButton_Click" 
            Text="Return" />
        <br />
        <br />
    
        <asp:Label ID="Label1" runat="server" 
            Text="Fill in the boxes below to add a new employee:"></asp:Label>
        <br />
    
    </div>
    <asp:Label ID="ssnLabel" runat="server" Text="SSN:"></asp:Label>
&nbsp;
    <asp:TextBox ID="ssnTB" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="firstLabel" runat="server" Text="First:"></asp:Label>
&nbsp;
    <asp:TextBox ID="firstTB" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lastLabel" runat="server" Text="Last:"></asp:Label>
&nbsp;
    <asp:TextBox ID="lastTB" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="addressLabel" runat="server" Text="Address:"></asp:Label>
&nbsp;
    <asp:TextBox ID="addressTB" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="phoneLabel" runat="server" Text="Phone:"></asp:Label>
&nbsp;
    <asp:TextBox ID="phoneTB" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="birthLabel" runat="server" Text="Date Of Birth:"></asp:Label>
&nbsp;
    <asp:TextBox ID="birthTB" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="hireLabel" runat="server" Text="Hire Date:"></asp:Label>
&nbsp;
    <asp:TextBox ID="hireTB" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="payLabel" runat="server" Text="Pay Rate:"></asp:Label>
&nbsp;
    <asp:TextBox ID="payTB" runat="server"></asp:TextBox>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="submitbutton" runat="server" onclick="submitbutton_Click" 
        Text="Submit" />
    </form>
</body>
</html>
