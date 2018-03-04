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
        public static void FindDuplicate()
        {
            int[] arr = { 4, 2, 1, 4, 3, 5 };
            int res = ArrayQ.FindDuplicate(arr);
        }

        [Test]
        public static void FindLadders()
        {
            BackTrackingQ back = new BackTrackingQ();
            System.Collections.Generic.List<string> words =
                new System.Collections.Generic.List<string>() { "lest", "leet", "lose", "code", "lode", "robe", "lost" };
            back.FindLadders2("leet", "code", words);
        }
    }
}
