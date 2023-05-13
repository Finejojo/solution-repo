using System;
using System.Linq;
using System.Text.RegularExpressions;
public class StripCommentsSolution
{
    public static string StripComments(string text, string[] commentSymbols)
    {

        var txtArray = text.Split('\n');
        for (int i = 0; i < txtArray.Length; i++)
        {
            for (int j = 0; j < commentSymbols.Length; j++)
            {
                if (txtArray[i].Contains(commentSymbols[j]))
                {
                    txtArray[i] = txtArray[i].Substring(0, txtArray[i].IndexOf(commentSymbols[j]));
                    txtArray[i] = txtArray[i].Trim();

                    break;
                }
            }
        }

        for (int a = 0; a < txtArray.Length; a++)
        {
            txtArray[a] = txtArray[a].TrimEnd();
        }

        return String.Join("\n", txtArray);
    }
}