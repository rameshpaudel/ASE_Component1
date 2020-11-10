using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPL_Component1
{
    abstract class Shape:ShapeInterface
    {
        protected Boolean isFilled = true;
        //The default color
        protected Color color; 
        protected int x, y; 
        //Stroke size for borders
        protected int strokeSize = 1;
        
        //
        protected  Point lastPoint;
        protected  Point currentPoint;

        public Shape()
        {
            color = Color.Red;
            x = y = 100;
        }

        public void setFill(Boolean status)
        {
            this.isFilled = status;
        }

        public Shape(Color colour, int x, int y)
        {

            this.color = colour; //shape's colour
            this.x = x; //its x pos
            this.y = y; //its y pos
            //can't provide anything else as "shape" is too general
        }

       // Draw the shape on the graphics
        public abstract void draw(Graphics g); //any derrived class must implement this method
        
        //Calculate the area 
        public abstract double calcArea();

        //Calculate the Perimeter
        public abstract double calcPerimeter();

        //Set the x,y coordinates
        public virtual void set(Color colour, params int[] list)
        {
            this.color = colour;
            this.x = list[0];
            this.y = list[1];
        }

        public void setStroke(int size)
        {
            this.strokeSize = size;
        }

        public void setColor(Color c)
        {
            this.color = c;
        }
        public override string ToString()
        {
            return base.ToString() + "    " + this.x + "," + this.y + " : ";
        }

        //Set the point, its used in case of line
        public  void setPoint(Point lastPoint , Point current)
        {
            this.lastPoint = lastPoint;
            this.currentPoint = current;
        }
    }
}
