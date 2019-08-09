using System.Threading;

/**
 * Author: Pantelis Andrianakis
 * Date: November 7th 2018
 */
public class IdManager
{
    private static long LAST_ID = 0;

    public static long GetNextId()
    {
        return Interlocked.Increment(ref LAST_ID);
    }
}
