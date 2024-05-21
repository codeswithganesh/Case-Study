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
    internal class AdminService:IAdminService
    {
        readonly IAdminRepository _adminRepository;
        public AdminService()
        {
            _adminRepository = new AdminRepository();
        }

        public void DeleteAdmin()
        {
            try
            {
                Console.WriteLine("Enter the Admin Id you want to delete");
                int id = int.Parse(Console.ReadLine());
                int result = _adminRepository.DeleteAdmin(id);

                if (result > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Delete Admin successful");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Delete Admin not successful");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid input. Please enter a valid Admin Id.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (AdminNotFoundException ex)
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

        public void GetAdminById()
        {
            try
            {
               

                List<Admin> list = _adminRepository.GetAdminById();
                if (list == null || list.Count == 0)
                {
                    //Console.ForegroundColor = ConsoleColor.DarkRed;
                    throw new AdminNotFoundException($"Admin not found.");
                    //Console.ForegroundColor = ConsoleColor.White;
                }

                foreach (Admin admin in list)
                {
                    Console.WriteLine(admin);
                }
            }
            catch (AdminNotFoundException ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid input. Please enter a valid AdminId.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void GetAdminByUsername()
        {
            try
            {
                Console.WriteLine("Enter the Username");
                string username = Console.ReadLine();

                List<Admin> list = _adminRepository.GetAdminByUsername(username);
                if (list == null || list.Count == 0)
                {
                   
                    throw new AdminNotFoundException($"No admins found with username {username}.");
                    
                }

                foreach (Admin admin in list)
                {
                    Console.WriteLine(admin);
                }
            }
            catch (AdminNotFoundException ex)
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


        public void RegisterAdmin()
        {
            try
            {
                Admin admin = new Admin();

                Console.WriteLine("Enter the FirstName");
                admin.FirstName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(admin.FirstName))
                    throw new InvalidInputException("FirstName is required");

                Console.WriteLine("Enter the LastName");
                admin.LastName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(admin.LastName))
                    throw new InvalidInputException("LastName is required");

                Console.WriteLine("Enter the Email");
                string email = Console.ReadLine();
                if (!IsValidEmail(email))
                {
                    throw new InvalidEmailFormatException("Invalid email format. Please enter a valid email address.");
                }
                admin.Email = email;


                Console.WriteLine("Enter the PhoneNumber");
                admin.PhoneNumber = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(admin.PhoneNumber))
                    throw new InvalidInputException("PhoneNumber is required");

                Console.WriteLine("Enter the UserName");
                admin.Username = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(admin.Username))
                    throw new InvalidInputException("Username is required");

                Console.WriteLine("Enter the Password");
                admin.Password = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(admin.Password))
                    throw new InvalidInputException("Password is required");

                Console.WriteLine("Enter the Admin Role");
                admin.Role = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(admin.Role))
                    throw new InvalidInputException("Role is required");

                Console.WriteLine("Enter the JoinDate");
                DateTime date = DateTime.Parse(Console.ReadLine());
                if(date > DateTime.Now)
                {
                    throw new InvalidDateException("Date Should be Less than the Todays Date");
                }
                admin.JoinDate = date;

                int result = _adminRepository.RegisterAdmin(admin);

                if (result > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Registration successful");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Registration not successful, please try again later");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (InvalidInputException ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch(InvalidDateException ex)
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

        public bool IsValidEmail(string email)
        {
            return email.Contains("@");

        }

        public void UpdateAdmin()
        {
            try
            {
                Admin admin = new Admin();

                Console.WriteLine("Enter the AdminId you want to update");
                admin.AdminID = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the Updated FirstName");
                admin.FirstName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(admin.FirstName))
                    throw new InvalidInputException("FirstName is required");

                Console.WriteLine("Enter the Updated LastName");
                admin.LastName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(admin.LastName))
                    throw new InvalidInputException("LastName is required");

                Console.WriteLine("Enter the Updated Email");
                admin.Email = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(admin.Email))
                    throw new InvalidInputException("Email is required");

                Console.WriteLine("Enter the Updated PhoneNumber");
                admin.PhoneNumber = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(admin.PhoneNumber))
                    throw new InvalidInputException("PhoneNumber is required");

                Console.WriteLine("Enter the Updated Username");
                admin.Username = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(admin.Username))
                    throw new InvalidInputException("Username is required");

                Console.WriteLine("Enter the Updated Password");
                admin.Password = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(admin.Password))
                    throw new InvalidInputException("Password is required");

                Console.WriteLine("Enter the Updated Admin Role");
                admin.Role = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(admin.Role))
                    throw new InvalidInputException("Role is required");

                Console.WriteLine("Enter the Updated JoinDate");
                DateTime date = DateTime.Parse(Console.ReadLine());
                if (date > DateTime.Now)
                {
                    throw new InvalidDateException("Date Should be Less than the Todays Date");
                }
                admin.JoinDate = date;

                int result = _adminRepository.UpdateAdmin(admin);

                if (result > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Update successful");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Update not successful, please try again later");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (InvalidInputException ex)
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
    }
}
