using Monopoly;

Console.Clear();
var players = new Player[] { new Player("Carlos"), new Player("Julio"), new Player("Jose"), new Player("Esteban"), new Player("Esteban") };
// for (int i = 0; i < 5; i++)
// {
Console.Clear();
var board = new Board("../properties.csv");
// players[0].CurrentPosition = 10;
// players[0].wasSentInJail = true;
while (true)
{
    bool repeat=false;
    for (int i = 0; i < 5; i++)
    {
        if(repeat)
        {
            i--;
            repeat=false;
        }
        Console.WriteLine(board.GetBoardAsString(players, i));
        ConsoleKey key = ConsoleKey.R;

        if (players[i].IsInJail())
            board.GameBoard[players[i].CurrentPosition].Action(ref players[i]);
        try
        {
            switch (key)
            {
                case ConsoleKey.R:
                    {
                        Board.RollDices(ref players[i]);
                        board.GameBoard[players[i].CurrentPosition].Action(ref players[i]);
                        break;
                    }
                case ConsoleKey.C:
                    {
                        if(players[i].Properties.Count()<=0)
                        throw new Exception("You do not have any!");
                        Console.WriteLine("Please choose the property you are wanting to add a house");
                        foreach (var item in players[i].Properties)
                        {
                            System.Console.WriteLine(item.Name);
                        }
                        try
                        {
                            string input = Console.ReadLine();
                            int index=-1;
                            for(int j=0; j<players[i].Properties.Count(); j++)
                            {
                                if (input == players[i].Properties.ElementAt(j).Name)
                                {
                                    index= j;
                                }
                            }
                            if (index==-1)
                            {
                                throw new Exception("Not a valid property");
                            }
                        }
                        catch { System.Console.WriteLine("Wrong property or you do not have properties"); }
                        repeat=true;
                        break;
                    }
                case ConsoleKey.H:
                    {
                        break;
                    }
                case ConsoleKey.S:
                    {
                        break;
                    }
                case ConsoleKey.E:
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        catch
        {
            // Console.Clear();
            System.Console.WriteLine("You cannot perform this action at the moment");
            Thread.Sleep(3000);
            repeat=true;

        }
        players[0].Money -= players[i].moneyToPay;
        // Thread.Sleep(5000);
        // Console.Clear();
    }
}
// Console.WriteLine(board.GetBoardAsString(players, 1));
// }



