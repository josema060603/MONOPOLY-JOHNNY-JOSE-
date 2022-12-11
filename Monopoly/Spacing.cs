namespace Monopoly;
public interface ISpacing  //Requirement 13: An interface, we use an interface that represents a box in the gameboard, which always will do an action over the player
{
public int Id{get; }
public void Action(ref Player player);
}