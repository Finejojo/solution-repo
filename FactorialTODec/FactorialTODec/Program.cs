using System;
using System.Collections.Generic;

public class Dec2Fact
{
    public static long fact(int n)
    {
        if (n <= 1) return 1;
        return n * fact(n - 1);
    }

    public static string dec2FactString(long nb)
    {
        var dic = new Dictionary<int, char> { { 10, 'A' }, { 11, 'B' }, { 12, 'C' }, { 13, 'D' }, { 14, 'E' }, { 15, 'F' }, { 16, 'G' }, { 17, 'H' }, { 18, 'I' }, { 19, 'J' }, { 20, 'K' }, { 21, 'L' }, { 22, 'M' }, { 23, 'N' }, { 24, 'O' }, { 25, 'P' }, { 26, 'Q' }, { 27, 'R' }, { 28, 'S' }, { 29, 'T' }, { 30, 'U' }, { 31, 'V' }, { 32, 'W' }, { 33, 'X' }, { 34, 'Y' }, { 35, 'Z' } };
        var str = "";
        int i = 0;
        //int maxFac = 0;
        while (true)
        {
            if ((long)i * fact(i) > nb)
            {
                break;
            }
            i++;
        }
        for (int a = i; a >= 0; a--)
        {
            long fac = fact(a);
            for (int b = a; b >= 0; b--)
            {
                long res = b * fac;
                if (res <= nb)
                {
                    nb -= res;
                    if (b > 9)
                    {
                        str += dic[b];
                    }
                    else str += b.ToString();
                    break;
                }
            }
        }
        return str[0] == '0' ? str.Substring(1) : str;
    }
    public static long factString2Dec(string str)
    {
        var dic = new Dictionary<char, int> { { 'A', 10 }, { 'B', 11 }, { 'C', 12 }, { 'D', 13 }, { 'E', 14 }, { 'F', 15 }, { 'G', 16 }, { 'H', 17 }, { 'I', 18 }, { 'J', 19 }, { 'K', 20 }, { 'L', 21 }, { 'M', 22 }, { 'N', 23 }, { 'O', 24 }, { 'P', 25 }, { 'Q', 26 }, { 'R', 27 }, { 'S', 28 }, { 'T', 29 }, { 'U', 30 }, { 'V', 31 }, { 'W', 32 }, { 'X', 33 }, { 'Y', 34 }, { 'Z', 35 } };
        int len = str.Length - 1;
        long sum = 0;
        for (int i = 0; i < str.Length; i++)
        {
            if (dic.ContainsKey(str[i]))
            {
                sum += dic[str[i]] * fact(len);
            }
            else sum += long.Parse(str[i].ToString()) * fact(len);
            len--;
        }
        return sum;
    }
}

