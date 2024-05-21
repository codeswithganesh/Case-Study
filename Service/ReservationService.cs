using CarConnect.Exceptions;
using CarConnect.Model;
using CarConnect.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.Service
{
    internal class ReservationService : IReservationService
    {
        readonly IReservationRepository _reservationRepository;
        readonly VehicleRepository _vehicleRepository;
        public ReservationService()
        {
            _reservationRepository = new ReservationRepository();
            _vehicleRepository = new VehicleRepository();
        }
        public void CancelReservation()
        {
            try
            {
                Console.WriteLine("Enter the Reservation Id you want to cancel");
                int id = int.Parse(Console.ReadLine());
                int vehicelid=_reservationRepository.GetVehicleId(id);
                int result = _reservationRepository.CancelReservation(id);

                if (result > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Cancel Reservation successful");
                    _reservationRepository.UpdateStatus(vehicelid, 1);
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Cancel Reservation not successful");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid input. Please enter a valid Reservation Id.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void CreateReservation()
        {
            try
            {
                Reservation reservation = new Reservation();
                Console.WriteLine("Enter the CustomerId");
                int id= int.Parse(Console.ReadLine());
                reservation.CustomerID = id;

                Console.WriteLine("Enter the VehicleId");
                reservation.VehicleID = int.Parse(Console.ReadLine());

                // Check if the vehicle is available
                bool isVehicleAvailable = _vehicleRepository.IsvehicleAvilable(reservation.VehicleID);
                if (!isVehicleAvailable)
                {
                    throw new ReservationException("The vehicle is already reserved or unavailable.");
                }

                Console.WriteLine("Enter the StartDate (yyyy-MM-dd)");
                DateTime date = DateTime.Parse(Console.ReadLine());
                if (date > DateTime.Now)
                {
                    throw new InvalidDateException("Date Should be Less than the Todays Date");
                }

                reservation.StartDate = date;
                Console.WriteLine("Enter the EndDate (yyyy-MM-dd)");
                DateTime date1 = DateTime.Parse(Console.ReadLine());
                if (date1 > DateTime.Now)
                {
                    throw new InvalidDateException("Date Should be Less than the Todays Date");
                }
                reservation.EndDate = date1;

                int result = _reservationRepository.CreateReservation(reservation);

                if (result > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Create Reservation successful");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Total Cost: {reservation.TotalCost}");
                    _reservationRepository.UpdateStatus(reservation.VehicleID,0);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Create Reservation not successful, please try again later");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (ReservationException ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (InvalidDateException ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid input. Please enter the correct data format.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

        public void GetReservationById()
        {
            try
            {
                

                List<Reservation> list = _reservationRepository.GetReservationById();
                if (list == null || list.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("No reservations found");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }

                foreach (Reservation reservation in list)
                {
                    Console.WriteLine(reservation);
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid Data");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void GetReservationsByCustomerId()
        {
            try
            {
                Console.WriteLine("Enter the CustomerId");
                int id=int.Parse(Console.ReadLine());

                List<Reservation> list = _reservationRepository.GetReservationsByCustomerId(id);
                if (list == null || list.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("No reservations found for the given Customer Id.");
                        Console.ForegroundColor = ConsoleColor.White;
                    return;
                }

                foreach (Reservation reservation in list)
                {
                    Console.WriteLine(reservation);
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid input. Please enter a valid Customer Id.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void UpdateReservation()
        {
            try
            {
                Reservation reservation = new Reservation();
                Console.WriteLine("Enter the ReservationId you want to Update");
                reservation.ReservationID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the VehicleiD");
                reservation.VehicleID= int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the  updated StartDate (yyyy-MM-dd)");
                DateTime date = DateTime.Parse(Console.ReadLine());
                if (date > DateTime.Now)
                {
                    throw new InvalidDateException("Date Should be Less than the Todays Date");
                }

                reservation.StartDate = date;
                Console.WriteLine("Enter the updated  EndDate (yyyy-MM-dd)");
                DateTime date1 = DateTime.Parse(Console.ReadLine());
                if (date1 > DateTime.Now)
                {
                    throw new InvalidDateException("Date Should be Less than the Todays Date");
                }
                reservation.EndDate = date1;


                int result = _reservationRepository.UpdateReservation(reservation);

                if (result > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Update Reservation successful");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Update Reservation not successful, please try again later");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid input. Please enter the correct data format.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (InvalidDateException ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void CreateReservationAuto()
        {
            try
            {
                Reservation reservation = new Reservation();
                
                reservation.CustomerID = AuthenticationService.customerId;

                Console.WriteLine("Enter the VehicleId");
                reservation.VehicleID = int.Parse(Console.ReadLine());

                // Check if the vehicle is available
                bool isVehicleAvailable = _vehicleRepository.IsvehicleAvilable(reservation.VehicleID);
                if (!isVehicleAvailable)
                {
                    throw new ReservationException("The vehicle is already reserved or unavailable.");
                }

                Console.WriteLine("Enter the StartDate (yyyy-MM-dd)");
                DateTime date = DateTime.Parse(Console.ReadLine());
                if (date > DateTime.Now)
                {
                    throw new InvalidDateException("Date Should be Less than the Todays Date");
                }

                reservation.StartDate = date;
                Console.WriteLine("Enter the EndDate (yyyy-MM-dd)");
                DateTime date1 = DateTime.Parse(Console.ReadLine());
                if (date1 > DateTime.Now)
                {
                    throw new InvalidDateException("Date Should be Less than the Todays Date");
                }
                reservation.EndDate = date1;



                int result = _reservationRepository.CreateReservationAuto(reservation);

                if (result > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Create Reservation successful");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Total Cost: {reservation.TotalCost}");
                    _reservationRepository.UpdateStatus(reservation.VehicleID, 0);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Create Reservation not successful, please try again later");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (InvalidDateException ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (ReservationException ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid input. Please enter the correct data format.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

        public void UpdateReservationAuto()
        {
            try
            {
                Reservation reservation = new Reservation();
                Console.WriteLine("Enter the ReservationId you want to Update");
                reservation.ReservationID = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the updated  StartDate (yyyy-MM-dd)");
                DateTime date = DateTime.Parse(Console.ReadLine());
                if (date > DateTime.Now)
                {
                    throw new InvalidDateException("Date Should be Less than the Todays Date");
                }

                reservation.StartDate = date;
                Console.WriteLine("Enter the updated  EndDate (yyyy-MM-dd)");
                DateTime date1 = DateTime.Parse(Console.ReadLine());
                if (date1 > DateTime.Now)
                {
                    throw new InvalidDateException("Date Should be Less than the Todays Date");
                }
                reservation.EndDate = date1;


                int result = _reservationRepository.UpdateReservationAuto(reservation);

                if (result > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Update Reservation successful");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Update Reservation not successful, please try again later");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid input. Please enter the correct data format.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (InvalidDateException ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }


        public void GetReservations()
        {
            try
            {
                

                List<Reservation> list = _reservationRepository.GetReservations();
                if (list == null || list.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("No reservations found");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }

                foreach (Reservation reservation in list)
                {
                    Console.WriteLine(reservation);
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid input. Please enter a valid Reservation Id.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void GetReservationsByCustomerIdAuto()
        {
            try
            {


                List<Reservation> list = _reservationRepository.GetReservationBycustIdAuto();
                if (list == null || list.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("No reservations found");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }

                foreach (Reservation reservation in list)
                {
                    Console.WriteLine(reservation);
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid input. Please enter a valid Reservation Id.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
