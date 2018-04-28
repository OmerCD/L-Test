using System;
using System.Collections.Generic;
using System.Data.SQLite;
using LTest.Models.EntityLayer;

namespace LTest.Models.FacadeLayer
{
    class FTest
    {
        public static int Insert(Test item)
        {
            DatabaseManager.BaglantiAc();
            SQLiteCommand com = new SQLiteCommand("INSERT INTO Testler(Sure, SoruSayisi, CevapSayisi, TestAdi) VALUES(@Sure, @SoruSayisi, @CevapSayisi, @TestAdi); Select last_insert_rowid()", DatabaseManager.Baglanti);//; Select last_insert_rowid()
            com.Parameters.AddWithValue("@Sure",item.Sure);
            com.Parameters.AddWithValue("@SoruSayisi", item.SoruSayisi);
            com.Parameters.AddWithValue("@CevapSayisi", item.CevapSayisi);
            com.Parameters.AddWithValue("@TestAdi", item.TestAdi);
            return Convert.ToInt16(com.ExecuteScalar());
        }

        public static int Update(Test item)
        {
            SQLiteCommand com = new SQLiteCommand("UPDATE Testler SET Sure=@Sure,SoruSayisi=@SoruSayisi,CevapSayisi=@CevapSayisi WHERE TestId=@TestId ", DatabaseManager.Baglanti);
            com.Parameters.AddWithValue("TestId", item.TestId);
            com.Parameters.AddWithValue("Sure", item.Sure);
            com.Parameters.AddWithValue("SoruSayisi", item.SoruSayisi);
            com.Parameters.AddWithValue("CevapSayisi", item.CevapSayisi);
            com.Parameters.AddWithValue("TestAdi", item.TestAdi);
            return com.ExecuteNonQuery();
        }

        public static int Delete(int testId)
        {
            SQLiteCommand com = new SQLiteCommand("DELETE FROM Testler WHERE TestId=@TestId");
            com.Parameters.AddWithValue("TestId", testId);
            return com.ExecuteNonQuery();
        }

        public static Test Select(string testAdi)
        {
            Test item = null;
            SQLiteCommand com = new SQLiteCommand("SELECT * FROM Testler WHERE TestAdi=@TestAdi ", DatabaseManager.Baglanti);
            com.Parameters.AddWithValue("@TestAdi", testAdi);
            SQLiteDataReader rdr=com.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    item = new Test
                    {
                        TestId = Convert.ToInt16(rdr["TestId"]),
                        Sure = Convert.ToInt16(rdr["Sure"]),
                        SoruSayisi = Convert.ToInt16(rdr["SoruSayisi"]),
                        CevapSayisi = Convert.ToInt16(rdr["CevapSayisi"]),
                        TestAdi = rdr["TestAdi"].ToString()
                    };
                }
            }
            return item;
        }

        public static List<Test> SelectAll()
        {
            DatabaseManager.BaglantiAc();
            List<Test> itemList = null;
            SQLiteCommand com = new SQLiteCommand("SELECT * FROM Testler", DatabaseManager.Baglanti);
            SQLiteDataReader rdr = com.ExecuteReader();
            if (rdr.HasRows)
            {
                itemList=new List<Test>();
                while (rdr.Read())
                {
                    Test item = new Test
                    {
                        TestId = Convert.ToInt16(rdr["TestId"]),
                        Sure = Convert.ToInt16(rdr["Sure"]),
                        SoruSayisi = Convert.ToInt16(rdr["SoruSayisi"]),
                        CevapSayisi = Convert.ToInt16(rdr["CevapSayisi"]),
                        TestAdi = rdr["TestAdi"].ToString()
                    };
                    itemList.Add(item);
                }
            }
            return itemList;
        }
    }
}
