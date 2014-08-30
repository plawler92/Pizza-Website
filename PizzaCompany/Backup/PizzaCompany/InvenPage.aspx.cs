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
    public partial class InvenPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            string name = nameTB.Text;
            string cost = costTB.Text;
            int amount = Convert.ToInt32(amountTB.Text);

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["PizzaCompanyConnectionString"].ConnectionString;

            SqlCommand comm = new SqlCommand();

            String query = "INSERT INTO Inventory (Inventory.invenName, Inventory.purchaseCost, Inventory.amount) VALUES(@name, @cost, @amount)";



            SqlParameter nameParam = new SqlParameter();
            nameParam.ParameterName = "@name";
            nameParam.SqlDbType = SqlDbType.NVarChar;
            nameParam.Size = 50;
            nameParam.Value = name;

            SqlParameter costParam = new SqlParameter();
            costParam.ParameterName = "@cost";
            costParam.SqlDbType = SqlDbType.NVarChar;
            costParam.Size = 50;
            costParam.Value = cost;

            SqlParameter amountParam = new SqlParameter();
            amountParam.ParameterName = "@amount";
            amountParam.SqlDbType = SqlDbType.Int;
            amountParam.Size = 50;
            amountParam.Value = amount;

            comm.Parameters.Add(nameParam);
            comm.Parameters.Add(costParam);
            comm.Parameters.Add(amountParam);


            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Connection = conn;

            conn.Open();

            comm.ExecuteNonQuery();

            conn.Close();

            nameTB.Text = "";
            costTB.Text = "";
            amountTB.Text = "";

            GridView1.DataBind();

        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["PizzaCompanyConnectionString"].ConnectionString;

            SqlCommand comm = new SqlCommand();

            String query = "DELETE FROM Inventory WHERE Inventory.invenID = @id";

            SqlParameter idParam = new SqlParameter();
            idParam.ParameterName = "@id";
            idParam.SqlDbType = SqlDbType.Int;
            idParam.Size = 4;
            idParam.Value = invenIDTB.Text;

            comm.Parameters.Add(idParam);

            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Connection = conn;

            conn.Open();

            comm.ExecuteNonQuery();

            conn.Close();

            invenIDTB.Text = "";

            GridView1.DataBind();
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            string name = editNameTB.Text;
            string cost = editCostTB.Text;
            int amount = Convert.ToInt32(editAmountTB.Text);

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["PizzaCompanyConnectionString"].ConnectionString;

            SqlCommand comm = new SqlCommand();

            String query = "UPDATE Inventory " +
                           "SET Inventory.invenName = @name, Inventory.purchaseCost = @cost, Inventory.amount = @amount " +
                           "WHERE Inventory.invenID = @id";




            SqlParameter nameParam = new SqlParameter();
            nameParam.ParameterName = "@name";
            nameParam.SqlDbType = SqlDbType.NVarChar;
            nameParam.Size = 50;
            nameParam.Value = name;

            SqlParameter costParam = new SqlParameter();
            costParam.ParameterName = "@cost";
            costParam.SqlDbType = SqlDbType.NVarChar;
            costParam.Size = 50;
            costParam.Value = cost;

            SqlParameter amountParam = new SqlParameter();
            amountParam.ParameterName = "@amount";
            amountParam.SqlDbType = SqlDbType.Int;
            amountParam.Size = 50;
            amountParam.Value = amount;

            SqlParameter idParam = new SqlParameter();
            idParam.ParameterName = "@id";
            idParam.SqlDbType = SqlDbType.Int;
            idParam.Size = 4;
            idParam.Value = invenIDTB.Text;

            comm.Parameters.Add(nameParam);
            comm.Parameters.Add(costParam);
            comm.Parameters.Add(amountParam);
            comm.Parameters.Add(idParam);


            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Connection = conn;

            conn.Open();

            comm.ExecuteNonQuery();

            conn.Close();

            editNameTB.Text = "";
            editCostTB.Text = "";
            editAmountTB.Text = "";
            invenIDTB.Text = "";

            GridView1.DataBind();
        }

        protected void editButton_Click(object sender, EventArgs e)
        {
            
            int id = Convert.ToInt32(invenIDTB.Text);

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["PizzaCompanyConnectionString"].ConnectionString;

            SqlCommand comm = new SqlCommand();

            String query = "SELECT Inventory.invenName, Inventory.purchaseCost, Inventory.amount " +
                           "FROM Inventory " +
                           "WHERE Inventory.invenID = @id ";

            SqlParameter idParam = new SqlParameter();
            idParam.ParameterName = "@id";
            idParam.SqlDbType = SqlDbType.Int;
            idParam.Size = 50;
            idParam.Value = id;

            comm.Parameters.Add(idParam);

            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Connection = conn;

            conn.Open();

            SqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                editNameTB.Text = Convert.ToString(reader["invenName"]);
                editCostTB.Text = Convert.ToString(reader["purchaseCost"]);
                editAmountTB.Text = Convert.ToString(reader["amount"]);
            }

            conn.Close();      
        }

        protected void returnButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeePage");
        }
    }
}