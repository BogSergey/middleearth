using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace middleearth
{
    class powerException : Exception
    {
        public powerException(String msg) : base(msg)
        {
        }
    }
}
