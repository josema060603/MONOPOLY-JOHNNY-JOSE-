namespace Monopoly;

//Each property box will contain the property of Owner, price, number of green houses, number of red
//houses, and color of property.
public class Property : ISpacing  //requirement 6: inheritance
{           //Requirenent 8: Second Example of Polymorphism
    public Property(string[] characs)
    {
        SetCharacteristics(characs);
    }

    public Color color { get; protected set; }

    public string Name { get; protected set; }
    private bool colorSetComplete;
    public bool ColorSetComplete { get { return colorSetComplete; } set { if (value == true) { Rent = RentWithColorSet; } colorSetComplete = value; } }
    public Player Owner;      //Requirement 11: Properties

    public int Price
    {
        get; protected set;
    }
    public int GreenHouses
    {
        get; protected set;
    }
    public int Hotel
    {
        get; protected set;
    }
    public int Rent
    {
        get; protected set;
    }
    public int RentWithColorSet
    {
        get; protected set;
    }
    public int GreenHouseRentIncrement1
    {
        get; protected set;
    }
    public int GreenHouseRentIncrement2
    {
        get; protected set;
    }
    public int GreenHouseRentIncrement3
    {
        get; protected set;
    }
    public int GreenHouseRentIncrement4
    {
        get; protected set;
    }
    public int HotelRentIncrement
    {
        get; protected set;
    }
    public int Id { get; set; }
    public virtual void SetCharacteristics(string[] characs)
    {

        if (characs.Length == 11)
        {
            Id = int.Parse(characs[0]);
            Name = characs[1];
            Price = int.Parse(characs[2]);
            Rent = int.Parse(characs[3]);
            RentWithColorSet = int.Parse(characs[4]);
            GreenHouseRentIncrement1 = int.Parse(characs[5]);
            GreenHouseRentIncrement2 = int.Parse(characs[6]);
            GreenHouseRentIncrement3 = int.Parse(characs[7]);
            GreenHouseRentIncrement4 = int.Parse(characs[8]);
            HotelRentIncrement = int.Parse(characs[9]);
            color = (Color)int.Parse(characs[10]);
        }
        else
        {
            return;
        }
    }


    public void AddGreenHouse(Player player)
    {

        if (this.colorSetComplete && this.GreenHouses < 4)
        {
            GreenHouses++;
            if (GreenHouses == 1) { Rent = GreenHouseRentIncrement1; player.moneyToPay += GreenHouseRentIncrement1 * 2; }
            else if (GreenHouses == 2) { Rent = GreenHouseRentIncrement2; player.moneyToPay += GreenHouseRentIncrement2 * 2; }
            else if (GreenHouses == 3) { Rent = GreenHouseRentIncrement3; player.moneyToPay += GreenHouseRentIncrement3 * 2; }
            else if (GreenHouses == 4) { Rent = GreenHouseRentIncrement4; player.moneyToPay += GreenHouseRentIncrement4 * 2; }
        }
        else
        {
            throw new Exception();
        }


    }
    public void AddHotel()
    {
        if (this.GreenHouses > 4 && this.Hotel < 2)
        {
            Hotel++;
        }
        else
        {
            throw new Exception();
        }

    }
    public static bool operator ==(Property property, Property property2)
    { //EXTRA POINTS: OPERATOR OVERLOADING
        if (property.Id == property2.Id)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool operator !=(Property property, Property property2)
    {
        if (property.Id == property2.Id)
        {
            return false;
        }
        else
        {
            return true;
        }


    }
    static public void ExchangeProperty(Player player1, Property property1, Player player2, Property property2)
    {
        property1.SetNewOwner(player1, player2, 0);
        property2.SetNewOwner(player2, player1, 0);
    }

    public virtual void Action(Player player)
    {
        if (this.Owner.Name == null)
        {
            this.SetOwner(player);
        }
        else
        {
            this.PayRent(player);
        }
    }
    public virtual void PayRent(Player player)
    {
        player.moneyToPay += this.Rent;
        this.Owner.moneyToPay -= this.Rent;
    }

    public static IEnumerable<Property> operator +(IEnumerable<Property> groupOfProperties, Property property)
    {
        var output = new List<Property>(groupOfProperties);
        output.Add(property);
        return output;
    }


    public enum Color { Brown, SkyBlue, Pink, Orange, Red, Yellow, Green, Blue }   //feature 5: enumerator type

}
