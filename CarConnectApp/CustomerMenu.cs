using CarConnect.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                Console.WriteLine("----------------------------Welcome to the CarConnect Platform-----------------------");
                Console.WriteLine("1.UpdateCustomer\n2.GetAvilableVehicles\n3.GetVehicleById\n4.CreateReservation\n5.CancelReservstion\n6.UpdateReservation\n7.GetReservationById\n8.GetReservationByCustomerId\n9.Logout");
                Console.WriteLine("Choose any One Option");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        customerservice.UpdateCustomer();
                        break;

                    case 2:
                        vehicleservice.GetAvailableVehicles();
                        break;
                    case 3:
                        vehicleservice.GetVehicleById();
                        break;

                    case 4:
                        reseravstionservice.CreateReservation();
                        break;
                    case 5:
                        reseravstionservice.CancelReservation();
                        break;
                    case 6:
                        reseravstionservice.UpdateReservation();
                        break;
                    
                    case 7:
                        reseravstionservice.GetReservationById();
                        break;
                    case 8:
                        reseravstionservice.GetReservationsByCustomerId();
                        break;
                    case 9:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Enter the Appropriate option");
                        break;


                }

            }
            car.Run();
        }

    }
}
