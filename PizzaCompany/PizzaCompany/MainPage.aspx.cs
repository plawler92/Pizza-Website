using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PizzaCompany
{
    public partial class MainPage : System.Web.UI.Page
    {
        string emp_password = "password";
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void OrderOnline_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderPage.aspx");
        }

        protected void CreateAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountPage.aspx");           
        }

        protected void Employee_Click(object sender, EventArgs e)
        {
            EmpPW.Visible = true;
            EmpPWTextBox.Visible = true;
            EmpPWButton.Visible = true;
        }

        protected void EmpPWButton_Click(object sender, EventArgs e)
        {
            if (EmpPWTextBox.Text == emp_password)
                Response.Redirect("EmployeePage.aspx");
        }
    }
}