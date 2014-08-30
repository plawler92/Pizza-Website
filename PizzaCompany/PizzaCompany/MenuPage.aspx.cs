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
    public partial class MenuPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void newItemTB_Click(object sender, EventArgs e)
        {
            string name = nameTB.Text;
            string cost = costTB.Text;
            int price = Convert.ToInt32(priceTB.Text);

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["PizzaCompanyConnectionString"].ConnectionString;

            SqlCommand comm = new SqlCommand();

            String query = "INSERT INTO Menu (Menu.menuName, Menu.makeCost, Menu.sellPrice) VALUES(@name, @cost, @price)";

         

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

            SqlParameter priceParam = new SqlParameter();
            priceParam.ParameterName = "@price";
            priceParam.SqlDbType = SqlDbType.Int;
            priceParam.Size = 50;
            priceParam.Value = price;            

            comm.Parameters.Add(nameParam);
            comm.Parameters.Add(costParam);
            comm.Parameters.Add(priceParam);
            

            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Connection = conn;

            conn.Open();

            comm.ExecuteNonQuery();

            conn.Close();

            nameTB.Text = "";
            costTB.Text = "";
            priceTB.Text = "";

            GridView1.DataBind();
        }

        protected void editButton_Click(object sender, EventArgs e)
        {
            
            int id = Convert.ToInt32(menuIDTB.Text);

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["PizzaCompanyConnectionString"].ConnectionString;

            SqlCommand comm = new SqlCommand();

            String query = "SELECT Menu.menuName, Menu.makeCost, Menu.sellPrice " +
                                "FROM Menu " +
                                "WHERE Menu.menuID = @id ";

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
                editNameTB.Text = Convert.ToString(reader["menuName"]);
                editCostTB.Text = Convert.ToString(reader["makeCost"]);
                editPriceTB.Text = Convert.ToString(reader["sellPrice"]);
            }
            
            conn.Close();             

        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            string name = editNameTB.Text;
            string cost = editCostTB.Text;
            string price = editPriceTB.Text;

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["PizzaCompanyConnectionString"].ConnectionString;

            SqlCommand comm = new SqlCommand();

            String query = "UPDATE Menu " +
                           "SET Menu.menuName = @name, Menu.makeCost = @cost, Menu.sellPrice = @price " +
                           "WHERE Menu.menuID = @id";

            

            
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

            SqlParameter priceParam = new SqlParameter();
            priceParam.ParameterName = "@price";
            priceParam.SqlDbType = SqlDbType.Int;
            priceParam.Size = 50;
            priceParam.Value = price;

            SqlParameter idParam = new SqlParameter();
            idParam.ParameterName = "@id";
            idParam.SqlDbType = SqlDbType.Int;
            idParam.Size = 4;
            idParam.Value = menuIDTB.Text;

            comm.Parameters.Add(nameParam);
            comm.Parameters.Add(costParam);
            comm.Parameters.Add(priceParam);
            comm.Parameters.Add(idParam);


            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Connection = conn;

            conn.Open();

            comm.ExecuteNonQuery();

            conn.Close();

            editNameTB.Text = "";
            editCostTB.Text = "";
            editPriceTB.Text = "";
            menuIDTB.Text = "";

            GridView1.DataBind();

        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {            

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["PizzaCompanyConnectionString"].ConnectionString;

            SqlCommand comm = new SqlCommand();

            String query = "DELETE FROM Menu WHERE Menu.menuID = @id";


            

            SqlParameter idParam = new SqlParameter();
            idParam.ParameterName = "@id";
            idParam.SqlDbType = SqlDbType.Int;
            idParam.Size = 4;
            idParam.Value = menuIDTB.Text;

            
            comm.Parameters.Add(idParam);


            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Connection = conn;

            conn.Open();

            comm.ExecuteNonQuery();

            conn.Close();
           
            menuIDTB.Text = "";

            GridView1.DataBind();
        }

        protected void returnButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmployeePage.aspx");
        }
    }
}