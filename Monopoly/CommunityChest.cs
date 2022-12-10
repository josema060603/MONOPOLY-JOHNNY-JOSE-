namespace Monopoly;

public class CommunityChest : ISpacing, IRandomCard
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
            player.Money += new Random().Next(-300, 301);
        }

        else
        {
            player.CurrentPosition = 10;
            player.wasSentInJail=true;
        }
    }

    public void Action(ref Player player)
    {
        DoAThing(ref player);
    }

    public static bool operator ==(CommunityChest property, CommunityChest property2)
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

    public static bool operator !=(CommunityChest property, CommunityChest property2)
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
}
