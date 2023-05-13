class Program
{
    public static int GetLengthOfMissingArray(object[][] arrayOfArrays)
    {
        if (arrayOfArrays == null)
        {
            return 0;
        }
        int missing = 0;
        var listOfCount = new List<int>();
        for (int i = 0; i < arrayOfArrays.Length; i++)
        {
            if (arrayOfArrays[i] == null || arrayOfArrays[i].Length == 0)
            {
                return 0;
            }
            listOfCount.Add(arrayOfArrays[i].Length);
        }
        listOfCount.Sort();

        for (int j = 1; j < listOfCount.Count; j++)
        {
            if (listOfCount[j] - listOfCount[j - 1] != 1)
            {
                missing = listOfCount[j - 1] + 1;
            }
        }
        return missing;
    }
    public static void Main()
    {
        var arr = new object[][] { };
        //arr[0] = new object[] { null,null };
        //arr[1] = new object[] { null, null, null,null };
        //arr[2] = new object[] { 1 };
        //arr[3] = new object[] { 5, 6, 7, 8, 9 };
        //Console.WriteLine(arr.Length);
        Console.WriteLine(GetLengthOfMissingArray(null));
    }
}