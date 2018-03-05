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
            AddValue(maxHeap, num, ref maxHeapSize);

            int maxHeapValue = maxHeap.Keys.First();
            RemoveValue(maxHeap, maxHeapValue, ref maxHeapSize);

            AddValue(minHeap, maxHeapValue, ref minHeapSize);

            if (maxHeapSize < minHeapSize)
            {
                int minHeapValue = minHeap.Keys.First();
                RemoveValue(minHeap, minHeapValue, ref minHeapSize);

                AddValue(maxHeap, minHeapValue, ref maxHeapSize);
            }
        }

        public void AddNum2(int num)
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
                    AddValue(maxHeap, num, ref maxHeapSize);
                    return;
                }

                int minHeapValue = minHeap.Keys.First();
                int maxHeapValue = maxHeap.Keys.First();

                // in the middle
                if ((num > maxHeapValue && num < minHeapValue) || num <= maxHeapValue)
                {
                    AddValue(maxHeap, num, ref maxHeapSize);
                }
                else /*(num >= minHeapValue)*/
                {
                    AddValue(minHeap, num, ref minHeapSize);
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
                if (num > maxHeapValue && num < minHeapValue)
                {
                    if (maxHeapSize > minHeapSize)
                    {
                        AddValue(minHeap, num, ref minHeapSize);
                    }
                    else
                    {
                        AddValue(maxHeap, num, ref maxHeapSize);
                    }
                }
                else if (num <= maxHeapValue)
                {
                    if (maxHeapSize > minHeapSize)
                    {
                        Rebalance(maxHeap, minHeap, maxHeapValue);
                        maxHeapSize--;
                        minHeapSize++;
                    }

                    AddValue(maxHeap, num, ref maxHeapSize);
                }
                else /*(num >= minHeapValue)*/
                {
                    if (minHeapSize > maxHeapSize)
                    {
                        Rebalance(minHeap, maxHeap, minHeapValue);
                        minHeapSize--;
                        maxHeapSize++;
                    }

                    AddValue(minHeap, num, ref minHeapSize);
                }
            }
        }

        private void Rebalance(SortedDictionary<int, int> from, SortedDictionary<int, int> to, int value)
        {
            from[value]--;
            if (from[value] == 0)
            {
                from.Remove(value);
            }

            if (!to.ContainsKey(value))
            {
                to.Add(value, 0);
            }

            to[value]++;
        }

        private void AddValue(SortedDictionary<int, int> to, int value, ref int size)
        {
            if (!to.ContainsKey(value))
            {
                to.Add(value, 0);
            }
            to[value]++;
            size++;
        }

        private void RemoveValue(SortedDictionary<int, int> from, int value, ref int size)
        {
            from[value]--;
            if (from[value] == 0)
            {
                from.Remove(value);
            }

            size--;
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
