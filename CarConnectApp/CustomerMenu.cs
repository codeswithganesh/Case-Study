using CarConnect.Repository;
using CarConnect.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.CarConnectApp
{
    public class CustomerMenu
    {
        CustomerService customerservice = new CustomerService();
        VehicleService vehicleservice = new VehicleService();
        ReservationService reseravstionservice=new ReservationService();
        CarConncetApplication car = new CarConncetApplication();
        
       

        public void RunCustomer()
        {
            bool flag = true;
            while (flag)
            {

                bool flag1 = true;
                Console.ForegroundColor= ConsoleColor.Cyan;
                Console.WriteLine("-*-*-*-*-*-*-*-*-*-Welcome to the CarConnect CustomerMenu-*-*-*-*-*-*-*-*-*-");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1.UpdateCustomer\n2.GetAvilableVehicles\n3.CreateReservation\n4.CancelReservstion\n5.UpdateReservation\n6.Your Reservations\n7.Logout");
                Console.WriteLine("Choose any One Option");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.WriteLine();
                        customerservice.UpdateCustomerAuto();
                        break;

                    case 2:
                        Console.WriteLine();
                        vehicleservice.GetAvailableVehicles();
                        break;
                    

                    case 3:
                        Console.WriteLine();
                        reseravstionservice.CreateReservationAuto();
                        break;
                    case 4:
                        Console.WriteLine();
                        reseravstionservice.CancelReservation();
                        break;
                    case 5:
                        Console.WriteLine();
                        reseravstionservice.UpdateReservation();
                        break;
                    
                    case 6:
                        Console.WriteLine();
                        reseravstionservice.GetReservationsByCustomerIdAuto();
                        break;
                    case 7:
                        flag = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Enter the Appropriate option");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;


                }

            }
            car.Run();
        }

    }
}
