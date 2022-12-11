namespace Monopoly;
public class Railroad : Property, ISpacing  //Requirement 3: Third class definition, we made a class just for railroad.
//REQUIREMENT 6: Inheritance, as RAILROADS can be owned, we inheritated from property 
//REQUIREMENT 7: Polymorphism, we overrode the function of set characteristics, since it is written differently in the csv file
{
    public Railroad(string[] characs) : base(characs)
    {
        this.SetCharacteristics(characs);
    }
    public int Rent2Items { get; set; }
    public int Rent3Items { get; set; }
    public int Rent4Items { get; set; }

    //EXTRA POINTS: XML, we used xml in order clear up what the method does

    ///<summary>
    ///SetCharacteristics takes a string array and the values inside of it are going to be parsed into intergers to create the properties of the class Railroad. It is an override inherited from property.
    ///</summary>
    public override void SetCharacteristics(string[] characs)
    {
        Id = int.Parse(characs[0]);
        Name = characs[1];
        Price = int.Parse(characs[2]);
        Rent = int.Parse(characs[3]);
    }
    public static bool operator ==(Railroad property, Railroad property2)
    { //EXTRA POINTS: OPERATOR OVERLOADING, we wanted a railroad to 
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

    public override void Action(ref Player player) //REQUIREMENT 7: polymorphism
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

//EXTRA POINTS: XML, we used xml in order clear up what the method does

    ///<summary>
    ///IncreaseRent will take as parameters a railroad and multiply by 2 the rent of it.
    ///</summary>
    static public void IncreaseRent(Railroad railroad)
    {

        railroad.Rent *= 2;
    }
}



