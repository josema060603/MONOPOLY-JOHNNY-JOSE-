namespace Monopoly;
public class FreeParkingLot : ISpacing
{
    public int Id { get ; set ; }=20;

    public void FreeParking(ref Player player){
        player.Money = player.Money;
    }

    public void Action(ref Player player)
    {
        FreeParking(ref player);
    }
}