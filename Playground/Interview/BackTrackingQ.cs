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


        public List<List<int>> Combine(int A, int B)
        {
            if (A < B)
            {
                return ans;
            }

            for (int i = 1; i <= A; i++)
            {
                List<int> set = new List<int>();
                set.Add(i);
                GenerateNumber(i + 1, set, A, B);
            }

            return ans;
        }

        private void GenerateNumber(int index, List<int> soFar, int maxElement, int total)
        {
            if (soFar.Count == total)
            {
                ans.Add(soFar);
                return;
            }

            for (int i = index; i <= maxElement; i++)
            {
                List<int> subSet = new List<int>(soFar);
                subSet.Add(i);
                GenerateNumber(i + 1, subSet, maxElement, total);
            }
        }
    }
}
