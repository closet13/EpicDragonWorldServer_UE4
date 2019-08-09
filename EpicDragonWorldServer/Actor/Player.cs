using MySql.Data.MySqlClient;
using System;

/**
 * Author: Pantelis Andrianakis
 * Date: November 7th 2018
 */
public class Player : Creature
{
    private static readonly string RESTORE_CHARACTER = "SELECT * FROM characters WHERE name=@name";
    private static readonly string STORE_CHARACTER = "UPDATE characters SET name=@name, race=@race, x=@x, y=@y, z=@z, heading=@heading, experience=@experience, hp=@hp, mp=@mp WHERE account=@account AND name=@name";

    private readonly GameClient client;
    private readonly string name;
    private readonly byte raceId;
    private readonly float height;
    private readonly float belly;
    private readonly int hairType;
    private readonly int hairColor;
    private readonly int skinColor;
    private readonly int eyeColor;
    private readonly long experience;
    private readonly byte accessLevel;
    private readonly Inventory inventory;

    public Player(GameClient client, string name)
    {
        this.client = client;
        this.name = name;

        // Load information from database.
        try
        {
            MySqlConnection con = DatabaseManager.GetConnection();
            MySqlCommand cmd = new MySqlCommand(RESTORE_CHARACTER, con);
            cmd.Parameters.AddWithValue("name", name);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                raceId = (byte)reader.GetInt16("race"); // TODO: Remove cast?
                height = reader.GetFloat("height");
                belly = reader.GetFloat("belly");
                hairType = (byte)reader.GetInt16("hair_type"); // TODO: Remove cast?
                hairColor = reader.GetInt32("hair_color");
                skinColor = reader.GetInt32("skin_color");
                eyeColor = reader.GetInt32("eye_color");

                float locX = reader.GetFloat("x");
                float locY = reader.GetFloat("y");
                float locZ = reader.GetFloat("z");

                // Check if player is outside of world bounds.
                if (locX < Config.WORLD_MINIMUM_X || locX > Config.WORLD_MAXIMUM_X || locY < Config.WORLD_MINIMUM_Y || locY > Config.WORLD_MAXIMUM_Y || locZ < Config.WORLD_MINIMUM_Z || locZ > Config.WORLD_MAXIMUM_Z)
                {
                    // Move to initial area.
                    SetLocation(Config.STARTING_LOCATION);
                }
                else
                {
                    SetLocation(new LocationHolder(locX, locY, locZ, reader.GetFloat("heading")));
                }

                experience = reader.GetInt64("experience");
                SetCurrentHp(reader.GetInt64("hp"));
                SetCurrentMp(reader.GetInt64("mp"));
                accessLevel = (byte)reader.GetInt16("access_level"); // TODO: Remove cast?
            }
            con.Close();
        }
        catch (Exception e)
        {
            LogManager.Log(e.ToString());
        }

        // Initialize inventory.
        inventory = new Inventory(name);
    }

    public void StoreMe()
    {
        try
        {
            MySqlConnection con = DatabaseManager.GetConnection();
            MySqlCommand cmd = new MySqlCommand(STORE_CHARACTER, con);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Parameters.AddWithValue("race", raceId);
            cmd.Parameters.AddWithValue("x", GetLocation().GetX());
            cmd.Parameters.AddWithValue("y", GetLocation().GetY());
            cmd.Parameters.AddWithValue("z", GetLocation().GetZ());
            cmd.Parameters.AddWithValue("heading", GetLocation().GetHeading());
            cmd.Parameters.AddWithValue("experience", experience);
            cmd.Parameters.AddWithValue("hp", GetCurrentHp());
            cmd.Parameters.AddWithValue("mp", GetCurrentMp());
            cmd.Parameters.AddWithValue("account", client.GetAccountName());
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception e)
        {
            LogManager.Log(e.ToString());
        }

        // Save inventory.
        inventory.Store(name);
    }

    public GameClient GetClient()
    {
        return client;
    }

    public string GetName()
    {
        return name;
    }

    public int GetRaceId()
    {
        return raceId;
    }

    public float GetHeight()
    {
        return height;
    }

    public float GetBelly()
    {
        return belly;
    }

    public int GetHairType()
    {
        return hairType;
    }

    public int GetHairColor()
    {
        return hairColor;
    }

    public int GetSkinColor()
    {
        return skinColor;
    }

    public int GetEyeColor()
    {
        return eyeColor;
    }

    public long GetExperience()
    {
        return experience;
    }

    public byte GetAccessLevel()
    {
        return accessLevel;
    }

    public Inventory GetInventory()
    {
        return inventory;
    }

    public void ChannelSend(SendablePacket packet)
    {
        client.ChannelSend(packet);
    }

    public override bool IsPlayer()
    {
        return true;
    }

    public override Player AsPlayer()
    {
        return this;
    }

    public override string ToString()
    {
        return "Player [" + name + "]";
    }
}
