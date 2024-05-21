using CarConnect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.Repository
{
    internal interface IReservationRepository
    {
        public List<Reservation> GetReservationById();
        public int GetVehicleId(int reservationid);
        public List<Reservation> GetReservationsByCustomerId(int customerId);
        public List<Reservation> GetReservations();
        public List<Reservation> GetReservationBycustIdAuto();

        public int CreateReservation(Reservation reservationData);

        public int CreateReservationAuto(Reservation reservationData);
        public int UpdateReservationAuto(Reservation reservationData);
        public int UpdateReservation(Reservation reservationData);

        public int CancelReservation(int reservationId);
        public void UpdateStatus(int vehileId,int availabilty);
    }
}
