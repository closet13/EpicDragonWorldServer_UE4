using System.Collections.Concurrent;
using System.Collections.Generic;

/**
 * Author: Pantelis Andrianakis
 * Date: April 27th 2019
 */
public class RegionHolder
{
    private readonly int x;
    private readonly int y;
    private readonly ConcurrentDictionary<long, WorldObject> objects = new ConcurrentDictionary<long, WorldObject>();
    private RegionHolder[] surroundingRegions;

    public RegionHolder(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void SetSurroundingRegions(RegionHolder[] surroundingRegions)
    {
        this.surroundingRegions = surroundingRegions;
    }

    public RegionHolder[] GetSurroundingRegions()
    {
        return surroundingRegions;
    }

    public void AddObject(WorldObject obj)
    {
        long objectId = obj.GetObjectId();
        RemoveObject(objectId);
        objects.TryAdd(objectId, obj);
    }

    public void RemoveObject(long objectId)
    {
        ((IDictionary<long, WorldObject>)objects).Remove(objectId);
    }

    public ICollection<WorldObject> GetObjects()
    {
        return objects.Values;
    }

    public int GetX()
    {
        return x;
    }

    public int GetY()
    {
        return y;
    }

    public override int GetHashCode()
    {
        return x ^ y;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        RegionHolder region = ((RegionHolder)obj);
        return x == region.GetX() && y == region.GetY();
    }

    public override string ToString()
    {
        return "Region [" + x + " " + y + "]";
    }
}
