namespace Monopoly;
public class FreeParkingLot : ISpacing
{
    public int Id { get ; set ; }=20;

    public void FreeParking(Player player){
        player.Money = player.Money;
    }

    public void Action(Player player)
    {
        FreeParking(player);
    }
}