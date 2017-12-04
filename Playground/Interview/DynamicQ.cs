using System.Collections.Generic;

namespace Playground.Interview
{
    public class DynamicQ
    {
        Dictionary<string, int> wordBreakResult = new Dictionary<string, int>();
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

            wordBreakResult.Clear();
            return WordBreak(A, hash);
        }

        private int WordBreak(string word, HashSet<string> hash)
        {
            if (hash.Contains(word))
            {
                return 1;
            }

            if (wordBreakResult.ContainsKey(word))
            {
                return wordBreakResult[word];
            }

            for (int i = 0; i < word.Length; i++)
            {
                string substring = word.Substring(0, i);
                if (hash.Contains(substring))
                {
                    string rightString = word.Substring(i, word.Length - i);
                    if(WordBreak(rightString, hash) == 1)
                    {
                        wordBreakResult.Add(word, 1);
                        return 1;
                    }
                }
            }

            wordBreakResult.Add(word, 0);
            return 0;
        }
    }
}
