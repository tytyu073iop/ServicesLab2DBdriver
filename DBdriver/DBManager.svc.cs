using DBdriver;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace DBdriver
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class DBManager : IDBDriverToRoster
    {
        public SqliteConnection connection;

        public List<Roster> GetAllRosters()
        {
            var command = connection.CreateCommand();
            command.CommandText = "SELECT playerid, jersey, fname, sname, position, birthday, weight, height, birthcity, birthstate FROM roster; ";

            var reader = command.ExecuteReader();

            return ReaderToRosters(reader);
        }

        public void AddRoster(Roster roster)
        {

            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO roster (playerid, jersey, fname, sname, position, birthday, Weight, Height, Birthcity, Birthstate) VALUES (@Playerid, @Jersey, @Fname, @Sname, @Postition, @Birthday, @Weight, @Height, @Birthcity, @Birthstate)";

            command.Parameters.AddWithValue("@Playerid", roster.Playerid);
            command.Parameters.AddWithValue("@Jersey", roster.Jersey);
            command.Parameters.AddWithValue("@Fname", roster.Fname);
            command.Parameters.AddWithValue("@Sname", roster.Sname);
            command.Parameters.AddWithValue("@Postition", roster.Position);
            command.Parameters.AddWithValue("@Birthday", roster.Birthday);
            command.Parameters.AddWithValue("@Weight", roster.Weight);
            command.Parameters.AddWithValue("@Height", roster.Height);
            command.Parameters.AddWithValue("@Birthcity", roster.Birthcity);
            command.Parameters.AddWithValue("@Birthstate", roster.Birthstate);

            command.ExecuteNonQuery();


        }

        public DBManager()
        {

#if DEBUG
            string dataSource = ":memory:";
#else
        string dataSource = PathHelper.GetFilesDirectory("db2.sqlite3");
#endif
            connection = new SqliteConnection($"Data Source={dataSource};Mode=ReadWrite");

            connection.Open();

#if DEBUG
            DBPreparation.PrepareInMemoryDb(this);
#endif
        }

        ~DBManager()
        {
            connection.Close();
        }

        private static List<Roster> ReaderToRosters(SqliteDataReader sdr)
        {
            var arr = new List<Roster>();
            while (sdr.Read())
            {
                arr.Add(new Roster
                {
                    Playerid = sdr[0].ToString(),
                    Jersey = Convert.ToInt32(sdr[1]),
                    Fname = sdr[2].ToString(),
                    Sname = sdr[3].ToString(),
                    Position = sdr[4].ToString(),
                    Birthday = sdr[5].ToString(),
                    Weight = Convert.ToInt32(sdr[6]),
                    Height = Convert.ToInt32(sdr[7]),
                    Birthcity = sdr[8].ToString(),
                    Birthstate = sdr[9].ToString()
                });
            }
            return arr;
        }
    }
}