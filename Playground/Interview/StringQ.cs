using System;
using System.Collections.Generic;

namespace Playground.Interview
{
    public class StringQ
    {
        public static int StrStr(string A, string B)
        {
            // A - original
            // B - substring

            if (string.IsNullOrEmpty(B) || string.IsNullOrEmpty(A))
            {
                return -1;
            }

            if(B.Length > A.Length)
            {
                return -1;
            }


            for (int i = 0; B.Length <= A.Length - i; i++)
            {
                for (int j = 0; j + i < A.Length; j++)
                {
                    if(B[j] != A[j + i])
                    {
                        break;
                    }

                    if (j == B.Length - 1)
                    {
                        return i;
                    }
                }
            }            

            return -1;
        }

        /// <summary>
        /// Given two words A and B, find the minimum number of steps required to convert A to B. (each operation is counted as 1 step.)
        /// You have the following 3 operations permitted on a word:
        /// Insert a character
        /// Delete a character
        /// Replace a character
        public int MinDistance(string A, string B)
        {
            if (A == B)
            {
                return 0;
            }
            else if (string.IsNullOrEmpty(A))
            {
                return B.Length;
            }
            else if (string.IsNullOrEmpty(B))
            {
                return A.Length;
            }

            if (A[A.Length - 1] == B[B.Length - 1])
            {
                return MinDistance(A.Substring(0, A.Length - 1), B.Substring(0, B.Length - 1));
            }

            string aU = A.Substring(0, A.Length - 1);
            string bU = B.Substring(0, B.Length - 1);

            return 1 + Math.Min(MinDistance(aU, bU), Math.Min(MinDistance(aU, B), MinDistance(A, bU)));
        }

        private static List<string> ans = new List<string>();
        public static List<string> RestoreIpAddresses(string A)
        {

            /* 
            Ip - min 4 characters. max 12 characters
            range 0-255

            take symbol.  check left counts if valid
            get substring and repeat.
            if everthing valid generate ip and add into res
            */

            ans.Clear();
            List<int> dots = new List<int>();
            RestoreIpAddresses(A, dots);
            return ans;
        }

        private static bool RestoreIpAddresses(string ip, List<int> dots)
        {
            if (dots.Count == 4 && string.IsNullOrEmpty(ip))
            {
                string ipAddress = string.Format("{0}.{1}.{2}.{3}", dots[0], dots[1], dots[2], dots[3]);
                Console.WriteLine(ipAddress);
                ans.Add(ipAddress);
                return true;
            }

            if (string.IsNullOrEmpty(ip))
            {
                return false;
            }

            for (int i = 0; i < 3 && i < ip.Length; i++)
            {                
                string test = ip.Substring(0, i + 1);
                int number = int.Parse(test);

                // handling 00
                if(number.ToString() != test)
                {
                    continue;
                }

                string left = ip.Substring(i + 1, ip.Length - i - 1);
                Console.WriteLine(number);
                if (number >= 0 && number <= 255 && CanGenerate(left.Length, 3 - dots.Count))
                {
                    Console.WriteLine(number);
                    List<int> addDots = new List<int>(dots);
                    addDots.Add(number);
                    RestoreIpAddresses(left, addDots);
                }
            }

            return false;
        }

        public static string LongestPalindrome(String s)
        {
            int start = 0, end = 0;
            int lenMax = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int len1 = ExpandAroundCenter(s, i, i);
                int len2 = ExpandAroundCenter(s, i, i + 1);
                int len = Math.Max(len1, len2);
                if (len > lenMax)
                {
                    lenMax = len;
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }
            return s.Substring(start, end - start + 1);
        }

        private static int ExpandAroundCenter(string s, int left, int right)
        {
            int leftIndex = left, rightIndex = right;
            while (leftIndex >= 0 && rightIndex < s.Length && s[leftIndex] == s[rightIndex])
            {
                leftIndex--;
                rightIndex++;
            }
            return rightIndex - leftIndex - 1;
        }

        private static bool CanGenerate(int len, int leftDots)
        {           
            return 3 * leftDots >= len;
        }

        /// <summary>
        /// Given an array of strings, return all groups of strings that are anagrams. Represent a group by a list of integers representing the index in the original list.
        /// </summary>
        public static List<List<int>> GetListAnagrams(List<string> arr)
        {
            /*
            Store sorted string into hash with list of index
            Add index if already anagram
            Iterate through array and get index. If first element is the same add to the resulted array
            */

            Dictionary<string, List<int>> dict = new Dictionary<string, List<int>>();
            List<List<int>> res = new List<List<int>>();
            for (int i = 0; i < arr.Count; i++)
            {
                string sort = GetSort(arr[i]);
                if (!dict.ContainsKey(sort))
                {
                    List<int> first = new List<int>();
                    first.Add(i + 1);
                    dict.Add(sort, first);
                }
                else
                {
                    List<int> elems = dict[sort];
                    elems.Add(i + 1);
                }
            }

            for (int j = 0; j < arr.Count; j++)
            {
                string sort = GetSort(arr[j]);
                var elems = dict[sort];
                if (elems[0] == j + 1)
                {
                    res.Add(elems);
                }
            }

            return res;
        }

        public static string GetSort(string str)
        {
            char[] ch = str.ToCharArray();
            Array.Sort(ch);
            return new string(ch);
        }

        /// <summary>
        /// Implement atoi to convert a string to an integer
        /// </summary>
        public int Atoi(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            char[] array = str.ToCharArray();
            int index = 0;

            while (array[index] == ' ')
            {
                index++;
                if (index >= array.Length)
                {
                    return 0;
                }
            }


            bool negative = false;
            if (array[index] == '-' || array[index] == '+')
            {
                negative = array[index] == '-';
                index++;
            }

            int res = 0;
            while (index < array.Length && char.IsNumber(array[index]))
            {
                int digit = array[index] - '0';
                int multiply = res * 10;

                // check overflow
                if (multiply / 10 != res || multiply + digit < multiply)
                {
                    return negative ? int.MinValue : int.MaxValue;
                }

                res = multiply + digit;
                index++;
            }

            return negative ? res * -1 : res;
        }

        public static int LengthOfLongestSubstring(string str)
        {
            Dictionary<char, int> pos = new Dictionary<char, int>();
            char[] chars = str.ToCharArray();

            int max = 0;
            int noRepeatPos = 0;
            int cur = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                char sym = chars[i];
                if (!pos.ContainsKey(sym))
                {
                    pos.Add(sym, i);
                    cur++;
                }
                else
                {
                    int len = i - noRepeatPos;
                    max = Math.Max(max, len);

                    int repPos = pos[sym];
                    if (repPos + 1 > noRepeatPos)
                    {
                        noRepeatPos = repPos + 1;
                    }

                    pos[sym] = i;
                    cur = i - noRepeatPos + 1;
                }
            }

            max = System.Math.Max(max, cur);
            return max;
        }
        
    }
}
