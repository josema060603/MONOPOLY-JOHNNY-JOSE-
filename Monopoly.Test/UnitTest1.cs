using NUnit.Framework;
using System.Collections.Generic;
namespace Monopoly.Test;
using System;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestBoard()
    {
        var path="../../../../properties.csv";
        var board = new Board(new Player?[] { new Player("Jose"), new Player("Hose"), new Player("Joseh"), new Player("Jhose"), new Player("Joshe") }, path);
        var testChest = board.GameBoard[33].Item1;
        Assert.IsTrue(new CommunityChest("33")==(CommunityChest) testChest);
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
        freeParkingLot.FreeParking(player);
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

        GoToJail gotojail = new GoToJail();
        Assert.AreEqual(30, gotojail.Id);

        StartingPoint startingpoint = new StartingPoint();
        Assert.AreEqual(0, startingpoint.Id);
    }

    [Test]
    public void TestAddGreenHouse()
    {
        string[] characs = { "10", "Johnny", "8", "7", "6", "5", "4", "3", "2", "1", "3" };
        Property newproperty = new Property(characs);
        var Johnny= new Player("Johnny");
        newproperty.AddGreenHouse(Johnny);
        Assert.AreEqual(1, newproperty.GreenHouses);
    }
    [Test]
    public void TestAdd2GreenHouses()
    {
        string[] characs = { "10", "Johnny", "8", "7", "6", "5", "4", "3", "2", "1", "3" };
        Property newproperty2 = new Property(characs);
        var Johnny= new Player("Johnny");
        newproperty2.AddGreenHouse(Johnny);
        newproperty2.AddGreenHouse(Johnny);
        Assert.AreEqual(2, newproperty2.GreenHouses);
    }
    [Test]
    public void TestChangeOfOwner()
    {
        // string[] characs = {"11","Johnny", "9", "8","7","6","5","4","3","2","1"};
        // Player OldOwner = new Player();
        // Player NewOwner = new Player();
        // Property property = new Property(characs);
        // List<Property> ListOfProperties = new List<Property>(){property};
        // OldOwner.Properties= ListOfProperties;
        // Assert.AreEqual(property, NewOwner);
        // Assert.AreEqual(null,OldOwner.Properties);
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
        Assert.AreEqual(2, railroad.Rent2Items);
        Assert.AreEqual(3, railroad.Rent3Items);
        Assert.AreEqual(4, railroad.Rent4Items);

    }
    [Test]
    public void TestRailRoadWithZeroAndNull()
    {
        string[] characs = { "8", null, "7", "6", "0", "0", "0" };
        Railroad railroad = new Railroad(characs);
        Assert.AreEqual(8, railroad.Id);
        Assert.AreEqual(null, railroad.Name);
        Assert.AreEqual(7, railroad.Price);
        Assert.AreEqual(6, railroad.Rent);
        Assert.AreEqual(0, railroad.Rent2Items);
        Assert.AreEqual(0, railroad.Rent3Items);
        Assert.AreEqual(0, railroad.Rent4Items);

    }

}