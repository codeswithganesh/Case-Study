using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConnect.Exceptions
{
    internal class InvalidEmailFormatException:Exception
    {
        public InvalidEmailFormatException(string msg):base(msg)
        {
            
        }
    }
}
