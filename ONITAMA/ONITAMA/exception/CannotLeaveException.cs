using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONITAMA.exception
{
    class CannotLeaveException : Exception
    {
        public CannotLeaveException() : base("Default message") { }

        public CannotLeaveException(string message) : base(message) { }
    }
}
