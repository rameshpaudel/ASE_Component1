using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPL_Component1
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>    Abstract Shape class  </summary>
    ///
    /// <remarks>   Ramesh Paudel. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public abstract class Shape : ShapeInterface
    {
        protected Boolean isFilled = true;
        //The default color
        protected Color color;
        protected int x, y;
        //Stroke size for borders
        protected int strokeSize = 1;

        //Points for line
        protected Point lastPoint;
        protected Point currentPoint;

        public Shape()
        {
            color = Color.Red;
            x = y = 100;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets if the shape is  filled. </summary>
        ///
        /// <remarks>   Ramesh Paudel </remarks>
        ///
        /// <param name="status">  Set true to fill the shape. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Draw the shape on the graphics </summary>
        ///
        /// <remarks>   Ramesh Paudel. </remarks>
        ///
        /// <param name="g">    The Graphics to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public abstract void draw(Graphics g); //any derrived class must implement this method

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Set the x,y coordinates </summary>
        ///
        /// <remarks>   Ramesh Paudel. </remarks>
        ///
        /// <param name="colour">   The colour to be set. </param>
        /// <param name="list">     A variable-length parameters list containing list. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual void set(Color colour, params int[] list)
        {
            this.color = colour;
            this.x = list[0];
            this.y = list[1];
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets the size of stroke. </summary>
        ///
        /// <remarks>   Ramesh Paudel. </remarks>
        ///
        /// <param name="size"> The size. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void setStroke(int size)
        {
            this.strokeSize = size;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets the default color. </summary>
        ///
        /// <remarks>   Ramesh Paudel. </remarks>
        ///
        /// <param name="c">    A Color to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void setColor(Color c)
        {
            this.color = c;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Set the point, its used in case of line </summary>
        ///
        /// <remarks>   Ramesh Paudel </remarks>
        ///
        /// <param name="lastPoint">    The starting point of line. </param>
        /// <param name="current">      The ending point of the line. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public void setPoint(Point lastPoint, Point current)
        {
            this.lastPoint = lastPoint;
            this.currentPoint = current;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets the x,y coordinates. </summary>
        ///
        /// <remarks>   Ramesh Paudel. </remarks>
        ///
        /// <param name="list"> A variable-length parameters list containing list. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void setCoordinates(int[] list)
        {
            this.x = list[0];
            this.y = list[1];

        }
    }
}
