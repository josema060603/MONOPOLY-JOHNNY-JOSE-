using NUnit.Framework;
using System.Collections.Generic;
namespace Monopoly.Test;
using Monopoly;
public class Tests
{

    [Test]
    public void TestBoard()
    {
        var board = new Board("../../../../properties.csv");
        var testChest = board.GameBoard[33];
        Assert.IsTrue(new CommunityChest("33")==(CommunityChest) testChest);
    }


    [Test]
    public void TestFreeParkingLotProperties2()
    {
        Player player = new Player("Johnny");
        FreeParkingLot freeParkingLot = new FreeParkingLot();
        freeParkingLot.Action(ref player);
        Assert.AreEqual(1500, player.Money);
        Assert.AreEqual(0, player.moneyToPay);

    }

    [Test]
    public void TestPLayers()
    {
        Player player = new Player("Johnny");
        string playername = "Johnny";
        Assert.AreEqual(playername, player.Name);
        Assert.AreEqual(1500, player.Money);
    }


    [Test]
    public void TestJail()
    {
        Jail jail = new Jail();
        Assert.AreEqual(10, jail.Id);

    }
    [Test]
    public void TestIsinJail()
    {
        Player prisioner = new Player();
        prisioner.CurrentPosition = 10;
        prisioner.wasSentInJail =true;
        bool IsPrisionerInJail = prisioner.IsInJail();
        Assert.AreEqual(true, IsPrisionerInJail);
    }

    [Test]
    public void TestStartingPoint()
    {
        StartingPoint startingpoint = new StartingPoint();
        Assert.AreEqual(0, startingpoint.Id);
    }

    [Test]
    public void TestAddGreenHouse()
    {
        string[] characs = { "10", "Johnny", "8", "7", "1", "1", "4", "3", "2", "1", "3" };
        Property newproperty = new Property(characs);
        Player player = new Player("Zhen Shuai");
        newproperty.ColorSetComplete = true;
        newproperty.AddGreenHouse(ref player);
        Assert.AreEqual(1, newproperty.GreenHouses);
    }
    [Test]
    public void TestAdd2GreenHouses()
    {
        string[] characs = { "10", "Johnny", "8", "7", "6", "5", "4", "3", "2", "1", "3" };
        Property newproperty2 = new Property(characs);
        Player player = new Player("johnny");
        newproperty2.ColorSetComplete = true;
        newproperty2.AddGreenHouse(ref player);
        newproperty2.AddGreenHouse(ref player);
        Assert.AreEqual(2, newproperty2.GreenHouses);
    }
    [Test]
    public void TestAddMoreHousesThanYouShould()
    {
        string[] characs = { "10", "Johnny", "8", "7", "6", "5", "4", "3", "2", "1", "3" };
        Property newproperty3 = new Property(characs);
        Player player = new Player();
        try
        {
            newproperty3.AddGreenHouse(ref player);
            newproperty3.AddGreenHouse(ref player);
            newproperty3.AddGreenHouse(ref player);
            newproperty3.AddGreenHouse(ref player);
            newproperty3.AddGreenHouse(ref player);
            Assert.Fail();
        }
        catch
        {
            Assert.Pass();
        }
    }
    [Test]
    public void TestAddMoreHousesWithoutColorSetComplete()
    {
        Player player = new Player("Chema");
        string[] characs = { "10", "Johnny", "8", "7", "6", "5", "4", "3", "2", "1", "3" };
        Property property = new Property(characs);
        property.ColorSetComplete = false;
        try
        {
            property.AddGreenHouse(ref player);
            property.AddGreenHouse(ref player);
            property.AddGreenHouse(ref player);
            Assert.Fail();
        }
        catch
        {
            Assert.Pass();
        }


    }
    [Test]
    public void TestSetNewOwner()
    {
        string[] characs = { "10", "Johnny", "10", "7", "6", "0", "4", "3", "2", "1", "7" };
        Player OldOwner = new Player("Juan");
        Player NewOwner = new Player("Jose");
        Property property = new Property(characs);
        property.SetOwner(ref OldOwner);
        property.SetNewOwner(ref NewOwner, ref OldOwner, 500);
        Assert.AreEqual(500, NewOwner.moneyToPay);


    }
    [Test]
    public void TestExchangeOfOwner()
    {
          string[] characs = { "10", "Johnny", "8", "7", "6", "5", "4", "3", "2", "1", "3" };
          string[] characs2 = {"14", "Johnny", "7", "2", "1", "4", "2", "5", "10", "8","4"};
          Player player = new Player("Jose");
          Player player2 = new Player("Johnny");
          Property newproperty = new Property(characs);
          Property newproperty2 = new Property(characs2);
          newproperty.SetOwner( ref player);
          newproperty2.SetOwner(ref player2);
          Property.ExchangeProperty(ref player, newproperty, ref player2, newproperty2);
          bool hasIt=false;
          foreach(var item in player.Properties)
          {
            if(item==newproperty2)
            {
                hasIt=true;
            }
          }
          Assert.IsTrue(hasIt);
    }
    [Test]
    public void TestRailRoad()
    {
        string[] characs = { "8", "Reading Railroad", "7", "6", "2", "3", "4" };
        Railroad railroad = new Railroad(characs);
        Assert.AreEqual(8, railroad.Id);
        Assert.AreEqual("Reading Railroad", railroad.Name);
        Assert.AreEqual(7, railroad.Price);
        Assert.AreEqual(6, railroad.Rent);


    }

