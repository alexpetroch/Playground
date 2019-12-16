using System.Collections.Generic;

namespace Playground.Interview
{
    public class DictionaryQ
    {
        /// <summary>
        /// You are given an array and you need to find number of tripets of indices such that the elements
        // at those indices are in geometric progression for a given common ratio and.
        // For example, . If , we have and at indices and
        // https://www.hackerrank.com/challenges/count-triplets-1/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps
        /// </summary>
        /// 
        public static long CountTriplets(List<long> arr, long r)
        {

            long res = 0;
            Dictionary<long, long> hash2 = new Dictionary<long, long>();
            Dictionary<long, long> hash3 = new Dictionary<long, long>();

            foreach (long value in arr)
            {
                if (hash3.ContainsKey(value))
                    res += hash3[value];

                if (hash2.ContainsKey(value))
                {
                    if (!hash3.ContainsKey(value * r))
                        hash3.Add(value * r, 0);

                    hash3[value * r] = hash2[value] + hash3[value * r];
                }

                if (!hash2.ContainsKey(value * r))
                    hash2.Add(value * r, 0);

                hash2[value * r] = hash2[value * r] + 1;
            }

            return res;
        }
    }
}
