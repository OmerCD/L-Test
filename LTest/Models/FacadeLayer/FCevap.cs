using Entity;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace LTest.Models.FacadeLayer
{
    class FCevap
    {

        public static int Insert(Cevap item)
        {
            DatabaseManager.BaglantiAc();
            SQLiteCommand com = new SQLiteCommand("INSERT INTO Cevaplar(SoruId, TestId, Cevap, Dogru) VALUES(@SoruId,@TestId,@Cevap,@Dogru)", DatabaseManager.Baglanti);//
            com.Parameters.AddWithValue("@SoruId", item.SoruId);
            com.Parameters.AddWithValue("@TestId", item.TestId);
            com.Parameters.AddWithValue("@Cevap", item.CevapText);
            com.Parameters.AddWithValue("@Dogru", item.Dogru);
            return com.ExecuteNonQuery();
        }

        public static int Update(Cevap item)
        {
            SQLiteCommand com = new SQLiteCommand("UPDATE Cevaplar SET Cevap=@Cevap,Dogru=@Dogru WHERE CevapId=@CevapId ", DatabaseManager.Baglanti);
            com.Parameters.AddWithValue("@CevapId", item.CevapId);
            com.Parameters.AddWithValue("@Cevap", item.CevapText);
            com.Parameters.AddWithValue("@Dogru", item.Dogru);
            return com.ExecuteNonQuery();
        }

        public static int DeleteAll(int testId)
        {
            SQLiteCommand com = new SQLiteCommand("DELETE FROM Cevaplar WHERE TestId=@TestId", DatabaseManager.Baglanti);
            com.Parameters.AddWithValue("TestId", testId);
            return com.ExecuteNonQuery();
        }

        public static List<Cevap> SelectBySoruId(int soruId)
        {
            DatabaseManager.BaglantiAc();
            List<Cevap> itemList = null;
            var com = new SQLiteCommand("SELECT * FROM Cevaplar WHERE SoruId=@SoruId", DatabaseManager.Baglanti);
            com.Parameters.AddWithValue("@SoruId", soruId);
            using (var rdr = com.ExecuteReader())
            {
                if (rdr.HasRows)
                {
                    itemList = new List<Cevap>();
                    while (rdr.Read())
                    {
                        Cevap item = new Cevap
                        {
                            CevapId = Convert.ToInt16(rdr["CevapId"]),
                            SoruId = Convert.ToInt16(rdr["SoruId"]),
                            TestId = Convert.ToInt16(rdr["TestId"]),
                            CevapText = rdr["Cevap"].ToString(),
                            Dogru = Convert.ToInt16(rdr["Dogru"])
                        };
                        itemList.Add(item);
                    }
                }
            }
            return itemList;
        }

        public static List<Cevap> SelectByTestId(int testId)
        {
            DatabaseManager.BaglantiAc();
            List<Cevap> itemList = null;
            var com = new SQLiteCommand("SELECT * FROM Cevaplar WHERE TestId=@TestId", DatabaseManager.Baglanti);
            com.Parameters.AddWithValue("@TestId", testId);
            using (var rdr = com.ExecuteReader())
            {
                if (rdr.HasRows)
                {
                    itemList = new List<Cevap>();
                    while (rdr.Read())
                    {
                        Cevap item = new Cevap
                        {
                            CevapId = Convert.ToInt16(rdr["CevapId"]),
                            SoruId = Convert.ToInt16(rdr["SoruId"]),
                            TestId = Convert.ToInt16(rdr["TestId"]),
                            CevapText = rdr["Cevap"].ToString(),
                            Dogru = Convert.ToInt16(rdr["Dogru"])
                        };
                        itemList.Add(item);
                    }
                }
            }
            return itemList;
        }
    }
}
