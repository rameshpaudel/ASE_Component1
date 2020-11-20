using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPL_Component1
{
    class InputParser
    {

        BaseParameterValidation baseValidator;
        ShapesValidator shapeValidator;
        public InputParser(Graphics g, string inp)
        {
            this.baseValidator = new BaseParameterValidation();
            this.shapeValidator = new ShapesValidator();
            parse(g, inp);

        }


        public void parse(Graphics gr, string input)
        {
            try
            {
                Console.WriteLine(input +" was the input");

                var inputArray = input.Split(' ');
                string shapeType = inputArray[0].ToLower();
                if (this.baseValidator.validate(inputArray))
                {
                    string[] inputArgs = inputArray[1].Split(',');
                    int[] args = Array.ConvertAll(inputArgs, Int32.Parse);
                    Console.WriteLine("[{0}] << ARGS", string.Join(", ", args));

                    
                    if (!this.shapeValidator.validate(shapeType))
                    {
                        MessageBox.Show("Invalid shape passed");
                    }
                    else
                    {
                        Console.WriteLine("Generated  "+shapeType+"  Shape !!!!!");
                        ShapesFactory factory = new ShapesFactory();
                        Shape c = factory.getShape(shapeType);
                        c.set(Color.Black, args);
                        c.draw(gr);
                    }
                }
                else
                {
                    baseValidator.errorMessage();
                }
            } catch (SystemException e)
            {
                MessageBox.Show("Error while parsing the data. Please try again");
            }
           



        }

    }
}
