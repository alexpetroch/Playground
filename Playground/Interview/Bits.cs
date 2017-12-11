namespace Playground.Interview
{
    public class Bits
    {
        public static int LongestZeroAroundOnes(int N)
        {
            int max = 0;
            int current = 0;
            bool zerous = false;

            while (N > 0)
            {
                if ((N & 1) == 1)
                {
                    break;
                }

                N = N >> 1;
            }

            while (N > 0)
            {
                int bit = N & 1;
                if (bit == 0)
                {
                    current++;
                    zerous = true;
                }
                else if (zerous == true)
                {
                    if (current > max)
                    {
                        max = current;
                    }

                    zerous = false;
                    current = 0;
                }

                N = N >> 1;
            }

            if(zerous == true && current > max)
            {
                max = current;
            }

            return max;
        }

        public static long Reverse(long a)
        {

            if (a < 0)
            {
                return 0;
            }

            int start = 0;
            int end = 31;

            long newValue = 0;

            while (start < 32)
            {
                long check = (long)1 << start;
                bool rev = ((long)a & check) == (long)check;
                if (rev)
                {
                    long add = (long)1 << end;
                    newValue += add;
                }

                start++;
                end--;
            }

            return newValue;
        }
    }
}
