using MySql.Data.MySqlClient;
using System;
using System.Data;

/**
 * Author: Pantelis Andrianakis
 * Date: November 10th 2018
 */
public class DatabaseManager
{
    private static readonly MySqlConnection[] CONNECTIONS = new MySqlConnection[Config.DATABASE_MAX_CONNECTIONS];
    private static int CONNECTION_COUNTER = 0;

    public static void Init()
    {
        Util.PrintSection("Database");

        try
        {
            for (int i = 0; i < Config.DATABASE_MAX_CONNECTIONS; i++)
            {
                CONNECTIONS[i] = new MySqlConnection(Config.DATABASE_CONNECTION_PARAMETERS);
                CONNECTIONS[i].Open();
            }
            for (int i = 0; i < Config.DATABASE_MAX_CONNECTIONS; i++)
            {
                CONNECTIONS[i].Close();
            }
        }
        catch (Exception e)
        {
            LogManager.Log(e.ToString());
        }

        LogManager.Log("Database: Initialized.");
    }

    public static MySqlConnection GetConnection()
    {
        MySqlConnection connection = null;
        lock (CONNECTIONS)
        {
            while (connection == null)
            {
                if (CONNECTION_COUNTER >= Config.DATABASE_MAX_CONNECTIONS)
                {
                    CONNECTION_COUNTER = 0;
                }
                if (CONNECTIONS[CONNECTION_COUNTER].State == ConnectionState.Closed)
                {
                    connection = CONNECTIONS[CONNECTION_COUNTER];
                    connection.Open();
                }
                CONNECTION_COUNTER++;
            }
        }
        return connection;
    }
}
