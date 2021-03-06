﻿using Playground.DataStructure;
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
                    if (WordBreak(rightString, hash) == 1)
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

        public List<List<int>> memory = new List<List<int>>();

        /// <summary>
        /// Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right 
        /// which minimizes the sum of all numbers along its path
        /// You can only move either down or right at any point in time.
        /// </summary>
        public int MinPathSum(List<List<int>> A)
        {
            /*
            Input matrix: mxn - non negative
            path from top left -> bottom right with min sum

            How we can go: down or right
            Start from top left and go to the all other points with sum calc
            Iterate/Recurce the same until rich the right bottom
            */

            for (int i = 0; i < A.Count; i++)
            {
                List<int> list = new List<int>();
                for (int j = 0; j < A[i].Count; j++)
                {
                    list.Add(-1);
                }

                memory.Add(list);
            }


            return CalculateMinPath(A, A.Count - 1, A[0].Count - 1);
        }

        private int CalculateMinPath(List<List<int>> A, int row, int column)
        {
            // wrong path
            if (row < 0 || column < 0)
            {
                return int.MaxValue;
            }

            // if reach check value and return;
            if (row == 0 && column == 0)
            {
                return A[0][0];
            }

            if (memory[row][column] != -1)
            {
                return memory[row][column];
            }


            // DP[i][j] = A[i][j] + min(DP[i-1][j],DP[i][j-1]).

            memory[row][column] = A[row][column] +
            System.Math.Min(CalculateMinPath(A, row - 1, column),
                            CalculateMinPath(A, row, column - 1));
            return memory[row][column];
        }

        int[] memo;
        /// <summary>
        /// Given A, how many structurally unique BST’s (binary search trees) that store values 1...A?
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumUniqueBinarySearchTrees(int n)
        {
            memo = new int[n + 1];
            return CalculateTrees(n);
        }

        private int CalculateTrees(int n)
        {
            if (n == 1 || n == 0)
            {
                return 1;
            }

            if (memo[n] != 0)
            {
                return memo[n];
            }

            int count = 0;
            for (int i = 1; i <= n; i++)
            {
                count += CalculateTrees(i - 1) * CalculateTrees(n - i);
            }

            memo[n] = count;
            return count;
        }

        public int MaxPathSumInTree(Tree<int>.Node root)
        {
            if (root == null)
            {
                return 0;
            }

            int max = int.MinValue;
            MaxPathSumInSubTree(root, ref max);
            return max;
        }

        private int MaxPathSumInSubTree(Tree<int>.Node node, ref int max)
        {
            if (node == null)
            {
                return 0;
            }

            int sumLeft = MaxPathSumInSubTree(node.Left, ref max);
            int sumRight = MaxPathSumInSubTree(node.Right, ref max);

            // Max with one child node
            int maxParent = Math.Max(node.Value, node.Value + Math.Max(sumLeft, sumRight));

            // Max Top represents the sum where the node is 'considered as it would be the root' 
            int maxTop = Math.Max(maxParent, node.Value + sumLeft + sumRight);

            // Store the Maximum Result.
            max = Math.Max(max, maxTop);
            return maxParent;
        }

        /// <summary>
        /// You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed,
        /// the only constraint stopping you from robbing each of them is that adjacent houses have security system connected and 
        /// it will automatically contact the police if two adjacent houses were broken into on the same night.
        /// Given a list of non-negative integers representing the amount of money of each house, determine the maximum amount of money you can rob tonight without alerting the police.
        /// </summary>
        public static int Rob(int[] nums)
        {

            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int n = nums.Length;
            int prevNo = 0;
            int prevYes = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int temp = prevNo;
                prevNo = System.Math.Max(prevNo, prevYes);
                prevYes = nums[i] + temp;
            }

            return System.Math.Max(prevNo, prevYes);
        }


        static int[] mem;
        public static int MaxSubsetSum(int[] arr)
        {

            if (arr == null)
            {
                return 0;
            }

            if (arr.Length <= 2)
            {
                return arr.Length == 1 ? arr[0] : System.Math.Max(arr[0], arr[1]);
            }

            mem = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
                mem[i] = arr[i];

            maxSubsetSum(arr, 0);
            maxSubsetSum(arr, 1);
            int max = System.Math.Max(mem[0], mem[1]);
            return max;
        }

        private static int maxSubsetSum(int[] arr, int index)
        {
            if (index >= arr.Length)
            {
                return 0;
            }

            if (mem[index] != arr[index])
            {
                return mem[index];
            }

            int max2 = System.Math.Max(arr[index], arr[index] + maxSubsetSum(arr, index + 2));
            mem[index] = System.Math.Max(max2, arr[index] + maxSubsetSum(arr, index + 3));
            return mem[index];
        }

        /// <summary>
        /// You are given coins of different denominations and a total amount of money amount. 
        /// Write a function to compute the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1.
        /// Example 1:
        /// Input: coins = [1, 2, 5], amount = 11
        /// Output: 3. Explanation: 11 = 5 + 5 + 1
        /// </summary>

        public static int CoinChange(int[] coins, int amount)
        {
            if (coins == null || coins.Length == 0)
                return 0;

            int[] dp = new int[amount + 1];
            for (int i = 0; i < amount + 1; i++)
                dp[i] = int.MaxValue;

            dp[0] = 0;
            for (int i = 0; i < coins.Length; i++)
            {
                for (int j = 1; j <= amount; j++)
                {
                    // dp[j - coins[i]] != Int32.MaxValue is key expression here
                    // if it is not maxvalue then it can be reached 
                    if (j - coins[i] >= 0 && dp[j - coins[i]] != Int32.MaxValue)
                        dp[j] = Math.Min(dp[j - coins[i]] + 1, dp[j]);

                }
            }

            if (dp[amount] == Int32.MaxValue)
                return -1;

            return dp[amount];
        }


        public static bool IsMatch(string a, string b)
        {
            if (string.IsNullOrEmpty(a) && string.IsNullOrEmpty(b))
                return true;

            if (a.Length < b.Length || string.IsNullOrEmpty(b))
                return false;

            HashSet<string> failed = new HashSet<string>();
            return IsMatch(a, b, failed);
        }

        private static bool IsMatch(string a, string b, HashSet<string> failed)
        {
            // Console.WriteLine("a = " + a + " b = " + b);

            if (failed.Contains(a + "  " + b))
            {
                return false;
            }

            if (a.Length < b.Length)
            {
                failed.Add(a + "  " + b);
                return false;
            }

            if (string.IsNullOrEmpty(a) && string.IsNullOrEmpty(b) ||
               a == b)
                return true;

            if (string.IsNullOrEmpty(b) && a.Length > 0)
            {
                foreach (char chA in a)
                {
                    if (IsUpper(chA))
                    {
                        failed.Add(a + "  " + b);
                        return false;
                    }
                }

                return true;
            }


            bool res = false;

            // Capital letters
            if (a[0] == b[0])
            {
                res = IsMatch(a.Substring(1, a.Length - 1), b.Substring(1, b.Length - 1), failed);
                if (!res)
                {
                    failed.Add(a.Substring(1, a.Length - 1) + "  " + b.Substring(1, b.Length - 1));
                }
            }
            else if (Char.ToUpper(a[0]) == b[0])
            {
                // two cases 
                res = IsMatch(a.Substring(1, a.Length - 1), b.Substring(1, b.Length - 1), failed) || IsMatch(a.Substring(1, a.Length - 1), b, failed);
                if (!res)
                {
                    failed.Add(a.Substring(1, a.Length - 1) + "  " + b.Substring(1, b.Length - 1));
                    failed.Add(a.Substring(1, a.Length - 1) + "  " + b);
                }
            }
            else if (IsUpper(a[0]) && a[0] != b[0])
            {
                res = false;
            }
            else
            {
                res = IsMatch(a.Substring(1, a.Length - 1), b, failed);
                if (!res)
                {
                    failed.Add(a.Substring(1, a.Length - 1) + "  " + b);
                }
            }

            if (!res)
            {
                failed.Add(a + "  " + b);
            }

            return res;
        }

        public static bool IsLower(char ch)
        {
            return ch >= 'a' && ch <= 'z';
        }

        public static bool IsUpper(char ch)
        {
            return ch >= 'A' && ch <= 'Z';
        }

        public static int LongestStrChain(string[] words)
        {

            if (words == null || words.Length == 0)
                return 0;

            Array.Sort(words, (x, y) => x.Length.CompareTo(y.Length));
            int[] dp = new int[words.Length];

            int res = 0;
            for (int i = 0; i < words.Length; i++)
            {
                dp[i] = 1;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (words[i].Length - words[j].Length != 1)
                        continue;

                    if (IsChain(words[j], words[i]))
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                }

                res = Math.Max(dp[i], res);
            }

            return res;
        }

        private static bool IsChain(string str1, string str2)
        {
            int i = 0;
            int j = 0;

            int diff = 0;
            while (i < str1.Length && j < str2.Length)
            {
                if (str1[i] == str2[j])
                {
                    i++;
                    j++;
                    continue;
                }

                j++;
                if (++diff > 1)
                    return false;
            }

            return true;
        }

    }
}
