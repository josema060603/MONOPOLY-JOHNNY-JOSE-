using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
namespace Monopoly.Test;
using Monopoly;
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestBoard()
    {
        var board = new Board(new Player?[] { new Player("Jose"), new Player("Hose"), new Player("Joseh"), new Player("Jhose"), new Player("Joshe") },"../../../../properties.csv" );
        var testChest = board.GameBoard[33].Item1;
        Assert.IsTrue(new CommunityChest("33")==(CommunityChest) testChest);
    }

    [Test]
    public void TestBoard2(){
        var Jose=new Player("Jose");
        var board = new Board(new Player?[] { Jose, new Player("Hose"), new Player("Joseh"), new Player("Jhose"), new Player("Joshe") }, "C:/Users/Usuario/Desktop/Monopoly-Johnny-Jose/properties.csv");
        Assert.IsTrue(0== Jose.CurrentPosition);
    }


    [Test]
    public void TestFreeParkingLotProperties()
    {
        FreeParkingLot freeparkinglot = new FreeParkingLot();
        int IdOfFreeParkingLot = freeparkinglot.Id;
        Assert.AreEqual(IdOfFreeParkingLot, 20);
    }
    [Test]
    public void TestFreeParkingLotProperties2()
    {
        Player player = new Player();
        player.Money = 1500;
        FreeParkingLot freeParkingLot = new FreeParkingLot();
        Assert.AreEqual(1500, player.Money);

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
    public void TestNullPlayers()
    {
        Player player2 = new Player();
        string playername2 = null;
        Assert.AreEqual(playername2, player2.Name);
        Assert.AreEqual(null, player2.Name);
    }

    [Test]
    public void TestJail()
    {
        Jail jail = new Jail();
        Assert.AreEqual(10, jail.Id);

    }    
    [Test]
    public void TestGoToJail(){
        Jail gotojail = new Jail();
        bool CanGetOutOfJail = gotojail.CanGetOutOfJail((6,6));
        Assert.AreEqual(true, CanGetOutOfJail);
    }

    [Test]
    public void TestStartingPoint(){
        StartingPoint startingpoint = new StartingPoint();
        Assert.AreEqual(0, startingpoint.Id);
    }
    
    [Test]
    public void TestAddGreenHouse()
    {
         string[] characs = { "10", "Johnny", "8", "7", "6", "5", "4", "3", "2", "1", "3" };
         Property newproperty = new Property(characs);
         Player player = new Player("Zhen Shuai");
         newproperty.ColorSetComplete=true;
         newproperty.AddGreenHouse(player);
         Assert.AreEqual(1, newproperty.GreenHouses);
    }
    [Test]
    public void TestAdd2GreenHouses()
    {
        // string[] characs = { "10", "Johnny", "8", "7", "6", "5", "4", "3", "2", "1", "3" };
        // Property newproperty2 = new Property(characs);
        // Player player = new Player();
        // newproperty2.AddGreenHouse(player);
        // newproperty2.AddGreenHouse(player);
        // Assert.AreEqual(2, newproperty2.GreenHouses);
    }
    [Test]
    public void TestAdd3GreenHouses()
    {
        // string[] characs = { "10", "Johnny", "8", "7", "6", "5", "4", "3", "2", "1", "3" };
        // Property newproperty3 = new Property(characs);
        // Player player = new Player();
        // newproperty3.AddGreenHouse(player);
        // newproperty3.AddGreenHouse(player);
        // newproperty3.AddGreenHouse(player);
        // Assert.AreEqual(3, newproperty3.GreenHouses);
    }
    [Test]
    public void TestSetNewOwner()
    {
        // string[] characs = {"10", "Johnny", "10", "7", "6", "0", "4", "3", "2", "1", "7"};
        // Player OldOwner = new Player("Juan");
        // Player NewOwner = new Player("Jose");
        //  OldOwner.Money = 1500;
        //  NewOwner.Money = 1500;
        //  Property property = new Property(characs);
        //  OldOwner.ChangeOfOwner(NewOwner, property);
        //  Assert.AreEqual(1491, NewOwner.Money);
        //  Assert.AreEqual(1509, OldOwner.Money);
        
        
    }
    [Test]
    public void TestExchangeOfOwner(){
        // Player player = new Player();
        // string[] characs = { "10", "Johnny", "8", "7", "6", "5", "4", "3", "2", "1", "3" };
        // Property newproperty = new Property(characs);
        // Player player2 = new Player("Johnny");
        // Property newproperty2 = new Property(characs);
        // Property.ExchangeProperty(player, newproperty, player2, newproperty2);
       


    
    }
    [Test]
    public void TestRailRoad()
    {
        string[] characs = { "8", "Reading Railroad", "7", "5"};
        Railroad railroad = new Railroad(characs);
        Assert.AreEqual(8, railroad.Id);
        Assert.AreEqual("Reading Railroad", railroad.Name);
        Assert.AreEqual(7, railroad.Price);
        Assert.AreEqual(5, railroad.Rent);

    }
    [Test]
    public void TestRailRoadWithZeroAndNull()
    {
        string[] characs = { "8", null, "7", "5"};
        Railroad railroad = new Railroad(characs);
        Assert.AreEqual(8, railroad.Id);
        Assert.AreEqual(null, railroad.Name);
        Assert.AreEqual(7, railroad.Price);
        Assert.AreEqual(5, railroad.Rent);

    }

    //
    [Test]
    public void TestProperties(){
        string[] characs = {"10", "Johnny", "10", "7", "6", "0", "4", "3", "2", "1", "7"};
        Property property = new Property(characs);
        Assert.AreEqual(10, property.Id);
        Assert.AreEqual("Johnny",property.Name);
        Assert.AreEqual(10, property.Price);
        Assert.AreEqual(7, property.Rent);
        Assert.AreEqual(6, property.RentWithColorSet);  
        Assert.AreEqual(0, property.GreenHouseRentIncrement1);
        Assert.AreEqual(4, property.GreenHouseRentIncrement2);
        Assert.AreEqual(3, property.GreenHouseRentIncrement3);
        Assert.AreEqual(2, property.GreenHouseRentIncrement4);
        Assert.AreEqual(1, property.HotelRentIncrement);
        Assert.AreEqual(Property.Color.Blue ,property.color);
    }
    [Test]
    public void TestPropertiesWithZero(){
        string[] characs = {"10", "Johnny", "0", "0", "0", "0", "0", "0", "0", "0", "0"};
        Property property = new Property(characs);
        Assert.AreEqual(10, property.Id);
        Assert.AreEqual("Johnny",property.Name);
        Assert.AreEqual(0, property.Price);
        Assert.AreEqual(0, property.Rent);
        Assert.AreEqual(0, property.RentWithColorSet);  
        Assert.AreEqual(0, property.GreenHouseRentIncrement1);
        Assert.AreEqual(0, property.GreenHouseRentIncrement2);
        Assert.AreEqual(0, property.GreenHouseRentIncrement3);
        Assert.AreEqual(0, property.GreenHouseRentIncrement4);
        Assert.AreEqual(0, property.HotelRentIncrement);
        Assert.AreEqual(Property.Color.Brown ,property.color);
    }
    [Test]
    public void TestAddHotel(){
        // string[] characs = { "10", "Johnny", "8", "7", "6", "0", "4", "3", "2", "1", "3" };
        // Property newproperty = new Property(characs);
        // Player player = new Player();
        // newproperty.AddGreenHouse(player);
        // newproperty.AddGreenHouse(player);
        // newproperty.AddGreenHouse(player);
        // newproperty.AddGreenHouse(player);
        // newproperty.AddHotel();
        // Assert.AreEqual(1, newproperty.Hotel);
    }
    [Test]
    public void TestAddHotelWithNotEnoughGreenHouses(){
        // string[] characs = { "10", "Johnny", "8", "7", "6", "0", "4", "3", "2", "1", "3" };
        // Property newproperty = new Property(characs);
        // Player player = new Player();
        // newproperty.AddGreenHouse(player);
        // newproperty.AddGreenHouse(player);
        // newproperty.AddHotel();
        // Assert.AreEqual(0, newproperty.Hotel);
    }
    
    [Test]
    public void TestPLayerLost(){
        Player loser = new Player();
        loser.Money = 0;
        loser.moneyToPay = 99;
        bool hasplayerlost= ExtensionMethod.HasPlayerLost(loser);
        Assert.AreEqual(true, hasplayerlost);
    }
    [Test]
    public void TestSetChatacteristics(){
        string[] stringofcharacters ={"10", "Chema", "100","110", "120"};
        Utilities utilities = new Utilities(stringofcharacters);
        utilities.SetCharacteristics(stringofcharacters);
        Assert.AreEqual(10,utilities.Id);
        Assert.AreEqual("Chema", utilities.Name);
        Assert.AreEqual(100, utilities.Price);
        Assert.AreEqual(110, utilities.Rent);
        Assert.AreEqual(120, utilities.Rent2);
    }
    [Test]
    public void TestSetChatacteristicsWIthNull(){
        // string[] stringofcharacters ={null, null, null,null,null};
        // Utilities utilities = new Utilities(stringofcharacters);
        // utilities.SetCharacteristics(stringofcharacters);
        // Assert.AreEqual(null,utilities.Id);
        // Assert.AreEqual(null, utilities.Name);
        // Assert.AreEqual(null, utilities.Price);
        // Assert.AreEqual(null, utilities.Rent);
        // Assert.AreEqual(null, utilities.Rent2);
    }
    [Test]
    public void testCommunityChest(){
        CommunityChest communitychest = new CommunityChest("2");
       int CommunityChestId = communitychest.Id;
       Assert.AreEqual(2, CommunityChestId);

    }
    [Test]
    public void TestEqualsOperator(){
        string[] characs = { "10", "Johnny", "8", "7", "6", "0", "4", "3", "2", "1", "3" };
        Property property1 = new Property(characs);
        Property property2 = new Property(characs);
        bool AreEqual = property1 == property2;
        Assert.AreEqual(true, AreEqual);
    }
    [Test]
    public void TestNotEqualsOperator(){
        string[] characs = { "10", "Johnny", "8", "7", "6", "0", "4", "3", "2", "1", "3" };
        string[] characs2 = {"9", "Jose", "9", "8", "3", "5", "4","7","2","4", "8"};
        Property property1 = new Property(characs);
        Property property2 = new Property(characs2);
        Assert.AreEqual(true, property1!= property2);
    }
    [Test]
    public void TestUtilities(){
        string[] characs = {"8", "Carlos", "7", "1","4"};
        Utilities utilities = new Utilities(characs);
        Assert.AreEqual(8, utilities.Id);
        Assert.AreEqual("Carlos",utilities.Name);
        Assert.AreEqual(7, utilities.Price);
        Assert.AreEqual(1, utilities.Rent);
        Assert.AreEqual(4,utilities.Rent2);
    }
    [Test]
    public void TestUtilities2(){
        string[] characs = {"9", null, "0", "0","0"};
        Utilities utilities = new Utilities(characs);
        Assert.AreEqual(9, utilities.Id);
        Assert.AreEqual(null,utilities.Name);
        Assert.AreEqual(0, utilities.Price);
        Assert.AreEqual(0, utilities.Rent);
        Assert.AreEqual(0,utilities.Rent2);
    }
}