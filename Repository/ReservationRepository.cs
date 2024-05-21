using CarConnect.Exceptions;
using CarConnect.Model;
using CarConnect.Service;
using CarConnect.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CarConnect.Repository
{
    internal class ReservationRepository : IReservationRepository
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;

        public delegate void SendSMSNotificationDelegate(string phoneNumber, string message);
        public delegate void SendEmailNotificationDelegate(string email, string subject, string body);

        public event SendSMSNotificationDelegate ReservationConfirmedSMS;
        public event SendEmailNotificationDelegate ReservationConfirmedEmail;

        public event SendSMSNotificationDelegate ReservationCancelledSMS;
        public event SendEmailNotificationDelegate ReservationCancelledEmail;

        public event SendSMSNotificationDelegate ReservationUpdatedSMS;
        public event SendEmailNotificationDelegate ReservationUpdatedEmail;

        public ReservationRepository()
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

        public int CancelReservation(int reservationId)
        {
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "delete from Reservation where ReservationId=@id";
                cmd.Parameters.AddWithValue("@id", reservationId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();
                OnReservationCancelled("customerPhoneNumber", "customer@example.com", "Reservation Cancelled", "Your reservation has been cancelled.");
                return result;
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("An error occurred while cancelling the reservation in the database.", ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public int CreateReservation(Reservation reservationData)
        {
            try
            {
                cmd.Parameters.Clear();
                double totalCost = TotalCost(reservationData.VehicleID, reservationData.StartDate, reservationData.EndDate);
                reservationData.TotalCost = totalCost;
                cmd.CommandText = "insert into Reservation values(@customerId,@vehicleid,@startdate,@enddate,@Totalcost,@status)";
                cmd.Parameters.AddWithValue("@customerid", reservationData.CustomerID);
                cmd.Parameters.AddWithValue("@vehicleid", reservationData.VehicleID);
                cmd.Parameters.AddWithValue("@startdate", reservationData.StartDate);
                cmd.Parameters.AddWithValue("@enddate", reservationData.EndDate);
                cmd.Parameters.AddWithValue("@Totalcost", reservationData.TotalCost);
                cmd.Parameters.AddWithValue("@status", "Available");
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();
                //OnReservationConfirmed("customerPhoneNumber", "customer@example.com", "Reservation Confirmed", "Your reservation has been confirmed.");
                //sqlConnection.Close();
                //if (result != 0)
                //{
                //    UpdateStatus(vehicleId);
                //}
                return result;
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("An error occurred while creating the reservation in the database.", ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void UpdateStatus(int vehileId,int availability)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "update Vehicle set Availability=@avail where VehicleId=@vid";
            cmd.Parameters.AddWithValue("@vid",vehileId);
            cmd.Parameters.AddWithValue("@avail", availability);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public double TotalCost(int vechicleid,DateTime start,DateTime end)
        {
            double cost;
            cmd.Parameters.Clear();
            cmd.CommandText = "select DailyRate from Vehicle where VehicleId=@id";
            cmd.Parameters.AddWithValue("@id", vechicleid);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            object result= cmd.ExecuteScalar();
            sqlConnection.Close();
            if(result != null)
            {
                cost= (double)(decimal)result;
            }
            else
            {
                cost = 0;
            }
            DateTime startDate = start;
            DateTime endDate = end;

            // Calculate the difference in days
            TimeSpan difference = endDate - startDate;
            int daysDifference = (int)difference.TotalDays;
            if (daysDifference < 1)
            {
                throw new Exception("End date must be after start date.");
            }
            double totalcost=cost*daysDifference;
            

            return totalcost;

        }

        public List<Reservation> GetReservationById()
        {
            List<Reservation> lreservation = new List<Reservation>();
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "select * from Reservation";
                //cmd.Parameters.AddWithValue("@id", ReservationId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Reservation reservation = new Reservation();
                    reservation.ReservationID = (int)reader["ReservationId"];
                    reservation.CustomerID = (int)reader["CustomerID"];
                    reservation.VehicleID = (int)reader["VechileId"];
                    reservation.StartDate = (DateTime)reader["StartDate"];
                    reservation.EndDate = (DateTime)reader["EndDate"];
                    reservation.TotalCost = (double)(decimal)reader["TotalCost"];
                    reservation.Status = (string)reader["Status"];
                    lreservation.Add(reservation);
                }
                return lreservation;
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("An error occurred while fetching reservation data from the database.", ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public List<Reservation> GetReservations()
        {
            List<Reservation> lreservation = new List<Reservation>();
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "select * from Reservation";
                
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Reservation reservation = new Reservation();
                    reservation.ReservationID = (int)reader["ReservationId"];
                    reservation.CustomerID = (int)reader["CustomerID"];
                    reservation.VehicleID = (int)reader["VechileId"];
                    reservation.StartDate = (DateTime)reader["StartDate"];
                    reservation.EndDate = (DateTime)reader["EndDate"];
                    reservation.TotalCost = (double)(decimal)reader["TotalCost"];
                    reservation.Status = (string)reader["Status"];
                    lreservation.Add(reservation);
                }
                return lreservation;
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("An error occurred while fetching reservation data from the database.", ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public List<Reservation> GetReservationsByCustomerId(int customerId)
        {
            List<Reservation> lreservation = new List<Reservation>();
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "select * from Reservation where CustomerId=@id";
                cmd.Parameters.AddWithValue("@id", customerId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Reservation reservation = new Reservation();
                    reservation.ReservationID = (int)reader["ReservationId"];
                    reservation.CustomerID = (int)reader["CustomerID"];
                    reservation.VehicleID = (int)reader["VechileId"];
                    reservation.StartDate = (DateTime)reader["StartDate"];
                    reservation.EndDate = (DateTime)reader["EndDate"];
                    reservation.TotalCost = (double)(decimal)reader["TotalCost"];
                    reservation.Status = (string)reader["Status"];
                    lreservation.Add(reservation);
                }
                return lreservation;
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("An error occurred while fetching reservation data from the database.", ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public int UpdateReservation(Reservation reservationData)
        {
           try
            {
                cmd.Parameters.Clear();
                double totalCost = TotalCost(reservationData.VehicleID, reservationData.StartDate, reservationData.EndDate);
                reservationData.TotalCost = totalCost;

                
                cmd.CommandText = "UPDATE Reservation SET StartDate=@startdate, EndDate=@enddate, TotalCost=@totalcost, Status=@status WHERE ReservationId=@rid";
                cmd.Parameters.AddWithValue("@rid", reservationData.ReservationID);
                cmd.Parameters.AddWithValue("@startdate", reservationData.StartDate);
                cmd.Parameters.AddWithValue("@enddate", reservationData.EndDate);
                cmd.Parameters.AddWithValue("@totalcost", reservationData.TotalCost);
                cmd.Parameters.AddWithValue("@status", "Available");  // Corrected spelling

                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();
            //OnReservationUpdated("customerPhoneNumber", "customer@example.com", "Reservation Updated", "Your reservation has been updated.");
            sqlConnection.Close();
            return result;

        }
            catch (SqlException ex)
            {
                
                Console.WriteLine("SQL Exception: " + ex.Message);
                throw new DatabaseConnectionException("An error occurred while updating the reservation in the database.", ex);
    }
            finally
            {
                sqlConnection.Close();
            }
        }


        private void OnReservationConfirmed(string phoneNumber, string email, string subject, string body)
        {
            ReservationConfirmedSMS?.Invoke(phoneNumber, "Your reservation has been confirmed.");
            ReservationConfirmedEmail?.Invoke(email, subject, body);
        }

        private void OnReservationCancelled(string phoneNumber, string email, string subject, string body)
        {
            ReservationCancelledSMS?.Invoke(phoneNumber, "Your reservation has been cancelled.");
            ReservationCancelledEmail?.Invoke(email, subject, body);
        }

        private void OnReservationUpdated(string phoneNumber, string email, string subject, string body)
        {
            ReservationUpdatedSMS?.Invoke(phoneNumber, "Your reservation has been updated.");
            ReservationUpdatedEmail?.Invoke(email, subject, body);
        }

        public int CreateReservationAuto(Reservation reservationData)
        {
            try
            {
                cmd.Parameters.Clear();
                double totalCost = TotalCost(reservationData.VehicleID, reservationData.StartDate, reservationData.EndDate);
                reservationData.TotalCost = totalCost;
                cmd.CommandText = "insert into Reservation values(@customerId,@vehicleid,@startdate,@enddate,@Totalcost,@status)";
                cmd.Parameters.AddWithValue("@customerid", reservationData.CustomerID);
                cmd.Parameters.AddWithValue("@vehicleid", reservationData.VehicleID);
                cmd.Parameters.AddWithValue("@startdate", reservationData.StartDate);
                cmd.Parameters.AddWithValue("@enddate", reservationData.EndDate);
                cmd.Parameters.AddWithValue("@Totalcost", reservationData.TotalCost);
                cmd.Parameters.AddWithValue("@status", "Booked");
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();
                //OnReservationConfirmed("customerPhoneNumber", "customer@example.com", "Reservation Confirmed", "Your reservation has been confirmed.");
                //sqlConnection.Close();
                //if (result != 0)
                //{
                //    UpdateStatus(vehicleId);
                //}
                return result;
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("An error occurred while creating the reservation in the database.", ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public int UpdateReservationAuto(Reservation reservationData)
        {
            try
            {
                cmd.Parameters.Clear();
                double totalCost = TotalCost(reservationData.VehicleID, reservationData.StartDate, reservationData.EndDate);
                reservationData.TotalCost = totalCost;
                cmd.CommandText = "Update Reservation set StartDate=@startdate,EndDate=@enddate,TotalCost=@Totalcost,Status=@status where ReservationId=@id";
                cmd.Parameters.AddWithValue("@id", reservationData.ReservationID);
               
                cmd.Parameters.AddWithValue("@startdate", reservationData.StartDate);
                cmd.Parameters.AddWithValue("@enddate", reservationData.EndDate);
                cmd.Parameters.AddWithValue("@Totalcost", reservationData.TotalCost);
                cmd.Parameters.AddWithValue("@status", "Booked");
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();
                //OnReservationUpdated("customerPhoneNumber", "customer@example.com", "Reservation Updated", "Your reservation has been updated.");
                return result;
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("An error occurred while updating the reservation in the database.", ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public List<Reservation> GetReservationBycustIdAuto()
        {
            List<Reservation> lreservation = new List<Reservation>();
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "select * from Reservation where CustomerId=@id";
                cmd.Parameters.AddWithValue("@id", AuthenticationService.customerId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Reservation reservation = new Reservation();
                    reservation.ReservationID = (int)reader["ReservationId"];
                    reservation.CustomerID = (int)reader["CustomerID"];
                    reservation.VehicleID = (int)reader["VechileId"];
                    reservation.StartDate = (DateTime)reader["StartDate"];
                    reservation.EndDate = (DateTime)reader["EndDate"];
                    reservation.TotalCost = (double)(decimal)reader["TotalCost"];
                    reservation.Status = (string)reader["Status"];
                    lreservation.Add(reservation);
                }
                return lreservation;
            }
            catch (SqlException ex)
            {
                throw new DatabaseConnectionException("An error occurred while fetching reservation data from the database.", ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }


        public int GetVehicleId(int reservationid)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "select VechileId from Reservation where ReservationId=@reservationid";
            cmd.Parameters.AddWithValue("@reservationid", reservationid);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            object result= cmd.ExecuteScalar();
            sqlConnection.Close();
            if(result != null )
            {
                return (int)result;
            }
            else
            {
                return 0;
            }

        }

    }
}
