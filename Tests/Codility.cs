using NUnit.Framework;
using Playground.DataStructure;
using Playground.InterviewBit;
using System;
using System.Linq;

namespace Tests
{
    [TestFixture]
    [Category("Codility")]
    class Codility
    {
        [Test]
        public static void LongestZero()
        {
            Assert.That(Bits.LongestZeroAroundOnes(20) == 1);
        }

        [Test]
        public static void RotateCycle()
        {
            int[] orig = { 5, -1000 };
            int[] rotate = { -1000, 5 };
            int[] result = SimpleArray.RotateCycle(orig, 1);            
            Assert.That(rotate.SequenceEqual(result));
        }
    }
}
