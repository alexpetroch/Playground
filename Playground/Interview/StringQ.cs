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

        private static bool CanGenerate(int len, int leftDots)
        {           
            return 3 * leftDots >= len;
        }
    }
}
