namespace Monopoly;

public class Chance : ISpacing, IRandomCard //REQUIREMENT 2: Second class definition, we did this class that is not part from property, in order to give luck to the player that lands on them.
{
    public Chance(string id)
    {
        Id = int.Parse(id);
    }

    public int Id { get; set; }


    public void DoAThing(ref Player player)
    {
        int probability = new Random().Next(0, 7);
        if (probability <= 1)
        {
            player.Money += new Random().Next(0, 101);
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

    public static bool operator ==(Chance property, Chance property2)
    { //EXTRA POINTS: OPERATOR OVERLOADING: again, we provided with a comparer of chances to see whether they are the same or not.
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
    { //EXTRA POINTS: OPERATOR OVERLOADING: again, we provided with a comparer of chances to see whether they are the same or not.

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