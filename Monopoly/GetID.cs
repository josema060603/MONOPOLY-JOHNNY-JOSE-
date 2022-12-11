namespace Monopoly;
 public class GetID<T> where T:  GoToJail //REQUIREMENT 10: Use of own generic type, we were wanting to have a generic class able to receive a class and use its id to display it in a method. 
{
    private T item;
    public GetID(T _item)
    {
        item=_item;
    }
     public int GetId()
    {
        return ((GoToJail) item).Id;
    }
}
