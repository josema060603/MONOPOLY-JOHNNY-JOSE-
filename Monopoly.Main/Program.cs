using Monopoly;
using System.Collections;
var players = new Player[] { new Player("Carlos"), new Player("Julio"), new Player("Jose"), new Player("Esteban"), new Player("Esteban") };
Console.Clear();
var board = new Board("../properties.csv");
while (true)
{
    bool repeat = false;
    for (int i = 0; i < 5; i++)
    {
        if (repeat)
        {
            i--;
            repeat = false;
        }
        Console.WriteLine(board.GetBoardAsString(players, i));
        ConsoleKey key = Console.ReadKey(true).Key;

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
                        if (players[i].Properties.Count() <= 0)
                            throw new Exception("You do not have any!");
                        Console.WriteLine("Please choose the property you are wanting to add a house");
                        foreach (var item in players[i].Properties)
                        {
                            System.Console.WriteLine(item.Name);
                        }
                        try
                        {
                            string input = Console.ReadLine();
                            int index = -1;
                            for (int j = 0; j < players[i].Properties.Count(); j++)
                            {
                                if (input == players[i].Properties.ElementAt(j).Name)
                                {
                                    index = j;
                                    players[i].Properties.ElementAt(j).AddGreenHouse(ref players[i]);
                                }
                            }
                            if (index == -1)
                            {
                                throw new Exception("Not a valid property");
                            }
                        }
                        catch { System.Console.WriteLine("Wrong property or you do not have properties"); }
                        repeat = true;
                        break;
                    }
                case ConsoleKey.H:
                    {
                        if (players[i].Properties.Count() <= 0)
                            throw new Exception("You do not have any!");
                        Console.WriteLine("Please choose the property you are wanting to add a hotel");
                        foreach (var item in players[i].Properties)
                        {
                            System.Console.WriteLine(item.Name);
                        }
                        try
                        {
                            string input = Console.ReadLine();
                            int index = -1;
                            for (int j = 0; j < players[i].Properties.Count(); j++)
                            {
                                if (input == players[i].Properties.ElementAt(j).Name)
                                {
                                    index = j;
                                    players[i].Properties.ElementAt(j).AddHotel(ref players[i]);
                                }
                            }
                            if (index == -1)
                            {
                                throw new Exception("Not a valid property");
                            }
                        }
                        catch { System.Console.WriteLine("Wrong property or you do not have properties"); }
                        repeat = true;
                        Console.Clear();
                        System.Console.WriteLine("Hotel added!");
                        break;
                    }
                case ConsoleKey.S:
                    {

                        if (players[i].Properties.Count() <= 0)
                        { throw new Exception("You do not have any!"); }
                        System.Console.WriteLine("Enter the name of the player you are willing to sell it");
                        foreach (var player in players)
                        {
                            System.Console.WriteLine(player.Name);
                        }
                        string name = Console.ReadLine();
                        int searchIndex = -1;
                        for (int p = 0; p < players.Count(); p++)
                        {
                            if (name == players[p].Name)
                            {
                                searchIndex = p;
                            }
                        }
                        if (searchIndex == -1)
                        { throw new Exception("Invalid PLayer"); }
                        System.Console.WriteLine("Enter the price");
                        int price;
                        while (true)
                        {
                            try { price = int.Parse(Console.ReadLine()); break; }
                            catch { System.Console.WriteLine("Try again, wrong input"); }
                        }
                        Console.WriteLine("Please choose the property you are wanting to sell");
                        foreach (var item in players[i].Properties)
                        {
                            System.Console.WriteLine(item.Name);
                        }
                        try
                        {
                            string input = Console.ReadLine();
                            int index = -1;
                            for (int j = 0; j < players[i].Properties.Count(); j++)
                            {
                                if (input == players[i].Properties.ElementAt(j).Name)
                                {
                                    index = j;
                                    players[i].Properties.ElementAt(j).SetNewOwner(ref players[searchIndex], ref players[i], price);
                                }
                            }
                            if (index == -1)
                            {
                                throw new Exception("Not a valid property");
                            }
                        }
                        catch { System.Console.WriteLine("Wrong property or you do not have properties"); }
                        repeat = true;
                        Console.Clear();
                        System.Console.WriteLine("Property succesfully sold!");
                        break;
                    }
                case ConsoleKey.E:
                    {
                        int index = -1;
                        int searchIndex = -1;
                        if (players[i].Properties.Count() <= 0)
                        { throw new Exception("You do not have any!"); }
                        Console.WriteLine("Please choose the property you are wanting to exchange");
                        foreach (var item in players[i].Properties)
                        {
                            System.Console.WriteLine(item.Name);
                        }
                        try
                        {
                            string input = Console.ReadLine();
                            for (int j = 0; j < players[i].Properties.Count(); j++)
                            {
                                if (input == players[i].Properties.ElementAt(j).Name)
                                {
                                    index = j;
                                }
                            }
                            if (index == -1)
                            {
                                throw new Exception("Not a valid property");
                            }
                        }
                        catch { System.Console.WriteLine("Wrong property or you do not have properties"); repeat = true; break; }

                        System.Console.WriteLine("Enter the name of the player you are willing to exchange it");
                        foreach (var player in players)
                        {
                            System.Console.WriteLine(player.Name);
                        }
                        string name = Console.ReadLine();
                        for (int p = 0; p < players.Count(); p++)
                        {
                            if (name == players[p].Name)
                            {
                                searchIndex = p;
                            }
                        }
                        if (searchIndex == -1)
                        { throw new Exception("Invalid PLayer"); }
                        Console.WriteLine("Please choose the property the owner is willing to give you");
                        foreach (var item in players[searchIndex].Properties)
                        {
                            System.Console.WriteLine(item.Name);
                        }
                        try
                        {
                            string input = Console.ReadLine();
                            int index2 = -1;
                            for (int j = 0; j < players[searchIndex].Properties.Count(); j++)
                            {
                                if (input == players[searchIndex].Properties.ElementAt(j).Name)
                                {
                                    index2 = j;
                                    Property.ExchangeProperty(ref players[i], players[i].Properties.ElementAt(index), ref players[searchIndex], players[searchIndex].Properties.ElementAt(index2));
                                }
                            }
                            if (index == -1)
                            {
                                throw new Exception("Not a valid property");
                            }
                        }
                        catch { System.Console.WriteLine("Wrong property or you do not have properties"); }
                        repeat = true;
                        Console.Clear();
                        System.Console.WriteLine("Property succesfully exchanged!");
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
            Console.Clear();
            System.Console.WriteLine("You cannot perform this action at the moment");
            Thread.Sleep(3000);
            repeat = true;

        }
        if (players[i].HasPlayerLost())
            players[i] = default;
        players[i].Money -= players[i].moneyToPay;
        players[i].moneyToPay = 0;
        Console.Clear();
    }
}




