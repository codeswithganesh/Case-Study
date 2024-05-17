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
        public List<Reservation> GetReservationById(int ReservationId);
        public List<Reservation> GetReservationsByCustomerId(int customerId);

        public int CreateReservation(Reservation reservationData);

        public int UpdateReservation(Reservation reservationData);

        public int CancelReservation(int reservationId);
    }
}
