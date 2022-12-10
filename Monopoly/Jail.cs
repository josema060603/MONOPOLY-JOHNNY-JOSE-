namespace Monopoly;
public class Jail : ISpacing  //Requireement 2: Second class definition
{   //Requirement 7 Polymorphism with Id from ISpacing

    public int Id { get; } = 10;


    void ISpacing.Action(ref Player player)
    {
        throw new NotImplementedException();
    }
}
