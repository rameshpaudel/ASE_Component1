////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  GPL_Component1\CommandValidator.cs </file>
///
/// <copyright file="CommandValidator.cs" company="rameshpaudel.com">
/// Copyright (c) 2020 Ramesh Paudel. All rights reserved.
/// </copyright>
///
/// <summary>   Implements the command validator class. </summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Linq;


namespace GPL_Component1
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A command validator. Validates all the valid command. </summary>
    ///
    /// <remarks>   Ramesh Paudel. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class CommandValidator
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Validates the command passed. </summary>
        ///
        /// <remarks>   Ramesh Paudel. </remarks>
        ///
        /// <param name="data"> The command name. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool validate(string data)
        {
            return checkValidFunction(data) || checkValidShape(data) || data.Contains("=") || checkIfValid(data);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'str' is digits only. </summary>
        ///
        /// <remarks>   Ramesh Paudel. </remarks>
        ///
        /// <param name="str">  The string. </param>
        ///
        /// <returns>   True if digits only, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Boolean IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'data' is valid variable. </summary>
        ///
        /// <remarks>   Ramesh Paudel. </remarks>
        ///
        /// <param name="data"> The variable name. </param>
        ///
        /// <returns>   True if valid variable, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Boolean isValidVar(string data)
        {
            Boolean isVar = data.Contains("=");

            if (isVar)
            {
                string[] varSplit = data.Trim().ToLower().Split('=');
                return IsDigitsOnly(varSplit[1].Trim());
            }
            return false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Check if the shape is valid. </summary>
        ///
        /// <remarks>   Ramesh Paudel. </remarks>
        ///
        /// <param name="validShape">   The valid shape. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Boolean checkValidShape(string validShape)
        {
            string[] validShapes = { "circle", "rectangle", "square", "triangle", "drawto" };
            return validShapes.Contains(validShape);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Check if passed string is a valid function. </summary>
        ///
        /// <remarks>   Ramesh Paudel. </remarks>
        ///
        /// <param name="func"> The function. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Boolean checkValidFunction(string func)
        {
            string[] validFunctions = { "loop", "if", "endif", "endloop", "moveto" };
            return validFunctions.Contains(func.Trim().ToLower());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Check if the passed string is a valid condition. </summary>
        ///
        /// <remarks>   Ramesh Paudel. </remarks>
        ///
        /// <param name="cond"> The string to check if the condition is valid. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Boolean checkValidCondition(string cond)
        {
            string[] validConds = { ">", "<", "=",">=", "<=", "==" };
            return validConds.Contains(cond);
        }

        public Boolean checkValidIfCondition(string cmd)
        {
            string[] split = cmd.Split(' ');
            if(split.Length == 5 && split[0].ToLower().Trim().Equals("if") && split[4].ToLower().Trim().Equals("then"))
            {
                return true;
            }
            return false;
        }

        public Boolean checkEndIf(string cond)
        {
            return cond.ToLower().Equals("endif");
        }


        public Boolean checkValidLoopCondition(string cmd)
        {
            string[] split = cmd.Split(' ');
            if (split.Length == 4 && split[0].ToLower().Trim().Equals("loop"))
            {
                return true;
            }
            return false;
        }
        public Boolean checkLoopStart(string str)
        {
            string s = str.Split(' ')[0].Trim().ToLower();
            return s.Equals("loop");

        }

        public Boolean checkLoopEnd(string str)
        {
            return str.Trim().ToLower().Equals("endloop");
        }

        protected Boolean checkIfValid(string s)
        {
            Boolean isLoopIncrementer = s.Contains("+") && s.Split('+').Length == 2;
            Boolean isValidVariable = s.Count(f => f == '=') == 1;
            return isLoopIncrementer || isValidVariable;
        }
    }
}
