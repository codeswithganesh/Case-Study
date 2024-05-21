using CarConnect.CarConnectApp;
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
    public class AuthenticationService
    {
        CustomerRepository customerRepository = new CustomerRepository();
        public static int customerId;
        readonly AuthenticationRepository _repository;
        public AuthenticationService()
        {
            _repository = new AuthenticationRepository();
        }
        public void AuthenticateCustomer()
        {
            try
            {
                CustomerMenu menu = new CustomerMenu();
                Console.WriteLine("Enter the Username");
                string username = Console.ReadLine();
                Console.WriteLine("Enter the Password");
                string password = Console.ReadLine();

                bool result = _repository.AuthenticateCustomer(username, password);
                if (result)
                {
                    //Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Welcome {username}");
                    customerId = customerRepository.GetCustomerId(username);
                    Console.WriteLine(customerId);
                    menu.RunCustomer();
                }
                else
                {
                    throw new AuthenticationException("Authentication failed. Please check your username and password.");
                }
            }
            catch (AuthenticationException ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                
            }
        }


        public void AuthenticateAdmin()
        {
            try
            {
                AdminMenu admin = new AdminMenu();
                Console.WriteLine("Enter the Username");
                string username = Console.ReadLine();
                Console.WriteLine("Enter the Password");
                string password = Console.ReadLine();
                bool result = _repository.AuthenticateAdmin(username, password);
                if (result == true)
                {
                    Console.WriteLine($"Welcome {username} ");
                    admin.RunAdmin();
                }
                else
                {
                    throw new AuthenticationException("Authentication failed. Please check your username and password.");
                }
            }
            catch (AuthenticationException ex)
            {
                Console.WriteLine(ex.Message);

            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);

            }

        }
    }
}
