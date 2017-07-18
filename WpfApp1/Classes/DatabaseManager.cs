using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace WpfApp1.Classes
{
    class DatabaseManager
    {
        private static readonly string Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\L-Test\";
        public static SQLiteConnection Baglanti = new SQLiteConnection("Data Source=" + Path + "database.db");

        public static void CreateDatabase()
        {
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
            AssignTableQueries(out var tableQueries);
            CheckTables(tableQueries);
        }

        private static void AssignTableQueries(out string[,] tableQueries)
        {
            tableQueries= new string[3,2];
            tableQueries[0, 0] = "testler";
            tableQueries[0, 1] = "CREATE TABLE `testler` (" +
                "`test_id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                "`sure`	INTEGER," +
                "`soru_sayisi`	INTEGER," +
                "`cevap_sayisi`	INTEGER," +
                "`test_adi`	TEXT," +
                "FOREIGN KEY(`test_id`) REFERENCES `testler`(`test_id`)" +
                " ); ";
            tableQueries[1, 0] = "sorular";
            tableQueries[1, 1] = "CREATE TABLE `sorular` (" +
                "`soru_id`	INTEGER PRIMARY KEY AUTOINCREMENT," +
                "`test_id`	INTEGER," +
                "`soru`	TEXT NOT NULL," +
                "FOREIGN KEY(`test_id`) REFERENCES `testler`(`test_id`)" +
                "); ";

            tableQueries[2, 0] = "cevaplar";
            tableQueries[2, 1] = "CREATE TABLE `cevaplar` (" +
                "`cevap_id`	INTEGER PRIMARY KEY AUTOINCREMENT," +
                "`soru_id`	INTEGER," +
                "`cevap`	TEXT," +
                "`dogru`	INTEGER," +
                "FOREIGN KEY(`soru_id`) REFERENCES `sorular`(`soru_id`)" +
                "); ";
        }

        private static void CheckTables(string[,] tableQueries)
        {
            if (Baglanti.State == ConnectionState.Closed)
                Baglanti.Open();
            for (var i = 0; i < tableQueries.GetLength(0); i++)
            {
                var tableName = tableQueries[i, 0];
                var query = tableQueries[i, 1];
                using (var cmd = new SQLiteCommand($"Select count(*) From sqlite_master Where type = 'table' AND name = '{tableName}' ", Baglanti))
                {
                    if (Convert.ToBoolean(cmd.ExecuteScalar())) continue;
                    using (var tableCreateCommand = new SQLiteCommand(query, Baglanti))
                    {
                        tableCreateCommand.ExecuteNonQuery();
                    }
                }
            }
            if (Baglanti.State == ConnectionState.Open)
                Baglanti.Close();
        }
    }
}
