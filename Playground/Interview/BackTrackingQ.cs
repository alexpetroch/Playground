using System.Collections.Generic;
using System.Text;

namespace Playground.Interview
{
    public class BackTrackingQ
    {
        List<List<int>> ans = new List<List<int>>();
        private List<string> ansStr = new List<string>();

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

        public static Dictionary<string, string> FlattenDictionary(Dictionary<string, object> dict)
        {
            if (dict == null || dict.Keys.Count == 0)
            {
                return null;
            }

            Dictionary<string, string> res = new Dictionary<string, string>();
            AddNesting(dict, res, string.Empty);
            return res;
        }

        public static void AddNesting(Dictionary<string, object> dict, Dictionary<string, string> res, string addKey)
        {
            foreach (string key in dict.Keys)
            {
                Dictionary<string, object> nestedDict = dict[key] as Dictionary<string, object>;

                string keyToAdd = string.Empty;
                if (string.IsNullOrEmpty(addKey))
                {
                    keyToAdd = key;
                }
                else
                {
                    keyToAdd = string.IsNullOrEmpty(key) ? addKey : addKey + "." + key;
                }

                if (nestedDict == null)
                {
                    res.Add(keyToAdd, dict[key].ToString());
                    continue;
                }

                AddNesting(nestedDict, res, keyToAdd);
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

        public List<string> FullJustify(List<string> words, int lineBreak)
        {
            ansStr.Clear();
            FullJustify(words, lineBreak, 0);
            return ansStr;
        }

        private void FullJustify(List<string> words, int lineBreak, int index)
        {
            if (index == words.Count)
            {
                return;
            }

            List<string> wordsToAdd = new List<string>();
            int wordsLength = 0;

            int currentIndex = index;
            while (currentIndex < words.Count && words[currentIndex].Length + wordsLength + wordsToAdd.Count * 1 <= lineBreak)
            {
                wordsToAdd.Add(words[currentIndex]);
                wordsLength += words[currentIndex].Length;
                currentIndex++;
            }

            // Fill spaces
            // The latest line

            StringBuilder sb = new StringBuilder(wordsToAdd[0]);
            if (currentIndex == words.Count)
            {
                for (int j = 1; j < wordsToAdd.Count; j++)
                {
                    sb.Append(" ");
                    sb.Append(wordsToAdd[j]);
                }
            }
            else
            {
                int average = 0;
                if (wordsToAdd.Count > 1)
                {
                    average = (lineBreak - wordsLength) / (wordsToAdd.Count - 1);
                }

                for (int j = 1; j < wordsToAdd.Count; j++)
                {
                    sb.Append(' ', average);
                    sb.Append(wordsToAdd[j]);
                }
            }

            if (sb.Length < lineBreak)
            {
                sb.Append(' ', lineBreak - sb.Length);
            }

            ansStr.Add(sb.ToString());
            FullJustify(words, lineBreak, currentIndex);
        }

        static List<List<int>> permuteRes = new List<List<int>>();
        /// <summary>
        /// Given a collection of numbers, return all possible permutations.
        /// Example: [1,2,3] will have the following permutations:
        /// [1,2,3]  [1,3,2]  [2,1,3] [2,3,1]  [3,1,2] [3,2,1]
        /// </summary>
        public static List<List<int>> Permute(List<int> A)
        {
            permuteRes.Clear();
            Permutate(A, 0);
            return permuteRes;
        }

        private static  void Permutate(List<int> list, int pointer)
        {
            if (pointer == list.Count)
            {
                permuteRes.Add(list);
                return;
            }

            for (int i = pointer; i < list.Count; i++)
            {
                List<int> permutation = new List<int>(list);
                permutation[pointer] = list[i];
                permutation[i] = list[pointer];
                Permutate(permutation, pointer + 1);
            }
        }

        public static List<List<int>> Permute2(List<int> A)
        {
            permuteRes.Clear();
            if (A.Count == 1)
            {
                permuteRes.Add(A);
                return permuteRes;
            }

            return Permutate2(A);
        }

        private static List<List<int>> Permutate2(List<int> orig)
        {
            List<List<int>> res = new List<List<int>>();
            if (orig.Count == 2)
            {
                res.Add(new List<int>() { orig[0], orig[1] });
                res.Add(new List<int>() { orig[1], orig[0] });
                return res;
            }

            for (int i = 0; i < orig.Count; i++)
            {
                List<int> copy = new List<int>(orig);
                int fixedElem = copy[i];
                copy.RemoveAt(i);

                var permForRest = Permutate2(copy);

                for(int j = 0; j < permForRest.Count; j++)
                {
                    permForRest[j].Insert(0, fixedElem);
                    res.Add(permForRest[j]);
                }
            }

            return res;
        }

        List<List<string>> parts = new List<List<string>>();
        /// <summary>
        /// Given a string s, partition s such that every string of the partition is a palindrome.
        /// Return all possible palindrome partitioning of s.
        /// For example, given s = "aab",
        /// Return   [     ["a", "a", "b"]     ["aa", "b"],   ]
        /// </summary>
        public List<List<string>> PartitionPalindrome(string orig)
        {
            List<string> cur = new List<string>();
            Partition(orig, cur, 0);
            return parts;
        }

        private void Partition(string orig, List<string> cur, int index)
        {
            if(index == orig.Length)
            {
                parts.Add(cur);
                return;
            }

            for (int i = index + 1; i <= orig.Length; i++)
            {
                string substring = orig.Substring(index, i - index);
                if(IsPalindrome(substring))
                {
                    List<string> newOne = new List<string>(cur);
                    newOne.Add(substring);
                    Partition(orig, newOne, i);
                }
            }
        }

        private bool IsPalindrome(string str)
        {
            int low = 0;
            int end = str.Length - 1;

            while (low < end)
            {
                if (str[low] != str[end])
                {
                    return false;
                }

                low++;
                end--;
            }

            return true;
        }
    }
}
