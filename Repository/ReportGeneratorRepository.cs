using CarConnect.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.Repository
{
    internal class ReportGeneratorRepository
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        public ReportGeneratorRepository()
        {
            sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            cmd = new SqlCommand();
        }
        public List<Object[]> ReservationHistoryBCustomer(string username)
        {
            List<Object[]> list = new List<object[]>();
            cmd.CommandText = @"select concat(FirstName,' ',LastName) as Name,Model,StartDate,EndDate,TotalCost,Status from Reservation join
            Customer on Reservation.CustomerId=Customer.CustomerId
            join Vehicle
            on Reservation.VechileId=Vehicle.VehicleId
            where Username=@username;";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                object[] reservationInfo = new object[]
                {
                    reader["Name"],
                    reader["Model"],
                    reader["StartDate"],
                    reader["EndDate"],
                    reader["TotalCost"],
                    reader["Status"]

                };
                list.Add(reservationInfo);

            }
            return list;
            sqlConnection.Close();
        }

        public List<Object[]> ReservationHistoryBModel(string model)
        {
            List<Object[]> list = new List<object[]>();
            cmd.CommandText = @"select concat(FirstName,' ',LastName) as Name,Model,StartDate,EndDate,TotalCost,Status from Reservation join
            Customer on Reservation.CustomerId=Customer.CustomerId
            join Vehicle
            on Reservation.VechileId=Vehicle.VehicleId
            where Model=@model;";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@model", model);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                object[] reservationInfo = new object[]
                {
                    reader["Name"],
                    reader["Model"],
                    reader["StartDate"],
                    reader["EndDate"],
                    reader["TotalCost"],
                    reader["Status"]

                };
                list.Add(reservationInfo);

            }
            sqlConnection.Close();
            return list;
        }
        //public List<Object[]> ReservationHistoryBDate(DateTime start,DateTime end)
        //{
        //    List<Object[]> list = new List<object[]>();
        //    cmd.CommandText = @"select concat(FirstName,' ',LastName) as Name,Model,StartDate,EndDate,TotalCost,Status from Reservation join
        //    Customer on Reservation.CustomerId=Customer.CustomerId
        //    join Vehicle
        //    on Reservation.VechileId=Vehicle.VehicleId
        //    where StartDate>=@start and EndDate<=@end;";
        //    cmd.Parameters.Clear();
        //    cmd.Parameters.AddWithValue("@start", start);
        //    cmd.Parameters.AddWithValue("@end", end);
        //    cmd.Connection = sqlConnection;
        //    sqlConnection.Open();
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        object[] reservationInfo = new object[]
        //        {
        //            reader["Name"],
        //            reader["Model"],
        //            reader["StartDate"],
        //            reader["EndDate"],
        //            reader["TotalCost"],
        //            reader["Status"]

        //        };
        //        list.Add(reservationInfo);

        //    }
        //    return list;
        //}

        public List<Object[]> RevenueReport()
        {
            List<Object[]> list = new List<object[]>();
            cmd.CommandText = @"select Model,sum(TotalCost) as cost from Reservation
            join Vehicle
            on Reservation.VechileId=Vehicle.VehicleId
            group by model;";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                object[] revenueInfo = new object[]
                {
                    reader["Model"],
                    reader["cost"]
                };
                list.Add(revenueInfo);
            }
            sqlConnection.Close();
            return list;


        }

        public List<Object[]> VehicleUtilizationReport()
        {
            List<Object[]> list = new List<object[]>();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @"
            SELECT Model,
                   SUM(DATEDIFF(MINUTE, StartDate, EndDate)) AS TotalMinutesBooked,
                   DATEDIFF(DAY, MIN(StartDate), MAX(EndDate)) AS TotalDays
            FROM Reservation
            JOIN Vehicle ON Reservation.VechileId = Vehicle.VehicleId
            GROUP BY Model;
        ";

               

                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string model = reader["Model"].ToString();
                    int totalMinutesBooked = Convert.ToInt32(reader["TotalMinutesBooked"]);
                    int totalDays = Convert.ToInt32(reader["TotalDays"]);

                    double utilizationPercentage = totalMinutesBooked / (double)(totalDays * 24 * 60) * 100;

                    object[] utilizationInfo = new object[]
                    {
                model,
                totalMinutesBooked,
                totalDays,
                utilizationPercentage
                    };
                    list.Add(utilizationInfo);
                }
            }
            sqlConnection.Close();

            return list;
        }
    }
}
