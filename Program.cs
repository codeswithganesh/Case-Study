using CarConnect.CarConnectApp;
using CarConnect.Repository;
using CarConnect.Service;

namespace CarConnect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarConncetApplication car = new CarConncetApplication();
            car.Run();
        }
    }
}
