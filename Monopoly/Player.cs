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
    }
    
    public IEnumerable<Property> Properties  //Requirement 15: Use of one build-in generic function
    {
        get; set;
    }
    public Player(string name)
    {
        moneyToPay=0;
        CurrentPosition=0;
        Name = name;
        Money = 1500;
        Properties = new List<Property>();   //Requirement 15: Use of one built-in generic function
    }
}
