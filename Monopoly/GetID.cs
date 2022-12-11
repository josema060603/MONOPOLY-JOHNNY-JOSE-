namespace Monopoly;
 public class GetID<T> where T:  GoToJail
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