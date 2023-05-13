public class Program
{
    public static void CamelCase()
    {
        string userInput = Console.ReadLine();

        while (userInput != null)
        {
            string str = "";
            int j = 0;
            if (userInput[0] == 'S')
            {
                if (userInput[2] == 'M')
                {
                    string methodStr = userInput.Substring(4, userInput.Length - 6);
                    for (int i = 0; i < methodStr.Length; i++)
                    {
                        if (methodStr[i].ToString().ToUpper() == methodStr[i].ToString())
                        {
                            str += methodStr.Substring(j, i).ToLower() + " ";
                            j = i;
                        }
                    }
                    str += methodStr.Substring(j).ToLower();
                }
                else
                {
                    string methodStr = userInput.Substring(4);
                    for (int i = 0; i < methodStr.Length; i++)
                    {
                        if (methodStr[i].ToString().ToUpper() == methodStr[i].ToString())
                        {
                            str += methodStr.Substring(j, i).ToLower() + " ";
                            j = i;
                        }
                    }
                    str += methodStr.Substring(j).ToLower();
                }
            }
            else
            {
                var methodStr = userInput.Substring(4).Split(' ');
                if (userInput[2] == 'M')
                {
                    str += methodStr[0];
                    for (int i = 1; i < methodStr.Length; i++)
                    {
                        str += methodStr[i][0].ToString().ToUpper() + methodStr[i].Substring(1);
                    }
                    str += "()";
                }
                else if (userInput[2] == 'C')
                {
                    for (int i = 0; i < methodStr.Length; i++)
                    {
                        str += methodStr[i][0].ToString().ToUpper() + methodStr[i].Substring(1);
                    }
                }
                else
                {
                    str += methodStr[0];
                    for (int i = 1; i < methodStr.Length; i++)
                    {
                        str += methodStr[i][0].ToString().ToUpper() + methodStr[i].Substring(1);
                    }
                }
            }
            Console.WriteLine(str.Trim());
            userInput = Console.ReadLine();
        }
    }
    public static void Main(string[] args)
    {
        int x = 8;
        int b = 16;
        int c = 64;
        x /= c /= b;
        Console.WriteLine(x + "," + b + "," + c);
    }
}