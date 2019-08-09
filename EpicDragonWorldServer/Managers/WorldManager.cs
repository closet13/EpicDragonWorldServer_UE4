using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

/**
 * Author: Pantelis Andrianakis
 * Date: November 7th 2018
 */
public class WorldManager
{
    private static readonly int VISIBILITY_RADIUS = 10000;
    private static readonly int MOVEMENT_BROADCAST_RADIUS = VISIBILITY_RADIUS + 100; // Need the extra distance to send location of objects getting out of range.
    private static readonly double REGION_RADIUS = Math.Sqrt(VISIBILITY_RADIUS);
    private static readonly int REGION_SIZE_X = (int)(Config.WORLD_MAXIMUM_X / REGION_RADIUS);
    private static readonly int REGION_SIZE_Y = (int)(Config.WORLD_MAXIMUM_Y / REGION_RADIUS);
    private static readonly RegionHolder[][] REGIONS = new RegionHolder[REGION_SIZE_X][];
    private static readonly List<GameClient> ONLINE_CLIENTS = new List<GameClient>();
    private static readonly ConcurrentDictionary<long, Player> PLAYER_OBJECTS = new ConcurrentDictionary<long, Player>();

    public static void Init()
    {
        Util.PrintSection("World");

        // Initialize regions.
        for (int x = 0; x < REGION_SIZE_X; x++)
        {
            REGIONS[x] = new RegionHolder[REGION_SIZE_Y];
            for (int y = 0; y < REGION_SIZE_Y; y++)
            {
                REGIONS[x][y] = new RegionHolder(x, y);
            }
        }

        // Set surrounding regions.
        for (int x = 0; x < REGION_SIZE_X; x++)
        {
            for (int y = 0; y < REGION_SIZE_Y; y++)
            {
                List<RegionHolder> surroundingRegions = new List<RegionHolder>();
                for (int sx = x - 1; sx <= (x + 1); sx++)
                {
                    for (int sy = y - 1; sy <= (y + 1); sy++)
                    {
                        if (((sx >= 0) && (sx < REGION_SIZE_X) && (sy >= 0) && (sy < REGION_SIZE_Y)))
                        {
                            surroundingRegions.Add(REGIONS[sx][sy]);
                        }
                    }
                }
                REGIONS[x][y].SetSurroundingRegions(surroundingRegions.ToArray());
            }
        }

        LogManager.Log("WorldManager: Initialized " + REGION_SIZE_X + " by " + REGION_SIZE_Y + " regions.");
    }

    public static RegionHolder GetRegion(WorldObject obj)
    {
        int x = (int)(obj.GetLocation().GetX() / REGION_RADIUS);
        int y = (int)(obj.GetLocation().GetY() / REGION_RADIUS);
        if (x < 0)
        {
            x = 0;
        }
        if (y < 0)
        {
            y = 0;
        }
        if (x >= REGION_SIZE_X)
        {
            x = REGION_SIZE_X - 1;
        }
        if (y >= REGION_SIZE_Y)
        {
            y = REGION_SIZE_Y - 1;
        }
        return REGIONS[x][y];
    }

    public static void AddObject(WorldObject obj)
    {
        if (obj.IsPlayer())
        {
            if (!PLAYER_OBJECTS.Values.Contains(obj.AsPlayer()))
            {
                lock (ONLINE_CLIENTS)
                {
                    ONLINE_CLIENTS.Add(obj.AsPlayer().GetClient());
                }
                PLAYER_OBJECTS.TryAdd(obj.GetObjectId(), obj.AsPlayer());

                // Log world access.
                if (Config.LOG_WORLD)
                {
                    LogManager.LogWorld("Player [" + obj.AsPlayer().GetName() + "] Account [" + obj.AsPlayer().GetClient().GetAccountName() + "] Entered the world.");
                }
            }
        }
    }

    public static void RemoveObject(WorldObject obj)
    {
        // Broadcast deletion to nearby players.
        foreach (Player player in GetVisiblePlayers(obj))
        {
            player.ChannelSend(new DeleteObject(obj));
        }

        // Remove from list and take necessary actions.
        if (obj.IsPlayer())
        {
            ((IDictionary<long, Player>)PLAYER_OBJECTS).Remove(obj.GetObjectId());
            // Store player.
            obj.AsPlayer().StoreMe();

            // Log world access.
            if (Config.LOG_WORLD)
            {
                LogManager.LogWorld("Player [" + obj.AsPlayer().GetName() + "] Account [" + obj.AsPlayer().GetClient().GetAccountName() + "] Left the world.");
            }
        }

        obj.GetRegion().RemoveObject(obj.GetObjectId());
    }

    public static List<WorldObject> GetVisibleObjects(WorldObject obj)
    {
        List<WorldObject> result = new List<WorldObject>();
        foreach (RegionHolder region in obj.GetRegion().GetSurroundingRegions())
        {
            foreach (WorldObject wo in region.GetObjects())
            {
                if (wo.GetObjectId() == obj.GetObjectId())
                {
                    continue;
                }
                if (obj.CalculateDistance(wo) < MOVEMENT_BROADCAST_RADIUS)
                {
                    result.Add(wo);
                }
            }
        }
        return result;
    }

    public static List<Player> GetVisiblePlayers(WorldObject obj)
    {
        List<Player> result = new List<Player>();
        foreach (RegionHolder region in obj.GetRegion().GetSurroundingRegions())
        {
            foreach (WorldObject wo in region.GetObjects())
            {
                if (!wo.IsPlayer())
                {
                    continue;
                }
                if (wo.GetObjectId() == obj.GetObjectId())
                {
                    continue;
                }
                if (obj.CalculateDistance(wo) < MOVEMENT_BROADCAST_RADIUS)
                {
                    result.Add(wo.AsPlayer());
                }
            }
        }
        return result;
    }

    public static Player GetPlayerByName(string name)
    {
        foreach (Player player in PLAYER_OBJECTS.Values)
        {
            if (player.GetName().ToLowerInvariant().Equals(name.ToLowerInvariant()))
            {
                return player;
            }
        }
        return null;
    }

    public static int GetOnlineCount()
    {
        return ONLINE_CLIENTS.Count;
    }

    public static void AddClient(GameClient client)
    {
        lock (ONLINE_CLIENTS)
        {
            if (!ONLINE_CLIENTS.Contains(client))
            {
                ONLINE_CLIENTS.Add(client);
            }
        }
    }

    public static void RemoveClient(GameClient client)
    {
        // Store and remove player.
        Player player = client.GetActiveChar();
        if (player != null)
        {
            RemoveObject(player);
        }

        // Remove from list.
        lock (ONLINE_CLIENTS)
        {
            ONLINE_CLIENTS.Remove(client);
        }
    }

    public static GameClient GetClientByAccountName(string accountName)
    {
        foreach (GameClient client in ONLINE_CLIENTS)
        {
            if (client.GetAccountName().Equals(accountName))
            {
                return client;
            }
        }
        return null;
    }
}
