namespace Monopoly;
public class Jail : ISpacing  //Requireement 2: Second class definition
{   //Requirement 7 Polymorphism with Id from ISpacing

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
