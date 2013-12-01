using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> randomArray = RandomArray.CreateRandomList(10);
            //int lis = LongestIncreasingSubsequence.lis(randomArray);
            bool result = BalancingParentheses.IsBalanced("[(){}]");
            Console.WriteLine();
            bool result1 = BalancingParentheses.IsBalanced("[()[]{}({}])");
            bool result2 = BalancingParentheses.IsBalanced("[[[]]]");
            bool result3 = BalancingParentheses.IsBalanced("[[[(())]]]{}{{[[[]]]}}()");
            bool result4 = BalancingParentheses.IsBalanced("[[]][][[[]]");
            bool result5 = BalancingParentheses.IsBalanced("{{}{]}[");
            bool result6 = BalancingParentheses.IsBalanced("{{[[}}]]");
            bool result7 = BalancingParentheses.IsBalanced("{]");
            bool result8 = BalancingParentheses.IsBalanced("[()[]{}({}])");
            bool result9 = BalancingParentheses.IsBalanced("(()))");
        }
    }
}
