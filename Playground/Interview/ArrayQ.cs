using System;
using System.Collections.Generic;

namespace Playground.InterviewBit
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

        public static int FirstMissingPositive(int[] array)
        {
            int miss = array.Length + 1;
            int index = 0;

            int index1 = Array.IndexOf(array, 1);

            // iterate array and organize them into the following way: 1, 2, 3, etc
            while (index < array.Length)
            {
                int value = array[index];
                if (value - 1 == index && array[value - 1] == value)
                {
                    index++;
                    continue;
                }

                if (value < array.Length && value > 0 && array[value - 1] != array[index])
                {
                    int temp = array[value - 1];
                    array[value - 1] = value;
                    array[index] = temp;
                }
                else
                {                   
                    index++;
                }
            }

            // iterate resulted array and find the first missing number    
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != i + 1)
                   return i + 1;
            }

            return miss;          
        }

        public static int Fibonacci(int number)
        {
            // 0, 1, 1, 2, 3, 5, 8, 13, 21
            if(number == 0)
            {
                return 0;
            }

            if (number == 1)
            {
                return 1;
            }

            return Fibonacci(number - 1) + Fibonacci(number - 2);
        }        

        public static int FindFrogJump (int X, int[] A)
        {
            if (X < 1 || A == null || A.Length == 0)
            {
                return -1;
            }

            bool[] leaves = new bool[X];
            for (int i = 0; i < A.Length; i++)
            {
                int leave = A[i];
                if (leave > 0 && !leaves[leave - 1])
                {
                    leaves[leave - 1] = true;
                    X--;
                }

                if (X == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public int[] MaxCounters(int N, int[] A)
        {
            if (N < 1)
            {
                return null;
            }

            int[] counters = new int[N];

            int max = 0;
            int setMax = 0;
            for (int i = 0; i < A.Length; i++)
            {
                int value = A[i];
                if (value == N + 1)
                {
                    setMax = max;
                }
                else
                {
                    if (setMax > 0 && counters[value - 1] < setMax)
                    {
                        counters[value - 1] = setMax;
                    }

                    counters[value - 1] = counters[value - 1] + 1;
                    if (counters[value - 1] > max)
                    {
                        max = counters[value - 1];
                    }
                }
            }

            for (int i = 0; i < N; i++)
            {
                if (setMax > 0 && counters[i] < setMax)
                {
                    counters[i] = setMax;
                }
            }

            return counters;
        }
    }
}
