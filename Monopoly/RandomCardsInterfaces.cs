namespace Monopoly;
public interface IRandomCard : ISpacing
{
    public void DoAThing(Player player, Board board);

}
public class CommunityChest : ISpacing, IRandomCard
{
    public CommunityChest(string id)
    {
        Id = int.Parse(id);
    }
    public int Id { get; set; }

    public void DoAThing(Player player, Board board)
    {
        int probability = new Random().Next(0, 7);
        if (probability <= 5)
        {
            player.Money += new Random().Next(-300, 301);
        }

        else
        {
            player.CurrentPosition = 10;
        }
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
public class Chance : ISpacing, IRandomCard
{
    public Chance(string id)
    {
        Id = int.Parse(id);
    }

    public int Id { get; set; }

    public void DoAThing(Player player, Board board)
    {
        int probability = new Random().Next(0, 7);
        if (probability <= 1)
        {
            player.Money += new Random().Next(0, 301);
        }

        else
        {
            player.CurrentPosition = 10;
        }
    }
     public static bool operator ==(Chance property, Chance property2)
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

    public static bool operator !=(Chance property, Chance property2)
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