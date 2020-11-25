using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        }

    
    
       


        void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
           
            
        }

             
     


        void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
          
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


        //Generate line on canvas
        private void DrawLineInCanvas(Point currentPoint)
        {
          
        }

 


       
    

        private void runButton_Click(object sender, EventArgs e)
        {
            string commandValue = commandInputBox.Text;
            InputParser ip = new InputParser(panelGraphics, commandValue);
            pictureBox1.Image = workingImage;
            pictureBox1.Refresh();
            commandInputBox.Text = "";


        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
          
        }

        private void colorPickBtn_Click(object sender, EventArgs e)
        {

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

        private void triangleBtnSelect_Click(object sender, EventArgs e)
        {
            selectedShapeButton = triangleBtnSelect;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
          
        }

        private void penTrackBar_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.ShowDialog();
            workingImage.Save(sf.FileName);
            /*paintImage.Save(sf.FileName);*/

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
