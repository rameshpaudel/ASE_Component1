using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPL_Component1
{
    public sealed class VariableParser
    {
        public static Dictionary<string, int> varDictionary;

        public static VariableParser instance = null;

        public static VariableParser GetInstance()
        {
            if (instance == null)
                instance = new VariableParser();
            return instance;

        }
        //Limit access make a singleton
        private VariableParser()
        {
            varDictionary = new Dictionary<string, int>();

        }

        public static void  setVariable(string data)
        {
            string[] split = data.Trim().ToLower().Split('=');
            if(split.Length > 1)
            {
                string trimmedKey = split[0].Trim();
                int value = Int32.Parse(split[1]);
                if (varDictionary.ContainsKey(trimmedKey))
                {
                    varDictionary[trimmedKey] = value;
                }
                else
                {
                    varDictionary.Add(trimmedKey, value);
                }
            }
        }


        public static int getVariable(string data)
        {
            if (isValid(data))
            {
                return varDictionary[data];
            }
            return -1;
        }

        public static Boolean isValid(string data)
        {
            return varDictionary.ContainsKey(data);
        }
    }
}
