using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.Exceptions
{
    internal class DatabaseConnectionException:Exception
    {
        public DatabaseConnectionException(string message, System.Data.SqlClient.SqlException ex) : base(message)
        {
        }
    }
}
