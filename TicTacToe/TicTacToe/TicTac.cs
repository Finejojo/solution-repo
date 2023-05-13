using System.Collections;

class TicTac
{
    private ArrayList arr;
    int count;
    List<int> playedPos;
    List<int> playerOneInput;
    List<int> playerTwoInput;
    public TicTac()
    {
        arr = new ArrayList() { new ArrayList { 1, 2, 3 }, new ArrayList { 4, 5, 6 }, new ArrayList { 7, 8, 9 } };
        playedPos = new List<int>();
        playerOneInput = new List<int>();
        playerTwoInput = new List<int>();
        count = 0;
    }

    public bool CheckWinner(List<int> player, string p)
    {
        if((player.Contains(1) && player.Contains(2) && player.Contains(3)) || (player.Contains(4) && player.Contains(5) && player.Contains(6)) || (player.Contains(7) && player.Contains(8) && player.Contains(9)) || (player.Contains(1) && player.Contains(4) && player.Contains(7)) || (player.Contains(2) && player.Contains(5) && player.Contains(8)) || (player.Contains(3) && player.Contains(6) && player.Contains(9)) || (player.Contains(1) && player.Contains(5) && player.Contains(9)) || (player.Contains(3) && player.Contains(5) && player.Contains(7)))
        {
            Console.WriteLine(p + " Wins!");
            return true;
        }
        return false;
    }

    public void Replay()
    {
        arr = new ArrayList() { new ArrayList { 1, 2, 3 }, new ArrayList { 4, 5, 6 }, new ArrayList { 7, 8, 9 } };
        Console.Clear();
        Display();
        Play();
    }

    public void Play()
    {
        string p;
        bool winner = false;
        while(count < 9 && !winner)
        {
            p = count % 2 == 0 ? "Player 1" : "Player 2";
            PlayersInput(count);
            winner = CheckWinner(count % 2 == 0 ? playerOneInput : playerTwoInput, p);
            count++;
        }
        if(!winner)
        {
            Console.WriteLine("No winner, Draw!");
        }
        Console.WriteLine("Press any key to continue or q to quit game");
        string cont = Console.ReadLine();
        if(cont.ToLower() != "q")
        {
            Replay();
        }else
        {
            Console.WriteLine("Game Over");
        }
    }

    public void PlayersInput(int player)
    {
        var row1 = (ArrayList)arr[0];
        var row2 = (ArrayList)arr[1];
        var row3 = (ArrayList)arr[2];
        if(player %2 == 0) Console.WriteLine("Player 1 enter your input between 1-9");
        else Console.WriteLine("Player 2 enter your input between 1-9");
        var player1 = Int32.TryParse(Console.ReadLine(), out int p1);
        while (!player1 || p1 < 1 || p1 > 9)
        { 
            Console.WriteLine("Please put a number 1-9");
            player1 = Int32.TryParse(Console.ReadLine(), out p1);
        }

        int index = p1 < 4 ? p1 - 1 : p1 > 6 ? p1 - 7 : p1 - 4;
        
        while (playedPos.Contains(p1) || p1 < 1 || p1 > 9)
        {
            if (player1) Console.WriteLine("That position already played");
            else Console.WriteLine("Incorrect Input");
            player1 = Int32.TryParse(Console.ReadLine(), out p1);
            index = p1 < 4 ? p1 - 1 : p1 > 6 ? p1 - 7 : p1 - 4;
        }


        if (p1 < 4)
        {
            row1[p1 - 1] = player %2 ==0?"X":"O";
        }else if(p1 > 6)
        {
            row3[p1 - 7] = player % 2 == 0 ? "X" : "O";
        }else
        {
            row2[p1 - 4] = player % 2 == 0 ? "X" : "O";
        }

        if (player % 2 == 0) playerOneInput.Add(p1);
        else playerTwoInput.Add(p1);
        playedPos.Add(p1);

        Console.Clear();
        Display();
        
    }

    public void Display()
    {
        var row1 = (ArrayList)arr[0];
        var row2 = (ArrayList)arr[1];
        var row3 = (ArrayList)arr[2];
    
        Console.WriteLine("       |       |      \r\n   " + row1[0] +"   |   " + row1[1] + "   |   " + row1[2] + "   \r\n       |       |       ");
        Console.WriteLine("---------------------");
        Console.WriteLine("       |       |      \r\n   " + row2[0] +"   |   " + row2[1] + "   |   "+ row2[2] + "   \r\n       |       |       ");
        Console.WriteLine("---------------------");
        Console.WriteLine("       |       |      \r\n   "+ row3[0] + "   |   "+ row3[1] + "   |   "+ row3[2] + "   \r\n       |       |       ");
    }
}
