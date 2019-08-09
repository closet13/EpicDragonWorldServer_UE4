using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

/**
 * Author: Pantelis Andrianakis
 * Date: November 7th 2018
 */
public class WorldObject
{
    private readonly long objectId = IdManager.GetNextId();
    private readonly DateTime spawnTime = DateTime.Now;
    private AnimationHolder animations = null;
    private LocationHolder location = new LocationHolder(0, 0, -1000);
    private RegionHolder region = null;
    private bool isTeleporting = false;

    public long GetObjectId()
    {
        return objectId;
    }

    public DateTime GetSpawnTime()
    {
        return spawnTime;
    }

    public AnimationHolder GetAnimations()
    {
        return animations;
    }

    public void SetAnimations(AnimationHolder animations)
    {
        this.animations = animations;
    }

    public LocationHolder GetLocation()
    {
        return location;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void SetLocation(LocationHolder location)
    {
        this.location = location;

        // When changing location test for appropriate region.
        RegionHolder testRegion = WorldManager.GetRegion(this);
        if (!testRegion.Equals(region))
        {
            if (region != null)
            {
                // Remove this object from the region.
                region.RemoveObject(objectId);

                // Broadcast change to players left behind when teleporting.
                if (isTeleporting)
                {
                    DeleteObject deleteObject = new DeleteObject(this);
                    foreach (RegionHolder nearbyRegion in region.GetSurroundingRegions())
                    {
                        foreach (WorldObject obj in region.GetObjects())
                        {
                            if (obj == this)
                            {
                                continue;
                            }
                            if (obj.IsPlayer())
                            {
                                obj.AsPlayer().ChannelSend(deleteObject);
                            }
                        }
                    }
                }
            }
            region = testRegion;
            region.AddObject(this);
        }
    }

    public RegionHolder GetRegion()
    {
        return region;
    }

    public void SetTeleporting()
    {
        isTeleporting = true;
        Task.Delay(1000).ContinueWith(task => StopTeleporting());
    }

    private void StopTeleporting()
    {
        isTeleporting = false;

        // Broadcast location to nearby players after teleporting.
        LocationUpdate locationUpdate = new LocationUpdate(this);
        foreach (Player nearby in WorldManager.GetVisiblePlayers(this))
        {
            if (nearby.IsPlayer())
            {
                nearby.AsPlayer().ChannelSend(locationUpdate);
            }
            if (IsPlayer())
            {
                AsPlayer().ChannelSend(new LocationUpdate(nearby));
            }
        }
    }

    public bool IsTeleporting()
    {
        return isTeleporting;
    }

    /// <summary>Calculates distance between this WorldObject and given x, y , z.</summary>
    /// <param name="x">the X coordinate</param>
    /// <param name="y">the Y coordinate</param>
    /// <param name="z">the Z coordinate</param>
    /// <returns>distance between object and given x, y, z.</returns>
    public double CalculateDistance(float x, float y, float z)
    {
        return Math.Pow(x - location.GetX(), 2) + Math.Pow(y - location.GetY(), 2) + Math.Pow(z - location.GetZ(), 2);
    }

    /// <summary>Calculates distance between this WorldObject and another WorldObject.</summary>
    /// <param name="obj">the other WorldObject</param>
    /// <returns>distance between object and given x, y, z.</returns>
    public double CalculateDistance(WorldObject obj)
    {
        return CalculateDistance(obj.GetLocation().GetX(), obj.GetLocation().GetY(), obj.GetLocation().GetZ());
    }

    /// <summary>Verify if object is instance of Creature.</summary>
    /// <returns>if object is instance of Creature.</returns>
    public virtual bool IsCreature()
    {
        return false;
    }

    /// <returns>Creature instance if current object is such, null otherwise.</returns>
    public virtual Creature AsCreature()
    {
        return null;
    }

    /// <summary>Verify if object is instance of Player.</summary>
    /// <returns>if object is instance of Player.</returns>
    public virtual bool IsPlayer()
    {
        return false;
    }

    /// <returns>Player instance if current object is such, null otherwise.</returns>
    public virtual Player AsPlayer()
    {
        return null;
    }

    /// <summary>Verify if object is instance of Monster.</summary>
    /// <returns>if object is instance of Monster.</returns>
    //public virtual bool IsMonster()
    //{
    //    return false;
    //}

    /// <returns>Monster instance if current object is such, null otherwise.</returns>
    //public virtual Monster AsMonster()
    //{
    //    return null;
    //}

    /// <summary>Verify if object is instance of Npc.</summary>
    /// <returns>if object is instance of Npc.</returns>
    //public virtual bool IsNpc()
    //{
    //    return false;
    //}

    /// <returns>Npc instance if current object is such, null otherwise.</returns>
    //public virtual Npc AsNpc()
    //{
    //    return null;
    //}

    public override string ToString()
    {
        return "WorldObject [" + objectId + "]";
    }
}
