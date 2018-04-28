using System;
using System.Collections.Generic;
using System.Data.SQLite;
using LTest.Models.EntityLayer;

namespace LTest.Models.FacadeLayer
{
    class FSoru
    {
        public static int Insert(Soru item)
        {
            DatabaseManager.BaglantiAc();
            SQLiteCommand com = new SQLiteCommand("INSERT INTO Sorular(TestId, Soru) VALUES(@TestId, @Soru); Select last_insert_rowid()", DatabaseManager.Baglanti);//
            com.Parameters.AddWithValue("@TestId", item.TestId);
            com.Parameters.AddWithValue("@Soru", item.SoruText);
            return Convert.ToInt16(com.ExecuteScalar());
        }

        public static int Update(Soru item)
        {
            SQLiteCommand com = new SQLiteCommand("UPDATE Sorular SET Soru=@Soru WHERE SoruId=@SoruId ", DatabaseManager.Baglanti);
            com.Parameters.AddWithValue("SoruId", item.SoruId);
            com.Parameters.AddWithValue("Soru", item.SoruText);
            return com.ExecuteNonQuery();
        }

        public static int Delete(int soruId)
        {
            SQLiteCommand com = new SQLiteCommand("DELETE FROM Sorular WHERE SoruId=@SoruId");
            com.Parameters.AddWithValue("SoruId", soruId);
            return com.ExecuteNonQuery();
        }

        public static List<Soru> SelectAll(int testId)
        {
            DatabaseManager.BaglantiAc();
            List<Soru> itemList = null;
            SQLiteCommand com = new SQLiteCommand("SELECT * FROM Sorular WHERE TestId=@TestId", DatabaseManager.Baglanti);
            com.Parameters.AddWithValue("@TestId", testId);
            SQLiteDataReader rdr = com.ExecuteReader();
            if (rdr.HasRows)
            {
                itemList = new List<Soru>();
                while (rdr.Read())
                {
                    var item = new Soru
                    {
                        TestId = Convert.ToInt16(rdr["TestId"]),
                        SoruId = Convert.ToInt16(rdr["SoruId"]),
                        SoruText = rdr["Soru"].ToString()
                    };
                    itemList.Add(item);
                }
            }
            return itemList;
        }
    }
}
