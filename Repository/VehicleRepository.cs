using CarConnect.Exceptions;
using CarConnect.Model;
using CarConnect.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CarConnect.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        public VehicleRepository()
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

        public List<Vehicle> GetVehicleById(int vehicleId)
        {
            try
            {
                List<Vehicle> lvehicles = new List<Vehicle>();
                cmd.CommandText = "select * from Vehicle where VehicleId=@id";
                cmd.Parameters.AddWithValue("@id", vehicleId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Vehicle vehicle = new Vehicle();
                    vehicle.VehicleID = (int)reader["VehicleId"];
                    vehicle.Model = (string)reader["Model"];
                    vehicle.Make = (string)reader["Make"];
                    vehicle.Year = (DateTime)reader["Year"];
                    vehicle.Color = (string)reader["Color"];
                    vehicle.RegistrationNumber = (string)reader["RegistrationNumber"];
                    vehicle.Availability = (int)reader["Availability"];
                    vehicle.DailyRate = (double)(decimal)reader["DailyRate"];
                    lvehicles.Add(vehicle);
                }
                sqlConnection.Close();

                if (lvehicles.Count == 0)
                {
                    throw new VehicleNotFoundException($"Vehicle with ID {vehicleId} was not found.");
                }

                return lvehicles;
            }
            catch (SqlException ex)
            
            {
                throw new DatabaseConnectionException("Unable to execute the database query.", ex);
            }
        }

        public List<Vehicle> GetAllVehicles()
        {
            try
            {
                List<Vehicle> lvehicles = new List<Vehicle>();
                cmd.CommandText = "select * from Vehicle";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Vehicle vehicle = new Vehicle();
                    vehicle.VehicleID = (int)reader["VehicleId"];
                    vehicle.Model = (string)reader["Model"];
                    vehicle.Make = (string)reader["Make"];
                    vehicle.Year = (DateTime)reader["Year"];
                    vehicle.Color = (string)reader["Color"];
                    vehicle.RegistrationNumber = (string)reader["RegistrationNumber"];
                    vehicle.Availability = (int)reader["Availability"];
                    vehicle.DailyRate = (double)(decimal)reader["DailyRate"];
                    lvehicles.Add(vehicle);
                }
                sqlConnection.Close();
                return lvehicles;
            }
            catch (SqlException ex)

            {
                throw new DatabaseConnectionException("Unable to execute the database query.", ex);
            }
        }

        public List<Vehicle> GetAvailableVehicles()
        {
            try
            {
                List<Vehicle> avilableVehicles = new List<Vehicle>();
                cmd.CommandText = "select * from Vehicle where Availability=1";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Vehicle vehicle = new Vehicle();
                    vehicle.VehicleID = (int)reader["VehicleId"];
                    vehicle.Model = (string)reader["Model"];
                    vehicle.Make = (string)reader["Make"];
                    vehicle.Year = (DateTime)reader["Year"];
                    vehicle.Color = (string)reader["Color"];
                    vehicle.RegistrationNumber = (string)reader["RegistrationNumber"];
                    vehicle.Availability = (int)reader["Availability"];
                    vehicle.DailyRate = (double)(decimal)reader["DailyRate"];
                    avilableVehicles.Add(vehicle);
                }
                sqlConnection.Close();
                return avilableVehicles;
            }
            catch (SqlException ex)

            {
                throw new DatabaseConnectionException("Unable to execute the database query.", ex);
            }
        }

        public int AddVehicle(Vehicle vehicle)
        {
            try
            {
                cmd.CommandText = "insert into Vehicle values(@model,@make,@year,@color,@rnumber,@avilability,@dailyrate);";
                cmd.Parameters.AddWithValue("@model", vehicle.Model);
                cmd.Parameters.AddWithValue("@make", vehicle.Make);
                cmd.Parameters.AddWithValue("@year", vehicle.Year);
                cmd.Parameters.AddWithValue("@color", vehicle.Color);
                cmd.Parameters.AddWithValue("@rnumber", vehicle.RegistrationNumber);
                cmd.Parameters.AddWithValue("@avilability", vehicle.Availability);
                cmd.Parameters.AddWithValue("@dailyrate", vehicle.DailyRate);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return result;
            }
            catch (SqlException ex)

            {
                throw new DatabaseConnectionException("Unable to execute the database query.", ex);
            }
        }

        public int UpdateVehicle(Vehicle vehicle)
        {
            try
            {
                cmd.CommandText = "update Vehicle set Model=@model,Make=@make,Year=@year,Color=@color,RegistrationNumber=@rnumber,Availability=@avail,DailyRate=@dailyrate where VehicleId=@id";
                cmd.Parameters.AddWithValue("@id", vehicle.VehicleID);
                cmd.Parameters.AddWithValue("@model", vehicle.Model);
                cmd.Parameters.AddWithValue("@make", vehicle.Make);
                cmd.Parameters.AddWithValue("@year", vehicle.Year);
                cmd.Parameters.AddWithValue("@color", vehicle.Color);
                cmd.Parameters.AddWithValue("@rnumber", vehicle.RegistrationNumber);
                cmd.Parameters.AddWithValue("@avail", vehicle.Availability);
                cmd.Parameters.AddWithValue("@dailyrate", vehicle.DailyRate);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();
                sqlConnection.Close();

                if (result == 0)
                {
                    throw new VehicleNotFoundException($"Vehicle with ID {vehicle.VehicleID} was not found.");
                }

                return result;
            }
            catch (SqlException ex)

            {
                throw new DatabaseConnectionException("Unable to execute the database query.", ex);
            }
        }

        public int RemoveVehicle(int vehicleId)
        {
            try
            {
                cmd.CommandText = "delete from Vehicle where VehicleId=@id";
                cmd.Parameters.AddWithValue("@id", vehicleId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();
                sqlConnection.Close();

                if (result == 0)
                {
                    throw new VehicleNotFoundException($"Vehicle with ID {vehicleId} was not found.");
                }

                return result;
            }
            catch (SqlException ex)

            {
                throw new DatabaseConnectionException("Unable to execute the database query.", ex);
            }
        }
        public bool IsvehicleAvilable(int vehicleid)
        {
            try
            {
                List<int> vehicles = new List<int>();
                cmd.CommandText = "Select VehicleId from Vehicle where Availability=1";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["VehicleId"];
                    vehicles.Add(id);
                }
                sqlConnection.Close();
                foreach (int id in vehicles)
                {
                    if (vehicles.Contains(vehicleid))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (SqlException ex)

            {
                throw new DatabaseConnectionException("Unable to execute the database query.", ex);
            }
        }






    }
}
