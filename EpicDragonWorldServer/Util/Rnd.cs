using System;

/**
 * Author: Pantelis Andrianakis
 * Date: May 16th 2019
 */
public class Rnd
{
    private static readonly Random RANDOM = new Random();

    /// <summary>
    /// Returns a random bool value.
    /// </summary>
    public static bool NextBool()
    {
        lock (RANDOM)
        {
            return RANDOM.Next(2) == 0;
        }
    }

    /// <summary>
    /// Generates random bytes and places them into a user-supplied byte array. The number of random bytes produced is equal to the length of the byte array.
    /// </summary>
    public static void NextBytes(byte[] bytes)
    {
        lock (RANDOM)
        {
            RANDOM.NextBytes(bytes);
        }
    }

    /// <summary>
    /// Returns a random int value between zero (inclusive) and the specified bound (exclusive).
    /// </summary>
    public static int Get(int bound)
    {
        lock (RANDOM)
        {
            return RANDOM.Next(bound);
        }
    }

    /// <summary>
    /// Returns a random int value between the specified origin (inclusive) and the specified bound (inclusive).
    /// </summary>
    public static int Get(int origin, int bound)
    {
        if (origin == bound)
        {
            return origin;
        }
        lock (RANDOM)
        {
            return origin + (int)((bound - origin + 1) * RANDOM.NextDouble());
        }
    }

    /// <summary>
    /// Returns a random int value.
    /// </summary>
    public static int NextInt()
    {
        lock (RANDOM)
        {
            return RANDOM.Next();
        }
    }

    /// <summary>
    /// Returns a random long value between zero (inclusive) and the specified bound (exclusive).
    /// </summary>
    public static long Get(long bound)
    {
        lock (RANDOM)
        {
            return (long)(RANDOM.NextDouble() * bound);
        }
    }

    /// <summary>
    /// Returns a random long value between the specified origin (inclusive) and the specified bound (inclusive).
    /// </summary>
    public static long Get(long origin, long bound)
    {
        if (origin == bound)
        {
            return origin;
        }
        lock (RANDOM)
        {
            return origin + (long)((bound - origin + 1) * RANDOM.NextDouble());
        }
    }

    /// <summary>
    /// Returns random long value.
    /// </summary>
    public static long NextLong()
    {
        return Get(0, long.MaxValue);
    }

    /// <summary>
    /// Returns a random double value between zero (inclusive) and the specified bound (exclusive).
    /// </summary>
    public static double Get(double bound)
    {
        lock (RANDOM)
        {
            return RANDOM.NextDouble() * bound;
        }
    }

    /// <summary>
    /// Returns a random double value between the specified origin (inclusive) and the specified bound (inclusive).
    /// </summary>
    public static double Get(double origin, double bound)
    {
        if (origin == bound)
        {
            return origin;
        }
        lock (RANDOM)
        {
            return origin + ((bound - origin + 1) * RANDOM.NextDouble());
        }
    }

    /// <summary>
    /// Returns a random double value between zero (inclusive) and one (exclusive).
    /// </summary>
    public static double NextDouble()
    {
        lock (RANDOM)
        {
            return RANDOM.NextDouble();
        }
    }
}
