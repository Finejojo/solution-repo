using System.Collections.Generic;
using System;
using System.Linq;
public class RomanNumerals
{
    public static string ToRoman(int n)
    {
        var dic = new Dictionary<int, string> { { 1, "I" }, { 4, "IV" }, { 5, "V" }, { 9, "IX" }, { 10, "X" }, { 40, "XL" }, { 50, "L" }, { 90, "XC" }, { 100, "C" }, { 400, "CD" }, { 500, "D" }, { 900, "CM" }, { 1000, "M" } };
        var list = new List<int> { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        var romanNum = "";
        if (dic.ContainsKey(n))
        {
            return dic[n].ToString();
        }
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] <= n)
            {
                int div = (int)n / list[i];
                romanNum += string.Concat(Enumerable.Repeat(dic[list[i]], div));
                n = n % list[i];
            }
        }


        return romanNum;
    }

    public static int FromRoman(string romanNumeral)
    {
        var dic = new Dictionary<char, int> { { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 } };

        if (romanNumeral.Length == 1)
        {
            return dic[romanNumeral[0]];
        }
        Console.WriteLine(romanNumeral);
        var result = 0;
        int i = 0;
        int j = i + 1;
        while (true)
        {
            result += dic[romanNumeral[j]] > dic[romanNumeral[i]] ? (-1 * dic[romanNumeral[i]]) : dic[romanNumeral[i]];
            if (j >= romanNumeral.Length - 1)
            {
                break;
            }
            i++; j++;
        }
        result += dic[romanNumeral[j]];
        return result;
    }
}