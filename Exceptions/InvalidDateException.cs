using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.Exceptions
{
    internal class InvalidDateException:Exception
    {
        public InvalidDateException( string msg):base(msg)
        {
            
        }
    }
}
