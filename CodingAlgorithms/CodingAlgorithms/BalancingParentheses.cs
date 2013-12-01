using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAlgorithms
{
    public class BalancingParentheses
    {
        public static bool IsBalanced(string input)
        {
            Stack<char> st = new Stack<char>();
            if (input.Length == 0)
                return false;
            else
            {
                for(int i = 0; i < input.Length; i++)
                {
                    var variable = input[i];
                    if (variable == '[' || variable == '{' || variable == '(')
                        st.Push(variable);
                    else if(variable == ']' || variable == '}' || variable == ')')
                    {
                        if (st.Count() > 0 && !CheckMatching(st.Peek(), variable))
                        {
                            return false;
                        }
                        else
                        {
                            if(st.Count() > 0)
                            st.Pop();
                            continue;
                        }
                    }
                }
                if (st.Count > 0)
                    return false;
                return true;
            }
            return false;
        }

        private static bool CheckMatching(char a, char b)
        {
            if ((a == '[' && b == ']'))
                return true;
            if (a == '{' && b == '}')
                return true;
            if (a == '(' && b == ')')
                return true;
            else
                return false;
        }
    }

    
}
