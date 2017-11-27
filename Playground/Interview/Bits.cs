namespace Playground.InterviewBit
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
    }
}
