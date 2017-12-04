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

        public void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        private void QuickSort(int[] array, int start, int end)
        {
            if(start >= end)
            {
                return;
            }

            int partition = Partition(array, start, end);
            QuickSort(array, start, partition - 1);
            QuickSort(array, partition + 1, end);
        }

        private int Partition(int[] array, int start, int end)
        {
            int pivot = array[start];
            int pIndex = start + 1;
            int temp = -1;

            for (int i = start + 1; i <= end; i++)
            {
                if (array[i] < pivot)
                {
                    temp = array[i];
                    array[i] = array[pIndex];
                    array[pIndex] = temp;
                    pIndex++;
                }
            }           

            temp = array[pIndex - 1];
            array[pIndex - 1] = pivot;
            array[start] = temp;
            return pIndex - 1;
        }

        public void MergeSort(int[] array)
        {
            int[] copy = new int[array.Length];
            Array.Copy(array, copy, array.Length);
            MergeSort(array, 0, array.Length - 1, copy);
        }

        private void MergeSort(int[] array, int start, int end, int[] copy)
        {
            if (start >= end)
            {
                return;
            }

            int middle = start + (end - start) / 2;

            // split and sort two half after that merge
            MergeSort(array, start, middle, copy);
            MergeSort(array, middle + 1, end, copy);
            SortSplitted(array, start, middle, end, copy);
            CopyArray(array, copy, start, end);
        }       

        private void SortSplitted(int[] array, int start, int middle, int end, int[] copy)
        {
            int left = start;
            int right = middle + 1;
            int index = start;

            while (left <= middle && right <= end)
            {
                if(array[left] < array[right])
                {
                    copy[index] = array[left];
                    left++;
                }
                else
                {
                    copy[index] = array[right];
                    right++;
                }

                index++;
            }

            while (left <= middle)
            {
                copy[index] = array[left];
                left++;
                index++;
            }

            while (right <= end)
            {
                copy[index] = array[right];
                right++;
                index++;
            }
        }

        private void CopyArray(int[] array, int[] copy, int start, int end)
        {
           for (int i = start; i <= end; i++)
            {
                array[i] = copy[i];
            }
        }
    }
}
