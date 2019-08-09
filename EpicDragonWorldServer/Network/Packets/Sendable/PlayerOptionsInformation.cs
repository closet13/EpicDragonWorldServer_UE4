using MySql.Data.MySqlClient;
using System;

/**
 * Author: Pantelis Andrianakis
 * Date: February 14th 2019
 */
public class PlayerOptionsInformation : SendablePacket
{
    private static readonly string ACCOUNT_CHARACTER_QUERY = "SELECT * FROM character_options WHERE name=@name";

    public PlayerOptionsInformation(Player player)
    {
        // Packet id.
        WriteShort(5);

        // Load options from database.
        try
        {
            MySqlConnection con = DatabaseManager.GetConnection();
            MySqlCommand cmd = new MySqlCommand(ACCOUNT_CHARACTER_QUERY, con);
            cmd.Parameters.AddWithValue("name", player.GetName());
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                WriteInt(reader.GetInt32("chat_color_normal"));
                WriteInt(reader.GetInt32("chat_color_message"));
                WriteInt(reader.GetInt32("chat_color_system"));
                WriteByte((byte)reader.GetInt16("chat_use_timestamps")); // TODO: Remove cast?
                WriteShort(reader.GetInt16("key_up_1"));
                WriteShort(reader.GetInt16("key_up_2"));
                WriteShort(reader.GetInt16("key_down_1"));
                WriteShort(reader.GetInt16("key_down_2"));
                WriteShort(reader.GetInt16("key_left_1"));
                WriteShort(reader.GetInt16("key_left_2"));
                WriteShort(reader.GetInt16("key_right_1"));
                WriteShort(reader.GetInt16("key_right_2"));
                WriteShort(reader.GetInt16("key_jump_1"));
                WriteShort(reader.GetInt16("key_jump_2"));
                WriteShort(reader.GetInt16("key_character_1"));
                WriteShort(reader.GetInt16("key_character_2"));
                WriteShort(reader.GetInt16("key_inventory_1"));
                WriteShort(reader.GetInt16("key_inventory_2"));
                WriteShort(reader.GetInt16("key_skills_1"));
                WriteShort(reader.GetInt16("key_skills_2"));
                WriteShort(reader.GetInt16("key_shortcut_1_1"));
                WriteShort(reader.GetInt16("key_shortcut_1_2"));
                WriteShort(reader.GetInt16("key_shortcut_2_1"));
                WriteShort(reader.GetInt16("key_shortcut_2_2"));
                WriteShort(reader.GetInt16("key_shortcut_3_1"));
                WriteShort(reader.GetInt16("key_shortcut_3_2"));
                WriteShort(reader.GetInt16("key_shortcut_4_1"));
                WriteShort(reader.GetInt16("key_shortcut_4_2"));
                WriteShort(reader.GetInt16("key_shortcut_5_1"));
                WriteShort(reader.GetInt16("key_shortcut_5_2"));
                WriteShort(reader.GetInt16("key_shortcut_6_1"));
                WriteShort(reader.GetInt16("key_shortcut_6_2"));
                WriteShort(reader.GetInt16("key_shortcut_7_1"));
                WriteShort(reader.GetInt16("key_shortcut_7_2"));
                WriteShort(reader.GetInt16("key_shortcut_8_1"));
                WriteShort(reader.GetInt16("key_shortcut_8_2"));
                WriteShort(reader.GetInt16("key_shortcut_9_1"));
                WriteShort(reader.GetInt16("key_shortcut_9_2"));
                WriteShort(reader.GetInt16("key_shortcut_10_1"));
                WriteShort(reader.GetInt16("key_shortcut_10_2"));
                WriteShort(reader.GetInt16("key_shortcut_11_1"));
                WriteShort(reader.GetInt16("key_shortcut_11_2"));
                WriteShort(reader.GetInt16("key_shortcut_12_1"));
                WriteShort(reader.GetInt16("key_shortcut_12_2"));
            }
            con.Close();
        }
        catch (Exception e)
        {
            LogManager.Log(e.ToString());
        }
    }
}
