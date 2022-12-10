namespace Monopoly;
public interface ISpacing  //Requirement 13: An interface
{
public int Id{get; }
public void Action(ref Player player);
}