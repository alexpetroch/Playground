using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    // [1  5] [ 2 4] [ 2 3] - 3 rooms [6 9] still 3 rooms enough

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
            if (intervals.Count == 1)
            {
                return false;
            }

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
            if (intervals.Count == 1)
            {
                return 1;
            }

            intervals.Sort(new IntervalComparison()); 

            // Stable -> Merge
            int minRooms = 1;
            int minSoFar = 1;
            int minEnd = intervals[0].EndTime;
            for (int i = 1; i < intervals.Count; i++)
            {
                if (intervals[i - 1].EndTime > intervals[i].StartTime)
                {
                    if(minSoFar == 1)
                    {
                        minSoFar++;
                        minEnd = Math.Min(intervals[i - 1].EndTime, intervals[i].EndTime);
                    }
                    else if (minEnd > intervals[i].StartTime)
                    {
                        minSoFar++;
                        minEnd = Math.Min(minEnd, intervals[i].EndTime);
                    }
                    minRooms = Math.Max(minSoFar, minRooms);
                }
                else
                {
                    minEnd = intervals[i].EndTime;
                    minSoFar = 1;
                }
            }

            return minRooms;
        }
    }

    internal class IntervalComparison : IComparer<Interval>
    {
        public int Compare(Interval interval1, Interval interval2)
        {
            // [1, 2] [1, 3]

            if (interval1.StartTime == interval2.StartTime && interval1.EndTime == interval2.EndTime)
            {
                return 0;
            }
            else if (interval1.StartTime < interval2.StartTime)
            {
                return -1;
            }
            else if (interval1.EndTime < interval2.EndTime)
            {
                return -1;
            }
            return 1;
        }
    }
}
