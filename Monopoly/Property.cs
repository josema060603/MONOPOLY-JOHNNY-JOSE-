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
    public Player Owner      //Requirement 11: Properties
    {
        get; protected set;
    }
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

        if (characs.Length == 10)
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

  
    public void AddGreenHouse()
    {

        GreenHouses++;
        if (GreenHouses == 1) { Rent = GreenHouseRentIncrement1; }
        else if (GreenHouses == 2) { Rent = GreenHouseRentIncrement2; }
        else if (GreenHouses == 3) { Rent = GreenHouseRentIncrement3; }
        else if (GreenHouses == 4) { Rent = GreenHouseRentIncrement4; }


    }
    public void AddHotel()
    {
        if (this.GreenHouses > 4)
        {
            Hotel++;
        }

    }
   public static bool operator == (Property property, Property property2){ //EXTRA POINTS: OPERATOR OVERLOADING
    if( property.Id == property2.Id){
        return true;
    }
    else{
        return false;
    }
    }

    public static bool operator != (Property property, Property property2){
    if( property.Id == property2.Id){
        return false;
    }
    else{
        return true;
    }

   }
  

    public enum Color { Brown, SkyBlue, Pink, Orange, Red, Yellow, Green, Blue }   //feature 5: enumerator type

}
