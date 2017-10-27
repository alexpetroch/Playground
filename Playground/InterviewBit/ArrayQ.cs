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
    }
}
