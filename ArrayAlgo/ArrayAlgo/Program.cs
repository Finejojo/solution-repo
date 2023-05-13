using ArrayAlgo;

public class Program
{
    private static void Main(string[] args)
    {
        var a = new int[] {-4,2,0,1,3,-2,-1};
        var result = ThreeSum.ThreeSumAlgo(a);
        foreach(var val in result)
        {
            Console.WriteLine(String.Join(",",val));
        }
    }
}