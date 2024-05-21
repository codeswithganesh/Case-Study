

using CarConnect.Exceptions;
using CarConnect.Model;
using CarConnect.Repository;

namespace CarConnect.Service
{
    internal class CustomerService : ICustomerService
    {
        readonly ICustomerRepository _customerRepository;
        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }

        

        public void GetCustomerById()
        {
            try
            {
                
                List<Customer> list = _customerRepository.GetCustomerById();

                if (list == null || list.Count == 0)
                {
                    //Console.ForegroundColor = ConsoleColor.DarkRed;
                    throw new CustomerNotFoundException($"Customer was not found.");
                }

                foreach (Customer customer in list)
                {
                    Console.WriteLine(customer);
                }
            }
            catch (CustomerNotFoundException ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid input. Please enter a valid CustomerId.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

        public void GetCustomerByUsername()
        {
            try
            {
                Console.WriteLine("Enter the Username");
                string username = Console.ReadLine();
                List<Customer> list = _customerRepository.GetCustomerByUsername(username);

                if (list == null || list.Count == 0)
                {
                    throw new CustomerNotFoundException($"No customers found with username {username}.");
                }

                foreach (Customer customer in list)
                {
                    Console.WriteLine(customer);
                }
            }
            catch (CustomerNotFoundException ex)
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

        public void RegisterCustomer()
        {
            try
            {
                Customer customer = new Customer();

                Console.WriteLine("Enter the firstname");
                customer.FirstName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(customer.FirstName))
                    throw new InvalidInputException("FirstName is required");

                Console.WriteLine("Enter the lastname");
                customer.LastName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(customer.LastName))
                    throw new InvalidInputException("LastName is required");

                Console.WriteLine("Enter the email");
                string email = Console.ReadLine();
                if (!IsValidEmail(email))
                {
                    //Console.ForegroundColor = ConsoleColor.DarkRed;
                    throw new InvalidEmailFormatException("Invalid email format. Please enter a valid email address.");
                }
                customer.Email = email;

                Console.WriteLine("Enter the Phoneno");
                customer.PhoneNumber = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(customer.PhoneNumber))
                    throw new InvalidInputException("PhoneNumber is required");

                Console.WriteLine("Enter the Address");
                customer.Address = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(customer.Address))
                    throw new InvalidInputException("Address is required");

                Console.WriteLine("Enter the Username");
                customer.Username = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(customer.Username))
                    throw new InvalidInputException("Username is required");

                Console.WriteLine("Enter the password");
                customer.Password = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(customer.Password))
                    throw new InvalidInputException("Password is required");

                customer.RegistrationDate = DateTime.Now;
                int result = _customerRepository.RegisterCustomer(customer);

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

        public void UpdateCustomer()
        {
            try
            {
                Customer customer = new Customer();

                Console.WriteLine("Enter the Customer ID you want to update");
                customer.CustomerID = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the updated firstname");
                customer.FirstName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(customer.FirstName))
                    throw new InvalidInputException("FirstName is required");

                Console.WriteLine("Enter the updated lastname");
                customer.LastName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(customer.LastName))
                    throw new InvalidInputException("LastName is required");

                Console.WriteLine("Enter the updated email");
               
                string email = Console.ReadLine();
                if (!IsValidEmail(email))
                {
                    throw new InvalidEmailFormatException("Invalid email format. Please enter a valid email address.");
                }
                customer.Email = email;

                Console.WriteLine("Enter the updated Phoneno");
                customer.PhoneNumber = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(customer.PhoneNumber))
                    throw new InvalidInputException("PhoneNumber is required");

                Console.WriteLine("Enter the updated Address");
                customer.Address = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(customer.Address))
                    throw new InvalidInputException("Address is required");

                Console.WriteLine("Enter the updated Username");
                customer.Username = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(customer.Username))
                    throw new InvalidInputException("Username is required");

                Console.WriteLine("Enter the updated password");
                customer.Password = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(customer.Password))
                    throw new InvalidInputException("Password is required");

                customer.RegistrationDate = DateTime.Now;
                int result = _customerRepository.UpdateCustomer(customer);

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

        public void UpdateCustomerAuto()
        {
            try
            {
                Customer customer = new Customer();

                

                Console.WriteLine("Enter the updated firstname");
                customer.FirstName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(customer.FirstName))
                    throw new InvalidInputException("FirstName is required");

                Console.WriteLine("Enter the updated lastname");
                customer.LastName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(customer.LastName))
                    throw new InvalidInputException("LastName is required");

                Console.WriteLine("Enter the updated email");
                string email = Console.ReadLine();
                if (!IsValidEmail(email))
                {
                    throw new InvalidEmailFormatException("Invalid email format. Please enter a valid email address.");
                }
                customer.Email = email;

                Console.WriteLine("Enter the updated Phoneno");
                customer.PhoneNumber = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(customer.PhoneNumber))
                    throw new InvalidInputException("PhoneNumber is required");

                Console.WriteLine("Enter the updated Address");
                customer.Address = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(customer.Address))
                    throw new InvalidInputException("Address is required");

                Console.WriteLine("Enter the updated Username");
                customer.Username = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(customer.Username))
                    throw new InvalidInputException("Username is required");

                Console.WriteLine("Enter the updated password");
                customer.Password = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(customer.Password))
                    throw new InvalidInputException("Password is required");

                customer.RegistrationDate = DateTime.Now;
                int result = _customerRepository.UpdateCustomerAuto(customer);

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

            public void DeleteCustomer()
        {
            try
            {
                Console.WriteLine("Enter the Customer Id you want to delete");
                int id = int.Parse(Console.ReadLine());
                int result = _customerRepository.DeleteCustomer(id);

                if (result > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Delete Customer successful");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {

                    throw new CustomerNotFoundException($"Customer with ID {id} was not found.");
                }
            }
            catch (CustomerNotFoundException ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Invalid input. Please enter a valid CustomerId.");
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
