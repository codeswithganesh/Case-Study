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
        public void GetReservationsByCustomerId();

        public void CreateReservation();

        public void UpdateReservation();

        public void CancelReservation();
    }
}
