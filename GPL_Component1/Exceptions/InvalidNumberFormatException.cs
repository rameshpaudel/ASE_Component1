using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPL_Component1.Exceptions
{
    [Serializable]
    class InvalidNumberFormatException:Exception
    {
        public InvalidNumberFormatException()
        {

        }
        public InvalidNumberFormatException(string name)
        : base(String.Format("Invalid number format : {0}", name))
        {

        }
    }
}
