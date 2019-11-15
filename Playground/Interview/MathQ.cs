using System;
using System.Collections.Generic;

namespace Playground.Interview
{
    public class MathQ
    {
        public static string ConvertToTitleBaseSymbol(int A)
        {
            string str = string.Empty;
            if (A < 0)
            {
                return str;
            }

            while (A > 0)
            {
                // Find remainder
                int rem = A % 26;

                // If remainder is 0, then a 'Z' must be there in output
                if (rem == 0)
                {
                    str += 'Z';
                    A = (A / 26) - 1;
                }
                else // If remainder is non-zero
                {
                    str += (char)('A' + (rem - 1));
                    A = A / 26;
                }
            }

            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static int isPalindrome(int A)
        {
            if (A < 0)
            {
                return 0;
            }

            int count = 0;
            int backup = A;
            while (A > 0)
            {
                A /= 10;
                count++;
            }

            A = backup;
            int check = 1;
            while (A > 0 && check < count)
            {
                int tail = A % 10;
                int head = (int)(A / System.Math.Pow(10, count - check));

                if (tail != head)
                {
                    return 0;
                }

                A = A - head * (int)(System.Math.Pow(10, count - check));
                A = A / 10;
                check += 2;
            }

            return 1;
        }

        public static int isPalindrome2(int number)
        {
            if (number < 0)
            {
                return 0;
            }

            int orig = number;
            int rev = 0;
            while (number > 0)
            {
                int dig = number % 10;
                rev = rev * 10 + dig;
                number = number / 10;
            }

            return (orig == rev ? 1 : 0);
        }

        public static long Pow (int x, int y)
        {
            if (y == 0)
            {
                return 1;
            }

            if (y == 1)
            {
                return x;
            }

            long half = Pow(x, y / 2);
            if (y % 2 == 1)
            {
                return half * half * x;
            }

            return half * half;
        }

        public static int PowWithoutRecursion(int x, int y)
        {
            if (y < 0 || x < 0)
            {
                return -1;
            }

            if (y == 0)
            {
                return 1;
            }

            int result = 1;
            int squire = x;
            while (y != 0)
            {
                if (y % 2 == 1)
                {
                    result = result * squire;
                }

                squire *= squire;
                y = y / 2;
            }
            return result;
        }

        public static int PowMod(int x, int y, int z)
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

        public static int PowModRecursive(int x, int n, int m)
        {

            if (n == 0)
            {
                return x != 0 ? 1 : 0;
            }

            if (n == 1)
            {
                if (x < 0)
                {
                    return (x + m) % m;
                }
                else
                {
                    return x % m;
                }
            }            

            if (n % 2 == 0)
            {
                int y = PowModRecursive(x, n / 2, m);
                return (y * y) % m;
            }

            return ((x % m) * PowModRecursive(x, (n - 1) / 2, m)) % m;
        }

        /// <summary>
        /// https://codility.com/programmers/lessons/3-time_complexity/tape_equilibrium/
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int TapeEquilibrium (int[] A)
        {
            // calculate the sum. set as return value
            int sum = 0;
            for (int i = 0; i < A.Length; i++)
            {
                sum += A[i];
            }

            int min = sum;

            // starting from the first index we will maintain the first sum and 
            // and calculate: all sum - minus the first part
            int leftPart = 0;
            for (int i = 0; i < A.Length; i++)
            {
                leftPart += A[i];
                int rigthPart = sum - leftPart;
                int value = Math.Abs(leftPart - rigthPart);
                if (value < min)
                {
                    min = value;
                }
            }

            return min;
        }

        /// <summary>
        /// https://codility.com/programmers/lessons/9-maximum_slice_problem/max_profit/
        /// </summary>
        /// <param name="array"></param>
        public static int MaxProfit (int[] array)
        {
            int max = 0;
            int maxProfit = 0;
            int min = array[0];


            for (int i = 1; i < array.Length; i++)
            {
                min = Math.Min(min, array[i]);
                maxProfit = Math.Max(0, array[i] - min);
                max = Math.Max(max, maxProfit);
            }

            return max;
        }

        /// <summary>
        /// Max Product Subarray
        /// </summary>
        public static int MaxProduct(List<int> A)
        {
            if (A == null)
            {
                return 0;
            }

            int max = 0;
            int maxSoFar = 0;
            int minSoFar = 0;

            for (int i = 0; i < A.Count; i++)
            {
                if (A[i] > 0)
                {
                    maxSoFar = Math.Max(A[i], A[i] * maxSoFar);                   
                    if (minSoFar < 0)
                    {
                        minSoFar = minSoFar * A[i];
                    }
                }
                else if (A[i] < 0)
                {
                    minSoFar = minSoFar == 0 ? A[i] : A[i] * minSoFar;
                    if (minSoFar > maxSoFar)
                    {
                        maxSoFar = minSoFar;
                        minSoFar = A[i];
                    }
                    else
                    {
                        minSoFar = maxSoFar > 0 ? maxSoFar * minSoFar : minSoFar;
                    }
                }
                else
                {
                    minSoFar = 0;
                    maxSoFar = 0;
                }

                max = Math.Max(maxSoFar, max);
            }

            return max;
        }

        /// <summary>
        /// Given an array S of n integers, find three integers in S such that the sum is closest to a given number, target. 
        /// Return the sum of the three integers.
        /// </summary>
        public static int ThreeSumClosest(List<int> array, int target)
        {

            if (array == null || array.Count < 3)
            {
                return 0;
            }

            array.Sort();

            int sum = array[0] + array[1] + array[2];
            for (int i = 0; i < array.Count; i++)
            {
                for (int j = i + 1, k = array.Count - 1; j < k;)
                {
                    int total = array[i] + array[j] + array[k];
                    if (total > target)
                    {
                        k--;
                    }
                    else if (total < target)
                    {
                        j++;
                    }
                    else
                    {
                        return target;
                    }

                    if (Math.Abs(total - target) < Math.Abs(sum - target))
                    {
                        sum = total;
                    }
                }
            }

            return sum;
        }

        /// <summary>
        /// https://codility.com/programmers/lessons/9-maximum_slice_problem/max_double_slice_sum/
        /// </summary>

        public static int MaxDoubleSliceSum(int[] array)
        {
            int[] maxStartingHere = new int[array.Length];
            int[] maxEndingHere = new int[array.Length];

            for (int i = 1; i < array.Length - 1; i++)
            {
                maxEndingHere[i] = Math.Max(0, maxEndingHere[i - 1] + array[i]);
            }

            for (int i = array.Length - 2; i > 0; i--)
            {
                maxStartingHere[i] = Math.Max(0, maxStartingHere[i + 1] + array[i]);
            }

            int max = 0;
            int temp = 0;
            for (int i = 1; i < array.Length - 1; i++)
            {
                temp = maxEndingHere[i - 1] + maxStartingHere[i + 1];
                if (temp > max)
                {
                    max = temp;
                    //Console.WriteLine(i + " " + maxEndingHere[i-1]  + " " + maxStartingHere[i+1]);
                }
            }

            return max;
        }

        static int count = 0;
        /// <summary>
        /// https://www.hackerrank.com/challenges/the-power-sum/problem
        /// </summary>
        /// <returns></returns>
        public static int PowerSum(int X, int N)
        {
            // start loop from up to sqrt from x 
            // calclate pow of cur of n - if equal  then break if more than n exit
            // if less recurcivelly repeat step 2         

            PowerSum(X, N, 0, 1, "");
            return count;
        }

         static void PowerSum(int total, int power, int current, int iter, string str)
        {
            if (current + System.Math.Pow(iter, power) > total)
            {
                return;
            }

            int end = (int)System.Math.Sqrt(total);

            for (int i = iter; i <= end; i++)
            {
                str += "," + i.ToString();
                Console.WriteLine("{0} {1} {2}", iter, i, current);
                int value = current + (int)System.Math.Pow(i, power);
                if (total == value)
                {
                    count++;
                }
                else if (value > total)
                {
                    return;
                }
                else
                {
                    PowerSum(total - value, power, value, iter + 1, str);
                }
            }

            return;
        }
    }
}
