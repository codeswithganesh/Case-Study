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
                    Console.WriteLine("Delete Admin successful");
                }
                else
                {
                    Console.WriteLine("Delete Admin not successful");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid Admin Id.");
            }
            catch (AdminNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }

        public void GetAdminById()
        {
            try
            {
                Console.WriteLine("Enter the AdminId");
                int id = int.Parse(Console.ReadLine());

                List<Admin> list = _adminRepository.GetAdminById(id);
                if (list == null || list.Count == 0)
                {
                    throw new AdminNotFoundException($"Admin with ID {id} was not found.");
                }

                foreach (Admin admin in list)
                {
                    Console.WriteLine(admin);
                }
            }
            catch (AdminNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid AdminId.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
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
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
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
                admin.JoinDate = DateTime.Parse(Console.ReadLine());

                int result = _adminRepository.RegisterAdmin(admin);

                if (result > 0)
                {
                    Console.WriteLine("Registration successful");
                }
                else
                {
                    Console.WriteLine("Registration not successful, please try again later");
                }
            }
            catch (InvalidInputException ex)
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
                admin.JoinDate = DateTime.Parse(Console.ReadLine());

                int result = _adminRepository.UpdateAdmin(admin);

                if (result > 0)
                {
                    Console.WriteLine("Update successful");
                }
                else
                {
                    Console.WriteLine("Update not successful, please try again later");
                }
            }
            catch (InvalidInputException ex)
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
    }
}
