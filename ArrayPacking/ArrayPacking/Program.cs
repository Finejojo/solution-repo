using System.Collections;

class Program
{
    public static int ConvertArrayToByte(int[] arr)
    {
        int M = 0;
        var binary = "";
        for(int i =0; i< arr.Length; i++)
        {
            var partBin = Convert.ToString(arr[i],2);
            partBin = new string('0', 8-partBin.Length) + partBin;
            binary = partBin + binary;
        }
        //Console.WriteLine(binary);
        M = Convert.ToInt32(binary,2);
        return M;
        //return arr.Reverse().Aggregate(0, (a, v) => (a << 8) + v);
        //return a.Select((x, i) => x << i * 8).Sum();
    }
    private static void Main(string[] args)
    {
        //var arr = new int[] { 24, 85, 0 };
        //Console.WriteLine(ConvertArrayToByte(arr));
        //Console.WriteLine(Convert.ToInt32("111111111111111111111111",2));   
        var arrList = new ArrayList { new List<int> { 1, 2, 3 }, "ada", 1, 3 };
        foreach(object obj in arrList)
        {
            Console.WriteLine(obj);
        }
    }
}