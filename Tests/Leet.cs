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
    }
}
