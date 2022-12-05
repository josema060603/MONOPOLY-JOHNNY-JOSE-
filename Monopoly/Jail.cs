namespace Monopoly;
public class Jail : ISpacing  //Requireement 2: Second class definition
{   //Requirement 7 Polymorphism with Id from ISpacing

    public int Id { get; } = 10;

    public bool CanGetOutOfJail((int, int) dice)
    {
        if (dice.Item1 == dice.Item2)
            return true;
        return false;
    }

    void ISpacing.Action(Player player)
    {
        throw new NotImplementedException();
    }
}
