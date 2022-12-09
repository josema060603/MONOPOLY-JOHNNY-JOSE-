namespace Monopoly;

public class GoToJail : ISpacing
{

    public int Id { get; } = 30;
    public void PlayerGoesToJail(Player player)
    {
        player.CurrentPosition=10;
        player.wasSentInJail=true;
    }
    void ISpacing.Action(Player player)
    {
        PlayerGoesToJail(player);
    }
}
