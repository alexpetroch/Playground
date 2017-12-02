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

    }
}
