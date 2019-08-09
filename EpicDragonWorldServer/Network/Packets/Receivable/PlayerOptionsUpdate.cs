using MySql.Data.MySqlClient;
using System;

/**
 * Author: Pantelis Andrianakis
 * Date: February 14th 2019
 */
public class PlayerOptionsUpdate
{
    private static readonly string UPDATE_CHARACTER_OPTIONS_QUERY = "UPDATE character_options SET chat_color_normal=@chat_color_normal, chat_color_message=@chat_color_message, chat_color_system=@chat_color_system, chat_use_timestamps=@chat_use_timestamps, key_up_1=@key_up_1, key_up_2=@key_up_2, key_down_1=@key_down_1, key_down_2=@key_down_2, key_left_1=@key_left_1, key_left_2=@key_left_2, key_right_1=@key_right_1, key_right_2=@key_right_2, key_jump_1=@key_jump_1, key_jump_2=@key_jump_2, key_character_1=@key_character_1, key_character_2=@key_character_2, key_inventory_1=@key_inventory_1, key_inventory_2=@key_inventory_2, key_skills_1=@key_skills_1, key_skills_2=@key_skills_2, key_shortcut_1_1=@key_shortcut_1_1, key_shortcut_1_2=@key_shortcut_1_2, key_shortcut_2_1=@key_shortcut_2_1, key_shortcut_2_2=@key_shortcut_2_2, key_shortcut_3_1=@key_shortcut_3_1, key_shortcut_3_2=@key_shortcut_3_2, key_shortcut_4_1=@key_shortcut_4_1, key_shortcut_4_2=@key_shortcut_4_2, key_shortcut_5_1=@key_shortcut_5_1, key_shortcut_5_2=@key_shortcut_5_2, key_shortcut_6_1=@key_shortcut_6_1, key_shortcut_6_2=@key_shortcut_6_2, key_shortcut_7_1=@key_shortcut_7_1, key_shortcut_7_2=@key_shortcut_7_2, key_shortcut_8_1=@key_shortcut_8_1, key_shortcut_8_2=@key_shortcut_8_2, key_shortcut_9_1=@key_shortcut_9_1, key_shortcut_9_2=@key_shortcut_9_2, key_shortcut_10_1=@key_shortcut_10_1, key_shortcut_10_2=@key_shortcut_10_2, key_shortcut_11_1=@key_shortcut_11_1, key_shortcut_11_2=@key_shortcut_11_2, key_shortcut_12_1=@key_shortcut_12_1, key_shortcut_12_2=@key_shortcut_12_2 WHERE name=@name";

    public PlayerOptionsUpdate(GameClient client, ReceivablePacket packet)
    {
        try
        {
            MySqlConnection con = DatabaseManager.GetConnection();
            MySqlCommand cmd = new MySqlCommand(UPDATE_CHARACTER_OPTIONS_QUERY, con);
            cmd.Parameters.AddWithValue("chat_color_normal", packet.ReadInt());
            cmd.Parameters.AddWithValue("chat_color_message", packet.ReadInt());
            cmd.Parameters.AddWithValue("chat_color_system", packet.ReadInt());
            cmd.Parameters.AddWithValue("chat_use_timestamps", packet.ReadByte());
            cmd.Parameters.AddWithValue("key_up_1", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_up_2", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_down_1", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_down_2", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_left_1", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_left_2", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_right_1", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_right_2", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_jump_1", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_jump_2", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_character_1", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_character_2", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_inventory_1", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_inventory_2", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_skills_1", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_skills_2", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_shortcut_1_1", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_shortcut_1_2", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_shortcut_2_1", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_shortcut_2_2", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_shortcut_3_1", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_shortcut_3_2", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_shortcut_4_1", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_shortcut_4_2", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_shortcut_5_1", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_shortcut_5_2", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_shortcut_6_1", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_shortcut_6_2", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_shortcut_7_1", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_shortcut_7_2", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_shortcut_8_1", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_shortcut_8_2", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_shortcut_9_1", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_shortcut_9_2", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_shortcut_10_1", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_shortcut_10_2", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_shortcut_11_1", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_shortcut_11_2", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_shortcut_12_1", packet.ReadShort());
            cmd.Parameters.AddWithValue("key_shortcut_12_2", packet.ReadShort());
            cmd.Parameters.AddWithValue("name", client.GetActiveChar().GetName());
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception e)
        {
            LogManager.Log(e.ToString());
        }
    }
}
