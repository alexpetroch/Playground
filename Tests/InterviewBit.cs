using NUnit.Framework;
using Playground.InterviewBit;

namespace Tests
{
    [TestFixture]
    [Category("InterviewBit")]
    public class InterviewBit
    {
        [Test]
        public static void SetToZeroRowsColumns()
        {
            int[,] matrix = { { 0, 1, 0 }, { 2, 3, 4 }, { 5, 0, 6 }};
            ArrayQ.SetToZeroRowsColumns(matrix);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Assert.That(matrix[i, j] == 0);
                }
            }

            int[,] matrix1 = { { 0, 1, 0 }, { 2, 3, 4 }, { 5, 0, 6 } };
            ArrayQ.SetToZeroRowsColumnsTwoBools(matrix1);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Assert.That(matrix1[i, j] == 0);
                }
            }
        }
    }
}
