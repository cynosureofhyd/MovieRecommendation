using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAlgorithms
{
    public class LongestIncreasingSubsequence
    {

       // public class InnerClass{
       //     public int MaxNo { get; set; }
       // }

       //private static int _lis( List<int> arr, int n, InnerClass cl)
       //{
       //     /* Base case */
       //     if(arr.Count() == 1)
       //         return 1;
 
       //     int res, max_ending_here = 1; // length of LIS ending with arr[n-1]
 
       //     /* Recursively get all LIS ending with arr[0], arr[1] ... ar[n-2]. If
       //        arr[i-1] is smaller than arr[n-1], and max ending with arr[n-1] needs
       //        to be updated, then update it */
       //     for(int i = 1; i < n; i++)
       //     {
       //         res = _lis(arr, i, cl);
       //         if (arr[i-1] < arr[n-1] && res + 1 > max_ending_here)
       //             max_ending_here = res + 1;
       //     }
 
       //     // Compare max_ending_here with the overall max. And update the
       //     // overall max if needed
       //     if (cl.MaxNo < max_ending_here)
       //        cl.MaxNo = max_ending_here;
 
       //     // Return length of LIS ending with arr[n-1]
       //     return max_ending_here;
       // }
 
       // // The wrapper function for _lis()
       // public static int lis(List<int> arr)
       // {
       //     // The max variable holds the result
       //     int max = 1;
       //     InnerClass cl = new InnerClass();
       //     cl.MaxNo = 1;
       //     // The function _lis() stores its result in max
       //     _lis( arr, arr.Count(), cl );
 
       //     // returns max
       //     return max;
       // }

        public class InnerClass
        {
            public int max { get; set; }
            public int minsofar { get; set; }
        }


        //public static int Find(List<int> array, int first, int last)
        //{
        //    if (array.Count <= 1)
        //        return 1;
        //    int minsofar = 0;
        //    for(int i = 0; i < array.Count(); i++)
        //    {
        //        InnerClass result = Wrapper(array, first, last);
        //        if (array[i] < result.minsofar)
        //            return 1 + result.max;
        //        else
        //            return result.max;
        //    }
        //}

        //private static InnerClass Wrapper(List<int> array, int first, int last)
        //{

        //}
    }
}
