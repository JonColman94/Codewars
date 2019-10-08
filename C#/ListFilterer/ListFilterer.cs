using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ListFilterer
{

    // Use LINQ to filter out strings;
    public static IEnumerable<int> GetIntegersFromList(List<object> listOfItems)
    {
        return listOfItems.OfType<int>();
    }
}
