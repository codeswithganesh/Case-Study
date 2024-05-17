using CarConnect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.Service
{
    internal interface IVehicleService
    {
        public void GetVehicleById();
        public void GetAvailableVehicles();

        public void AddVehicle();

        public void UpdateVehicle();

        public void RemoveVehicle();
    }
}
