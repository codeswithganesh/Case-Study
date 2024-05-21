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
    public class VehicleService : IVehicleService
    {
        readonly IVehicleRepository _vehicleRepository;
        public VehicleService()
        {
            _vehicleRepository = new VehicleRepository();
        }

        public void GetVehicleById()
        {
            try
            {
                
                List<Vehicle> list = _vehicleRepository.GetVehicleById();

                if (list == null || list.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;

                    Console.WriteLine("No vehicle found with the given ID.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }

                foreach (Vehicle vehicle in list)
                {
                    Console.WriteLine(vehicle);
                }
            }
            catch (VehicleNotFoundException ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid input format. Please enter a valid VehicleId.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void GetAvailableVehicles()
        {
            try
            {
                List<Vehicle> list = _vehicleRepository.GetAvailableVehicles();

                if (list == null || list.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("No available vehicles found.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }

                foreach (Vehicle vehicle in list)
                {
                    Console.WriteLine(vehicle);
                }
            }
            catch (VehicleNotFoundException ex)
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

        
        public void AddVehicle()
        {
            try
            {
                Vehicle vehicle = new Vehicle();
                Console.WriteLine("Enter the Model");
                vehicle.Model = Console.ReadLine();
                Console.WriteLine("Enter the Make");
                vehicle.Make = Console.ReadLine();
                Console.WriteLine("Enter the Year in YYYY-MM-DD format");
                DateTime date = DateTime.Parse(Console.ReadLine());
                if (date >= DateTime.Now)
                {
                    throw new InvalidDateException("Date Should be Less than the Todays Date");
                }

                vehicle.Year = date;
                Console.WriteLine("Enter the Color");
                vehicle.Color = Console.ReadLine();
                Console.WriteLine("Enter the Registration Number");
                vehicle.RegistrationNumber = Console.ReadLine();
                Console.WriteLine("Enter the Availability (1 for available, 0 for not available)");
                vehicle.Availability = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the DailyRate");
                vehicle.DailyRate = double.Parse(Console.ReadLine());

                int result = _vehicleRepository.AddVehicle(vehicle);

                if (result > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("AddVehicle successful");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("AddVehicle not successful, please try again later");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid input format. Please enter the correct data.");
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
     

        public void UpdateVehicle()
        {
            try
            {
                Vehicle vehicle = new Vehicle();
                Console.WriteLine("Enter the VehicleId you want to update");
                vehicle.VehicleID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the updated Model");
                vehicle.Model = Console.ReadLine();
                Console.WriteLine("Enter the updated Make");
                vehicle.Make = Console.ReadLine();
                Console.WriteLine("Enter the updated Year in YYYY-MM-DD format");
                DateTime date = DateTime.Parse(Console.ReadLine());
                if (date >= DateTime.Now)
                {
                    throw new InvalidDateException("Date Should be Less than the Todays Date");
                }

                vehicle.Year = date;
                Console.WriteLine("Enter the updated Color");
                vehicle.Color = Console.ReadLine();
                Console.WriteLine("Enter the updated Registration Number");
                vehicle.RegistrationNumber = Console.ReadLine();
                Console.WriteLine("Enter the updated Availability (1 for available, 0 for not available)");
                vehicle.Availability = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the updated DailyRate");
                vehicle.DailyRate = double.Parse(Console.ReadLine());

                int result = _vehicleRepository.UpdateVehicle(vehicle);

                if (result > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("UpdateVehicle successful");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("UpdateVehicle not successful, please try again later");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (VehicleNotFoundException ex)
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
                Console.WriteLine("Invalid input format. Please enter the correct data.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
        public void RemoveVehicle()
        {
            try
            {
                Console.WriteLine("Enter the Vehicle Id you want to remove");
                int id = int.Parse(Console.ReadLine());
                int result = _vehicleRepository.RemoveVehicle(id);

                if (result > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Remove Vehicle successful");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Remove Vehicle not successful, please try again later");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (VehicleNotFoundException ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid input format. Please enter a valid VehicleId.");
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
