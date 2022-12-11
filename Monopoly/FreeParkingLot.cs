namespace Monopoly;
public class FreeParkingLot : ISpacing //REQUIREMNT 3: A third class definition, each box has a different class
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