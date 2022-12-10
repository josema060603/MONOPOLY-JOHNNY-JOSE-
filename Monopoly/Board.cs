namespace Monopoly;
public class Board    //requirement 1 a class definition
{
    public Tuple<ISpacing, Player[]>?[] GameBoard
    {
        get; set;
    }
    public Board(Player[] players, string path)
    {
        GameBoard = new Tuple<ISpacing, Player[]>[40];
        var parkingLot = new FreeParkingLot();
        var jail = new Jail();
        var startingPoint = new StartingPoint();
        GameBoard[startingPoint.Id] = new Tuple<ISpacing, Player[]>(startingPoint, players);
        GameBoard[parkingLot.Id] = new Tuple<ISpacing, Player[]>(parkingLot, new Player[5]);
        GameBoard[jail.Id] = new Tuple<ISpacing, Player[]>(jail, new Player[5]);
        for (int i = 0; i < GameBoard.Length; i++)
        {
            if (GameBoard[i] == null)
            {
                if (File.ReadAllLines(path)[i].Split(",").Length == 11)
                {
                    GameBoard[i] = new Tuple<ISpacing, Player[]>(new Property(File.ReadAllLines(path)[i].Split(",")), new Player[5]);
                }
                else if (File.ReadAllLines(path)[i].Split(",").Length == 4)
                {
                    GameBoard[i] = new Tuple<ISpacing, Player[]>(new Railroad(File.ReadAllLines(path)[i].Split(",")), new Player[5]);
                }
                else if (File.ReadAllLines(path)[i].Split(",").Length == 5)
                {
                    GameBoard[i] = new Tuple<ISpacing, Player[]>(new Utilities(File.ReadAllLines(path)[i].Split(",")), new Player[5]);
                }
                else if (File.ReadAllLines(path)[i].Split(",")[1] == "C")
                {
                    GameBoard[i] = new Tuple<ISpacing, Player[]>(new CommunityChest(File.ReadAllLines(path)[i].Split(",")[0]), new Player[5]);
                }
                else if (File.ReadAllLines(path)[i].Split(",")[1] == "Ch")
                {
                    GameBoard[i] = new Tuple<ISpacing, Player[]>(new Chance(File.ReadAllLines(path)[i].Split(",")[0]), new Player[5]);
                }
                else if (int.Parse(File.ReadAllLines(path)[i].Split(",")[0]) == 12 || int.Parse(File.ReadAllLines(path)[i].Split(",")[0]) == 12)
                {
                    GameBoard[i] = new Tuple<ISpacing, Player[]>(new Utilities((File.ReadAllLines(path)[i]).Split(",")), new Player[5]);
                }
            }
        }


    }
    public string GetBoardAsString(Player[] players, int indexOfCurrent)
    {
        var propertiesToDisplay = "";

        for (int j = 0; j < players[indexOfCurrent].Properties.Count(); j++)
        {
            propertiesToDisplay += players[indexOfCurrent].Properties.ElementAt(j).Name + "-";
        }
        string output = $@"
|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
|                   |    -Red-        |                 |     -Red-       |      -Red-       |                  |   -Yellow-     |   -Yellow-     |                 |    -Yellow-    |                   |
|                   | KENTUCKY        |  CHANCE         | INDIANA         | ILLINOIS         | B. & O.          |ATLANTIC        |   VENTNOR      | WATER           |MARVIN          |                   |
|FREE PARKING       | AVE.            |                 | AVE.            | AVE.             | RAILROAD         | AVE            |   AVE          | WORKS           |GARDENS         | GO TO JAIL        |           
|                   | $220            |                 |$220             | $240             | $200             | $260           |   $260         | $150            | $280           |                   | 
|  {this.PlayerIsHere(players, 20)}  | {this.PlayerIsHere(players, 21)} | {this.PlayerIsHere(players, 22)} | {this.PlayerIsHere(players, 23)} | {this.PlayerIsHere(players, 24)} | {this.PlayerIsHere(players, 25)} | {this.PlayerIsHere(players, 26)} | {this.PlayerIsHere(players, 27)} | {this.PlayerIsHere(players, 28)} | {this.PlayerIsHere(players, 29)} |  {this.PlayerIsHere(players, 30)}  |        
|-------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------|
|     -Orange-      |                                                                                                                                                                |      -Green-      |         
|                   |                                                                                                                                                                |                   |
|NEW YORK AVE.      |                                                                                                                                                                |PACIFIC AVE.       | 
|$200               |                                                                                                                                                                |$300               | 
|  {this.PlayerIsHere(players, 19)}  |                                                                                                                                                                |  {this.PlayerIsHere(players, 31)}  |
|-------------------|                                                                                                                                                                |-------------------| 
|     -Orange-      |                                                                                                                                                                |     -Green-       |         
|                   |                                                                                                                                                                |                   |
|TENNESSEE AVE      |                                                                                                                                                                |NORTH C. AVE.      | 
|$180               |                                                                                                                                                                |$300               |
|  {this.PlayerIsHere(players, 18)}  |                                                                                                                                                                |  {this.PlayerIsHere(players, 32)}  | 
|-------------------|                                                                                                                                                                |-------------------| 
|COMMUNITY CH.      |                                                                                                                                                                |COMMUNITY CH.      | 
|                   |                                                                                                                                                                |                   |
|  {this.PlayerIsHere(players, 17)}  |                                                                                                                                                                |  {this.PlayerIsHere(players, 33)}  | 
|-------------------|                                                                                                                                                                |-------------------| 
|    -Orange-       |                                                                                                                                                                |     -Green-       |                        
|ST. JAMES P.       |                                                                                                                                                                |PENNSYLV. AVE      | 
|$180               |                                                                                                                                                                |$320               |
|                   |                                                                                                                                                                |                   |
|  {this.PlayerIsHere(players, 16)}  |                                                                                                                                                                |  {this.PlayerIsHere(players, 34)}  | 
|-------------------|                                                                                                                                                                |-------------------| 
|                   |                                                                                                                                                                |                   |
|PENNSYLVANIA       |                                                                                                                                                                | SHORT LINE        | 
|$200               |                                                                                                                                                                |$200               |
|                   |                                                                                                                                                                |                   |
|  {this.PlayerIsHere(players, 15)}  |                                                                                                                                                                |  {this.PlayerIsHere(players, 35)}  | 
|-------------------|                                                                                                                                                                |-------------------| 
|     -Pink-        |                                                                                                                                                                |                   |                   
|VIRGINIA AV.       |                                                                                                                                                                |    CHANCE         | 
|$160               |                                                                                                                                                                |                   |
|                   |                                                                                                                                                                |                   |
|  {this.PlayerIsHere(players, 14)}  |                                                                                                                                                                |  {this.PlayerIsHere(players, 36)}  |
|-------------------|                                                                                                                                                                |-------------------|
|     -Pink-        |                                                                                                                                                                |      -Blue-       |                       
|STATES AVE.        |                                                                                                                                                                |  PARK PLACE       |
|$140               |                                                                                                                                                                |$350               |
|                   |                                                                                                                                                                |                   |
|  {this.PlayerIsHere(players, 13)}  |                                                                                                                                                                |  {this.PlayerIsHere(players, 37)}  | 
|-------------------|                                                                                                                                                                |-------------------|
|                   |                                                                                                                                                                |                   |                        
|ELECTRIC CO.       |                                                                                                                                                                | LUXURY TAX        | 
|$150               |                                                                                                                                                                |$100               |
|                   |                                                                                                                                                                |                   |
|  {this.PlayerIsHere(players, 12)}  |                                                                                                                                                                |  {this.PlayerIsHere(players, 38)}  | 
|-------------------|                                                                                                                                                                |-------------------|
|     -Pink-        |                                                                                                                                                                |     -Blue-        |                 
| ST CHARLES        |                                                                                                                                                                |  BOARDWALK        | 
| $140              |                                                                                                                                                                |$400               |
|                   |                                                                                                                                                                |                   |
|  {this.PlayerIsHere(players, 11)}  |                                                                                                                                                                |  {this.PlayerIsHere(players, 39)}  | 
|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------|
|        |          |    -SkyBlue-    |    -SkyBlue-    |                 |    -SkyBlue-     |                  |   INCOME       |   -Brown-      |                 |    -Brown-     |                   |                                                              
| JUST   |  IN      | CONNECTICUT     | VERMONT         |   CHANCE        | ORIENTAL         | READING          |     TAX        |   BALTI        | COMMUNITY       |MEDITERRA.      |   +₩200           |
|VISITING|JAIL      |    Avenue       | AVENUE          |     ?           | AVENUE           | RAILROAD         |                |   AVENUE       | CHEST           |  AVENU         |      GO           | 
|        *----------| $120            | $100            |                 |                  |                  |                |                |                 |                |  <------------    |
|                   |                 |                 |                 |                  |                  |                |                |                 |                |                   | 
|  {this.PlayerIsHere(players, 10)}  | {this.PlayerIsHere(players, 9)} | {this.PlayerIsHere(players, 8)} | {this.PlayerIsHere(players, 7)} | {this.PlayerIsHere(players, 6)} | {this.PlayerIsHere(players, 5)} | {this.PlayerIsHere(players, 4)} | {this.PlayerIsHere(players, 3)} | {this.PlayerIsHere(players, 2)} | {this.PlayerIsHere(players, 1)} |  {this.PlayerIsHere(players, 0)}  |
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
        output += @$"
         It is currently the turn of {players[indexOfCurrent].Name}
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
    // public void processTurn(ref Player[] players, Player player)
    // {
    //     if (player.moneyToPay > player.Money)
    //     {
    //         players = (Player[])from p in players where p != player select p;
    //     }
    //     else
    //     {
    //         player.Money -= player.moneyToPay;
    //     }
    // }
    public string PlayerIsHere(Player[] players, int CurrentPosition)
    {
        string output = "";
        foreach (var player in players)
        {
            if (player.Name!=null )
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