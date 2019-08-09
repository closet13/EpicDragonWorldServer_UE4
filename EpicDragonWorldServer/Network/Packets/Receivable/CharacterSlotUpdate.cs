using MySql.Data.MySqlClient;
using System;

/**
 * Author: Pantelis Andrianakis
 * Date: November 7th 2018
 */
public class CharacterSlotUpdate
{
    private static readonly string CHARACTER_SLOT_UPDATE_QUERY = "UPDATE characters SET slot=@slot WHERE account=@account AND slot=@oldslot";

    public CharacterSlotUpdate(GameClient client, ReceivablePacket packet)
    {
        // Read data.
        byte oldSlot = (byte)packet.ReadByte();
        byte newSlot = (byte)packet.ReadByte();

        // Database queries.
        try
        {
            MySqlConnection con = DatabaseManager.GetConnection();
            MySqlCommand cmd = new MySqlCommand(CHARACTER_SLOT_UPDATE_QUERY, con);
            cmd.Parameters.AddWithValue("slot", 0);
            cmd.Parameters.AddWithValue("account", client.GetAccountName());
            cmd.Parameters.AddWithValue("oldslot", oldSlot);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception e)
        {
            LogManager.Log(e.ToString());
        }

        try
        {
            MySqlConnection con = DatabaseManager.GetConnection();
            MySqlCommand cmd = new MySqlCommand(CHARACTER_SLOT_UPDATE_QUERY, con);
            cmd.Parameters.AddWithValue("slot", oldSlot);
            cmd.Parameters.AddWithValue("account", client.GetAccountName());
            cmd.Parameters.AddWithValue("oldslot", newSlot);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception e)
        {
            LogManager.Log(e.ToString());
        }

        try
        {
            MySqlConnection con = DatabaseManager.GetConnection();
            MySqlCommand cmd = new MySqlCommand(CHARACTER_SLOT_UPDATE_QUERY, con);
            cmd.Parameters.AddWithValue("slot", newSlot);
            cmd.Parameters.AddWithValue("account", client.GetAccountName());
            cmd.Parameters.AddWithValue("oldslot", 0);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception e)
        {
            LogManager.Log(e.ToString());
        }
    }
}
