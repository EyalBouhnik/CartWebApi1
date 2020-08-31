using BussinessObject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataManager
    {
        public Cart GetCart(int id)
        {
            string commandText = "SELECT * FROM Cart WHERE UserId = @ID;";
            SqlDataReader rdr = null;
            Cart cart = new Cart();

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.Add("@ID", SqlDbType.Int);
                command.Parameters["@ID"].Value = id;

                try
                {
                    connection.Open();
                    rdr = command.ExecuteReader();

                    while (rdr.Read())
                    {
                        cart.Id = Convert.ToInt32(rdr["Id"].ToString());
                        cart.UserId = Convert.ToInt32(rdr["UserId"].ToString());
                        cart.ProductId = Convert.ToInt32(rdr["ProductId"].ToString());
                        cart.Quantity = Convert.ToInt32(rdr["Quantity"].ToString());
                        cart.Price = Convert.ToDecimal(rdr["Price"].ToString());
                        cart.DateCreated = Convert.ToDateTime(rdr["DateCreated"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return cart;
        }

        public void InsertCart(Cart newCart)
        {
            string sql = "INSERT INTO Cart(UserId,ProductId,Quantity,Price,DateCreated) VALUES(@UserId,@ProductId,@Quantity,@Price,@DateCreated)";
            
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = newCart.UserId;
                cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = newCart.ProductId;
                cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = newCart.Quantity;
                cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = newCart.Price;
                cmd.Parameters.Add("@DateCreated", SqlDbType.DateTime).Value = DateTime.Now;
                
                cmd.CommandType = CommandType.Text;

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void DeleteCart(int id)
        {
            string sql = "DELETE FROM Cart WHERE Id = @ID";

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                cmd.CommandType = CommandType.Text;

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void UpdateCart(Cart updateCart)
        {
            string sql = "UPDATE Cart set UserId = @UserId,ProductId = @ProductId ,Quantity = @Quantity,Price = @Price Where Id = @Id";

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = updateCart.Id;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = updateCart.UserId;
                cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = updateCart.ProductId;
                cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = updateCart.Quantity;
                cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = updateCart.Price;

                cmd.CommandType = CommandType.Text;

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public string GetConnectionString()
        {
            string conn = string.Empty;

            //this is needed to support unit test connection string
            if (Environment.CurrentDirectory.Contains("IIS Express"))
            {
                return ConfigurationManager.AppSettings["myConnectionString"];
            }
            else
            {
                return "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + System.IO.Path.Combine(
                Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.IndexOf("CartWebApi"))
                , "CartWebApi\\CartWebApi\\App_Data\\SampleDatabase.mdf" + ";Integrated Security=True");
            }
        }
    }
}
