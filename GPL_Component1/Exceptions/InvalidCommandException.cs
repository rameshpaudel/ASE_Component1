using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPL_Component1.Exceptions
{
    [Serializable]
    class InvalidCommandException : Exception
    {
        public InvalidCommandException()
        {

        }
        public InvalidCommandException(string name, int i)
        : base(String.Format("Invalid command {0} supplied on line {1}", name, i))
        {

        }
    }
}
