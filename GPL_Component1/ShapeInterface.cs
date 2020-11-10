using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPL_Component1
{
    interface ShapeInterface
    {       
            void set(System.Drawing.Color c, params int[] list);
            void draw(Graphics g);
            double calcArea();
            double calcPerimeter();

    }
}
