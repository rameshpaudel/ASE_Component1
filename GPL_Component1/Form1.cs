﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPL_Component1
{
    public partial class Form1 : Form
    {

        //main Graphics object of the pictureBox
        Graphics panelGraphics;
        // Working Graphics object, whicll will work when dragging items
        Graphics workingGraphics;

        private int strokeSize = 1;

        Color currentColor;


        /// <summary>   The file dialog. </summary>
        OpenFileDialog fd = new OpenFileDialog();

        Button selectedShapeButton;
        Boolean isFilled;

        Point firstPoint;
        Boolean haveFirstPoint;


        ColorDialog colorPicker = new ColorDialog();


        Bitmap paintImage;

        Bitmap workingImage;
        // declare variable 
        Point lastPoint;
        bool isMouseDown = false;
        ShapesFactory sf;

        public Form1()
        {
            InitializeComponent();
            this.loadPictureBox();
            this.currentColor = Color.Black;
            selectedShapeButton = penButton;
            /*this.EnableDrawing();*/
            sf = new ShapesFactory();

        }



        private Shape DrawShapeInWorkingImage(Point currentPoint)
        {
            Pen pen = new Pen(this.currentColor, strokeSize);

            // Draw outline while drawing shapes
            Pen outLinePen = new Pen(Color.Black);
            outLinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            workingImage = new Bitmap(paintImage);
            workingGraphics = Graphics.FromImage(workingImage);


            int startPointX = lastPoint.X < currentPoint.X ? lastPoint.X : currentPoint.X;
            int startPointY = lastPoint.Y < currentPoint.Y ? lastPoint.Y : currentPoint.Y;

            int shapeWidth = (lastPoint.X > currentPoint.X ? lastPoint.X : currentPoint.X) - startPointX;
            int shapeHeight = (lastPoint.Y > currentPoint.Y ? lastPoint.Y : currentPoint.Y) - startPointY;

            int[] coOrdinates = { startPointX, startPointY, shapeWidth, shapeHeight };

            Shape myShape = sf.GetShape(selectedShapeButton.Text);

            myShape.setStroke(strokeSize);

            if (myShape is Line)
            {
                myShape.setPoint(lastPoint, currentPoint);
            }

            myShape.set(colorPicker.Color, coOrdinates);

            if (isMouseDown)
            {
                workingGraphics.DrawRectangle(outLinePen, startPointX, startPointY, shapeWidth, shapeHeight);
            }
            myShape.setFill(isFilled);
            myShape.draw(workingGraphics);
            pictureBox1.Refresh();
            pictureBox1.Image = workingImage;
            return myShape;

        }


        void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            Shape s = DrawShapeInWorkingImage(e.Location);
            s.draw(panelGraphics);
            pictureBox1.Image = workingImage;
            pictureBox1.Refresh();


        }



        private void TrackCoordinates()
        {
            ToolTip trackTip = new ToolTip();
            this.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
        }





        // pictureBox1 MouseDown event
        void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;
            isMouseDown = true;
            pictureBox1.Image = paintImage;
            pictureBox1.Refresh();




        }

        // make canvas to drawlines in pictureBox1
        private void DrawLineInCanvas(Point currentPoint)
        {

            // Form pen with the color selected and the size value in tracker


            Shape line = sf.GetShape("pen");
            line.setColor(colorPicker.Color);
            line.setStroke(strokeSize);
            line.setPoint(lastPoint, currentPoint);

            line.draw(panelGraphics);
            lastPoint = currentPoint;

            /*pictureBox1.Image = workingImage;*/
            pictureBox1.Refresh();

        }




        private void loadPictureBox()
        {

            int width = pictureBox1.Width;
            int height = pictureBox1.Height;

            paintImage = new Bitmap(width, height);

            panelGraphics = Graphics.FromImage(paintImage);

            panelGraphics.FillRectangle(Brushes.White, 0, 0, width, height);

            pictureBox1.Image = paintImage;

            pictureBox1.MouseDown += new MouseEventHandler(pictureBox1_MouseDown); // picture Box mouse down
            pictureBox1.MouseMove += new MouseEventHandler(pictureBox1_MouseMove); // picture box mouse move
            pictureBox1.MouseUp += new MouseEventHandler(pictureBox1_MouseUp); // picture box mouse up

            workingImage = paintImage;


        }


        private void runButton_Click(object sender, EventArgs e)
        {
            
            InputParser ip = new InputParser(colorPicker.Color, isFilled, commandInputBox);
            ip.Parse(panelGraphics);
            pictureBox1.Image = workingImage;
            pictureBox1.Refresh();
            

        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            loadPictureBox();
            commandInputBox.Text = "";
        }

        private void colorPickBtn_Click(object sender, EventArgs e)
        {

            colorPicker.ShowDialog();
        }



        private void penButton_Click(object sender, EventArgs e)
        {
            selectedShapeButton = penButton;
        }

        private void circleButtonSelect_Click(object sender, EventArgs e)
        {
            selectedShapeButton = circleButtonSelect;
        }

        private void rectangleBtnSelect_Click(object sender, EventArgs e)
        {
            selectedShapeButton = rectangleBtnSelect;
        }

        private void squareBtnSelect_Click(object sender, EventArgs e)
        {
            selectedShapeButton = squareBtnSelect;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by triangleBtnSelect for click events. </summary>
        ///
        /// <remarks>   Ramesh Paudel  </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void triangleBtnSelect_Click(object sender, EventArgs e)
        {
            selectedShapeButton = triangleBtnSelect;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by pictureBox1 for mouse move events. </summary>
        ///
        /// <remarks>   Ramesh Paudel  </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Mouse event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            String tipText = String.Format("({0}, {1})", e.X, e.Y);

            if (isMouseDown)
            {
                toolTip1.Show(tipText, this, e.Location);
                if (selectedShapeButton.Text == "Pen")
                {
                    DrawLineInCanvas(e.Location);
                }
                else
                {
                    DrawShapeInWorkingImage(e.Location);

                }
            }
        }

        private void penTrackBar_ValueChanged(object sender, EventArgs e)
        {
            strokeSize = penTrackBar.Value;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            fd.ShowDialog();

            paintImage = new Bitmap(fd.FileName);
            panelGraphics = Graphics.FromImage(paintImage);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by saveToolStripMenuItem for click events. </summary>
        ///
        /// <remarks>   Ramesh Paudel  </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.ShowDialog();
            workingImage.Save(sf.FileName);
            /*paintImage.Save(sf.FileName);*/
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by checkBox1 for checked changed events. </summary>
        ///
        /// <remarks>   Ramesh Paudel  </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            isFilled = checkBox1.Checked;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by exitToolStripMenuItem for click events. </summary>
        ///
        /// <remarks>   Ramesh Paudel  </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by loadToolStripMenuItem for click events./ </summary>
        ///
        /// <remarks>   Ramesh Paudel  </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            fd.ShowDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                commandInputBox.Clear();
                string line = "";
                StreamReader sr = new StreamReader(fd.FileName);
                while (line != null)
                {
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        commandInputBox.Text += line;
                        commandInputBox.Text += "\r\n";
                    }
                }
            }

        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copyright 2020\nRamesh Paudel\nLeeds Beckett University\n");
        }
    }
}
