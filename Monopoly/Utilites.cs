namespace Monopoly;
public class Utilities : Property, ISpacing
{
    public Utilities(string[] characs) : base(characs)
    {
        this.SetCharacteristics(characs);
    }
    public int Rent2{get; set;}
    public override void SetCharacteristics(string[] characs)
    {
        Id=int.Parse(characs[0]);
        Name=characs[1];
        Price=int.Parse(characs[2]);
        Rent=int.Parse(characs[3]);
        Rent2=int.Parse(characs[4]);

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