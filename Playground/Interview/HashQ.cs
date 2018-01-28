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
    }
}
