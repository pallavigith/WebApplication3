using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class ProductDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;


        public ProductDAL()
        {
            con = new System.Data.SqlClient.SqlConnection(Startup.ConnectionString);
        }
        public List<Product> GetAllProducts()
        {
            List<Product> list = new List<Product>();
            String str = "Select * from Product";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product p = new Product();
                    p.Product_Id = Convert.ToInt32(dr["Product_Id"]);
                    p.Product_Name = dr["Product_Name"].ToString();
                    p.Product_Price = Convert.ToDecimal(dr["Product_Price"]);
                    p.Company_Name = dr["Company_Name"].ToString();
                    p.Product_Description = dr["Product_Description"].ToString();
                    list.Add(p);
                }
                con.Close();
                return list;
            }
            else
            {

                return null;
            }
        }
        public Product GetProductById(int id)
        {
            Product p = new Product();
            string str = "select * from Product where Id=@id";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    p.Product_Id = Convert.ToInt32(dr["Product_Id"]);
                    p.Product_Name = dr["Product_Name"].ToString();
                    p.Product_Price = Convert.ToDecimal(dr["Product_Price"]);
                    p.Company_Name = dr["Company_Name"].ToString();
                    p.Product_Description = dr["Product_Description"].ToString();
                }
                con.Close();
                return p;
            }
            else
            {
                con.Close();
                return p;
            }


            return null;
        }
        public int Save(Product prod)
        {
            string str = "insert into Product values(@name,@price)";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@name", prod.Product_Name);
            cmd.Parameters.AddWithValue("@price", prod.Product_Price);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

            return 1;
        }
        public int Update(Product prod)
        {
            string str = "update Product set Name=@name,Price=@price where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", prod.Product_Id);
            cmd.Parameters.AddWithValue("@name", prod.Product_Name);
            cmd.Parameters.AddWithValue("@price", prod.Product_Price);
            cmd.Parameters.AddWithValue("@Company", prod.Company_Name);
            cmd.Parameters.AddWithValue("@Description", prod.Product_Description);

            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;


        }

        public int Delete(int id)
        {
            string str = "delete from Product where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }

    }
}


    

