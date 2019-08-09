using MySql.Data.MySqlClient;
using System;

/**
 * Author: Pantelis Andrianakis
 * Date: November 7th 2018
 */
public class CharacterSelectUpdate
{
    private static readonly string CHARACTER_SELECTED_RESET_QUERY = "UPDATE characters SET selected=0 WHERE account=@account";
    private static readonly string CHARACTER_SELECTED_UPDATE_QUERY = "UPDATE characters SET selected=1 WHERE account=@account AND slot=@slot";

    public CharacterSelectUpdate(GameClient client, ReceivablePacket packet)
    {
        // Read data.
        int slot = packet.ReadByte();

        // Make existing characters selected value false.
        try
        {
            MySqlConnection con = DatabaseManager.GetConnection();
            MySqlCommand cmd = new MySqlCommand(CHARACTER_SELECTED_RESET_QUERY, con);
            cmd.Parameters.AddWithValue("account", client.GetAccountName());
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception e)
        {
            LogManager.Log(e.ToString());
        }

        // Set character selected.
        try
        {
            MySqlConnection con = DatabaseManager.GetConnection();
            MySqlCommand cmd = new MySqlCommand(CHARACTER_SELECTED_UPDATE_QUERY, con);
            cmd.Parameters.AddWithValue("account", client.GetAccountName());
            cmd.Parameters.AddWithValue("slot", slot);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception e)
        {
            LogManager.Log(e.ToString());
        }
    }
}
