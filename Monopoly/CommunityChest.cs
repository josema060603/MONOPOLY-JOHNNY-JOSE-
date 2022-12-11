namespace Monopoly;

public class CommunityChest : ISpacing, IRandomCard //REQUIREMENT 3: A third class definition, we made a class just for community chests, that their chances of winning or gaining money are different
{
    public CommunityChest(string id)
    {
        Id = int.Parse(id);
    }
    public int Id { get; set; }

    public void DoAThing(ref Player player)
    {
        int probability = new Random().Next(0, 7);
        if (probability <= 5)
        {
            player.Money += new Random().Next(-100, 101);
        }

        else
        {
            player.CurrentPosition = 10;
            player.wasSentInJail = true;
        }
    }

    public void Action(ref Player player)
    {
        DoAThing(ref player);
    }

    public static bool operator ==(CommunityChest property, CommunityChest property2)
    { //EXTRA POINTS: OPERATOR OVERLOADING: again, we provided with a comparer of community chest to see whether they are the same or not.

        if (property.Id == property2.Id)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool operator !=(CommunityChest property, CommunityChest property2)
    { //EXTRA POINTS: OPERATOR OVERLOADING: again, we provided with a comparer of community chest to see whether they are the same or not.

        if (property.Id == property2.Id)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