    [Test]
    public void TestProperties()
    {
        string[] characs = { "10", "Johnny", "10", "7", "6", "0", "4", "3", "2", "1", "7" };
        Property property = new Property(characs);
        Assert.AreEqual(10, property.Id);
        Assert.AreEqual("Johnny", property.Name);
        Assert.AreEqual(10, property.Price);
        Assert.AreEqual(7, property.Rent);
        Assert.AreEqual(6, property.RentWithColorSet);
        Assert.AreEqual(0, property.GreenHouseRentIncrement1);
        Assert.AreEqual(4, property.GreenHouseRentIncrement2);
        Assert.AreEqual(3, property.GreenHouseRentIncrement3);
        Assert.AreEqual(2, property.GreenHouseRentIncrement4);
        Assert.AreEqual(1, property.HotelRentIncrement);
        Assert.AreEqual(Property.Color.Blue, property.color);
    }

    [Test]
    public void TestAddHotel()
    {
        string[] characs = { "10", "Johnny", "8", "7", "6", "0", "4", "3", "2", "1", "3" };
        Property newproperty = new Property(characs);
        Player player = new Player("chemo");
        newproperty.ColorSetComplete = true;
        newproperty.AddGreenHouse(ref player);
        newproperty.AddGreenHouse(ref player);
        newproperty.AddGreenHouse(ref player);
        newproperty.AddGreenHouse(ref player);
        newproperty.AddHotel(ref player);
        Assert.AreEqual(1, newproperty.Hotel);
    }
    [Test]
    public void TestAddHotelWithNotEnoughGreenHouses()
    {
        string[] characs = { "10", "Johnny", "8", "7", "6", "0", "4", "3", "2", "1", "3" };
        Property newproperty = new Property(characs);
        Player player = new Player();
        newproperty.ColorSetComplete = true;
        newproperty.AddGreenHouse(ref player);
        newproperty.AddGreenHouse(ref player);
        try
        {
            newproperty.AddHotel(ref player);
            Assert.Fail();
        }
        catch
        {
            Assert.Pass();
        }
    }

    [Test]
    public void TestPLayerLost()
    {
        Player loser = new Player();
        loser.Money = 0;
        loser.moneyToPay = 99;
        bool hasplayerlost = ExtensionMethod.HasPlayerLost(ref loser);
        Assert.AreEqual(true, hasplayerlost);
    }
    [Test]
    public void TestSetChatacteristics()
    {
        string[] stringofcharacters = { "10", "Chema", "100", "110", "120" };
        Utilities utilities = new Utilities(stringofcharacters);
        utilities.SetCharacteristics(stringofcharacters);
        Assert.AreEqual(10, utilities.Id);
        Assert.AreEqual("Chema", utilities.Name);
        Assert.AreEqual(100, utilities.Price);
        Assert.AreEqual(110, utilities.Rent);
        Assert.AreEqual(120, utilities.Rent2);
    }

