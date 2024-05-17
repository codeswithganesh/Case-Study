

using CarConnect.Service;

namespace CarConnect.CarConnectApp
{
    internal class CarConncetApplication
    {
        public void Run()
        {
            AdminMenu adminmenu=new AdminMenu();
            AdminService adminservice = new AdminService();
            CustomerMenu customermenu=new CustomerMenu();
            AuthenticationService authenticationservice= new AuthenticationService();
            CustomerService customerservice = new CustomerService();
            bool flag = true;
            while(flag)
            {
                Console.WriteLine("************Welcome to the CarConncetPlatform**************");
                Console.WriteLine("1.Admin\n2.Customer\n3.Exit App");
                int input=int.Parse(Console.ReadLine());
                switch(input)
                {
                    case 1:
                        Console.WriteLine("1.Admin Login\t2.Register");
                        int input1 = int.Parse(Console.ReadLine());
                        if(input1 == 1)
                        {
                            authenticationservice.AuthenticateAdmin();

                        }
                        else if(input1 == 2)
                        {
                            adminservice.RegisterAdmin();
                        }
                        else
                            Console.WriteLine("Enter the Valid Choice");
                    break;
                    case 2:
                        Console.WriteLine("1.Customer Login\t2.Register");
                        int input2 = int.Parse(Console.ReadLine());
                        if (input2 == 1)
                        {
                            authenticationservice.AuthenticateCustomer();

                        }
                        else if (input2 == 2)
                        {
                            customerservice.RegisterCustomer();
                        }
                        else
                            Console.WriteLine("Enter the Valid Choice");
                        break;
                    case 3:
                        flag= false;
                        break;
                    default:
                        Console.WriteLine("enter the valid choice");
                        break;
                }
            }
        }
    }
}
