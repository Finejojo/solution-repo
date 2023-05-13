using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;

public class Program
{

    public static void Main()
    {
        WebRequest request = WebRequest.Create("https://coderbyte.com/api/challenges/json/age-counting");
        WebResponse response = request.GetResponse();
        var count = 0;
        var str = "";
        using (var stream = response.GetResponseStream())
        using (var reader = new StreamReader(stream))
        {
            string json = reader.ReadToEnd();
            var strArr = json.Split(" ");
            var newArr = new List<string>();
            newArr.AddRange(strArr);
            for (int i = 0; i < newArr.Count; i++)
            {
                if (newArr[i].Contains("age="))
                {
                    var index = newArr[i].IndexOf("=");
                    str += newArr[i].Substring(index + 1);
                }
            }
            Console.WriteLine(str);
            var numStr = str.Split(",");
            var result = numStr.Count(x => Int32.TryParse(x, out int y) && y >= 50);

            // Do something with the JSON string
            Console.WriteLine(result);
        }
        //var num

    }
}