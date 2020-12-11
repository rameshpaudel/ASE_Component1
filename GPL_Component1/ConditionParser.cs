using GPL_Component1.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPL_Component1
{
    class ConditionParser
    {
        Boolean isValid = false;

        string variableName;
        int variableValue;
        string condition;

        protected CommandValidator cv;

        public ConditionParser()
        {
            cv = new CommandValidator();
        }
        public Boolean checkValidIfCondition(string cmd)
        {
            string[] split = cmd.Split(' ');
            if (split.Length == 5 && split[0].ToLower().Trim().Equals("if") && split[4].ToLower().Trim().Equals("then"))
            {
                return true;
            }
            return false;
        }


        public void setCondition(string input)
        {
           
            string[] split = input.Split(' ');
            if (checkValidIfCondition(input))
            {
                if(split.Length == 5)
                {
                    variableName = split[1].Trim().ToLower();
                    condition = split[2].Trim().ToLower();
                    if (!this.cv.checkValidCondition(condition))
                    {
                        throw new InvalidConditionException();
                    }
                    string value = split[3].Trim().ToLower();
                    variableValue = Int32.Parse(value);
                    this.isValid = true;
                    
                    return;
                }
                
                return;

            }
        }
        public void setLoopCondition(string input)
        {
            string[] split = input.Split(' ');
            if (this.cv.checkValidLoopCondition(input))
            {
                if (split.Length == 4)
                {
                    variableName = split[1].Trim().ToLower();
                    condition = split[2].Trim().ToLower();
                    if (!this.cv.checkValidCondition(condition))
                    {
                        throw new InvalidConditionException();
                    }
                    string value = split[3].Trim().ToLower();
                    variableValue = Int32.Parse(value);
                    this.isValid = true;

                    return;
                }
                this.isValid = false;
                return;

            }
        }

        public Boolean check()
        {
            return isValid;
        }

        public Boolean validateExpression()
        {
            if (string.IsNullOrEmpty(variableName))
            {
                return false;
            }
            var parsedVar = VariableParser.getVariable(variableName);
            switch (condition)
            {
                case "==":
                    return parsedVar == variableValue;
                case "<=":
                    return parsedVar <= variableValue;
                case ">=":
                    return parsedVar >= variableValue;
                case "=>":
                    return parsedVar >= variableValue;
                case ">":
                    return parsedVar > variableValue;
                case "<":
                    return parsedVar < variableValue;
                case "=":
                    return parsedVar == variableValue;
                default:
                    return false;
            }
        }
    }
}
