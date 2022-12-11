namespace Monopoly;
public class Utilities : Property, ISpacing // REQUIREMENT 6: Inheritance, we made possible to inherite from property class, since the item inherited can be owned.
{//REQUIREMENT 7: Polymorphism, we overrode the function of set characteristics, since it is written differently in the csv file
    public Utilities(string[] characs) : base(characs)
    {
        this.SetCharacteristics(characs);
    }
    public int Rent2{get; set;}
    public override void SetCharacteristics(string[] characs) //REQUIREMENT 7: Polymorphism, we overrode the function of set characteristics, since it is written differently in the csv file
    {
        Id=int.Parse(characs[0]);
        Name=characs[1];
        Price=int.Parse(characs[2]);
        Rent=int.Parse(characs[3]);
        Rent2=int.Parse(characs[4]);

    }
    public  void Action(ref Player player)
    {
        if(this.Owner.Name==null)
        {
            this.SetOwner(ref player);
        }
        else
        {
          this.PayRent(ref player);  
        }
    }


}