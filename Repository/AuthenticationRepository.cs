using CarConnect.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.Repository
{
    public class AuthenticationRepository
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        public AuthenticationRepository()
        {
            sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            cmd = new SqlCommand();
        }
        public bool AuthenticateCustomer(string username, string password)
        {
            Dictionary<string, string> customerpair = new Dictionary<string, string>();
            cmd.CommandText = "select UserName,Password from Customer";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string user = (string)reader["UserName"];
                string pswrd = (string)reader["Password"];
                customerpair[user] = pswrd;
            }
            sqlConnection.Close();
            if (customerpair.ContainsKey(username))
            {
                string storedpassword = customerpair[username];
                if (storedpassword == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }



        public bool AuthenticateAdmin(string username, string password)
        {
            Dictionary<string, string> Adminpair = new Dictionary<string, string>();
            cmd.CommandText = "select UserName,Password from Admin";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string user = (string)reader["UserName"];
                string pswrd = (string)reader["Password"];
                Adminpair[user] = pswrd;
            }
            sqlConnection.Close();
            if (Adminpair.ContainsKey(username))
            {
                string storedpassword = Adminpair[username];
                if (storedpassword == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}
