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
                Console.WriteLine("Enter the VehicleId");
                int id = int.Parse(Console.ReadLine());
                List<Vehicle> list = _vehicleRepository.GetVehicleById(id);

                if (list == null || list.Count == 0)
                {
                    Console.WriteLine("No vehicle found with the given ID.");
                    return;
                }

                foreach (Vehicle vehicle in list)
                {
                    Console.WriteLine(vehicle);
                }
            }
            catch (VehicleNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid VehicleId.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }
        public void GetAvailableVehicles()
        {
            try
            {
                List<Vehicle> list = _vehicleRepository.GetAvailableVehicles();

                if (list == null || list.Count == 0)
                {
                    Console.WriteLine("No available vehicles found.");
                    return;
                }

                foreach (Vehicle vehicle in list)
                {
                    Console.WriteLine(vehicle);
                }
            }
            catch (VehicleNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
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
                vehicle.Year = DateTime.Parse(Console.ReadLine());
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
                    Console.WriteLine("AddVehicle successful");
                }
                else
                {
                    Console.WriteLine("AddVehicle not successful, please try again later");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter the correct data.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
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
                vehicle.Year = DateTime.Parse(Console.ReadLine());
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
                    Console.WriteLine("UpdateVehicle successful");
                }
                else
                {
                    Console.WriteLine("UpdateVehicle not successful, please try again later");
                }
            }
            catch (VehicleNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter the correct data.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
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
                    Console.WriteLine("Remove Vehicle successful");
                }
                else
                {
                    Console.WriteLine("Remove Vehicle not successful, please try again later");
                }
            }
            catch (VehicleNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid VehicleId.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }

        
    }
}
