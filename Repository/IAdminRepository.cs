

using CarConnect.Model;

namespace CarConnect.Repository
{
    internal interface IAdminRepository
    {
        public List<Admin> GetAdminById(int adminId);
        public List<Admin> GetAdminByUsername(string username);

        public int RegisterAdmin(Admin admin);

        public int UpdateAdmin(Admin admin);

        public int DeleteAdmin(int adminId);
    }
}
