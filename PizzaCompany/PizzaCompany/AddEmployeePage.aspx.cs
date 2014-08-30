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
    public partial class AddEmployeePAge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitbutton_Click(object sender, EventArgs e)
        {
            //string acct_name = accountTextBox.Text;
            //string f_name = fNameTextBox.Text;
            //string l_name = lNameTextBox.Text;
            //string address = addressTextBox.Text;
            //string email = emailTextBox.Text;
            //string phone = phoneTextBox.Text;
            //string password = passwordTextBox.Text;
            //string zip = ZipTextBox.Text;
            int ssn = Convert.ToInt32(ssnTB.Text);
            string first = firstTB.Text;
            string last = lastTB.Text;
            string address = addressTB.Text;
            string phone = phoneTB.Text;
            string birth_date = birthTB.Text;
            string hire_date = hireTB.Text;
            string pay_rate = payTB.Text;


            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["PizzaCompanyConnectionString"].ConnectionString;

            SqlCommand comm = new SqlCommand();

            String query = "INSERT INTO Employee (Employee.employeeSSN, Employee.employeeFirst, Employee.employeeLast, Employee.employeeAddress, Employee.employeePhone, Employee.employeeBirthDate, Employee.employeeHireDate, Employee.employeePayRate) VALUES(@ssn, @first, @last, @address, @phone, @birth, @hire, @pay)";

            //@ssn, @first, @last, @address, @phone, @birth, @hire, @pay

            SqlParameter ssnParam = new SqlParameter();
            ssnParam.ParameterName = "@ssn";
            ssnParam.SqlDbType = SqlDbType.Int;
            ssnParam.Size = 50;
            ssnParam.Value = ssn;

            SqlParameter firstParam = new SqlParameter();
            firstParam.ParameterName = "@first";
            firstParam.SqlDbType = SqlDbType.NVarChar;
            firstParam.Size = 50;
            firstParam.Value = first;

            SqlParameter lastParam = new SqlParameter();
            lastParam.ParameterName = "@last";
            lastParam.SqlDbType = SqlDbType.NVarChar;
            lastParam.Size = 50;
            lastParam.Value = last;

            SqlParameter addressParam = new SqlParameter();
            addressParam.ParameterName = "@address";
            addressParam.SqlDbType = SqlDbType.NVarChar;
            addressParam.Size = 50;
            addressParam.Value = address;

            //@ssn, @first, @last, @address, @phone, @birth, @hire, @pay

            SqlParameter phoneParam = new SqlParameter();
            phoneParam.ParameterName = "@phone";
            phoneParam.SqlDbType = SqlDbType.NVarChar;
            phoneParam.Size = 50;
            phoneParam.Value = phone;

            SqlParameter birthParam = new SqlParameter();
            birthParam.ParameterName = "@birth";
            birthParam.SqlDbType = SqlDbType.NVarChar;
            birthParam.Size = 50;
            birthParam.Value = birth_date;

            SqlParameter hireParam = new SqlParameter();
            hireParam.ParameterName = "@hire";
            hireParam.SqlDbType = SqlDbType.NVarChar;
            hireParam.Size = 50;
            hireParam.Value = hire_date;

            SqlParameter payParam = new SqlParameter();
            payParam.ParameterName = "@pay";
            payParam.SqlDbType = SqlDbType.NVarChar;
            payParam.Size = 50;
            payParam.Value = pay_rate;

            comm.Parameters.Add(ssnParam);
            comm.Parameters.Add(firstParam);
            comm.Parameters.Add(lastParam);
            comm.Parameters.Add(addressParam);
            comm.Parameters.Add(phoneParam);
            comm.Parameters.Add(birthParam);
            comm.Parameters.Add(hireParam);
            comm.Parameters.Add(payParam);

            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Connection = conn;

            conn.Open();

            comm.ExecuteNonQuery();

            conn.Close();

            ssnTB.Text = "";
            firstTB.Text = "";
            lastTB.Text = "";
            addressTB.Text = "";
            phoneTB.Text = "";
            birthTB.Text = "";
            hireTB.Text = "";
            payTB.Text = "";

            Response.Redirect("EmployeePage.aspx");

        }

        protected void returnButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeePage.aspx");
        }
    }
}