namespace Monopoly;

//Each property box will contain the property of Owner, price, number of green houses, number of red
//houses, and color of property.
public class Property : ISpacing  //// REQUIREMENT 6: Inheritance, we made possible to inherite from property class, since the item inherited can be owned.
{           //REQUIREMENT 8: Polymophism: The method set characteristics is abstract, so each of the different inherited classes read from the IO differently
    public Property(string[] characs)
    {
        SetCharacteristics(characs);
    }

    public Color color { get; protected set; }

    public string Name { get; protected set; }
    private bool colorSetComplete;
    public bool ColorSetComplete { get { return colorSetComplete; } set { if (value == true) { Rent = RentWithColorSet; } colorSetComplete = value; } } //REQUIREMENT 11: Use of properties, in this case, we made a personalized set  in order to increase rent after color set is complete
    public Player Owner;      

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

//EXTRA POINTS: XML, we used xml in order clear up what the method does

    

    ///<sumamry>
    ///This function will add a green house if the color set is complete and if there are less than 4 green houses. If those requirement are not met, it will return an exception
    ///</summary>
    public void AddGreenHouse(ref Player player)
    {

        {
            if (this.colorSetComplete && this.GreenHouses < 4)
            {
                GreenHouses++;
                if (GreenHouses == 1)
                {
                    Rent = GreenHouseRentIncrement1;
                    if (player.Money < GreenHouseRentIncrement1)
                    { throw new Exception(); }
                    player.moneyToPay += GreenHouseRentIncrement1;
                }
                else if (GreenHouses == 2)
                {
                    Rent = GreenHouseRentIncrement2;
                    if (player.Money < GreenHouseRentIncrement1)
                    { throw new Exception(); }
                    player.moneyToPay += GreenHouseRentIncrement2;
                }
                else if (GreenHouses == 3)
                {
                    Rent = GreenHouseRentIncrement3;
                    if (player.Money < GreenHouseRentIncrement1)
                    { throw new Exception(); }
                    player.moneyToPay += GreenHouseRentIncrement3;
                }
                else if (GreenHouses == 4)
                {
                    Rent = GreenHouseRentIncrement4;
                    if (player.Money < GreenHouseRentIncrement1)
                    { throw new Exception(); }
                    player.moneyToPay += GreenHouseRentIncrement4;
                }
            }
            else
            {
                throw new Exception();
            }
        }


    }

//EXTRA POINTS: XML, we used xml in order clear up what the method does



    ///<summary
    ///This function will add a hotel if the player can affort it and if there are more than 3 green houses and less than 2 houses, if those requirements are not met, it will throw an exception
    ///</summary
    public void AddHotel(ref Player player)
    {
        if (player.moneyToPay > HotelRentIncrement)
        {
            if (this.GreenHouses > 3 && this.Hotel < 2)
            {
                Hotel++;
                player.moneyToPay += HotelRentIncrement;
            }
            else
            {
                throw new Exception();
            }
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

//EXTRA POINTS: XML, we used xml in order clear up what the method does



    ///<summary>
    /// EchangeProperty is the responsible of making a trade with properties. they can only trade 1 with 1, and the player´s money remain the same
    ///</summary>
    static public void ExchangeProperty(ref Player player1, Property property1, ref Player player2, Property property2)
    {
        property1.Owner = player2;
        player2.Properties = player2.Properties + property1;
        player1.Properties = player1.Properties - property1;
        property2.Owner = player1;
        player1.Properties = player1.Properties + property2;
        player2.Properties = player2.Properties - property2;

    }

    public virtual void Action(ref Player player)//REQUIREMENT 8: Polymorphism
    {
        if (this.Owner.Name == null)
        {
            this.SetOwner(ref player);
        }
        else
        {
            this.PayRent(ref player);
        }
    }
    public virtual void PayRent(ref Player player)//REQUIREMENT 8: Polymorphism
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
    public static IEnumerable<Property> operator -(IEnumerable<Property> groupOfProperties, Property property)
    {
        var output = new List<Property>(groupOfProperties);
        output.Remove(property);
        return output;
    }


    public enum Color { Brown, SkyBlue, Pink, Orange, Red, Yellow, Green, Blue }   //REQUIREMENT 5: Enum, we made the tokens enums, since their index is an integer and would allows to generate a random token for each player.

}
