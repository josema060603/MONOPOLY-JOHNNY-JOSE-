namespace Monopoly;

public static class ExtensionMethod //NOT A REQUIREMENT: we did extension methods so some of the logic was easier to write
{

//REQUIREMENT 12: static function, we made this functions static: 1. they are extension methods, 2. they are implement the same way with each plpayer
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


    //EXTRA POINTS: XML, we wrote the xml so the function was more clever
    
    ///<summary>
    ///This method takes as parameters a property, 2 players, new owner and old owner and the price. The property will be removed from the old owner and the price will be added to his money, the property will be added to the new owner and the price will be substracted from the new owner´s money
    ///</summary>
    public static void SetNewOwner(this Property property, ref Player newOwner, ref Player oldOwner, int price)
    {
//REQUIREMENT 12: static function, we made this functions static: 1. they are extension methods, 2. they are implement the same way with each plpayer

        if (newOwner.Money - price < 0)
        {
            throw new Exception();
        }
        else
        {
            newOwner.moneyToPay += price;
            oldOwner.Money = oldOwner.Money + price;
            oldOwner.Properties = from x in oldOwner.Properties where x != property select x; //EXTRA POINTS: use of query expressions, we used a query expression in order to get the llist of property without the property
            newOwner.Properties=newOwner.Properties + property;
            property.Owner = newOwner;
        }
    }

    public static void SetOwner(this Property property, ref Player Owner)
    {
//REQUIREMENT 12: static function, we made this functions static: 1. they are extension methods, 2. they are implement the same way with each plpayer

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