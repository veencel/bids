using System;
using Homework.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomeworkTests.Unit
{
    [TestClass]
    public class ArrayTest
    {
        [TestMethod]
        public void ItCanBeConstructedFromAnArray()
        {
            int[] numbers = new[] { 1, 2, 3 };

            var array = new Array<int>(numbers);

            Assert.AreEqual(3, array.Length);

            Assert.AreEqual(1, array[0]);
            Assert.AreEqual(2, array[1]);
            Assert.AreEqual(3, array[2]);
        }

        [TestMethod]
        public void ItCanAddAnItem()
        {
            var array = new Array<int>();

            Assert.AreEqual(0, array.Length);

            array.Add(2);

            Assert.AreEqual(1, array.Length);
            Assert.AreEqual(2, array[0]);

            array.Add(4);

            Assert.AreEqual(2, array.Length);
            Assert.AreEqual(4, array[1]);

            array.Add(6);

            Assert.AreEqual(3, array.Length);
            Assert.AreEqual(6, array[2]);
        }

        [TestMethod]
        public void ItCanMapTheItems()
        {
            var array = new Array<int>(new[] { 2, 4, 6 });

            var mapped = array.Map((number) => $"{number * 3}");

            Assert.AreEqual(3, mapped.Length);
            Assert.AreEqual("6", mapped[0]);
            Assert.AreEqual("12", mapped[1]);
            Assert.AreEqual("18", mapped[2]);
        }

        [TestMethod]
        public void ItCanBeReducedIntoASingleValue()
        {
            var array = new Array<int>(new[] { 2, 4, 6 });

            int reduced = array.Reduce((number, carry) => number + carry, 0);

            Assert.AreEqual(12, reduced);
        }

        [TestMethod]
        public void ItCanFilterTheItems()
        {
            var array = new Array<int>(new[] { 2, 3, 4, 5, 6 });

            var filtered = array.Filter((number) => number % 2 == 0);

            Assert.AreEqual(3, filtered.Length);
            Assert.AreEqual(2, filtered[0]);
            Assert.AreEqual(4, filtered[1]);
            Assert.AreEqual(6, filtered[2]);
        }

        [TestMethod]
        public void ItCanGetTheMaxValue()
        {
            var array = new Array<string>(new[] { "2", "3", "4" });

            string maximum = array.Max((numberString, max) => int.Parse(numberString) > int.Parse(max));

            Assert.AreEqual("4", maximum);
        }

        [TestMethod]
        public void ItCanBeUsedInForeach()
        {
            var array = new Array<int>(new[] { 2, 4, 6 });

            int counter = 0;

            foreach (int number in array)
            {
                Assert.AreEqual(array[counter++], number);
            }
        }

        [TestMethod]
        public void ItCanBeIndexed()
        {
            var array = new Array<int>(new[] { 2, 4, 6 });

            Assert.AreEqual(4, array[1]);

            array[1] = 123;

            Assert.AreEqual(123, array[1]);
        }

        [TestMethod]
        public void ItCanMergeAnOtherArray()
        {
            var array = new Array<int>(new[] { 1, 2 });
            var other = new Array<int>(new[] { 3, 4 });

            array.Merge(other);

            Assert.AreEqual(4, array.Length);
            Assert.AreEqual(1, array[0]);
            Assert.AreEqual(2, array[1]);
            Assert.AreEqual(3, array[2]);
            Assert.AreEqual(4, array[3]);
        }

        [TestMethod]
        public void ItCanPopTheFirstItem()
        {
            var array = new Array<int>(new[] { 10, 20, 30 });

            int first = array.PopFirst();

            Assert.AreEqual(10, first);

            Assert.AreEqual(2, array.Length);
            Assert.AreEqual(20, array[0]);
        }

        [TestMethod]
        public void ItCanGetTheUnderlyingArray()
        {
            int[] normalArray = new[] { 10, 20, 30 };
            var array = new Array<int>(normalArray);

            Assert.AreEqual(normalArray, array.All());
        }
    }
}
