namespace Monopoly;

public static class ExtensionMethod
{
    static public bool HasPlayerLost(this Player player)
    {
        if (player.moneyToPay > player.Money)
            return true;
        return false;
    }
    static public bool IsInJail(this Player player)
    {
        if (player.CurrentPosition == 11)
            return true;
        return false;
    }
    
    public static void SetNewOwner(this Property property, Player newOwner, Player oldOwner, int price)
    {

        if (newOwner.Money-price < 0)
        {
            throw new Exception();
        }
        else
        {
            newOwner.moneyToPay+=price;
            oldOwner.Money = oldOwner.Money + price;
            oldOwner.Properties= from x in oldOwner.Properties where x!=property select x;
            newOwner.Properties+=property;
            property.Owner=newOwner;
        }
    }
    public static void SetOwner(this Property property, Player Owner)
    {

        Owner.moneyToPay += property.Price;
        property.Owner=Owner;
        Owner.Properties += property;
    
        var colors = new List<Property.Color>();
        foreach (var item in Owner.Properties)
        {
            if (item.color == property.color)
            {
                colors.Add(item.color);
            }
        }
        if ((int)property.color != 1 || (int)property.color != 8)
        {
            if (colors.Count() > 2)
            {
                property.colorSetComplete = true;
            }
            property.colorSetComplete = false;
        }
        else
        {
            if (colors.Count() > 1)
            {
                property.colorSetComplete = true;
            }
            property.colorSetComplete = false;
        }
    


    }

}