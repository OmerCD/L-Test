using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows;

namespace LTest.Models
{
    class DatabaseManager
    {
        private static readonly string Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\L-Test\";
        //public static SQLiteConnection Baglanti = new SQLiteConnection("Data Source= C:\\Users\\Hasan\\Documents\\GitHub\\L-Test\\database.db");
        public static SQLiteConnection Baglanti = new SQLiteConnection("Data Source= "+Path+"database.db");

        public static void BaglantiAc()
        {
            if (Baglanti.State==ConnectionState.Closed)
            {
                try
                {
                    Baglanti.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata Kodu: 0x04 " + ex.Message);
                }
            }
        }
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
            tableQueries[0, 0] = "Testler";
            tableQueries[0, 1] = "CREATE TABLE `Testler` (" +
                "`TestId`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                "`Sure`	INTEGER," +
                "`SoruSayisi`	INTEGER," +
                "`CevapSayisi`	INTEGER," +
                "`TestAdi`	TEXT," +
                "FOREIGN KEY(`TestId`) REFERENCES `Testler`(`TestId`)" +
                " ); ";
            tableQueries[1, 0] = "Sorular";
            tableQueries[1, 1] = "CREATE TABLE `Sorular` (" +
                "`SoruId`	INTEGER PRIMARY KEY AUTOINCREMENT," +
                "`TestId`	INTEGER," +
                "`Soru`	TEXT NOT NULL," +
                "FOREIGN KEY(`TestId`) REFERENCES `Testler`(`TestId`)" +
                "); ";

            tableQueries[2, 0] = "Cevaplar";
            tableQueries[2, 1] = "CREATE TABLE `Cevaplar` (" +
                "`CevapId`	INTEGER PRIMARY KEY AUTOINCREMENT," +
                "`SoruId`	INTEGER," +
                "`TestId`	INTEGER," +
                "`Cevap`	TEXT," +
                "`Dogru`	INTEGER," +
                "FOREIGN KEY(`SoruId`) REFERENCES `Sorular`(`SoruId`)" +
                "FOREIGN KEY(`TestId`) REFERENCES `Sorular`(`SoruId`)" +
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
