using System;
using System.Collections.Generic;


namespace Algorithms.Test
{
    public class Utility
    {
        public static bool IsSorted(IList<int> collection)
        {
            for (int i = 1; i < collection.Count - 1; i++)
            {
                if (collection[i] < collection[i - 1])
                    return false;
            }
            return true;
        }
    }
}