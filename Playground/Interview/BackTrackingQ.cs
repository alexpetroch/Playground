using System.Collections.Generic;
using System.Text;

namespace Playground.Interview
{
    public class BackTrackingQ
    {
        List<List<int>> ans = new List<List<int>>();
        private List<string> ansStr;

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


        public List<string> GetSubsets(string str)
        {
            ansStr = new List<string>();
            ansStr.Add("");
            GetSubsets(str, "", 0);
            return ansStr;
        }

        public void GetSubsets(string str, string soFar, int index)
        {
            for (int i = index; i < str.Length; i++)
            {
                string newSoFar = "";
                newSoFar = soFar + str[i];
                ansStr.Add(newSoFar);
                GetSubsets(str, newSoFar, i + 1);
            }
        }
    }
}
