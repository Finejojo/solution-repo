internal class Program
{
    //1,-2,3,-4 4= 3+2+1 , 5 = 4+3+2+1, n= (n-1)+(n-2)+(n-3)+...+3+2+1; n(n-1)/2 = n^2
               
    /*
     -2,1,3,-4
    -2,1,3,-4
    -4,1,3,-2
    -4,1,3,-2
    -4,-2,3,1
    -4,-2,1,3

     */
    public static int[] SortNegativeAndPositive(int[] arr)
    {
        int i = 0;
        //int j = arr.Length - 1;
        int j = i + 1;
        while(i < arr.Length -2)
        {
            if(arr[i] > arr[j])
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }

            if(j == arr.Length -1)
            {
                i++;
                j = i+1;
                continue;
            }
            j++;
            
        }

        return arr;
    }

    public static int CountPairs(int[] arr, int sum)
    {
        int count = 0;
        int i = 0;
        int j = arr.Length - 1;
        while(i < arr.Length -2)
        {
            if (arr[j] + arr[i]  == sum)
            {
                count++;
            }

            if(j == i+1)
            {
                i++;
                j = arr.Length-1;
                continue;
            }
            j--;
        }
        return count;
    }

    public static int[] Intersection(int[] arr1, int[] arr2)
    {
        var ls1 = new List<int>();
        ls1.AddRange(arr1);
        var ls2 = new List<int>();
        ls2.AddRange(arr2);
        var intersect = new List<int>();
        if(ls1.Count <= ls2.Count)
        {
            //Console.WriteLine("ls1");
            for(int i= 0; i < ls1.Count; i++)
            {
                //Console.WriteLine(i);
                if (ls2.Contains(ls1[i])) {
                    //Console.WriteLine(i);
                    intersect.Add(ls1[i]);
                }
            }
        }

        if(ls2.Count <= ls1.Count)
        {
            //Console.WriteLine("ls2");
            for (int j= 0; j < ls2.Count; j++)
            {
                //Console.WriteLine(j);
                if (ls1.Contains(ls2[j]))
                {
                    intersect.Add(ls2[j]);
                }
            }
        }
        return intersect.ToArray();
    }
    private static void Main(string[] args)
    {
        /*
        var a = new int[] { -12, 11, -13, -5, 6, -7, 5, -3, -6 };
        SortNegativeAndPositive(a);
        foreach(var b in a) Console.WriteLine(b);
        /*
        var arr = new int[] { 1, 5, 7, -1, 5 };
        int sum = 6;
        Console.WriteLine(CountPairs(arr, sum));
        */
        
        /*
        int[] arr1 = { 2, 5, 6 };
        int[] arr2 = { 4, 6, 8, 10 };
        int[] res = Intersection(arr1, arr2);
        foreach(int i in res) Console.WriteLine(i);
        */
        var dic = new Dictionary<int, int> { };
        Console.WriteLine(dic.Count);
    }
}