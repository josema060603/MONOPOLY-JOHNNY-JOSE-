namespace Monopoly;
public class Board    //requirement 1 a class definition
{
    public Tuple<ISpacing, Player?[]>?[] GameBoard
    {
        get; set;
    }
    public Board(Player?[] players, string path)
    {
        GameBoard = new Tuple<ISpacing, Player?[]>?[40];
        var parkingLot = new FreeParkingLot();
        var jail = new Jail();
        var startingPoint = new StartingPoint();
        GameBoard[startingPoint.Id] = new Tuple<ISpacing, Player?[]>(startingPoint, players);
        GameBoard[parkingLot.Id] = new Tuple<ISpacing, Player?[]>(parkingLot, new Player?[5]);
        GameBoard[jail.Id] = new Tuple<ISpacing, Player?[]>(jail, new Player?[5]);
        for (int i = 0; i < GameBoard.Length; i++)
        {
            if (GameBoard[i] == null)
            {
                if (File.ReadAllLines(path)[i].Split(",").Length == 11)
                {
                    GameBoard[i] = new Tuple<ISpacing, Player?[]>(new Property(File.ReadAllLines(path)[i].Split(",")), new Player?[5]);
                }
                else if (File.ReadAllLines(path)[i].Split(",").Length == 4)
                {
                    GameBoard[i] = new Tuple<ISpacing, Player?[]>(new Railroad(File.ReadAllLines(path)[i].Split(",")), new Player?[5]);
                }
                else if (File.ReadAllLines(path)[i].Split(",").Length == 5)
                {
                    GameBoard[i] = new Tuple<ISpacing, Player?[]>(new Utilities(File.ReadAllLines(path)[i].Split(",")), new Player?[5]);
                }
                else if (File.ReadAllLines(path)[i].Split(",")[1] == "C")
                {
                    GameBoard[i] = new Tuple<ISpacing, Player?[]>(new CommunityChest(File.ReadAllLines(path)[i].Split(",")[0]), new Player?[5]);
                }
                else if (File.ReadAllLines(path)[i].Split(",")[1] == "Ch")
                {
                    GameBoard[i] = new Tuple<ISpacing, Player?[]>(new Chance(File.ReadAllLines(path)[i].Split(",")[0]), new Player?[5]);
                }
                else if (int.Parse(File.ReadAllLines(path)[i].Split(",")[0]) == 12 || int.Parse(File.ReadAllLines(path)[i].Split(",")[0]) == 12)
                {
                    GameBoard[i] = new Tuple<ISpacing, Player?[]>(new Utilities((File.ReadAllLines(path)[i]).Split(",")), new Player?[5]);
                }
            }
        }


    }
    public string GetBoardAsString(Player[] players, int indexOfCurrent)
    {
        var propertiesToDisplay = "";
      
            for(int j=0; j<players[indexOfCurrent].Properties.Count(); j++)
            {
                propertiesToDisplay+=players[indexOfCurrent].Properties.ElementAt(j).Name + "-";
            }

        string output = $@"
|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
|                   |                 |                 |                 |                  |                  |                |                 |                |                   |
|                   | KENTUCKY        |  CHANCE         | INDIANA         | ILLINOIS         | B. & O.          |ATLANTIC        | WATER           |MARVIN          |                   |
|FREE PARKING       | AVE.            |                 | AVE.            | AVE.             | RAILROAD         | AVE            | WORKS           |GARDENS         | GO TO JAIL        |           
|                   | $220            |                 |$220             | $240             | $200             | $260           | $150            | $280           |                   | 
|                   |                 |                 |                 |                  |                  |                |                 |                |                   |        
|-------------------|-----------------------------------------------------------------------------------------------------------------------------------------------|-------------------|
|                   |
|                   |                                                                                                                                               |                   |
|NEW YORK AVE.      |                                                                                                                                               |PACIFIC AVE.       | 
|$200               |                                                                                                                                               |$300               | 
|                   |                                                                                                                                               |                   |
|-------------------|                                                                                                                                               |-------------------| 
|                   |                                                                                                                                               |                   |         
|                   |                                                                                                                                               |                   |
|TENNESSEE AVE      |                                                                                                                                               |NORTH C. AVE.      | 
|$180               |                                                                                                                                               |$300               |
|                   |                                                                                                                                               |                   | 
|-------------------|                                                                                                                                               |-------------------| 
|COMMUNITY CH.      |                                                                                                                                               |COMMUNITY CH.      | 
|                   |                                                                                                                                               |                   |
|                   |                                                                                                                                               |                   | 
|-------------------|                                                                                                                                               |-------------------| 
|                   |                                                                                                                                               |                   |                        
|ST. JAMES P.       |                                                                                                                                               |PENNSYLV. AVE      | 
|$180               |                                                                                                                                               |$320               |
|                   |                                                                                                                                               |                   |
|                   |                                                                                                                                               |                   | 
|-------------------|                                                                                                                                               |-------------------| 
|                   |                                                                                                                                               |                   |
|PENNSYLVANIA       |                                                                                                                                               | SHORT LINE        | 
|$200               |                                                                                                                                               |$200               |
|                   |                                                                                                                                               |                   |
|                   |                                                                                                                                               |                   | 
|-------------------|                                                                                                                                               |-------------------| 
|VIRGINIA AV.       |                                                                                                                                               |    CHANCE         | 
|$160               |                                                                                                                                               |                   |
|                   |                                                                                                                                               |                   |
|                   |                                                                                                                                               |                   |
|-------------------|                                                                                                                                               |-------------------|
|                   |                                                                                                                                               |                   |                       
|STATES AVE.        |                                                                                                                                               |  PARK PLACE       |
|$140               |                                                                                                                                               |$350               |
|                   |                                                                                                                                               |                   |
|                   |                                                                                                                                               |                   | 
|-------------------|                                                                                                                                               |-------------------|
|                   |                                                                                                                                               |                   |                        
|ELECTRIC CO.       |                                                                                                                                               | LUXURY TAX        | 
|$150               |                                                                                                                                               |$100               |
|                   |                                                                                                                                               |                   |
|                   |                                                                                                                                               |                   | 
|-------------------|                                                                                                                                               |-------------------|
|                   |                                                                                                                                               |                   |                 
| ST CHARLES        |                                                                                                                                               |  BOARDWALK        | 
| $140              |                                                                                                                                               |$400               |
|                   |                                                                                                                                               |                   |
|                   |                                                                                                                                               |                   | 
|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
|        |          |                 |                 |                 |                  |                  |                |                 |                |                   |                                                              
| JUST   |  IN      | CONNECTIC       | VERMONT         |   CHANCE        | ORIENTAL         | READING          |   BALTI        | COMMUNITY       |MEDITERRA.      |   +₩200           |
|VISITING|JAIL      | UT Avenue       | AVENUE          |     ?           | AVENUE           | RAILROAD         |   AVENUE       | CHEST           |  AVENU         |      GO           | 
|        *----------| $120            | $100            |                 |                  |                  |                |                 |                |  <------------    |
|                   |                 |                 |                 |                  |                  |                |                 |                |                   | 
|                   |                 |                 |                 |                  |                  |                |                 |                |                   |
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";

        output += @$" It is currently the turn of {players[indexOfCurrent]}
        You currently have ₩{players[indexOfCurrent].Money}
        Your properties are: {propertiesToDisplay}
        For exchanging properties, type exchange
        For adding green houses, type addhouse
        For adding hotels, type addhotel
        To roll the dices, type dice";

        return output;
    }
    static public Tuple<int, int> RollDices(Player player)
    {
        int numberDice1 = new Random().Next(1, 7);
        int numberDice2 = new Random().Next(1, 7);
        return new Tuple<int, int>(numberDice1, numberDice2);
    }
    //This method is the most important of the game 
    public void processTurn(ref Player[] players, Player player)
    {
        if(player.moneyToPay>player.Money)
        {
            players= (Player[])from p in players where p!=player select p;
        }
        else
        {
            player.Money-=player.moneyToPay;
        }
    }
    public string PlayerIsHere(Player?[] players, int CurrentPosition)
    {
        string output = "";
        foreach (var player in players)
        {
            if (player != null)
            {
                if (((Player)player).CurrentPosition == CurrentPosition)
                {
                    output += $"[{((Player)player).token}]";
                }
                else
                {
                    output += "[ ]";
                }
            }
            else
            {
                output += "[ ]";
            }
        }
        return output;
    }
}