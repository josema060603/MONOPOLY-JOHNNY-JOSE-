namespace Monopoly;

public static class ExtensionMethod
{
    static public bool HasPlayerLost(this ref Player player)
    {
        if (player.moneyToPay > player.Money)
            return true;
        return false;
    }
    static public bool IsInJail(this ref Player player)
    {
        if (player.CurrentPosition == 10 && player.wasSentInJail)
            return true;
        return false;
    }
        //
    public static void SetNewOwner(this Property property, ref Player newOwner, ref Player oldOwner, int price)
    {

        if (newOwner.Money - price < 0)
        {
            throw new Exception();
        }
        else
        {
            newOwner.moneyToPay += price;
            oldOwner.Money = oldOwner.Money + price;
            oldOwner.Properties = from x in oldOwner.Properties where x != property select x;
            newOwner.Properties=newOwner.Properties + property;
            property.Owner = newOwner;
        }
    }

    public static void SetOwner(this Property property, ref Player Owner)
    {

        Owner.moneyToPay += property.Price;
        Owner.Properties=Owner.Properties + property;
        property.Owner = Owner;
        //After this part, the new owner has been already changed, nonetheless, it is important to check if this completes a color set.
        if (property.Id != 5 && property.Id != 15 && property.Id != 25 && property.Id != 35)
        {
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
                    property.ColorSetComplete = true;
                }
                property.ColorSetComplete = false;
            }
            else
            {
                if (colors.Count() > 1)
                {
                    property.ColorSetComplete = true;
                }
                property.ColorSetComplete = false;
            }
        }
        else if (property.Id == 5 || property.Id == 15 || property.Id == 25 || property.Id == 35)
        {
            var railroads = new List<Property>();
            foreach (var item in Owner.Properties)
            {
                if (item is Railroad)
                {
                    railroads.Add(item);
                }
            }
            if (railroads.Count() > 1)
            {
                foreach (var item in Owner.Properties)
                {
                    if (item is Railroad)
                    {
                        Railroad.IncreaseRent((Railroad) item);
                    }
                }
            }

        }
    }
}