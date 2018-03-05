using System;
using System.Collections.Generic;

namespace Playground.Interview
{
    // A list of meetings, start time and end time [1, 3] [3, 5], [4, 6]

    // Input - no overllaps, positive numer 
    //  [3, 5] and [4, 6] - mean overlap

    // Solution
    // first sort intervals
    // check end of time from previos interval with a new start time of next interval

    // i = 1 until end of intervals
    // if end time (i-1) > begin time (i) -> overlap 
    // othewise increment
    // reach end of list -> no overlap


    // [1, 2] [1, 3] - overlap
    // [1, 2] [2, 3]
    // [2, 3] [1, 4] -> [1 4] [2 3] -> overlap
    // [1 2] -> no overlap because of 1 element
    // [1 3] [2 4]  [4  6] [5 7]  - 2 rooms
    // [1  4] [ 2 6] [ 4 6] - 2 

    // Solution: the intervals should be sorted.
    // 
    // take the first and the next : if overlap increare room and update range
    // maintans min  
    // minRoomsSoFar = 1 -> overlap increment minRooms -> again overlap increment 
    // [1 4] [3 6] [2 9] [10 15] -> // O(n)
    // [1 2]
    // after first iteration should one after first merge [1 6] [2 9] -> [1 9] [10 15] -> no overlap: reset start and end time to 10 and 15 
    // [1, 10] [2, 12] [10, 11] -> 2 maintans max start and min end time for overlaps ->
    // [1 10] [2 12] -> [2 10] -> [] [10 12] -> no intervals [10 13] -> 10 12 [11 12] -> count


    // [1 5] -> 2, end increment rooms 
    // check the other interval if end of time the next interval is less than current end ->increment roota
    // choose the next interval 



    public class Interval
    {
        public int StartTime;
        public int EndTime;
    }

    public class OverlapSolution
    {
        private List<Interval> intervals = new List<Interval>();

        public void AddInterval(Interval interval)
        {
            if (interval == null)
            {
                throw new ArgumentException("interval");
            }

            intervals.Add(interval);
        }

        public bool CheckOverlap()
        {
           intervals.Sort(new IntervalComparison()); 
            for (int i = 1; i < intervals.Count; i++) 
            {
                if (intervals[i - 1].EndTime > intervals[i].StartTime)
                {
                    return true;
                }
            }

            return false;
        }

        public int MinRooms()
        {
            intervals.Sort(new IntervalComparison()); 

            SortedSet<int> sorted = new SortedSet<int>();
            sorted.Add(intervals[0].EndTime);

            // keep min element
            // [[1,8],[6,20],[9,16],[13,17]]
            // if min is more than start time than add element
            // else 

            int minRooms = 1;

            for (int i = 1; i < intervals.Count; i++)
            {
               if(sorted.Min > intervals[i].StartTime)
               {
                  minRooms++;                  
               }
               else
               {
                   sorted.Remove(sorted.Min);
               }

               sorted.Add(intervals[i].EndTime);
            }

            return minRooms;
        }
    }

    internal class IntervalComparison : IComparer<Interval>
    {
        public int Compare(Interval interval1, Interval interval2)
        {
            // [1, 2] [1, 3]
            return interval1.StartTime.CompareTo(interval2.StartTime);
        }
    }
}
