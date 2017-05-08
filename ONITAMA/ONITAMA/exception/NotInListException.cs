using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONITAMA.exception
{
    class NotInListException : Exception 
    {
        public NotInListException(): base("Default message"){}

        public NotInListException(string message) : base(message){}
    }
}
