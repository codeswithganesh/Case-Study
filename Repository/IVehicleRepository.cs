using CarConnect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.Repository
{
    public  interface IVehicleRepository
    {
        public List<Vehicle> GetVehicleById(int vehicleId);
        public List<Vehicle> GetAvailableVehicles();

        public int AddVehicle(Vehicle vehicleData);

        public int UpdateVehicle(Vehicle vehicleData);

        public int RemoveVehicle(int vehicleId);
    }
}
