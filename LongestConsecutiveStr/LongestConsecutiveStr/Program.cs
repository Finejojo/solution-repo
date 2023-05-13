class Program
{

    public static void longestConsecutiveStr(string str)
    {
        int currentCount = 1;
        int maxOccurenceCount = 0;
        char maxOccurenceStr = ' ';
        int i = 0;
        int j = 1;
        while (j < str.Length)
        {
            if (str[i] == str[j])
            {
                currentCount++;   
            }else
            {
                if(currentCount > 1 && currentCount > maxOccurenceCount)
                {
                   maxOccurenceCount = currentCount;
                   maxOccurenceStr = str[i];
                }
                currentCount = 1; 
            }
            i++;
            j++;
            if (j == str.Length-1 && currentCount > 1 && currentCount > maxOccurenceCount)
            {
                maxOccurenceCount = currentCount;
                maxOccurenceStr = str[i];
            }
        }

        Console.WriteLine(maxOccurenceStr + " " + maxOccurenceCount);
        
        

        
    }
    private static void Main(string[] args)
    {
        longestConsecutiveStr("abbbbbbbbBbbbbbbbBBBBbbbbbbcccccccccccccc");
    }
}