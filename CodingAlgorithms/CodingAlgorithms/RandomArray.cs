using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAlgorithms
{
    public class RandomArray
    {
        public static List<int> CreateRandomList(int size)
        {
            List<int> randomArray = new List<int>();
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                randomArray.Add(rand.Next());
            }
            return randomArray;
        }
    }
}
