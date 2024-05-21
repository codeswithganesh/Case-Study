using CarConnect.Exceptions;
using CarConnect.Model;
using CarConnect.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CarConnect.Repository
{
    internal class AdminRepository : IAdminRepository
    {
        private readonly SqlConnection _sqlConnection;
        private readonly SqlCommand _cmd;

        public AdminRepository()
        {
            _sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            _cmd = new SqlCommand();
        }

        public int DeleteAdmin(int adminId)
        {
            try
            {
                _cmd.Parameters.Clear();
                _cmd.CommandText = "DELETE FROM Admin WHERE AdminId = @id";
                _cmd.Parameters.AddWithValue("@id", adminId);
                _cmd.Connection = _sqlConnection;
                _sqlConnection.Open();
                int result = _cmd.ExecuteNonQuery();
                return result;
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Unable to establish a connection to the database.",ex);
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public List<Admin> GetAdminById()
        {
            try
            {
                _cmd.Parameters.Clear();
                List<Admin> lAdmin = new List<Admin>();
                _cmd.CommandText = "SELECT * FROM Admin";
                
                _cmd.Connection = _sqlConnection;
                _sqlConnection.Open();
                SqlDataReader reader = _cmd.ExecuteReader();
                while (reader.Read())
                {
                    Admin admin = new Admin
                    {

                        AdminID = (int)reader["AdminId"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Email = (string)reader["Email"],
                        PhoneNumber = (string)reader["PhoneNumber"],
                        Username = (string)reader["UserName"],
                        Password = (string)reader["Password"],
                        Role = (string)reader["Role"],
                        JoinDate = (DateTime)reader["JoinDate"]
                    };
                    lAdmin.Add(admin);
                }
                return lAdmin;
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Unable to establish a connection to the database.", ex);
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public List<Admin> GetAdminByUsername(string username)
        {
            try
            {
                _cmd.Parameters.Clear();
                List<Admin> lAdmin = new List<Admin>();
                _cmd.CommandText = "SELECT * FROM Admin WHERE UserName = @username";
                _cmd.Parameters.AddWithValue("@username", username);
                _cmd.Connection = _sqlConnection;
                _sqlConnection.Open();
                SqlDataReader reader = _cmd.ExecuteReader();
                while (reader.Read())
                {
                    Admin admin = new Admin
                    {
                        AdminID = (int)reader["AdminId"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Email = (string)reader["Email"],
                        PhoneNumber = (string)reader["PhoneNumber"],
                        Username = (string)reader["UserName"],
                        Password = (string)reader["Password"],
                        Role = (string)reader["Role"],
                        JoinDate = (DateTime)reader["JoinDate"]
                    };
                    lAdmin.Add(admin);
                }
                return lAdmin;
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Unable to establish a connection to the database.", ex);
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public int RegisterAdmin(Admin admin)
        {
            try
            {
                _cmd.Parameters.Clear();
                _cmd.CommandText = "INSERT INTO Admin VALUES (@firstname, @lastname, @email, @phno, @username, @password, @role, @joindate)";
                _cmd.Parameters.AddWithValue("@firstname", admin.FirstName);
                _cmd.Parameters.AddWithValue("@lastname", admin.LastName);
                _cmd.Parameters.AddWithValue("@email", admin.Email);
                _cmd.Parameters.AddWithValue("@phno", admin.PhoneNumber);
                _cmd.Parameters.AddWithValue("@username", admin.Username);
                _cmd.Parameters.AddWithValue("@password", admin.Password);
                _cmd.Parameters.AddWithValue("@role", admin.Role);
                _cmd.Parameters.AddWithValue("@joindate", admin.JoinDate);
                _cmd.Connection = _sqlConnection;
                _sqlConnection.Open();
                int result = _cmd.ExecuteNonQuery();
                return result;
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Unable to establish a connection to the database.", ex);
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public int UpdateAdmin(Admin admin)
        {
            try
            {
                _cmd.Parameters.Clear();
                _cmd.CommandText = "UPDATE Admin SET FirstName = @firstname, LastName = @lastname, Email = @email, PhoneNumber = @phno, UserName = @username, Password = @password, Role = @role, JoinDate = @joindate WHERE AdminId = @id";
                _cmd.Parameters.AddWithValue("@id", admin.AdminID);
                _cmd.Parameters.AddWithValue("@firstname", admin.FirstName);
                _cmd.Parameters.AddWithValue("@lastname", admin.LastName);
                _cmd.Parameters.AddWithValue("@email", admin.Email);
                _cmd.Parameters.AddWithValue("@phno", admin.PhoneNumber);
                _cmd.Parameters.AddWithValue("@username", admin.Username);
                _cmd.Parameters.AddWithValue("@password", admin.Password);
                _cmd.Parameters.AddWithValue("@role", admin.Role);
                _cmd.Parameters.AddWithValue("@joindate", admin.JoinDate);
                _cmd.Connection = _sqlConnection;
                _sqlConnection.Open();
                int result = _cmd.ExecuteNonQuery();
                return result;
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Unable to establish a connection to the database.", ex);
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
    }
}
