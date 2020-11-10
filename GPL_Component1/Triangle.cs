using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPL_Component1
{
    class Triangle:Shape
    {
        int height, hypotenus, baseSize;
        private Point[] points;
        public Triangle() : base()
        {

        }
        public Triangle(Color colour, int x, int y, int height, int hypotenus, int baseSize) : base(colour, x, y)
        {

            this.height = height; //the only thingthat is different from shape
            this.hypotenus = hypotenus;
            this.baseSize = baseSize;
        }


        public override void set(Color colour, params int[] list)
        {
            //list[0] is x, list[1] is y, list[2] is radius
            base.set(colour, list[0], list[1]);
            this.hypotenus = list[2];
            this.height = list[3];
            this.baseSize = 20;

            Point point1 = new Point() { X = list[0], Y = list[2] + list[3] };
            Point point2 = new Point() { X = list[0] + (list[2]  / 2), Y = list[1]};
            Point point3 = new Point() { X = list[0] + list[2], Y = list[1]+ list[3]};
            points = new Point[] { point1, point2, point3 };

        }

     



        public override void draw(Graphics g)
        {

            Pen pen = new Pen(color, strokeSize);
            SolidBrush sb = new SolidBrush(color);
            if (isFilled) { 
                g.FillPolygon(sb, points);
            }
            g.DrawPolygon(pen, points);

        }

        public override double calcArea()
        {
            return 1/2* baseSize * height;
        }

        public override double calcPerimeter()
        {
            return baseSize + height + hypotenus;
        }

        public override string ToString() //all classes inherit from object and ToString() is abstract in object
        {
            return base.ToString() + "  " + this.height;
        }
    }
}