    [Test]
    public void testCommunityChest()
    {
        CommunityChest communitychest = new CommunityChest("2");
        int CommunityChestId = communitychest.Id;
        Assert.AreEqual(2, CommunityChestId);

    }
    [Test]
    public void TestEqualsOperator()
    {
        string[] characs = { "10", "Johnny", "8", "7", "6", "0", "4", "3", "2", "1", "3" };
        Property property1 = new Property(characs);
        Property property2 = new Property(characs);
        bool AreEqual = property1 == property2;
        Assert.AreEqual(true, AreEqual);
    }
    [Test]
    public void TestNotEqualsOperator()
    {
        string[] characs = { "10", "Johnny", "8", "7", "6", "0", "4", "3", "2", "1", "3" };
        string[] characs2 = { "9", "Jose", "9", "8", "3", "5", "4", "7", "2", "4", "8" };
        Property property1 = new Property(characs);
        Property property2 = new Property(characs2);
        Assert.AreEqual(true, property1 != property2);
    }
    [Test]
    public void TestUtilities()
    {
        string[] characs = { "8", "Carlos", "7", "1", "4" };
        Utilities utilities = new Utilities(characs);
        Assert.AreEqual(8, utilities.Id);
        Assert.AreEqual("Carlos", utilities.Name);
        Assert.AreEqual(7, utilities.Price);
        Assert.AreEqual(1, utilities.Rent);
        Assert.AreEqual(4, utilities.Rent2);
    }

    [Test]
    public void TestRollDices(){
        Player player = new Player("Chema ");
        Player player2 = new Player("Carlos");
        Board.RollDices(ref player);
        if(player.CurrentPosition != player2.CurrentPosition){
            Assert.Pass();
        }
        else {
            Assert.Fail();
        }
    }
    [Test]
    public void TestIncreaseRentRailroad(){
        string[] characs = {"21", "Johnny","80", "12"};
        Railroad railroad = new Railroad(characs);
        Railroad.IncreaseRent(railroad);
        Assert.AreEqual(24, railroad.Rent);

    }
    [Test]
    public void TestIncomingTax(){
        Player player = new Player("motomami");
        IncomingTax tax = new IncomingTax();
        tax.Action( ref player);
        Assert.AreEqual(100, player.moneyToPay);
    }
    [Test]
    public void TestEqualsOperatorRailroad(){
        string[] charac = {"6", "blass", "21", "13"};
        Railroad railroad = new Railroad(charac);
        Railroad railroad2 = new Railroad(charac);
        bool AreRailroadsEqual = railroad == railroad2;
        Assert.AreEqual(true, AreRailroadsEqual);
    }
    [Test]
    public void TestNotEqualsOperatorRailroad(){
        string[] charac = {"6", "blass", "21", "13"};
        Railroad railroad = new Railroad(charac);
        Railroad railroad2 = new Railroad(charac);
        bool AreRailroadsEqual = railroad != railroad2;
        Assert.AreEqual(false, AreRailroadsEqual);
    }
    [Test]
    public void TestEqualOperatorChance(){
        Chance chance1 = new Chance("6");
        Chance chance2 = new Chance("6");
        bool AreChanceEqual = chance1 == chance2;
        Assert.AreEqual(true, AreChanceEqual);
    }
    [Test]
    public void TestNotEqualOperatorChance(){
        Chance chance1 = new Chance("9");
        Chance chance2 = new Chance("6");
        bool AreChanceEqual = chance1 != chance2;
        Assert.AreEqual(true, AreChanceEqual);
    }
    
