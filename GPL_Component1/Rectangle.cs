using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPL_Component1
{
    class Rectangle : Shape
    {
        int width, height;
        public Rectangle() : base()
        {
            width = 100;
            height = 100;
        }
        public Rectangle(Color colour, int x, int y, int width, int height) : base(colour, x, y)
        {

            this.width = width; //the only thingthat is different from shape
            this.height = height;
        }

        public override void set(Color colour, params int[] list)
        {
            //list[0] is x, list[1] is y, list[2] is width, list[3] is height
            base.set(colour, list[0], list[1]);
            this.width = list[2];
            this.height = list[3];

        }

        public override void draw(Graphics g)
        {
            Pen p = new Pen(color, 2);
            SolidBrush b = new SolidBrush(color);
            if (isFilled)
            {
                g.FillRectangle(b, x, y, width, height);
            }
            g.DrawRectangle(p, x, y, width, height);
        }

        public override double calcArea()
        {
            return width * height;
        }

        public override double calcPerimeter()
        {
            return 2 * width + 2 * height;
        }
    }
}
