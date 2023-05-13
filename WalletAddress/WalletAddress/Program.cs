using System.Collections.Generic;
public class Program
{
    private void GenerateHash(out byte[] AddressHash, out byte[] AddressKey)
    {
        var address = GenerateAddress();
        using (var hash = new System.Security.Cryptography.HMACSHA512())
        {
            AddressKey = hash.Key;
            AddressHash = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(address));
        }
    }

    private bool VerifyAddress(string Address, byte[] AddressHash, byte[] AddressKey)
    {
        using (var hash = new System.Security.Cryptography.HMACSHA512(AddressKey))
        {
            var computedHash = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Address));
            return computedHash.SequenceEqual(AddressHash);
        }
    }
    private static string GenerateAddress()
    {
        var address = "0x";
        var str = "ZQAx0sewCq2SWFu7yhn1jEbgTokMI3KLOPml4DiGRptrB5H8YNJUfv6cXVd9az";
        var rnd = new Random();
        for (int i = 0; i < 23; i++)
        {
            address += str[rnd.Next(0, 61)];
        }
        return address;
    }
    private static void Main(string[] args)
    {
        var a = new List<string>();
        a.Insert(0, "Yes");
        a.Insert(0, "No");
        a.Remove("No");
        bool b;
        Console.WriteLine(a.Contains("Yes"));
        var cacheValuePair = new Dictionary<string, int>();
        cacheValuePair.Add("Key", 2);
        cacheValuePair.Add("Value", 3);
        //cacheValuePair.Remove("Key");
        Console.WriteLine(cacheValuePair["Key"] != null ? cacheValuePair["Key"]:"Yepa");
        var t = new int[3][];
        t[0] = new int[] {1,3};
        t[1] = new int[] {0,4};
        t[2] = new int[] {-3,5};
        foreach (var pair in t) Console.WriteLine(pair[0]);
        var nt = t.OrderByDescending(x => x[0]).ToArray();
        foreach (var pair in nt) Console.WriteLine(pair[0]);

        Console.WriteLine(t);

        var laptopRange = new Dictionary<int, List<int>>();
        laptopRange.Add(1, new List<int> { 0,4});
        foreach(var key in laptopRange.Keys)
        {
            Console.WriteLine(laptopRange[key]);
        }
        var test = "abchdef";
        Console.WriteLine(test.OrderBy(x => x).ToString());
    }
}