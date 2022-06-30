using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class UserDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;


        public UserDAL()
        {
            con = new System.Data.SqlClient.SqlConnection(Startup.ConnectionString);
        }
        public List<User> GetAllUser()
        {
            List<User> list = new List<User>();
            String str = "Select * from User";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                   User u = new User();
                    u.User_Id = Convert.ToInt32(dr["User_Id"]);
                    u.User_FullName = dr["UserFullName"].ToString();
                    u.EmailId = Convert.ToDecimal(dr["Password"]);
                    list.Add(u);
                }
                con.Close();
                return list;
            }
            else
            {

                return null;
            }
        }
        public User GetUserById(int id)
        {
            User u= new User();
            string str = "select * from User where Id=@id";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                  u.User_Id= Convert.ToInt32(dr["User_Id"]);
                   u.User_FullName = dr["UserFull_Name"].ToString();
                    u.EmailId = Convert.ToDecimal(dr["EmailId"]);
                    u.Password = Convert.ToInt32(dr["Password"]);
                    u.RoleId = Convert.ToInt32(dr["RoleId"]);
                }
                con.Close();
                return u;
            }
            else
            {
                con.Close();
                return u;
            }


            return null;
        }
        public int Save(User u)
        {
            string str = "insert into User values(@name,@price)";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@name", u.User_FullName);
            cmd.Parameters.AddWithValue("@Id", u.User_Id);
            cmd.Parameters.AddWithValue("@EmailId", u.EmailId);
            cmd.Parameters.AddWithValue("@Password", u.Password);
            cmd.Parameters.AddWithValue("@RoleId", u.RoleId);

            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

            return 1;
        }
        public int Update(User u)
        {
            string str = "update Course set Name=@name,Price=@price where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id",u.User_Id );
            cmd.Parameters.AddWithValue("@name", u.User_FullName);
            cmd.Parameters.AddWithValue("@Email", u.EmailId);
            cmd.Parameters.AddWithValue("@Password", u.Password);
            cmd.Parameters.AddWithValue("@RoleId", u.RoleId);


            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;


        }

        public int Delete(int id)
        {
            string str = "delete from User where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }

    }
}

  
