using System;
using System.Collections.Generic;
using System.Text;

namespace Playground.Interview
{
    public class ArrayQ
    {
        public static void SetToZeroRowsColumns(int[,] matrix)
        {
            bool[] rows = new bool[matrix.GetLength(0)];
            bool[] columns = new bool[matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(matrix[i, j] == 0)
                    {
                        rows[i] = true;
                        columns[j] = true;
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (rows[i] == true || columns[j] == true)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
        }

        public static void SetToZeroRowsColumnsTwoBools(int[,] matrix)
        {
            bool firstRow = false;
            bool firstColumn = false;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    if(matrix[i, j] == 0)
                    {
                        if (i == 0 || j == 0)
                        {
                            firstRow = true;
                            firstColumn = true;
                        }
                        else
                        {
                            matrix[0, j] = 0;
                            matrix[i, 0] = 0;
                        }                                                
                    }                   
                }
            }

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, 0] == 0 || matrix[0, j] == 0)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

            if(firstRow)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[0, j] = 0;
            }

            if (firstColumn)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                    matrix[i, 0] = 0;
            }
        }

        /// <summary>
        /// https://codility.com/programmers/lessons/8-leader/equi_leader/
        /// </summary>
        public int EquiLeader(int[] A)
        {
            int size = 0;
            int value = 0;

            Dictionary<int, int> counts = new Dictionary<int, int>();
            for (int i = 0; i < A.Length; i++)
            {
                if (size == 0)
                {
                    value = A[i];
                    size = 1;
                }
                else
                {
                    if (value == A[i])
                    {
                        size++;
                    }
                    else
                    {
                        size--;
                    }
                }

                if (!counts.ContainsKey(A[i]))
                {
                    counts.Add(A[i], 1);
                }
                else
                {
                    counts[A[i]]++;
                }
            }

            int leader = 0;
            if (size > 0)
            {
                leader = value;
            }
            else
            {
                return 0;
            }

            int equi = 0;
            int leftLeaders = 0;
            int rightLeaders = counts[leader];

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == leader)
                {
                    leftLeaders++;
                    rightLeaders--;
                }

                if (rightLeaders > (A.Length - i - 1) / 2 && leftLeaders > (i + 1) / 2)
                {
                    equi++;
                }
            }

            return equi;
        }

        public static int Fibonacci(int number)
        {
            if(number == 0 || number == 1)
            {
                return number;
            }

            return Fibonacci(number - 1) + Fibonacci(number - 2);
        }

        public static void RotateMatrix(int[,] matrix)
        {           
            for (int first = 0, last = matrix.GetLength(0) - 1; first < last; first++, last--)
            {
                for (int i = first; i < last; i++)
                {
                    // save top
                    int top = matrix[first, i];

                    // save to top from left
                    int left = matrix[last + first - i, first];
                    matrix[first, i] = left;

                    // save to left from bottom
                    int bottom = matrix[last, last + first - i];
                    matrix[last + first - i, first] = bottom;

                    // save to bottom from right
                    int right = matrix[i, last];
                    matrix[last, last + first - i] = right;

                    // save to right from top
                    matrix[i, last] = top;
                }
            }


        }

        /// <summary>
        /// https://codility.com/programmers/lessons/15-caterpillar_method/abs_distinct/
        /// </summary>
        public static int AbsDistinct(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                return 0;
            }

            int front = 0;
            int back = array.Length - 1;
            int distinct = array.Length;

            while (front <= back)
            {
                // Remove duplicate elements from the left
                while (front != back && front + 1 < array.Length && array[front] == array[front + 1])
                {
                    distinct--;
                    front++;
                }

                // Remove duplicate elements from the right
                while (front != back && back > 0 && array[back] == array[back - 1])
                {
                    distinct--;
                    back--;
                }

                if (front == back)
                {
                    break;
                }

                int sum = array[front] + array[back];

                if (sum == 0)
                {
                    distinct--;
                    front++;
                    back--;
                }
                else if (sum < 0)
                {
                    front++;
                }
                else
                {
                    back--;
                }

                //Console.WriteLine(string.Format("{0} {1} D{2} L{3} R{4}", front, back, distinct, left, right));
            }

            return distinct;
        }

        /// <summary>
        /// Given an array A of integers, find the maximum of j - i subjected to the constraint of A[i] less or equal A[j]
        /// If there is no solution possible, return -1
        /// </summary>
        public static int MaximumGap(List<int> A)
        {
            /*
            1. Prepare intMin array from index 0
            2. Prepare intMax array from index n-1
            3. Iterate from the index 0 and compare intMin with intMax with maintaining max distance
            */

            int[] minFromStart = new int[A.Count];
            int[] maxFromEnd = new int[A.Count];


            // [3 5 4 2]
            // [3 3 3 2]
            int min = int.MaxValue;
            for (int i = 0; i < A.Count; i++)
            {
                min = Math.Min(min, A[i]);
                minFromStart[i] = min;
            }

            // [3 5 4 2]
            // [5 5 4 2]
            int max = int.MinValue;
            for (int j = A.Count - 1; j >= 0; j--)
            {
                max = Math.Max(max, A[j]);
                maxFromEnd[j] = max;
            }

            int startIndex = 0;
            int endIndex = 0;
            int maxDiff = -1;

            // [3 3 3 2]
            // [5 5 4 2]
            while (startIndex < A.Count && endIndex < A.Count)
            {
                if (minFromStart[startIndex] <= maxFromEnd[endIndex])
                {
                    maxDiff = Math.Max(maxDiff, endIndex - startIndex);
                    endIndex++;
                }
                else
                {
                    startIndex++;
                }
            }

            return maxDiff;
        }

        /// <summary>
        /// Given n non-negative integers representing an elevation map where the width of each bar is 1, 
        /// compute how much water it is able to trap after raining.
        /// </summary>
        public static int RainWaterTrap(List<int> array)
        {
            int res = 0;

            int left = 0;
            int right = array.Count - 1;

            int leftMax = 0;
            int rightMax = 0;

            while (left <= right)
            {
                if (array[left] < array[right])
                {
                    if (array[left] >= leftMax)
                    {
                        leftMax = array[left];
                    }
                    else
                    {
                        res += leftMax - array[left];
                    }

                    left++;
                }
                else
                {
                    if (array[right] >= rightMax)
                    {
                        rightMax = array[right];
                    }
                    else
                    {
                        res += rightMax - array[right];
                    }

                    right--;
                }
            }

            return res;
        }

        public static int RainWaterTrap2(List<int> array)
        {
            int res = 0;
            int[] left = new int[array.Count];
            int[] right = new int[array.Count];

            // calculate max from left
            // 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1
            left[0] = array[0];
            for(int i = 1; i < array.Count; i++)
            {
                left[i] = Math.Max(array[i], left[i - 1]);
            }

            // calculate max from right
            right[array.Count - 1] = array[array.Count - 1];
            for (int j = array.Count - 2; j >= 0; j--)
            {
                right[j] = Math.Max(array[j], right[j + 1]);
            }

            // iterate and calculate difference
            for (int k = 0; k < array.Count; k++)
            {
                res += Math.Min(left[k], right[k]) - array[k];
            }

            return res;
        }

        /// <summary>
        /// Find an index of an array such that its value occurs at more than half of indices in the array.
        /// </summary>
        public static int Dominator (int[] array)
        {
            int value = 0;
            int count = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (count == 0)
                {
                    count++;
                    value = array[i];
                }
                else
                {
                    if (value == array[i])
                    {
                        count++;
                    }
                    else
                    {
                        count--;
                    }
                }
            }

            // check
            int index = -1;
            if (count > 0)
            {
                int check = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == value)
                    {
                        check++;
                        index = i;
                    }
                }

                if (check > array.Length / 2)
                {
                    return index;
                }
            }

            return -1;
        }

        /// <summary>
        /// Given two integers representing the numerator and denominator of a fraction, return the fraction in string format.
        /// If the fractional part is repeating, enclose the repeating part in parentheses
        /// </summary>
        public static string FractionToDecimal(int divisible, int divider)
        {
            /*
            calculate sign
            calculate total part
            calculate fraction part
                maintain hash to find repeated number 
                   if found -> detect index and put number in brackets
            */

            if (divider == 0)
            {
                throw new ArgumentException("divider");
            }

            StringBuilder res = new StringBuilder();

            if((divisible < 0 && divider > 0) || (divisible > 0 && divider < 0))
            {
                res.Append("-");
            }

            long num = Math.Abs((long)divisible);
            long div = Math.Abs((long)divider);        

            // integral part
            res.Append(num / div);

            num %= div;
            if (num == 0)
            {
                return res.ToString();
            }        
            // fractional part
            res.Append(".");

            Dictionary<long, int> map = new Dictionary<long, int>();
            map.Add(num, res.Length);

            while (num != 0) {
                num *= 10;
                res.Append(num / div);

                num %= div;
                if (map.ContainsKey(num)) {
                    int index = map[num];
                    res.Insert(index, '(');
                    res.Append(")");
                    break;
                }
                else {
                    map.Add(num, res.Length);
                }
            }
            return res.ToString();
        }
        
        /// <summary>
        /// Say you have an array for which the ith element is the price of a given stock on day i.
        /// Design an algorithm to find the maximum profit.You may complete as many transactions as you like (ie, buy one and sell one share of the stock multiple times).
        /// However, you may not engage in multiple transactions at the same time(ie, you must sell the stock before you buy again).
        /// </summary>
        public int MaxProfit(List<int> arr)
        {
            if (arr.Count == 0)
            {
                return 0;
            }

            int maxProfit = 0;

            for (int i = 1; i < arr.Count; i++)
            {
                if (arr[i - 1] < arr[i])
                {
                    maxProfit += arr[i] - arr[i - 1];
                }
            }

            return maxProfit;
        }

        public int maxProfit2(List<int> stocks)
        {
            return 0;

        }

        /// <summary>
        /// Remove duplicates from Sorted Array
        /// Given a sorted array, remove the duplicates in place such that each element appears only once and return the new length.
        /// </summary>
        public int RemoveDuplicates(List<int> sortedArray)
        {
            /*
            keep iterate through array
            keep index and keep distinctIndex
            value is the same keep distinctIndex
            value is not the same increment distinctIndex
            */

            if (sortedArray == null || sortedArray.Count == 0)
            {
                return 0;
            }
        
            int distinctIndex = 0;
            for (int i = 0; i < sortedArray.Count - 1; i++)
            {
                if (sortedArray[i] != sortedArray[i + 1])
                {
                    distinctIndex++;
                    sortedArray[distinctIndex] = sortedArray[i + 1];
                }
            }

            return distinctIndex + 1;
        }       

        /// <summary>
        ///  O(n) solution
        /// Remove duplicates from Sorted Array
        /// Given a sorted array, remove the duplicates in place such that each element appears only once and return the new length.
        /// </summary>   

        public int CanCompleteCircuit(List<int> gas, List<int> cost)
        {

            /*
                Need to define whther we can return to the same position.
                start from i. 
                    and get gas[i] count inrement with previos count.
                    check how much to go to next station. if more than 0 then move, otherwise stop

                have two loops. starting from first element.
                   start from second one and update remaining gas and decrement cost with next index.
                   iterate until both indexes are the same
            */

            int totalGas = 0;
            int totalCost = 0;
            int index = 0;
            int curLeft = 0;

            for (int i = 0; i < gas.Count; i++)
            {
                totalGas += gas[i];
                totalCost += cost[i];
                curLeft += (gas[i] - cost[i]);

                if (curLeft < 0)
                {
                    curLeft = 0;
                    index = i + 1;
                }
            }

            if (totalGas >= totalCost)
            {
                return index;
            }

            return -1;
        }

        /// <summary>
        /// O(n2) solution
        /// You have a car with an unlimited gas tank and it costs cost[i] of gas to travel from station i to its next station (i+1). 
        /// You begin the journey with an empty tank at one of the gas stations.
        /// Return the minimum starting gas station’s index if you can travel around the circuit once, otherwise return -1.
        /// </summary>
        public int CanCompleteCircuit2(List<int> gas, List<int> cost)
        {
            /*
                Need to define whether we can return to the same position.
                start from i. 
                    and get gas[i] count increment with previews count.
                    check how much to go to next station. if more than 0 then move, otherwise stop

                have two loops. starting from first element.
                   start from second one and update remaining gas and decrement cost with next index.
                   iterate until both indexes are the same
            */

            for (int i = 0; i < gas.Count; i++)
            {
                if (gas[i] < cost[i]) continue;

                int remaining = gas[i] - cost[i];
                int index = (i + 1) % gas.Count;
                while (index != i && remaining >= 0)
                {
                    remaining += gas[index] - cost[index];
                    index = (index + 1) % gas.Count;
                }

                if (index == i && remaining >= 0)
                {
                    return index;
                }
            }

            return -1;
        }

        /// <summary>
        /// You are given the following :
        /// A positive number N
        /// Heights : A list of heights of N persons standing in a queue
        /// Infronts : A list of numbers corresponding to each person(P) that gives the number of persons 
        /// who are taller than P and standing in front of P. You need to return list of actual order of persons’s height
        /// </summary>
        public List<int> PersonsInOrder(List<int> heights, List<int> infronts)
        {
            SortedDictionary<int, int> persons = new SortedDictionary<int, int>();
            for (int i = 0; i < heights.Count; i++)
            {
                persons.Add(heights[i], infronts[i]);
            }

            int[] result = new int[heights.Count];
            foreach (int key in persons.Keys)
            {
                int searchSpot = persons[key];
                int index = GetIndexForPerson(result, searchSpot);                
                result[index] = key;
            }

            var list = new List<int>(result);
            return list;
        }

        private int GetIndexForPerson(int[] result, int searchSpot)
        {
            int countFill = 0;
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] != 0)
                {
                    countFill++;
                    continue;
                }

                int current = i - countFill;
                if(current == searchSpot)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
