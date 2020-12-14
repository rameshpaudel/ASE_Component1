using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPL_Component1.Exceptions
{
    [Serializable]
    class InvalidParameterException : Exception
    {

        public InvalidParameterException()
        {
        }

        public InvalidParameterException(string name, string line)
         : base(String.Format("Invalid parameter {0} on line : {1}", name, line))
        {

        }
    }
}
