namespace Monopoly;
public class Board    //requirement 1 a class definition
{
    public ISpacing[] GameBoard
    {
        get; set;
    }
    public Board( string path)
    {
        GameBoard = new ISpacing[40];
        var parkingLot = new FreeParkingLot();
        var jail = new Jail();
        var startingPoint = new StartingPoint();
        var incomingTax= new IncomingTax();
        GameBoard[startingPoint.Id] = startingPoint;
        GameBoard[parkingLot.Id] = parkingLot;
        GameBoard[jail.Id] =jail;
        GameBoard[incomingTax.Id]= incomingTax;
        for (int i = 0; i < GameBoard.Length; i++)
        {
            if (GameBoard[i] == null)
            {
                if (File.ReadAllLines(path)[i].Split(",").Length == 11)
                {
                    GameBoard[i] = new Property(File.ReadAllLines(path)[i].Split(","));
                }
                else if (File.ReadAllLines(path)[i].Split(",").Length == 4)
                {
                    GameBoard[i] =new Railroad(File.ReadAllLines(path)[i].Split(","));
                }
                else if (File.ReadAllLines(path)[i].Split(",").Length == 5)
                {
                    GameBoard[i] = new Utilities(File.ReadAllLines(path)[i].Split(","));
                }
                else if (File.ReadAllLines(path)[i].Split(",")[1] == "C")
                {
                    GameBoard[i] = new CommunityChest(File.ReadAllLines(path)[i].Split(",")[0]);
                }
                else if (File.ReadAllLines(path)[i].Split(",")[1] == "Ch")
                {
                    GameBoard[i] = new Chance(File.ReadAllLines(path)[i].Split(",")[0]);
                }
                else if (int.Parse(File.ReadAllLines(path)[i].Split(",")[0]) == 12 || int.Parse(File.ReadAllLines(path)[i].Split(",")[0]) == 12)
                {
                    GameBoard[i] = new Utilities((File.ReadAllLines(path)[i]).Split(","));
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
        For exchanging properties, press E
        For selling properties, press S
        For adding green houses, press C
        For adding hotels, press H
        To roll the dices, press R";

        return output;
    }
    static public void RollDices(ref Player player)
    {
        int numberDice1 = new Random().Next(1, 7);
        int numberDice2 = new Random().Next(1, 7);
        player.CurrentPosition+=numberDice1+numberDice2;
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
                if (player.CurrentPosition == CurrentPosition)
                {
                    output += $"[{player.token}]";
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