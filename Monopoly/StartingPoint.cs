namespace Monopoly;

public class StartingPoint : ISpacing
{
    public int Id
    {
        get;
        set;
    }=0;

    void ISpacing.Action(ref Player player)
    {
        throw new NotImplementedException();
    }
}