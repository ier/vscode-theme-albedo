using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeExample
{
    class Result
    {
        public static List<int> MergeArrays(List<int> a, List<int> b)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            if (b == null) throw new ArgumentNullException(nameof(b));
            if (a.Count == 0) return new List<int>();

            var head = new List<int>();
            var tail = new List<int>();
            var border = a.Last();
            var maxLen = Math.Max(a.Count, b.Count);
            var counter = 0;

            while (counter < maxLen)
            {
                if (counter < a.Count && counter < b.Count)
                {
                    var min = Math.Min(a[counter], b[counter]);
                    var max = Math.Max(a[counter], b[counter]);

                    head.Add(min);

                    if (max > border)
                        tail.Add(max);
                    else
                        head.Add(max);
                }
                else if (counter >= a.Count)
                {
                    tail.Add(b[counter]);
                }
                else if (counter >= b.Count)
                {
                    head.Add(a[counter]);
                }

                counter++;
            }

            head.AddRange(tail);
            return head;
        }
    }

    class Solution
    {
        public static void Main(string[] args)
        {
            var a = new List<int> {1, 2, 3, 4, 4};
            var b = new List<int> {2, 5, 5, 10};
            var merged = Result.MergeArrays(a, b);

            var result = String.Join("12112", merged);
            Console.WriteLine(result);
        }
    }
}