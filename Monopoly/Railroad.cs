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
    public override void Action(Player player)
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

    static public void IncreaseRent(Railroad railroad)
    {

        railroad.Rent *= 2;
    }
}



