using CarConnect.Exceptions;
using CarConnect.Model;
using CarConnect.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CarConnect.Service;

namespace CarConnect.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        public CustomerRepository()
        {
            try
            {
                sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
                cmd = new SqlCommand();
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("Unable to establish a connection to the database.", ex);
            }
        }

        public List<Customer> GetCustomerById()
        {
            List<Customer> lcustomer = new List<Customer>();
            try
            {
                cmd.Parameters.Clear(); 
                cmd.CommandText = "select * from Customer";
               // cmd.Parameters.AddWithValue("@id", customerId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.CustomerID = (int)reader["CustomerId"];
                    customer.FirstName = (string)reader["FirstName"];
                    customer.LastName = (string)reader["LastName"];
                    customer.Email = (string)reader["Email"];
                    customer.PhoneNumber = (string)reader["phoneNumber"];
                    customer.Address = (string)reader["Address"];
                    customer.Username = (string)reader["UserName"];
                    customer.Password = (string)reader["Password"];
                    customer.RegistrationDate = (DateTime)reader["RegistrationDate"];
                    lcustomer.Add(customer);
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("An error occurred while fetching customer data from the database.", ex);
            }
            finally
            {
                sqlConnection.Close();
            }
            return lcustomer;
        }

        public List<Customer> GetCustomerByUsername(string username)
        {
            List<Customer> lcustomer = new List<Customer>();
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "select * from Customer where Username=@username";
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.CustomerID = (int)reader["CustomerId"];
                    customer.FirstName = (string)reader["FirstName"];
                    customer.LastName = (string)reader["LastName"];
                    customer.Email = (string)reader["Email"];
                    customer.PhoneNumber = (string)reader["phoneNumber"];
                    customer.Address = (string)reader["Address"];
                    customer.Username = (string)reader["UserName"];
                    customer.Password = (string)reader["Password"];
                    customer.RegistrationDate = (DateTime)reader["RegistrationDate"];
                    lcustomer.Add(customer);
                }
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("An error occurred while fetching customer data from the database.", ex);
            }
            finally
            {
                sqlConnection.Close();
            }
            return lcustomer;
        }

        public int RegisterCustomer(Customer customer)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = @"insert into Customer values(@firstname,@lastname,@email,@phoneno,@address
                                ,@username,@password,@registrationdate)";
                cmd.Parameters.AddWithValue("@firstname", customer.FirstName);
                cmd.Parameters.AddWithValue("@lastname", customer.LastName);
                cmd.Parameters.AddWithValue("@email", customer.Email);
                cmd.Parameters.AddWithValue("@phoneno", customer.PhoneNumber);
                cmd.Parameters.AddWithValue("@address", customer.Address);
                cmd.Parameters.AddWithValue("@username", customer.Username);
                cmd.Parameters.AddWithValue("@password", customer.Password);
                cmd.Parameters.AddWithValue("@registrationdate", customer.RegistrationDate);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("An error occurred while registering the customer in the database.", ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public int UpdateCustomer(Customer customer)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = @"update Customer
                                    set FirstName=@firstname,LastName=@lastname,Email=@email,phoneNumber=@phoneno,Address=@address,Username=@username,
                                    Password=@password,RegistrationDate=@registrationdate where CustomerId=@id";
                cmd.Parameters.AddWithValue("@id", customer.CustomerID);
                cmd.Parameters.AddWithValue("@firstname", customer.FirstName);
                cmd.Parameters.AddWithValue("@lastname", customer.LastName);
                cmd.Parameters.AddWithValue("@email", customer.Email);
                cmd.Parameters.AddWithValue("@phoneno", customer.PhoneNumber);
                cmd.Parameters.AddWithValue("@address", customer.Address);
                cmd.Parameters.AddWithValue("@username", customer.Username);
                cmd.Parameters.AddWithValue("@password", customer.Password);
                cmd.Parameters.AddWithValue("@registrationdate", customer.RegistrationDate);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("An error occurred while updating the customer in the database.", ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public int UpdateCustomerAuto(Customer customer)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = @"update Customer
                                    set FirstName=@firstname,LastName=@lastname,Email=@email,phoneNumber=@phoneno,Address=@address,Username=@username,
                                    Password=@password,RegistrationDate=@registrationdate where CustomerId=@id";
                cmd.Parameters.AddWithValue("@id", AuthenticationService.customerId);
                cmd.Parameters.AddWithValue("@firstname", customer.FirstName);
                cmd.Parameters.AddWithValue("@lastname", customer.LastName);
                cmd.Parameters.AddWithValue("@email", customer.Email);
                cmd.Parameters.AddWithValue("@phoneno", customer.PhoneNumber);
                cmd.Parameters.AddWithValue("@address", customer.Address);
                cmd.Parameters.AddWithValue("@username", customer.Username);
                cmd.Parameters.AddWithValue("@password", customer.Password);
                cmd.Parameters.AddWithValue("@registrationdate", customer.RegistrationDate);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("An error occurred while updating the customer in the database.", ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public int DeleteCustomer(int customerId)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "delete from Customer where CustomerId=@id";
                cmd.Parameters.AddWithValue("@id", customerId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("An error occurred while deleting the customer from the database.", ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public int GetCustomerId(string username)
        {
            try
            {
                cmd.Parameters.Clear(); 
                cmd.CommandText = "select CustomerId from Customer where UserName=@username";
                cmd.Parameters.AddWithValue("username", username);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                object result = cmd.ExecuteScalar();
                if(result == null)
                {
                    return 0;
                }
                return (int)result;
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("An error occurred while deleting the customer from the database.", ex);
            }
            finally
            {
                sqlConnection.Close();
            }


        }
    }
}
