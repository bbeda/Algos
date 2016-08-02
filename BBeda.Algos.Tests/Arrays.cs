using BBeda.Algos.Arrays;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBeda.Algos.Tests
{
    [TestFixture]
    public class Arrays
    {
        [Test]
        [TestCase(new[] { 3, 4, 6, 7 }, ExpectedResult = true)]
        [TestCase(new[] { -2, 3, 4, 6, 7 }, ExpectedResult = true)]
        [TestCase(new[] { 3 }, ExpectedResult = true)]
        [TestCase(new[] { 3, 3 }, ExpectedResult = true)]
        [TestCase(new int[0], ExpectedResult = true)]
        [TestCase(new[] { 3, 2 }, ExpectedResult = false)]
        [TestCase(new[] { 3, -5 }, ExpectedResult = false)]
        [TestCase(new[] { 3, -3 }, ExpectedResult = false)]

        public bool IsSorted(int[] array)
        {
            return array.IsSorted();
        }

        [Test]
        [TestCase(new[] { 10, 7, 9, 6, 4, 2, 1 })]
        [TestCase(new[] { 3 })]
        [TestCase(new[] { 3, 3 })]
        [TestCase(new int[0])]
        [TestCase(new[] { 7, 6, 2, 5 })]
        [TestCase(new[] { -8, 2, 1, 20, 4 })]
        [TestCase(new[] { 8, 2, 25, 5, 8 })]
        [TestCase(new[] { 7, 7, 5, 2 })]
        [TestCase(new[] { -1, 0, 1 })]
        public void MergeSort(int[] array)
        {
            var sorted = array.MergeSort();
            Assert.IsTrue(sorted.IsSorted());
        }

        [TestCase(10)]
        [TestCase(100)]
        [TestCase(1000)]
        [TestCase(10000)]
        [TestCase(100000)]
        [TestCase(1000000)]
        [TestCase(10000000)]
        [TestCase(10000000)]
        public void MergeSort(int size)
        {
            var rand = new Random();
            var array = Enumerable.Range(0, size).Select(v => rand.Next(0, size)).ToArray();
            var sorted = array.MergeSort();
            Assert.IsTrue(sorted.IsSorted());
        }
    }
}
