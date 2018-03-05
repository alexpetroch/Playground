using NUnit.Framework;
using Playground.Interview;

namespace Tests
{
    [TestFixture]
    [Category("Leet")]
    public class Leet
    {

        [Test]
        public static void FindKthLargest()
        {
            ArrayQ arrayQ = new ArrayQ();
            int[] arr = { 3, 2, 1, 5, 6, 4 };
            int res = arrayQ.FindKthLargest(arr, 2);
        }

        [Test]
        public static void LetterCombinations()
        {
            BackTrackingQ back = new BackTrackingQ();
            var combines = back.LetterCombinations("23");
        }

        [Test]
        public static void Median()
        {
            MedianFinder median = new MedianFinder();
            median.AddNum(40);
            median.AddNum(12);
            median.AddNum(16);
            median.AddNum(14);
            median.AddNum(35);
            median.AddNum(19);
            median.AddNum(34);
            median.AddNum(35);
            median.AddNum(28);
            median.AddNum(35);
            median.AddNum(26);
            median.AddNum(6);
            median.AddNum(8);
            median.AddNum(2);

            median.FindMedian();

            median.AddNum(14);
            median.AddNum(25);
            median.AddNum(25);
            median.AddNum(4);
            median.AddNum(33);
            median.AddNum(18);
        }

        [Test]
        public static void Rob()
        {
            int[] arr = new int[] { 12, 3, 4, 20, 1 };
            int res = DynamicQ.Rob(arr);   
        }
    }
}
