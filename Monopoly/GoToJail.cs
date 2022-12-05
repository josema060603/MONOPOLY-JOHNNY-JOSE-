namespace Monopoly;

public class GoToJail : ISpacing
{

    public int Id { get; } = 30;

    void ISpacing.Action(Player player)
    {
        throw new NotImplementedException();
    }
}