    [Test]
    public void TestPlayerGoesToJail(){
        Player player = new Player("Blass");
        GoToJail gotojail = new GoToJail();
        gotojail.PlayerGoesToJail(ref player);
        Assert.AreEqual(10, player.CurrentPosition);
        Assert.AreEqual(true, player.wasSentInJail);
    }
    [Test]
    public void TestPayRent(){
        Player player = new Player("Carlos");
        string[] characs = { "10", "Johnny", "8", "7", "6", "0", "4", "3", "2", "1", "3" };
        Property property = new Property(characs);
        property.PayRent(ref player);
        Assert.AreEqual(7, player.moneyToPay);
    }
    [Test]
    public void TestplusProperty(){
        string[] characs = { "10", "Johnny", "8", "7", "6", "0", "4", "3", "2", "1", "3" };
        Property property = new Property(characs);
        IEnumerable<Property> ienumerable = new List<Property>();
        ienumerable+=property;
        Assert.IsTrue(((List<Property>)ienumerable).Contains(property));
    }
    [Test]
    public void TestMinusProperty(){
        string[] characs = { "10", "Johnny", "8", "7", "6", "0", "4", "3", "2", "1", "3" };
        Property property = new Property(characs);
        IEnumerable<Property> ienumerable = new List<Property>();
        ienumerable+=property;
        ienumerable -=property;
        Assert.IsTrue(!(((List<Property>)ienumerable).Contains(property)));
    }
    [Test]
    public void TestGetString(){
        var board= new Board("../../../../properties.csv");
        var Carlos=new Player("Carlos");
        var Carla=new Player("Carla");
        var Carle=new Player("Carle");
        var Char=new Player("Char");
        var Chuy=new Player("Chuy");
        var players= new Player[]{Carlos, Carla, Carle, Char, Chuy};
        var gottenString= board.GetBoardAsString(players, 0);
        var expectedString =$"\r\n|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|\r\n|                   |    -Red-        |                 |     -Red-       |      -Red-       |                  |   -Yellow-     |   -Yellow-     |                 |    -Yellow-    |                   |\r\n|                   | KENTUCKY        |  CHANCE         | INDIANA         | ILLINOIS         | B. & O.          |ATLANTIC        |   VENTNOR      | WATER           |MARVIN          |                   |\r\n|FREE PARKING       | AVE.            |                 | AVE.            | AVE.             | RAILROAD         | AVE            |   AVE          | WORKS           |GARDENS         | GO TO JAIL        |           \r\n|                   | $220            |                 |$220             | $240             | $200             | $260           |   $260         | $150            | $280           |                   | \r\n|  [ ][ ][ ][ ][ ]  | [ ][ ][ ][ ][ ] | [ ][ ][ ][ ][ ] | [ ][ ][ ][ ][ ] | [ ][ ][ ][ ][ ] | [ ][ ][ ][ ][ ] | [ ][ ][ ][ ][ ] | [ ][ ][ ][ ][ ] | [ ][ ][ ][ ][ ] | [ ][ ][ ][ ][ ] |  [ ][ ][ ][ ][ ]  |        \r\n|-------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------|\r\n|     -Orange-      |                                                                                                                                                                |      -Green-      |         \r\n|                   |                                                                                                                                                                |                   |\r\n|NEW YORK AVE.      |                                                                                                                                                                |PACIFIC AVE.       | \r\n|$200               |                                                                                                                                                                |$300               | \r\n|  [ ][ ][ ][ ][ ]  |                                                                                                                                                                |  [ ][ ][ ][ ][ ]  |\r\n|-------------------|                                                                                                                                                                |-------------------| \r\n|     -Orange-      |                                                                                                                                                                |     -Green-       |         \r\n|                   |                                                                                                                                                                |                   |\r\n|TENNESSEE AVE      |                                                                                                                                                                |NORTH C. AVE.      | \r\n|$180               |                                                                                                                                                                |$300               |\r\n|  [ ][ ][ ][ ][ ]  |                                                                                                                                                                |  [ ][ ][ ][ ][ ]  | \r\n|-------------------|                                                                                                                                                                |-------------------| \r\n|COMMUNITY CH.      |                                                                                                                                                                |COMMUNITY CH.      | \r\n|                   |                                                                                                                                                                |                   |\r\n|  [ ][ ][ ][ ][ ]  |                                                                                                                                                                |  [ ][ ][ ][ ][ ]  | \r\n|-------------------|                                                                                                                                                                |-------------------| \r\n|    -Orange-       |                                                                                                                                                                |     -Green-       |                        \r\n|ST. JAMES P.       |                                                                                                                                                                |PENNSYLV. AVE      | \r\n|$180               |                                                                                                                                                                |$320               |\r\n|                   |                                                                                                                                                                |                   |\r\n|  [ ][ ][ ][ ][ ]  |                                                                                                                                                                |  [ ][ ][ ][ ][ ]  | \r\n|-------------------|                                                                                                                                                                |-------------------| \r\n|                   |                                                                                                                                                                |                   |\r\n|PENNSYLVANIA       |                                                                                                                                                                | SHORT LINE        | \r\n|$200               |                                                                                                                                                                |$200               |\r\n|                   |                                                                                                                                                                |                   |\r\n|  [ ][ ][ ][ ][ ]  |                                                                                                                                                                |  [ ][ ][ ][ ][ ]  | \r\n|-------------------|                                                                                                                                                                |-------------------| \r\n|     -Pink-        |                                                                                                                                                                |                   |                   \r\n|VIRGINIA AV.       |                                                                                                                                                                |    CHANCE         | \r\n|$160               |                                                                                                                                                                |                   |\r\n|                   |                                                                                                                                                                |                   |\r\n|  [ ][ ][ ][ ][ ]  |                                                                                                                                                                |  [ ][ ][ ][ ][ ]  |\r\n|-------------------|                                                                                                                                                                |-------------------|\r\n|     -Pink-        |                                                                                                                                                                |      -Blue-       |                       \r\n|STATES AVE.        |                                                                                                                                                                |  PARK PLACE       |\r\n|$140               |                                                                                                                                                                |$350               |\r\n|                   |                                                                                                                                                                |                   |\r\n|  [ ][ ][ ][ ][ ]  |                                                                                                                                                                |  [ ][ ][ ][ ][ ]  | \r\n|-------------------|                                                                                                                                                                |-------------------|\r\n|                   |                                                                                                                                                                |                   |                        \r\n|ELECTRIC CO.       |                                                                                                                                                                | LUXURY TAX        | \r\n|$150               |                                                                                                                                                                |$100               |\r\n|                   |                                                                                                                                                                |                   |\r\n|  [ ][ ][ ][ ][ ]  |                                                                                                                                                                |  [ ][ ][ ][ ][ ]  | \r\n|-------------------|                                                                                                                                                                |-------------------|\r\n|     -Pink-        |                                                                                                                                                                |     -Blue-        |                 \r\n| ST CHARLES        |                                                                                                                                                                |  BOARDWALK        | \r\n| $140              |                                                                                                                                                                |$400               |\r\n|                   |                                                                                                                                                                |                   |\r\n|  [ ][ ][ ][ ][ ]  |                                                                                                                                                                |  [ ][ ][ ][ ][ ]  | \r\n|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------|\r\n|        |          |    -SkyBlue-    |    -SkyBlue-    |                 |    -SkyBlue-     |                  |   INCOME       |   -Brown-      |                 |    -Brown-     |                   |                                                              \r\n| JUST   |  IN      | CONNECTICUT     | VERMONT         |   CHANCE        | ORIENTAL         | READING          |     TAX        |   BALTI        | COMMUNITY       |MEDITERRA.      |   +₩200           |\r\n|VISITING|JAIL      |    Avenue       | AVENUE          |     ?           | AVENUE           | RAILROAD         |                |   AVENUE       | CHEST           |  AVENU         |      GO           | \r\n|        *----------| $120            | $100            |                 |                  |                  |                |                |                 |                |  <------------    |\r\n|                   |                 |                 |                 |                  |                  |                |                |                 |                |                   | \r\n|  [ ][ ][ ][ ][ ]  | [ ][ ][ ][ ][ ] | [ ][ ][ ][ ][ ] | [ ][ ][ ][ ][ ] | [ ][ ][ ][ ][ ] | [ ][ ][ ][ ][ ] | [ ][ ][ ][ ][ ] | [ ][ ][ ][ ][ ] | [ ][ ][ ][ ][ ] | [ ][ ][ ][ ][ ] |  [{Carlos.token}][{Carla.token}][{Carle.token}][{Char.token}][{Chuy.token}]  |\r\n----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------\r\n         It is currently the turn of Carlos\r\n        You currently have ₩1500\r\n        Your properties are: \r\n        For exchanging properties, press E\r\n        For selling properties, press S\r\n        For adding green houses, press C\r\n        For adding hotels, press H\r\n        To roll the dices, press R";
        Assert.AreEqual(expectedString, gottenString);
    }
}