class Program
{
    static List<int> insertedSort(List<int> arr)
    {
        int i = 0;
        int j = 1;
        
        while(j < arr.Count)
        {
            if (arr[j] >= arr[i])
            {
                i++; j++;
            }
            else
            {
               int temp = arr[j];
               arr[j] = arr[i]; 
               arr[i] = temp;
                if(i != 0)
                {
                    i--; j--;
                }
            }
        }
        return arr;
    }
    static void display(List<int> arr)
    {
        for(int i = 0; i < arr.Count; i++)
        {
            Console.Write(arr[i] + " ");
        }
    }
    static void Main(string[] args)
    {
        var arr = new List<int> { 3,5,1,3,7,4,6,2};
        Console.WriteLine("Unsorted Array");
        display(arr);
        Console.WriteLine("");
        Console.WriteLine("Sorted Array");
        display(insertedSort(arr));
    }
}