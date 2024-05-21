

using CarConnect.Service;
using System.Net;

namespace CarConnect.CarConnectApp
{
    internal class AdminMenu
    {
        public void RunAdmin()
        {
            AdminService adminService = new AdminService();
            CustomerService customerService = new CustomerService();
            ReservationService reservationService = new ReservationService();
            VehicleService vehicleService = new VehicleService();
            ReportGeneratorService reportGeneratorService = new ReportGeneratorService();
            CarConncetApplication car=new CarConncetApplication();
            bool flag = true;
            while (flag)
            {

                bool flag1 = true;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("-*-*-*-*-*-*-*-*-*-Welcome to the CarConncet AdminMenu-*-*-*-*-*-*-*-*-*-");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();

                Console.WriteLine("1.CustomerService\n2.VehicleService\n3.ReservationService\n4.AdminService\n5.ReportGenerator\n6.Logout");
                Console.WriteLine("Choose any One Option");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:

                        while (flag1)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Welcome to the CustomerService");
                            Console.WriteLine("1.GetCustomerAllCustomers\n2.GetCustomerByUsername\n3.RegisterCustomer\n4.UpdateCustomer\n5.DeleteCustomer\n6.Back to MainMenu");
                            Console.WriteLine("Choose any One Option");
                            int input1 = int.Parse(Console.ReadLine());
                            switch (input1)
                            {
                                case 1:
                                    customerService.GetCustomerById();
                                    break;

                                case 2:
                                    customerService.GetCustomerByUsername();
                                    break;
                                case 3:
                                    customerService.RegisterCustomer();
                                    break;
                                case 4:
                                    customerService.UpdateCustomer();
                                    break;
                                case 5:
                                    customerService.DeleteCustomer();
                                    break;
                                case 6:
                                    flag1 = false;
                                    break;
                                default:
                                    Console.WriteLine("Enter the Appropriate Option");
                                    break;
                            }
                        }
                        break;

                    case 2:
                        while (flag1)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Welcome to the Vehicle Service");
                            Console.WriteLine("1.GetVehicleAllVehicles\n2.GetAvilableVehicles\n3.AddVehicle\n4.UpdateVehicle\n5.RemoveVehicle\n6.Back To Main Menu");
                            Console.WriteLine("Choose any One Option");
                            int input1 = int.Parse(Console.ReadLine());
                            switch (input1)
                            {
                                case 1:
                                    vehicleService.GetVehicleById();
                                    break;

                                case 2:
                                    vehicleService.GetAvailableVehicles();
                                    break;
                                case 3:
                                    vehicleService.AddVehicle();
                                    break;
                                case 4:
                                    vehicleService.UpdateVehicle();
                                    break;
                                case 5:
                                    vehicleService.RemoveVehicle();
                                    break;
                                case 6:
                                    flag1 = false;
                                    break;
                                default:
                                    Console.WriteLine("Enter the Appropriate Option");
                                    break;
                            }
                        }
                        break;
                    case 3:
                        while (flag1)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Welcome to the Reservation Service");
                            Console.WriteLine("1.GetAllReservations\n2.GetReservtionsByCustomerId\n3.CreateReservation\n4.UpdateReservation\n5.CancelReservation\n6.Back To MainMenu");
                            Console.WriteLine("Choose any One Option");
                            int input1 = int.Parse(Console.ReadLine());
                            switch (input1)
                            {
                                case 1:
                                    reservationService.GetReservationById();
                                    break;

                                case 2:
                                    reservationService.GetReservationsByCustomerId();
                                    break;
                                case 3:
                                    reservationService.CreateReservation();
                                    break;
                                case 4:
                                    reservationService.UpdateReservation();
                                    break;
                                case 5:
                                    reservationService.CancelReservation();
                                    break;

                                case 6:
                                    flag1 = false;
                                    break;
                                default:
                                    Console.WriteLine("Enter the Appropriate Option");
                                    break;
                            }
                        }
                        break;

                    case 4:
                        while (flag1)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Welcome to the AdminService");
                            Console.WriteLine("1.GetAllAdmins\n2.GetAdminByUserName\n3.RegisterAdmin\n4.UpdateAdmin\n5.DeleteAdmin\n6.Back to MainMenu");
                            Console.WriteLine("Choose any One Option");
                            int input1 = int.Parse(Console.ReadLine());
                            switch (input1)
                            {
                                case 1:
                                    adminService.GetAdminById();
                                    break;

                                case 2:
                                    adminService.GetAdminByUsername();
                                    break;
                                case 3:
                                    adminService.RegisterAdmin();
                                    break;
                                case 4:
                                    adminService.UpdateAdmin();
                                    break;
                                case 5:
                                    adminService.DeleteAdmin();
                                    break;

                                case 6:
                                    flag1 = false;
                                    break;
                                default:
                                    Console.WriteLine("Enter the Appropriate Option");
                                    break;
                            }
                        }
                        break;
                    case 5:
                        while (flag1)
                        {
                            Console.WriteLine();
                            bool flag2 = true;
                            Console.WriteLine("Welcome to the Report Generator");
                            Console.WriteLine("1.Reservation History Report\n2.Vehicle Utilization Report\n3.Revenue Report\n4.Back to MainMEnu");
                            Console.WriteLine("Choose any One Option");
                            int input1 = int.Parse(Console.ReadLine());
                            switch (input1)
                            {
                                case 1:
                                    while(flag2)
                                    {
                                        Console.WriteLine("1.ReservationHistoryByModel\n2.ReservationHistoryByCustomer\n3.Back To MainMenu");
                                        Console.WriteLine("Choose any One Option");
                                        int input2 = int.Parse(Console.ReadLine());
                                        switch (input2)
                                        {
                                            case 1:reportGeneratorService.ReservationHistoryBModel();
                                                break;
                                            case 2:reportGeneratorService.ReservationHistoryBCustomer();
                                                break;
                                            case 3:
                                                flag2 = false;
                                                break;
                                            default:
                                                Console.WriteLine("Enter the Valid Input");
                                                break;

                                        }
                                     }
                                    break;

                                case 2:
                                    reportGeneratorService.VehicleUtilizationReport();
                                    break;
                                case 3:
                                    reportGeneratorService.RevenueReport();
                                    break;
                                case 4:
                                    flag1 = false;
                                    break;
                                default:
                                    Console.WriteLine("Enter the Appropriate Option");
                                    break;
                            }
                        }
                        break;


                    case 6:
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
