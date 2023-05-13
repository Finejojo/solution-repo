internal class Program
{
    static List<int> bubbleSort(List<int> arr)
    {
        int k = arr.Count - 1;
        int i = 0;
        int j = 1;
        while (k >= 0) 
        {
            if(arr[i] >= arr[j])
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
            
            if(j < k)
            {
                i++; j++;
                
            }else
            {
                //foreach(int a in arr) Console.Write(a);
                //Console.WriteLine();
                i = 0;
                j = 1;
                k--;
            }
        }

        return arr;
    }

    static void display(List<int> arr)
    {
        for (int i = 0; i < arr.Count; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }
    static void Main(string[] args)
    {
        var arr = new List<int> { 3, 5, 8, 9, 6, 2 };
        Console.WriteLine("Unsorted Array");
        display(arr);
        
        Console.WriteLine("Sorted Array");
        display(bubbleSort(arr));
    }
}