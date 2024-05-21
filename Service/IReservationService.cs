using CarConnect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.Service
{
    internal interface IReservationService
    {
        public void GetReservationById();
        public void GetReservations();
        public void GetReservationsByCustomerId();

        public void CreateReservation();
        public void CreateReservationAuto();

        public void UpdateReservation();
        public void GetReservationsByCustomerIdAuto();
        public void CancelReservation();
    }
}
