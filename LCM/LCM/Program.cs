using System;
using System.Collections.Generic;
using System.Linq;

public static class Program
{
    public static int Gcd(int a, int b)
    {
        if (b == 0) return a;

        return Gcd(b, a % b);
    }
    public static int Lcm(List<int> nums)
    {
        if (nums.Count == 0) return 1;
        if (nums.Contains(0)) return 0;
        if (nums.Count == 1) return nums[0];
        int i = 1;
        int lcm;
        var tempNums = new List<int> { nums[0], nums[1] };
        
        while (true)
        {
            int prod = tempNums.Aggregate((a, b) => a * b);
            lcm = (int)(tempNums[0] > tempNums[1] ? prod / Gcd(tempNums[0], tempNums[1]) : prod / Gcd(tempNums[1], tempNums[0]));
            i++;
            if (i >= nums.Count) break;
            tempNums[0] = lcm;
            tempNums[1] = nums[i];
        }

        return lcm;
    }

    public static int Lcm2(List<int> nums)
    {
        if (nums.Count == 0) return 1;
        if (nums.Contains(0)) return 0;

        var sum = nums.Max();
        while (nums.Count(i => sum % i == 0) != nums.Count)
            sum += nums.Max();

        return sum;
    }
}
