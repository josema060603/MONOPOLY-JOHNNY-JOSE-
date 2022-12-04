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

}