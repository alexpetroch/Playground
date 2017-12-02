using System;

namespace Playground.DataStructure
{
    public class SimpleArray
    {
        public static int BinarySearch(int[] array, int value)
        {
            int index = -1;
            Array.Sort(array);

            int start = 0;
            int end = array.Length - 1;

            while (start <= end)
            {
                int middle = start + (end - start) / 2;
                if(array[middle] == value)
                {
                    return middle;
                }
                else if (value > array[middle])
                {
                    start = middle + 1;
                }
                else
                {
                    end = middle - 1;
                }
            }

            return index;
        }

        public static int FindCount(int[] array, int value)
        {
            int count = 0;

            int start = 0;
            int end = array.Length - 1;

            while (start <= end)
            {
                int middle = start + (end - start) / 2;
                if (array[middle] == value)
                {                    
                    count = 1;

                    // go to the left
                    int i = middle - 1;
                    while (i >= start)
                    {
                        if (array[i] != value)
                        {
                            break;
                        }
                        count++;
                        i--;
                    }

                    // go to the right
                    i = middle + 1;
                    while (i <= end)
                    {
                        if (array[i] != value)
                        {
                            break;
                        }

                        count++;
                        i++;
                    }

                    return count;
                }
                else if (value > array [middle])
                {
                    start = middle + 1;
                }
                else
                {
                    end = middle - 1;
                }
            }



            return count;
        }

        public static int Sqrt(int a)
        {
            if(a <= 0)
            {
                return 0;
            }

            int start = 0;
            int end = a;

            while (start <= end)
            {
                int middle = start + (end - start) / 2;
                long value = (long)middle * middle;
              
                if (value == a)
                {
                    return middle;
                }
                else if (value > a)
                {
                    end = middle - 1;
                }
                else
                {
                    start = middle + 1;
                }
            }

            long a1 = (long)start * start;
            if (a1 - a < 0)
            {
                return start;
            }

            return end;
        }

        public static int Sqrt2(int x)
        {
            if (x == 0 || x == 1)
            {
                return x;
            }

            int start = 0;
            int end = x;
            int ans = 1;
            while (start <= end)
            {
                int middle = start + (end - start) / 2;
                if (middle * middle == x)
                {
                    return middle;
                }
                else if (middle * middle < x)
                {
                    ans = middle;
                    start = middle + 1;
                }
                else
                {
                    end = middle - 1;
                }
            }

            return ans;
        }

        public static int PowMod (int x, int y, int z)
        {
            int ans = 1;
            int square = x;
            if (y == 0)
            {
                return 1;
            }
                
            while (y != 0)
            {
                if (y % 2 == 1)
                {
                    ans = ans * square;
                }
                    
                square = (square * square) % z;
                y = y / 2;

                if (ans > z)
                {
                    ans = ans % z;
                }                    
            }

            return ans;
        }

        public static int[] RotateCycle(int[] A, int K)
        {
            if (K == 0 || A.Length == 0 || (A.Length % K == 0 && K != 1))
            {
                return A;
            }

            int rotate = K > A.Length ? K % A.Length : K;
            int length = A.Length;

            int[] arrayRotate = new int[length];

            for (int i = 0; i < length; i++)
            {
                arrayRotate[(i + rotate) % length] = A[i];
            }

            return arrayRotate;
        }
        public int FindTriangle(int[] A)
        {
            if (A == null || A.Length < 3)
            {
                return 0;
            }

            Array.Sort(A);

            for (int i = 0; i < A.Length - 2; i++)
            {
                if (A[i] + A[i + 1] > A[i + 2])
                {
                    return 1;
                }
            }

            return 0;
        }
    }
}
