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
