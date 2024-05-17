using CarConnect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.Service
{
    internal interface IAdminService
    {
        public void GetAdminById();
        public void GetAdminByUsername();

        public void RegisterAdmin();

        public void UpdateAdmin();

        public void DeleteAdmin();
    }
}
