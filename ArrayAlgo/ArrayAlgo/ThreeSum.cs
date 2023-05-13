using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAlgo
{
    public class ThreeSum
    {
        public static List<List<int>> ThreeSumAlgo(int[] arr)
        {
            var result = new List<List<int>>();
            Array.Sort(arr);
            var i = 0; var j = i + 1; var k = arr.Length - 1;
            while (i < arr.Length - 2 && arr[i] <= 0)
            {
                while (j < k)
                {
                    var sum = arr[i] + arr[j] + arr[k];
                    if (sum > 0)
                    {
                        k--; continue;
                    }
                    if (sum < 0)
                    {
                        j++; continue;
                    }
                    if (sum == 0)
                    {
                        result.Add(new List<int>() { arr[i], arr[j], arr[k] });
                        while (arr[j] == arr[j + 1]) j++;
                        while (arr[k] == arr[k - 1]) k--;
                        j++;
                        k--;
                    }
                }
                while (arr[i] == arr[i + 1]) i++;
                i++;
                j = i + 1;
                k = arr.Length - 1;
            }

            return result;
        }
    }
}
