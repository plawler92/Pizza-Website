using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace PizzaCompany
{
    public partial class EmployeePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addEmp_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEmployeePage.aspx");
        }

        protected void showEmpButton_Click(object sender, EventArgs e)
        {
            GridView1.Visible = true;
            hideEmpInfoButton.Visible = true;
            showEmpButton.Visible = false;
            la.Visible = true;
            removeEMPButton.Visible = true;
            removeTB.Visible = true;

        }

        protected void hideEmpInfoButton_Click(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            hideEmpInfoButton.Visible = false;
            showEmpButton.Visible = true;
            la.Visible = false;
            removeEMPButton.Visible = false;
            removeTB.Visible = false;
        }

        protected void editMenuButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuPage.aspx");
        }

        protected void editInvenButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("InvenPage.aspx");
        }

        protected void showOrderButton_Click(object sender, EventArgs e)
        {
            GridView2.Visible = true;
            hideOrderButton.Visible = true;
            showOrderButton.Visible = false;
        }

        protected void hideOrderButton_Click(object sender, EventArgs e)
        {
            GridView2.Visible = false;
            showOrderButton.Visible = true;
            hideOrderButton.Visible = false;
        }

        protected void mainPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }

        protected void removeEMPButton_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["PizzaCompanyConnectionString"].ConnectionString;

            SqlCommand comm = new SqlCommand();

            String query = "DELETE FROM Employee WHERE Employee.employeeSSN = @ssn";

            SqlParameter ssnParam = new SqlParameter();
            ssnParam.ParameterName = "@ssn";
            ssnParam.SqlDbType = SqlDbType.Int;
            ssnParam.Size = 50;
            ssnParam.Value = Convert.ToInt32(removeTB.Text);
            
            comm.Parameters.Add(ssnParam);            

            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Connection = conn;

            conn.Open();

            comm.ExecuteNonQuery();

            conn.Close();
            GridView1.DataBind();
            removeTB.Text = "";
        }
    }
}