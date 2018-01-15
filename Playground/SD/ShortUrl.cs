using System.Text;

namespace Playground.SD
{
    /*
    Use/Functional Req:
    1. Generate Short URL from Long URL
    2. Redirect to Long URL from Short URL
    
    Non - functional:
    1. Highly available over consistency
    2. Minimum latency

    Extension:
    1. Monitoring/Logging/Report/Analytics
    2. Auto scaling

    System analysis:
    - Reads redirect/Write ratio: 10:1
    - Traffic/Count of new URL: 10mln per month => 
        QPS write: 10000000 / 30 / 24 / 3600 = 4 pes sec
        QPS read: 10000000 * 10 / 30 / 24 / 3600 = 40 pes sec
    - Storage: let's assume 3 years to keep
        10mln * 12 * 3 = 3.6 bln URL * 128chars per row * 2 byte for 1 char = 920.8 bln bytes ~ 1Tb  
        1bln bytes = 1Gb    
    - Bandwidth: 4 write * 128 chars * 2 byte = 1024 bytes per sek = 1Kb per sec
                 40 read * 128 chars * 2 byte = 10 Kb
    - Cache memory: assuming to keep 10% from URL
                 40 read per sec * 3600 * 24 = 3.5 mln requests per day
                 3.5 mln requests per day * 128 chars * 2 bytes = ~ 1bln bytes ~ 1 Gb per day cache

    High Level:

                           Read Services  -> Cache -> Db (NoSql - key / store)
    Client  -> Load Bal                    
                           Write Services  -> Key Gen -> Db (NoSql - key / store)

    */


    public class ShortUrl
    {
        string encoding = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";


        public string GetShortUrl(int dbId)
        {
            if(dbId < 1)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();
            while (dbId != 0)
            {
                int ind = dbId % encoding.Length;
                char ch = encoding[ind];
                sb.Append(ch);

                dbId /= encoding.Length;
            }

            return Reverse(sb.ToString());
        }

        public string Reverse(string str)
        {
            int low = 0;
            int end = str.Length - 1;

            char[] chars = str.ToCharArray();
            while(low < end)
            {
                char temp = chars[low];
                chars[low] = chars[end];
                chars[end] = temp;

                low++;
                end--;
            }

            return new string(chars);
        }

        public int GetIdFromShortUrl(string shortUrl)
        {
            int res = 0;
            for(int i = 0; i < shortUrl.Length ; i++)
            {
                res *= encoding.Length;
                int digit = encoding.IndexOf(shortUrl[i]);
                res += digit;
            }

            return res;
        }
    }
}
