using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

/**
 * Author: Pantelis Andrianakis
 * Date: May 5th 2019
 */
public class SkillData
{
    private static readonly string RESTORE_SKILLS = "SELECT * FROM skills";
    private static readonly Dictionary<long, SkillHolder> SKILLS = new Dictionary<long, SkillHolder>();

    public static void Load()
    {
        Util.PrintSection("Skills");

        SKILLS.Clear();
        try
        {
            MySqlConnection con = DatabaseManager.GetConnection();
            MySqlCommand cmd = new MySqlCommand(RESTORE_SKILLS, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int skillId = reader.GetInt32("skill_id");
                int skillLevel = reader.GetInt32("level");
                SKILLS.Add(GetSkillHashCode(skillId, skillLevel), new SkillHolder(skillId, skillLevel, (SkillType)Enum.Parse(typeof(SkillType), reader.GetString("type")), reader.GetInt32("reuse"), reader.GetInt32("range"), reader.GetInt32("param_1"), reader.GetInt32("param_2")));
            }
            con.Close();
        }
        catch (Exception e)
        {
            LogManager.Log(e.ToString());
        }

        LogManager.Log("SkillData: Loaded " + SKILLS.Count + " skills.");
    }

    private static long GetSkillHashCode(int skillId, int skillLevel)
    {
        return (skillId * 100000) + skillLevel;
    }

    public static SkillHolder GetSkillHolder(int skillId, int skillLevel)
    {
        if (!SKILLS.ContainsKey(skillId))
        {
            return null;
        }
        return SKILLS[GetSkillHashCode(skillId, skillLevel)];
    }
}
