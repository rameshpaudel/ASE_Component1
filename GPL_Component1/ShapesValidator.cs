using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPL_Component1
{
    public class ShapesValidator
    {

        private string[] shapeList()
        {
            string[] list = {
                "circle",
                "rectangle",
                "square",
                "triangle"
            };
            return list;
        }
        public bool validate(string data)
        {
            return shapeList().Contains(data);
        }

        public void errorMessage()
        {
            System.Windows.Forms.MessageBox.Show("Error shape passed");
        }
    }
}
