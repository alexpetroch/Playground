using System.Collections.Generic;

namespace Playground.Interview
{
    class HashQ
    {
        Dictionary<string, int> hash = new Dictionary<string, int>();

        /// <summary>
        /// You are given a string, S, and a list of words, L, that are all of the same length.
        /// Find all starting indices of substring(s) in S that is a concatenation of each word in L exactly once and without any intervening characters.
        /// Example : S: "barfoothefoobarman" L: ["foo", "bar"]
        /// You should return the indices: [0,9].
        /// </summary>
        public List<int> FindSubstring(string str, List<string> words)
        {
            /*
            All L is the same length.
            Calculate the len of segment where all worsd should be.
            Put words into the hash
            Starting from i till i - segmentLenght
                Check Segment
                   Create the other hash say hash2 
                   check word with existing hash
                   if found add word in hash2
                   if not return false

                   comapre hash and hash2. If the same segment is true

                If Segemnt is valid add into result
            */

            List<int> res = new List<int>();

            // Calculate the len of segment where all worsd should be.
            int lenWord = words[0].Length;
            int maxChars = lenWord * words.Count;

            // Put words into the hash
            for (int i = 0; i < words.Count; i++)
            {
                if (!hash.ContainsKey(words[i]))
                {
                    hash.Add(words[i], 0);
                }

                hash[words[i]]++;
            }

            for (int i = 0; i <= str.Length - maxChars; i++)
            {
                string check = str.Substring(i, maxChars);
                if (CheckSegment(check, lenWord))
                {
                    res.Add(i);
                }
            }

            return res;
        }


        private bool CheckSegment(string str, int lenWord)
        {
            int index = 0;
            Dictionary<string, int> hash2 = new Dictionary<string, int>();
            while (index <= str.Length - lenWord)
            {
                string check = str.Substring(index, lenWord);
                if (hash.ContainsKey(check))
                {
                    index += lenWord;
                    if (!hash2.ContainsKey(check))
                    {
                        hash2.Add(check, 0);
                    }

                    hash2[check]++;
                }
                else
                {
                    return false;
                }
            }

            // check that hashes the same
            if (hash.Keys.Count != hash2.Keys.Count)
            {
                return false;
            }

            foreach (string key in hash.Keys)
            {
                if (!hash2.ContainsKey(key) || hash[key] != hash2[key])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// You are given an array of N integers, A1, A2 ,…, AN and an integer K. Return the of count of distinct numbers in all windows of size K.
        /// Formally, return an array of size N-K+1 where i’th element in this array contains number of distinct elements in sequence Ai, Ai+1 ,…, Ai+k-1.
        /// For example, A =[1, 2, 1, 3, 4, 3] and K = 3
        /// All windows of size K are [1, 2, 1] [2, 1, 3] [1, 3, 4] [3, 4, 3]
        /// So, we return an array[2, 3, 3, 2].
        /// </summary>
        public List<int> DistinctNumbers(List<int> arr, int windowSize)
        {
            /*
            Define arrays of size = windowSize. 
            Count distinct elements in each array.
            Add this number to res array
            Return res array.

            Input: Arr size 10000
                   windowSize < arrSize

            Constraints:
                  Arr - null, return empty array
                  WindowSize > Arr size -> empty array

            Create a hashTable of windowSize + count elements
            Calculate distinct numbers.
            Put number to the list

            Iterate through reaming elements
            Update previous one + Add a new one.
            If value previews is removed add distinct, if add and it exists keep distinct, otherwise increment
            */

            /*
            Test cases: {} 1 - >return empty
                        {1,2,1,3,4,1} window = 3 
                            -> d = 2, add
                        -> cycle: 1->removed, 3->added 2-1-3 ->d-3
                        -> i = 5, to be removed = 2;					
            */

            List<int> res = new List<int>();
            if (arr == null || arr.Count < windowSize)
            {
                return res;
            }


            Dictionary<int, int> hash = new Dictionary<int, int>();

            // fill the size
            int distinct = 0;
            for (int i = 0; i < windowSize; i++)
            {
                if (!hash.ContainsKey(arr[i]))
                {
                    hash.Add(arr[i], 0);
                    distinct++;
                }

                hash[arr[i]]++;
            }

            res.Add(distinct);

            for (int i = windowSize; i < arr.Count; i++)
            {
                int removed = arr[i - windowSize];  // 0 index to be removed 
                int added = arr[i];                 // 3 index

                hash[removed]--;
                if (hash[removed] == 0)
                {
                    distinct--;
                }

                if (!hash.ContainsKey(added))
                {
                    hash.Add(added, 0);
                }

                if (hash[added] == 0)
                {
                    distinct++;
                }

                hash[added]++;
                res.Add(distinct);
            }

            return res;
        }
    }
}
