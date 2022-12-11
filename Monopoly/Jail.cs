namespace Monopoly;
public class Jail : ISpacing  //REQUIREMENT 2: second class definition, the class of jail only takes money if the user was sent there from the go to jail class.
{
    public int Id { get; } = 10;


    public void Action(ref Player player)
    {
        if(player.wasSentInJail)
        {
            player.moneyToPay+=100;
            player.wasSentInJail=false;
        }
        
    }
}
