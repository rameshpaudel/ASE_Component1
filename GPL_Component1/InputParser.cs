using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;
using GPL_Component1.Exceptions;

namespace GPL_Component1
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An input parser which parses the command from the textbox </summary>
    ///
    /// <remarks>   Ramesh Paudel, 12/24/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    class InputParser
    {

        TextBox editor;

        ShapesFactory factory = new ShapesFactory();

        //Validators to validate all methods
        BaseParameterValidation baseValidator;
        CommandValidator cmdValidator;

        ConditionParser conditionParser;

        //All shapes in the chart
        List<Shape> shapeList = new List<Shape>();

        Color currentColor = Color.Black;

        int[] defaultPosititon = { 10, 15 };

        //Filling the shapes with color
        Boolean isFilled = false;

        //Total number of lines of code
        int totalNumberOfLines = 0;

        ArrayList errorLines = new ArrayList();

        int ifStartIndex = -1;

        int loopStartIndex = -1;
        int loopEndIndex = -1;

        int loopCounter = 0;

        /// <summary>   True to if found. </summary>
        Boolean ifFound = false;
        Boolean ifStatus;


        string loopCode;
        /// <summary>   True if loop started. </summary>
        Boolean loopStarted = false;


        public InputParser(Color color, Boolean filled, TextBox textArea)
        {
            this.baseValidator = new BaseParameterValidation();
            this.cmdValidator = new CommandValidator();
            totalNumberOfLines = textArea.Lines.Length;
            currentColor = color;
            editor = textArea;
            isFilled = filled;

            conditionParser = new ConditionParser();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Generate the paramters with x,y coordinates </summary>
        ///
        /// <remarks>   Ramesh Paudel </remarks>
        ///
        /// <param name="inputArgs">    The input arguments. </param>
        ///
        /// <returns>   An int[]. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected int[] parameterGenerator(string[] inputArgs)
        {
            return defaultPosititon.Union(intConverter(inputArgs)).ToArray();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Parses the data, if present a variable then converts it into variable value </summary>
        ///
        /// <remarks>   Ramesh Paudel</remarks>
        ///
        /// <param name="data"> The data. </param>
        ///
        /// <returns>   An int[]. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected int[] intConverter(string[] data)
        {
            List<int> variablePlaced = new List<int>();

            for (var d = 0; d < data.Length; d++)
            {

                if (!this.cmdValidator.IsDigitsOnly(data[d]))
                {
                    int actualValue = VariableParser.getVariable(data[d]);
                    if (actualValue != -1)
                    {
                        variablePlaced.Add(actualValue);
                    }
                }
                else
                {
                    if (!(string.IsNullOrEmpty(data[d]) || string.IsNullOrWhiteSpace(data[d])))
                    {
                        variablePlaced.Add(Int32.Parse(data[d]));

                        continue;
                    }
                    else
                    {
                       // throw new InvalidNumberFormatException();
                    }


                }
            }
            return variablePlaced.ToArray();

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>    Check if the passed command is valid </summary>
        ///
        /// <remarks>   Ramesh Paudel  </remarks>
        ///
        /// <param name="command">  The command. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Boolean commandValidation(string command)
        {
            return this.cmdValidator.validate(command);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Parses the source code by each line and paints it</summary>
        ///
        /// <remarks>   Ramesh Paudel</remarks>
        ///
        /// <param name="gr">   The graphics. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Parse(Graphics gr)
        {
            CodeValidator cv = new CodeValidator();


            if (!cv.checkLoopAndIfValidation(editor))
            {
                return;
            }
            int[] loopPos = cv.loopPosition();

            loopEndIndex = loopPos[1];
            string[] commands = editor.Lines;
            try
            {
                //Read the source code
                for (int i = 0; i < commands.Length; i++)
                {

                    //Trim all the whitespaces from the input
                    string parsedInput = trimWhitespace(commands[i]);


                    //Check if the if statment is initialized
                    if (ifStartIndex > -1)
                    {
                        if (!ifStatus)
                        {
                            continue;
                        }
                        //Check if the command has endif statment
                        if (this.cmdValidator.checkEndIf(commands[i].Trim()))
                        {
                            ifFound = false;
                            ifStatus = false;
                            ifStartIndex = -1;
                            continue;
                        }
                    }

                    if (this.cmdValidator.checkValidIfCondition(parsedInput))
                    {

                        checkAndRunCondition(parsedInput, i);
                        continue;

                    }


                    if (this.cmdValidator.checkLoopStart(parsedInput))
                    {
                        this.conditionParser.setLoopCondition(parsedInput);
                        loopStartIndex = i;
                        if (this.conditionParser.check())
                        {

                            if (this.conditionParser.validateExpression())
                            {
                                loopStarted = true;
                                continue;
                            }
                        }
                    }

                    if (loopStarted)
                    {
                        if (this.cmdValidator.checkLoopEnd(parsedInput))
                        {
                            loopEndIndex = i;
                            loopStarted = false;
                        }
                    }

                    singleLineCodeParser(parsedInput, i);
                }





            }
            catch (InvalidConditionException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (InvalidNumberFormatException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (InvalidCommandException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (InvalidParameterException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            try
            {

                runLoopIfPresent();
            } catch(IndexOutOfRangeException exp)
            {
                
            }
            paintShapes(gr);

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Paint all the shapes generated from the source code </summary>
        ///
        /// <remarks>   Ramesh Paudel </remarks>
        ///
        /// <param name="gr">   The graphics. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        protected void paintShapes(Graphics gr)
        {
            for (int i = 0; i < shapeList.Count; i++) // Loop through List with for
            {
                Shape shape = shapeList[i];
                shape.draw(gr);
            }

        }


        protected void runMoveTo(string[] inputParams)
        {
            //Generate parameters
            int[] args = intConverter(inputParams);

            if (args.Length == 2)
            {
                Shape shape = shapeList.Last();
                shape.setCoordinates(args);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the 'draw to' command from the code. </summary>
        ///
        /// <remarks>   Ramesh Paudel, 12/28/2020. </remarks>
        ///
        /// <param name="inputParams">  Options for controlling the input. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void runDrawTo(string[] inputParams)
        {
            Point initialPoint = new Point(Int32.Parse(inputParams[0].Trim()));
            Point finalPoint = new Point(Int32.Parse(inputParams[1].Trim()));
            //Generate parameters
            int[] args = parameterGenerator(inputParams);
            //Generate the shape 
            Shape c = factory.GetShape("line");
            c.setPoint(initialPoint, finalPoint);
            shapeList.Add(c);
            c.setFill(isFilled);
            c.set(currentColor, args);
        }

        protected void generateShape(string[] inputParams, string shape)
        {
            //Generate parameters
            int[] args = parameterGenerator(inputParams);
            //Generate the shape 
            Shape c = factory.GetShape(shape);
            shapeList.Add(c);
            c.setFill(isFilled);
            c.set(currentColor, args);
        }

        protected void parseVariable(string parsedInput)
        {
            VariableParser.setVariable(parsedInput.Trim().ToLower());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Executes the 'loop if present' operation. </summary>
        ///
        /// <remarks>   Ramesh Paudel </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void runLoopIfPresent()
        {
            string[] code = editor.Lines;
            if (loopStartIndex != -1)
            {
                this.conditionParser.setLoopCondition((code[loopStartIndex]));
            }
            //get the value of the counter

            //iterate the counter and add to the counter
            try
            {
               

                while (this.conditionParser.validateExpression())
                {

                    if (loopStartIndex != -1 || code.Length >= loopStartIndex)
                    {
                        this.conditionParser.setCondition(code[loopStartIndex]);

                    }
                    for (int i = (loopStartIndex + 1); i < loopEndIndex; i++)
                    {
                        //Check if the code is empty
                        if (string.IsNullOrEmpty(code[i]) || string.IsNullOrWhiteSpace(code[i]))
                        {
                            continue;
                        }


                        ///Check if the loop contains a incrementor of conditional variable
                        if (code[i].Contains("+") && code[i].Split('+').Length == 2)
                        {
                            string[] incrementOperation = code[i].Trim().Split('+');
                            string varName = incrementOperation[0].Trim().ToLower();
                            string varValue = incrementOperation[1].Trim().ToLower();
                            int varInt = Int32.Parse(varValue);
                            int oldVar = VariableParser.getVariable(varName);
                            string expression = varName + " = " + (varInt + oldVar);
                            VariableParser.setVariable(expression);
                            //Skip the line after the operation
                            continue;
                        }
        
                        singleLineCodeParser(code[i], i);
                    }
                    //Set the condition again 
                    this.conditionParser.setLoopCondition(code[loopStartIndex]);

                }
            }
            catch (InvalidCommandException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (InvalidParameterException ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Check and run move to. </summary>
        ///
        /// <remarks>   Ramesh Paudel, 12/28/2020. </remarks>
        ///
        /// <exception cref="InvalidParameterException">    Thrown when an Invalid Parameter error
        ///                                                 condition occurs. </exception>
        ///
        /// <param name="inputParams">  Options for controlling the input. </param>
        /// <param name="i">            Zero-based index of the. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void checkAndRunMoveTo(string[] inputParams, int i)
        {
            //Validate the moveto has to have 2 parameters
            if (this.baseValidator.validate(inputParams))
            {
                runMoveTo(inputParams);
            }
            else
            {
                MessageBox.Show("Invalid parameter supplied on moveto on line :" + (i + 1) + "\nExactly 2 parameters required");
                throw new InvalidParameterException("moveto", "" + (i + 1));
            }
        }

        protected void checkAndRunCondition(string parsedInput, int i)
        {
            this.conditionParser.setCondition(parsedInput);
            if (this.conditionParser.check())
            {
                ifStartIndex = i;
                ifFound = true;
                ifStatus = this.conditionParser.validateExpression();
            }
            else
            {
                throw new InvalidConditionException("" + i);
            }
        }


        protected void singleLineCodeParser(string parsedInput, int i)
        {

            //Number of equal Sign
            int equalsCount = parsedInput.Count(f => f == '=');

            Boolean isAVariable = equalsCount == 1;

            //If the variable is Valid
            if (isAVariable && this.cmdValidator.isValidVar(parsedInput))
            {
                parseVariable(parsedInput);
                return;
            }

            
            string[] inputArray = trimWhitespace(parsedInput).Trim().Split(' ');
            string callingMethod = inputArray[0];

            if (!commandValidation(callingMethod))
            {
                errorLines.Add(i + 1);
                throw new InvalidCommandException(callingMethod, (i + 1));
            }

            //Check if the parameters are present in the code
            if (this.baseValidator.validate(inputArray))
            {
                //Split the parameters
                string[] inputParams = inputArray[1].Split(',');

                if (callingMethod.Equals("moveto"))
                    checkAndRunMoveTo(inputParams, i);

                if (callingMethod.Equals("drawto"))
                    runDrawTo(inputParams);

                //Check if the shape is valid
                if (this.cmdValidator.checkValidShape(callingMethod))
                    generateShape(inputParams, callingMethod);

                return;
            }

            throw new InvalidParameterException("supplied", "" + (i + 1));



        }


        private string trimWhitespace(string s)
        {
            return Regex.Replace(s, @"\s+", " ").ToLower();
        }


    }
}
