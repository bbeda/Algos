using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBeda.Algos.Arrays
{
    public static class ArraysExtensions
    {
        public static bool IsSorted(this int[] input)
        {
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] < input[i - 1])
                    return false;
            }

            return true;
        }

        public static int[] MergeSort(this int[] input)
        {
            return input.MergeSort(0, input.Length);
        }

        public static int[] MergeSort(this int[] input, int start, int end)
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


            var left = MergeSort(input, start, start + length / 2);
            var right = MergeSort(input, start + length / 2, end);
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
