using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPL_Component1
{
    class BaseParameterValidation
    {
        public Boolean validate(string[] data)
        {
            return data.Length >= 2;
        }



        public void errorMessage()
        {
            System.Windows.Forms.MessageBox.Show("Invalid parameters passed. Three or more arguments required to pass the test");
        }
    }
}
