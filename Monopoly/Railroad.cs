namespace Monopoly;
public class Railroad : Property, ISpacing  //Requirement 3: Third class definition
{
    public Railroad(string[] characs) : base(characs)
    {
        this.SetCharacteristics(characs);
    }
    public int Rent2Items { get; set; }
    public int Rent3Items { get; set; }
    public int Rent4Items { get; set; }


    public override void SetCharacteristics(string[] characs)
    {
        Id = int.Parse(characs[0]);
        Name = characs[1];
        Price = int.Parse(characs[2]);
        Rent = int.Parse(characs[3]);
        Rent2Items = int.Parse(characs[4]);
        Rent3Items = int.Parse(characs[5]);
        Rent4Items = int.Parse(characs[6]);
    }
    public static bool operator ==(Railroad property, Railroad property2)
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

    public static bool operator !=(Railroad property, Railroad property2)
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
    public virtual void Action(Player player)
    {
        if(this.Owner.Name==null)
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
        player.moneyToPay+=this.Rent;
        this.Owner.moneyToPay-=this.Rent;
    }



}