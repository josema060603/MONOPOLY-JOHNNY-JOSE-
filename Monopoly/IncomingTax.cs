namespace Monopoly;
public class IncomingTax : ISpacing //REQUIREMENT 3: third class definition: Again, a class for each of the boxes, this one only takes money from the user
{
    public int Id{get;}=4;

    public void Action(ref Player player)
    {
        player.moneyToPay+=100;
    }
}