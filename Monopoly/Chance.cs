namespace Monopoly;

public class Chance : ISpacing, IRandomCard
{
    public Chance(string id)
    {
        Id = int.Parse(id);
    }

    public int Id { get; set; }


    public void DoAThing(Player player)
    {
        int probability = new Random().Next(0, 7);
        if (probability <= 1)
        {
            player.Money += new Random().Next(0, 301);
        }

        else
        {
            player.CurrentPosition = 10;
            player.wasSentInJail=true;
        }
    }

    void ISpacing.Action(Player player)
    {
        DoAThing(player);
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