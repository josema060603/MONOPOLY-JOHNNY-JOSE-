namespace Monopoly;
public struct Player   //feature 4: struct definition 
{
    public int CurrentPosition{get; set;}
    public string Name
    {
        get; set;
    }
    public int Money
    {
        get; set;
    }
    public int moneyToPay
    {
        get; set;
    }=0;
    
    public IEnumerable<Property> Properties  //Requirement 15: Use of one build-in generic function
    {
        get; set;
    }
    public Player(string name)
    {
        CurrentPosition=0;
        Name = name;
        Money = 1500;
        Properties = new List<Property>();   //Requirement 15: Use of one built-in generic function
    }
}

public static class ExtensionMethod
{
    static public bool HasPlayerLost(this Player player)
    {
        if(player.moneyToPay>player.Money)
        return true;
        return false;
    }
    static public bool IsInJail(this Player player)
    {
        if(player.CurrentPosition==11)
        return true;
        return false;
    }
        public static void ChangeOfOwner(this  Player oldOwner, Player newOwner, Property property)
    {
    
        int MoneyLeftByNewOwner = newOwner.Money - property.Price;
        if(MoneyLeftByNewOwner < 0){
            return;
        }
        else{
            newOwner.Money = MoneyLeftByNewOwner;
            oldOwner.Money = oldOwner.Money + property.Price;
            newOwner.Properties=oldOwner.Properties.Where(Properties => Properties == property);
        }



    }

}