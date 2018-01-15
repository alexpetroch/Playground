using System;
using System.Collections.Generic;

namespace Playground.Interview
{
    public class DynamicQ
    {
        Dictionary<string, int> _wordBreakResult = new Dictionary<string, int>();
        Dictionary<string, string> _wordBreakSpaceResult = new Dictionary<string, string>();

        List<string> ans = new List<string>();
        Dictionary<string, int> memString = new Dictionary<string, int>();
        string _sentance = string.Empty;
        
        /// <summary>
        /// https://www.interviewbit.com/problems/word-break/
        /// </summary>
        public int WordBreak(string A, List<string> B)
        {

            HashSet<string> hash = new HashSet<string>();
            for (int i = 0; i < B.Count; i++)
            {
                hash.Add(B[i]);
            }

            _wordBreakResult.Clear();
            return WordBreak(A, hash);
                
        }

        private int WordBreak(string word, HashSet<string> hash)
        {
            if (hash.Contains(word))
            {
                return 1;
            }

            if (_wordBreakResult.ContainsKey(word))
            {
                return _wordBreakResult[word];
            }

            for (int i = 0; i < word.Length; i++)
            {
                string substring = word.Substring(0, i);
                if (hash.Contains(substring))
                {
                    string rightString = word.Substring(i, word.Length - i);
                    if(WordBreak(rightString, hash) == 1)
                    {
                        _wordBreakResult.Add(word, 1);
                        return 1;
                    }
                }
            }

            _wordBreakResult.Add(word, 0);
            return 0;
        }

        public object WordBreakAddSpace(string str, List<string> dic)
        {
            HashSet<string> hash = new HashSet<string>();
            for (int i = 0; i < dic.Count; i++)
            {
                hash.Add(dic[i]);
            }

            _wordBreakSpaceResult.Clear();
            return WordBreakAddSpace(str, hash);
        }

        private string WordBreakAddSpace(string word, HashSet<string> hash)
        {
            if (hash.Contains(word))
            {
                return word;
            }

            if (_wordBreakSpaceResult.ContainsKey(word))
            {
                return _wordBreakSpaceResult[word];
            }

            for (int i = 0; i < word.Length; i++)
            {
                string substring = word.Substring(0, i);
                if (hash.Contains(substring))
                {
                    string rightString = word.Substring(i, word.Length - i);
                    string sentance = WordBreakAddSpace(rightString, hash);
                    if (sentance != null)
                    {
                        _wordBreakSpaceResult.Add(word, substring + " " + sentance);
                        return substring + " " + sentance;
                    }
                }
            }

            _wordBreakSpaceResult.Add(word, null);
            return null;
        }

        public static int ClimbStairs(int A)
        {
            int[] steps = new int[A + 1];
            int total = CountStairs(0, A, steps);

            int[] steps2 = new int[A + 1];
            int total2 = CountStairs2(A, steps2);
            return total;
        }

        private static int CountStairs(int current, int max, int[] steps)
        {
            if (current == max)
            {                
                return 1;
            }
            else if (current > max)
            {
                return 0;
            }
            else if (steps[current] != 0)
            {
                return steps[current];
            }

            steps[current] = CountStairs(current + 1, max, steps) + CountStairs(current + 2, max, steps);
            return steps[current];
        }

        private static int CountStairs2(int current, int[] steps)
        {
            if (current == 0)
            {
                return 1;
            }
            else if (current < 0)
            {
                return 0;
            }
            else if (steps[current] > -1)
            {
                return steps[current];
            }

            steps[current] = CountStairs2(current - 1, steps) + CountStairs2(current - 2, steps);
            return steps[current];
        }

        /// <summary>
        ///  Given an array of non-negative integers, you are initially positioned at the first index of the array.
        ///  Each element in the array represents your maximum jump length at that position.
        ///  Determine if you are able to reach the last index.
        /// </summary>
        public bool CanJump(List<int> array)
        {
            int currJump = 0;
            for (int i = 0; i < array.Count; i++)
            {
                if (currJump < 0) return false;

                currJump = Math.Max(array[i], currJump);
                currJump--;
            }

            return true;
        }        
    }
}
