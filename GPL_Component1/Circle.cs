using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPL_Component1
{
    class Circle:Shape
    {
        int radius;

        public Circle() : base()
        {

        }
        public Circle(Color colour, int x, int y, int radius) : base(colour, x, y)
        {

            this.radius = radius; //the only thingthat is different from shape
        }


        public override void set(Color colour, params int[] list)
        {
            //list[0] is x, list[1] is y, list[2] is radius
            base.set(colour, list[0], list[1]);
            this.radius = list[2];
        }



        public override void draw(Graphics g)
        {

            Pen p = new Pen(color, strokeSize);
            SolidBrush b = new SolidBrush(color);
            int diameter = radius * 2;

            if (isFilled)
            {
                g.FillEllipse(b, x, y, diameter, diameter);
            }
            g.DrawEllipse(p, x, y, diameter, diameter);

        }

        public override double calcArea()
        {
            return Math.PI * (radius ^ 2);
        }

        public override double calcPerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public override string ToString() //all classes inherit from object and ToString() is abstract in object
        {
            return base.ToString() + "  " + this.radius;
        }
    }
}
