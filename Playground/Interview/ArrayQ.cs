using System;
using System.Collections.Generic;

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
    }
}
