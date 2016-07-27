using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 4;
            var rand = new Random();
            var array = Enumerable.Range(0, n).Select(v => rand.Next(0, n)).ToArray();
            Console.WriteLine(IsSorted(array));
            var sw = new Stopwatch();

            sw.Start();
            Array.Sort(array);
            sw.Stop();
            Console.WriteLine($"{IsSorted(array)} in {sw.Elapsed.TotalSeconds}");

            sw.Restart();
            var result = MergeSort(array, 0, array.Length);
            sw.Stop();

            Console.WriteLine($"{IsSorted(result)} in {sw.Elapsed.TotalSeconds}");

        }

        static bool IsSorted(int[] input)
        {
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] < input[i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        static int[] MergeSort(int[] input, int start, int end)
        {
            var length = end - start;
            if (length == 0)
            {
                return new int[0];
            }

            if (length == 1)
            {
                return new int[1] { input[start] };
            }


            var left = MergeSort(input, start, (length + 1) / 2);
            var right = MergeSort(input, length / 2, end);
            var lx = 0;
            var rx = 0;
            var result = new int[length];
            for (int i = 0; i < length; i++)
            {
                if (lx < left.Length && (rx == right.Length || left[lx] < right[rx]))
                {
                    result[i] = left[lx];
                    lx++;
                    continue;
                }
                else
                {
                    result[i] = right[rx];
                    rx++;
                }
            }

            return result;
        }
    }
}
