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
                int result = _reservationRepository.CancelReservation(id);

                if (result > 0)
                {
                    Console.WriteLine("Cancel Reservation successful");
                }
                else
                {
                    Console.WriteLine("Cancel Reservation not successful");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid Reservation Id.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }

        public void CreateReservation()
        {
            try
            {
                Reservation reservation = new Reservation();
                Console.WriteLine("Enter the CustomerId");
                reservation.CustomerID = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the VehicleId");
                reservation.VehicleID = int.Parse(Console.ReadLine());

                // Check if the vehicle is available
                bool isVehicleAvailable = _vehicleRepository.IsvehicleAvilable(reservation.VehicleID);
                if (!isVehicleAvailable)
                {
                    throw new ReservationException("The vehicle is already reserved or unavailable.");
                }

                Console.WriteLine("Enter the StartDate (yyyy-MM-dd)");
                reservation.StartDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter the EndDate (yyyy-MM-dd)");
                reservation.EndDate = DateTime.Parse(Console.ReadLine());
                
                

                int result = _reservationRepository.CreateReservation(reservation);

                if (result > 0)
                {
                    Console.WriteLine("Create Reservation successful");
                    Console.WriteLine($"Total Cost: {reservation.TotalCost}");
                }
                else
                {
                    Console.WriteLine("Create Reservation not successful, please try again later");
                }
            }
            catch (ReservationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter the correct data format.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }

        }

        public void GetReservationById()
        {
            try
            {
                Console.WriteLine("Enter the ReservationId");
                int id = int.Parse(Console.ReadLine());

                List<Reservation> list = _reservationRepository.GetReservationById(id);
                if (list == null || list.Count == 0)
                {
                    Console.WriteLine("No reservations found with the given ID.");
                    return;
                }

                foreach (Reservation reservation in list)
                {
                    Console.WriteLine(reservation);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid Reservation Id.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
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
                    Console.WriteLine("No reservations found for the given Customer Id.");
                    return;
                }

                foreach (Reservation reservation in list)
                {
                    Console.WriteLine(reservation);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid Customer Id.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }

        public void UpdateReservation()
        {
            try
            {
                Reservation reservation = new Reservation();
                Console.WriteLine("Enter the ReservationId you want to Update");
                reservation.ReservationID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Updated CustomerId");
                reservation.CustomerID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Updated VehicleId");
                reservation.VehicleID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Updated StartDate (yyyy-MM-dd)");
                reservation.StartDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Updated EndDate (yyyy-MM-dd)");
                reservation.EndDate = DateTime.Parse(Console.ReadLine());
                

                int result = _reservationRepository.UpdateReservation(reservation);

                if (result > 0)
                {
                    Console.WriteLine("Update Reservation successful");
                }
                else
                {
                    Console.WriteLine("Update Reservation not successful, please try again later");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter the correct data format.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }
    }
}
