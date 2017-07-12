using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONITAMA.exception
{
    class ObstacleException : Exception 
    {
        public ObstacleException(): base("Default message"){}

        public ObstacleException(string message) : base(message){}
    }
}
