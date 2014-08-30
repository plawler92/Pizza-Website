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
    public partial class OrderPage : System.Web.UI.Page
    {
        int cust_id, order_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void proceedButton_Click(object sender, EventArgs e)
        {
            if (firstNameTB.Text != "" || lastNameTB.Text != "" || addressTB.Text != "" || phoneTB.Text != "" || zipTB.Text != "")
            {
                OrderLabel.Visible = true;
                GridView1.Visible = true;
                Label1.Visible = true;
                menuNameTB.Visible = true;
                Label2.Visible = true;
                quantityTB.Visible = true;
                addOrderButton.Visible = true;
                errorLabel.Visible = false;
                updateButton.Visible = true;
                mitButton.Visible = true;
                resetButton.Visible = true;

                SqlConnection conn = new SqlConnection();

                conn.ConnectionString = ConfigurationManager.ConnectionStrings["PizzaCompanyConnectionString"].ConnectionString;

                SqlCommand comm = new SqlCommand();

                String query = "INSERT INTO UserAccount ( UserAccount.userFirst, UserAccount.userLast, UserAccount.userAddress, UserAccount.userPhone, UserAccount.userZip) VALUES(@first, @last, @address, @phone, @zip)";

                SqlParameter firstParam = new SqlParameter();
                firstParam.ParameterName = "@first";
                firstParam.SqlDbType = SqlDbType.NVarChar;
                firstParam.Size = 50;
                firstParam.Value = firstNameTB.Text;

                SqlParameter lastParam = new SqlParameter();
                lastParam.ParameterName = "@last";
                lastParam.SqlDbType = SqlDbType.NVarChar;
                lastParam.Size = 50;
                lastParam.Value = lastNameTB.Text;

                SqlParameter addressParam = new SqlParameter();
                addressParam.ParameterName = "@address";
                addressParam.SqlDbType = SqlDbType.NVarChar;
                addressParam.Size = 50;
                addressParam.Value = addressTB.Text;

                SqlParameter phoneParam = new SqlParameter();
                phoneParam.ParameterName = "@phone";
                phoneParam.SqlDbType = SqlDbType.NVarChar;
                phoneParam.Size = 50;
                phoneParam.Value = phoneTB.Text;

                SqlParameter zipParam = new SqlParameter();
                zipParam.ParameterName = "@zip";
                zipParam.SqlDbType = SqlDbType.NVarChar;
                zipParam.Size = 50;
                zipParam.Value = zipTB.Text;

                comm.Parameters.Add(firstParam);
                comm.Parameters.Add(lastParam);
                comm.Parameters.Add(addressParam);
                comm.Parameters.Add(phoneParam);
                comm.Parameters.Add(zipParam);

                comm.CommandText = query;
                comm.CommandType = CommandType.Text;
                comm.Connection = conn;

                conn.Open();

                comm.ExecuteNonQuery();

                conn.Close();

                query = "SELECT userID FROM UserAccount " +
                        "WHERE userFirst = @first AND userLast = @last AND userAddress = @address AND userZip = @zip";


                comm.CommandText = query;

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();

                
                while (reader.Read())
                {
                    cust_id = Convert.ToInt32(reader["userID"]);
                }
                Session.Add("custID", cust_id);

                conn.Close();

                query = "INSERT INTO Orders (Orders.userID, Orders.orderDate) " +
                        "VALUES (@cust_id, @date)";

                SqlParameter custParam = new SqlParameter();
                custParam.ParameterName = "@cust_id";
                custParam.SqlDbType = SqlDbType.Int;
                custParam.Size = 50;
                custParam.Value = cust_id;

                SqlParameter dateParam = new SqlParameter();
                dateParam.ParameterName = "@date";
                dateParam.SqlDbType = SqlDbType.Date;
                dateParam.Size = 50;
                dateParam.Value = DateTime.Now;

                comm.Parameters.Remove(firstParam);
                comm.Parameters.Remove(lastParam);
                comm.Parameters.Remove(addressParam);
                comm.Parameters.Remove(phoneParam);
                comm.Parameters.Remove(zipParam);

                comm.Parameters.Add(custParam);
                comm.Parameters.Add(dateParam);                                    

                comm.CommandText = query;
                comm.CommandType = CommandType.Text;
                comm.Connection = conn;

                conn.Open();

                comm.ExecuteNonQuery();

                conn.Close();

                query = "SELECT Orders.orderID FROM Orders WHERE Orders.userID = @cust_id AND Orders.orderDate = @date";

                comm.CommandText = query;

                conn.Open();

                reader = comm.ExecuteReader();
                

                while (reader.Read())
                {
                    
                    order_id = Convert.ToInt32(reader["orderID"]);
                }
                Session.Add("orderID", order_id);
         
                conn.Close();

                firstNameTB.Enabled = false;
                lastNameTB.Enabled = false;
                addressTB.Enabled = false;
                phoneTB.Enabled = false;
                zipTB.Enabled = false;

                proceedButton.Enabled = false;
               
               
            }
            else
            {
                errorLabel.Visible = true;
            }


        }

        protected void addOrderButton_Click(object sender, EventArgs e)
        {
            //messing up because it's inserting first            

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["PizzaCompanyConnectionString"].ConnectionString;

            SqlCommand comm = new SqlCommand();

            String query = "INSERT INTO OrderDetails(OrderDetails.orderID, OrderDetails.menuID, OrderDetails.quantity) VALUES (@orderID, @menuID, @quant)";
            
            SqlParameter orderParam = new SqlParameter();
            orderParam.ParameterName = "@orderID";
            orderParam.SqlDbType = SqlDbType.Int;
            orderParam.Size = 50;
            orderParam.Value = Session["orderID"];

            SqlParameter menuParam = new SqlParameter();
            menuParam.ParameterName = "@menuID";
            menuParam.SqlDbType = SqlDbType.Int;
            menuParam.Size = 50;
            menuParam.Value = Convert.ToInt32(menuNameTB.Text);

            SqlParameter quantParam = new SqlParameter();
            quantParam.ParameterName = "@quant";
            quantParam.SqlDbType = SqlDbType.Int;
            quantParam.Size = 50;
            quantParam.Value = Convert.ToInt32(quantityTB.Text);

            comm.Parameters.Add(orderParam);
            comm.Parameters.Add(menuParam);
            comm.Parameters.Add(quantParam);

            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Connection = conn;

            conn.Open();

            comm.ExecuteNonQuery();

            conn.Close();

            comm.Parameters.Remove(quantParam);
            
            query = "SELECT Menu.menuName, OrderDetails.quantity, Menu.sellPrice FROM OrderDetails INNER JOIN " +
                    " Menu ON OrderDetails.menuID = Menu.menuID WHERE (OrderDetails.orderID = @orderID) ";

            comm.CommandText = query;

            conn.Open();

           SqlDataReader reader = comm.ExecuteReader();
            order.Text = "";
            totalLabel.Text = "";
            int total_cost = 0;

            while (reader.Read())
            {
                order.Text += Convert.ToString(reader["menuName"]) + "     ";
                order.Text += Convert.ToString(reader["quantity"]) + "    $";              
                order.Text += Convert.ToString(reader["sellPrice"]) + " <br/>";
                total_cost += Convert.ToInt32(reader["quantity"]) * Convert.ToInt32(reader["sellPrice"]);
                totalLabel.Text = "$"+Convert.ToString(total_cost);
            }
            menuNameTB.Text = "";
            quantityTB.Text = "";


        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["PizzaCompanyConnectionString"].ConnectionString;

            SqlCommand comm = new SqlCommand();

            String query = "SELECT OrderDetails.quantity FROM OrderDetails  "+
                            "WHERE OrderDetails.orderID = @orderID AND OrderDetails.menuID = @menuID";

            SqlParameter orderParam = new SqlParameter();
            orderParam.ParameterName = "@orderID";
            orderParam.SqlDbType = SqlDbType.Int;
            orderParam.Size = 50;
            orderParam.Value = Session["orderID"];

            SqlParameter menuParam = new SqlParameter();
            menuParam.ParameterName = "@menuID";
            menuParam.SqlDbType = SqlDbType.Int;
            menuParam.Size = 50;
            menuParam.Value = Convert.ToInt32(menuNameTB.Text);

            comm.Parameters.Add(orderParam);
            comm.Parameters.Add(menuParam);            

            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Connection = conn;

            conn.Open();

            SqlDataReader reader = comm.ExecuteReader();

            int quantity = 0;

            while (reader.Read())
            {
                quantity = Convert.ToInt32(reader["quantity"]);
            }

            conn.Close();

            query = "UPDATE OrderDetails SET OrderDetails.quantity = @quant " +
                    "WHERE OrderDetails.orderID = @orderID AND OrderDetails.menuID = @menuID";

            SqlParameter quantParam = new SqlParameter();
            quantParam.ParameterName = "@quant";
            quantParam.SqlDbType = SqlDbType.Int;
            quantParam.Size = 50;
            quantParam.Value = Convert.ToInt32(quantityTB.Text)+quantity;

            comm.Parameters.Add(quantParam);

            comm.CommandText = query;

            conn.Open();

            comm.ExecuteNonQuery();

            conn.Close();

            query = "SELECT Menu.menuName, OrderDetails.quantity, Menu.sellPrice FROM OrderDetails INNER JOIN " +
                    " Menu ON OrderDetails.menuID = Menu.menuID WHERE (OrderDetails.orderID = @orderID) ";

            comm.CommandText = query;

            conn.Open();

            reader = comm.ExecuteReader();
            order.Text = "";
            totalLabel.Text = "";
            int total_cost = 0;

            while (reader.Read())
            {
                order.Text += Convert.ToString(reader["menuName"]) + "     ";
                order.Text += Convert.ToString(reader["quantity"]) + "    $";
                order.Text += Convert.ToString(reader["sellPrice"]) + " <br/>";
                total_cost += Convert.ToInt32(reader["quantity"]) * Convert.ToInt32(reader["sellPrice"]);
                totalLabel.Text = "$" + Convert.ToString(total_cost);
            }
            menuNameTB.Text = "";
            quantityTB.Text = "";

        }

        protected void menuNameTB_TextChanged(object sender, EventArgs e)
        {
            // do nothing
        }

        protected void mitButton_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["PizzaCompanyConnectionString"].ConnectionString;

            SqlCommand comm = new SqlCommand();

            String query = "UPDATE Orders SET Orders.orderTime = @time WHERE orderID = @orderID";
            DateTime.Now.TimeOfDay.ToString();

            SqlParameter timeParam = new SqlParameter();
            timeParam.ParameterName = "@time";
            timeParam.SqlDbType = SqlDbType.Time;
            timeParam.Size = 50;
            timeParam.Value = DateTime.Now.TimeOfDay;

            SqlParameter orderParam = new SqlParameter();
            orderParam.ParameterName = "@orderID";
            orderParam.SqlDbType = SqlDbType.Int;
            orderParam.Size = 50;
            orderParam.Value = Session["orderID"];

            comm.Parameters.Add(timeParam);
            comm.Parameters.Add(orderParam);

            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Connection = conn;

            conn.Open();

            comm.ExecuteNonQuery();

            conn.Close();

            Response.Redirect("ConfirmationPage.aspx");
        }

        protected void resetButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["PizzaCompanyConnectionString"].ConnectionString;

            SqlCommand comm = new SqlCommand();

            String query = "DELETE FROM OrderDetails WHERE OrderDetails.orderID = @orderID";

            SqlParameter orderParam = new SqlParameter();
            orderParam.ParameterName = "@orderID";
            orderParam.SqlDbType = SqlDbType.Int;
            orderParam.Size = 50;
            orderParam.Value = Session["orderID"];            

            comm.Parameters.Add(orderParam);            

            comm.CommandText = query;
            comm.CommandType = CommandType.Text;
            comm.Connection = conn;

            conn.Open();

            comm.ExecuteNonQuery();

            conn.Close();

            order.Text = "";
            totalLabel.Text = "";
        }

    }
}