namespace Monopoly;
public class IncomingTax : ISpacing
{
    public int Id{get;}=4;

    public void Action(ref Player player)
    {
        player.moneyToPay+=100;
    }
}