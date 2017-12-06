﻿using System.Collections.Generic;

namespace Playground.Interview
{
    public class BackTrackingQ
    {
        List<List<int>> ans = new List<List<int>>();

        public List<List<int>> Subsets(List<int> list)
        {
            list.Sort();
            var empty = new List<int>();
            ans.Add(empty);
            getSets(0, empty, list);
            return ans;
        }

        private void getSets(int index, List<int> soFar, List<int> list)
        {
            for (int i = index; i < list.Count; i++)
            {
                var sub = new List<int>(soFar);
                sub.Add(list[i]);
                ans.Add(sub);
                getSets(i + 1, sub, list);
            }
            return;
        }
    }
}
