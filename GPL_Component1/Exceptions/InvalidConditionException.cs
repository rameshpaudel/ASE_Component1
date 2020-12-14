using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPL_Component1.Exceptions
{
    [Serializable]
    class InvalidConditionException : Exception
    {
        public InvalidConditionException()
        {

        }
        public InvalidConditionException(string name)
        : base(String.Format("Invalid condition  on line {0}", name))
        {

        }
    }
}
