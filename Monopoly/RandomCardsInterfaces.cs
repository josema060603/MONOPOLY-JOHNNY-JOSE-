namespace Monopoly;
public interface IRandomCard : ISpacing //REQUIREMENT 14, INterface 2 this cannot be owned, we made a random card interface that will do a thing accordingly.
{
    public void DoAThing(ref Player player);

}
