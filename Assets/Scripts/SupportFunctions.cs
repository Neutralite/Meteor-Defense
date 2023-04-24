using System.Collections.Generic;

public class SupportFunctions
{
    public static void MoveBetweenLists<T>(List<T> source, List<T> destination, T obj)
    {
        source.Remove(obj);
        destination.Add(obj);
    }
}
