using System;
using System.Collections.Generic;
using System.Linq;

namespace Find_K_Closest_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 0, 0, 1, 2, 3, 34, 7, 7, 8 };
            Console.WriteLine(string.Join(" ",FindClosestElements(input, 3, 5)));
            Console.WriteLine(string.Join(" ", FindClosestElementBnarySearch(input, 3, 5)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="arr">input array</param>
        /// <param name="k">k no of elements</param>
        /// <param name="x">k closest element closest to value x</param>
        /// <returns></returns>
        static IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            IList<int> result = new List<int>();
            int length = arr.Length;
            int low = 0;
            int high = length - 1;
            while(high - low >= k)
            {
                if (arr[high] - x >= x - arr[low]) high--;
                else low++;
            }

            for (int i = low; i <= high; i++)
                result.Add(arr[i]);

            return result;
        }

        static IList<int> FindClosestElementBnarySearch(int[] arr, int k , int x)
        {
            IList<int> result = new List<int>();
            int length = arr.Length;
            if (x < arr[0]) return arr.Skip(0).Take(k).ToList();

            if (x > arr[length - 1]) return arr.Skip(length - k).Take(k).ToList();

            int low = 0;
            int high = length - k;
            while(low < high)
            {
                int mid = (high + low) / 2 - low;
                if (Math.Abs(arr[mid] - x) > Math.Abs(arr[mid + k] - x)) low = mid + 1;
                else high = mid;
            }

            for (int i = low; i < low + k; i++)
                result.Add(arr[i]);

            return result;
        }
    }
}
