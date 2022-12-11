namespace Monopoly;

public class GoToJail : ISpacing //REQUIREMENT 3: Third class definition, again, each box has its specific class, in this case this one sends the player to Jail
{

    public int Id { get; } = 30;
    public void PlayerGoesToJail(ref Player player)
    {
        player.CurrentPosition=10;
        player.wasSentInJail=true;
    }
    public void Action(ref Player player)
    {
        PlayerGoesToJail(ref player);
    }
}
