using CarConnect.CarConnectApp;
using CarConnect.Repository;
using CarConnect.Service;

namespace CarConnect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ReservationService service = new ReservationService();
            //service.GetReservationsByCustomerId();


            //ReservationRepository repository = new ReservationRepository();


            CarConncetApplication car = new CarConncetApplication();
            car.Run();
        }
    }
}
