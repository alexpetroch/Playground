using Playground.DataStructure;
using System;
using System.Collections.Generic;

namespace Playground.Interview
{
    public class TrieQ
    {
        public List<int> SortFeedbacks(string goodWordsSeparated, List<string> feedbackWords)
        {
            /*
            Build trie of Good Words
            List<Class Review>
            {
                count: ? - > set
                index: 0..n
            }
            Write Sort
            Iterate throug it and print index
            */

            Trie trie = BuildTrie(goodWordsSeparated, '_');

            List<WordReview> wordsReview = new List<WordReview>();
            for (int i = 0; i < feedbackWords.Count; i++)
            {
                WordReview word = new WordReview();
                word.Position = i;           
                word.CountGoods = CountWords(trie, feedbackWords[i], '_');
                wordsReview.Add(word);
            }

            wordsReview.Sort(new WordReviewComparatorDescending());
            List<int> res = new List<int>();
            for (int i = 0; i < wordsReview.Count; i++)
            {
                res.Add(wordsReview[i].Position);
            }

            return res;
        }

        private Trie BuildTrie(string listWords, char sep)
        {
            string[] goodsWords = listWords.Split(sep);
            Trie trie = new Trie();

            for (int i = 0; i < goodsWords.Length; i++)
            {
                trie.Insert(goodsWords[i]);
            }

            return trie;
        }

        private int CountWords(Trie trie, string word, char sep)
        {
            int count = 0;
            string[] words = word.Split(sep);            
            for (int j = 0; j < words.Length; j++)
            {
                if (trie.Find(words[j]))
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Find shortest unique prefix to represent each word in the list.
        /// Example:  Input: [zebra, dog, duck, dove]  Output: {z, dog, du, dov
        /// where we can see that  zebra = z dog = dog duck = du dove = dov
        /// </summary>
        public List<string> GetPrefix(List<string> words)
        {
            /*
            Build trie.
            Take word and mark it as first prefix.
            Go through word. 
            If there are more than one branch then mark next item as next suffix

            Test case: zebra, dog, duck

            zebra -> z.. traverse. no more keys and find word. add substring as (0,1)
            dog -> d, exist then increment i++ and take next element, do..dog.  add substring as (0,2)

            // Corner cases: TBD
            */

            Trie trie = new Trie();
            foreach (string str in words)
            {
                trie.Insert(str);
            }

            List<string> res = new List<string>();
            foreach (string word in words)
            {
                int charsCount = 1;
                var node = trie.Root;
                for (int i = 0; i < word.Length; i++)
                {
                    if (node.Childs.Keys.Count > 1)
                    {
                        charsCount = i + 1;
                    }

                    node = node.Childs[word[i]];
                }

                string strPrefix = word.Substring(0, charsCount);
                res.Add(strPrefix);
            }

            return res;
        }
    }

    public class WordReviewComparatorDescending : IComparer<WordReview>
    {
        public int Compare(WordReview x, WordReview y)
        {
            if(x.CountGoods == y.CountGoods)
            {
                return x.Position.CompareTo(y.Position);
            }

            return y.CountGoods.CompareTo(x.CountGoods);
        }
    }

    public class WordReview
    {
        public int Position;
        public int CountGoods;
    }


}
