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
    }
}
