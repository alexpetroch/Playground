using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Interview
{
    public class MedianFinder
    {
        SortedDictionary<int, int> minHeap;
        SortedDictionary<int, int> maxHeap;
        int minHeapSize = 0;
        int maxHeapSize = 0;

        /** initialize your data structure here. */
        public MedianFinder()
        {
            minHeap = new SortedDictionary<int, int>();
            maxHeap = new SortedDictionary<int, int>(new DescendCopmarer<int>());
        }

        public void AddNum(int num)
        {
            /*
            count size of heaps. if the same
            get max from maxHeap
                min from minHeap

            if num > minHeap -> go to minHeap
               num < maxHeap -> go to maxHeap           
               in the middle -> go to maxHeap
            MaxHeap (from less to middle)      MinHeap (from middle + 1 to large) 
            5 3                                10 13

            if count is not the same
            num > minHeap -> go to minHeap. Take elem from minHeap and move to maxHeap
            num < maxHeap -> go to maxHeap. Take elem from maxHeap and move to minHeap
            in the middle -> go to less sized heap        
            7 5 3        10 13 14        
            */

            if (minHeapSize == maxHeapSize)
            {
                // corner case
                if (maxHeapSize == 0)
                {
                    maxHeap.Add(num, 1);
                    maxHeapSize++;
                    return;
                }

                int minHeapValue = minHeap.Keys.First();
                int maxHeapValue = maxHeap.Keys.First();

                // in the middle
                if ((num > maxHeapValue && num < minHeapValue) || num <= maxHeapValue)
                {
                    if (!maxHeap.ContainsKey(num))
                    {
                        maxHeap.Add(num, 0);
                    }

                    maxHeap[num]++;
                    maxHeapSize++;
                }
                else /*(num >= minHeapValue)*/
                {
                    if (!minHeap.ContainsKey(num))
                    {
                        minHeap.Add(num, 0);
                    }
                    minHeap[num]++;
                    minHeapSize++;
                }
            }
            else
            {
                int maxHeapValue = maxHeap.Keys.First();
                if (minHeapSize == 0)
                {
                    if (num > maxHeapValue)
                    {
                        minHeap.Add(num, 1);
                    }
                    else
                    {
                        maxHeap.Remove(maxHeapValue);
                        maxHeap.Add(num, 1);
                        minHeap.Add(maxHeapValue, 1);
                    }

                    minHeapSize++;
                    return;
                }

                int minHeapValue = minHeap.Keys.First();
                maxHeapValue = maxHeap.Keys.First();

                // in the middle
                if ((num > maxHeapValue && num < minHeapValue) || num <= maxHeapValue)
                {
                    if (maxHeapSize > minHeapSize)
                    {
                        maxHeap[maxHeapValue]--;
                        if (maxHeap[maxHeapValue] == 0)
                        {
                            maxHeap.Remove(maxHeapValue);
                        }

                        maxHeapSize--;

                        if (!minHeap.ContainsKey(maxHeapValue))
                        {
                            minHeap.Add(maxHeapValue, 0);
                        }

                        minHeap[maxHeapValue]++;
                        minHeapSize++;
                    }

                    if (!maxHeap.ContainsKey(num))
                    {
                        maxHeap.Add(num, 0);
                    }

                    maxHeap[num]++;
                    maxHeapSize++;
                }
                else /*(num >= minHeapValue)*/
                {
                    if (minHeapSize > maxHeapSize)
                    {
                        minHeap[minHeapValue]--;
                        if (minHeap[minHeapValue] == 0)
                        {
                            minHeap.Remove(minHeapValue);
                        }

                        minHeapSize--;

                        if (!maxHeap.ContainsKey(minHeapValue))
                        {
                            maxHeap.Add(minHeapValue, 0);
                        }

                        maxHeap[minHeapValue]++;
                        maxHeapSize++;
                    }

                    if (!minHeap.ContainsKey(num))
                    {
                        minHeap.Add(num, 0);
                    }
                    minHeap[num]++;
                    minHeapSize++;
                }
            }
        }

        public double FindMedian()
        {
            if (minHeapSize != maxHeapSize)
            {
                return maxHeapSize > minHeapSize ? maxHeap.Keys.First() : minHeap.Keys.First();
            }

            if (maxHeapSize == 0)
            {
                return 0;
            }

            int minHeapValue = minHeap.Keys.First();
            int maxHeapValue = maxHeap.Keys.First();
            return ((double)maxHeapValue + minHeapValue) / 2;
        }
    }

    public class DescendCopmarer<T> : IComparer<T> where T : IComparable<T>
    {
        public int Compare(T x, T y)
        {
            return y.CompareTo(x);
        }
    }

}
