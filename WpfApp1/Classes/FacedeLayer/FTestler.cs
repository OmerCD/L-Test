using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Dynamic;
using System.Windows;
using WpfApp1.Classes.EntityLayer;

namespace WpfApp1.Classes.FacedeLayer
{
    class FTestler
    {
        public static int Insert(Testler item)
        {
            DatabaseManager.BaglantiAc();
            SQLiteCommand com = new SQLiteCommand("INSERT INTO testler(Sure, SoruSayisi, CevapSayisi, TestAdi) VALUES(@Sure, @SoruSayisi, @CevapSayisi, @TestAdi); Select last_insert_rowid()", DatabaseManager.Baglanti);//; Select last_insert_rowid()
            com.Parameters.AddWithValue("@Sure",item.Sure);
            com.Parameters.AddWithValue("@SoruSayisi", item.SoruSayisi);
            com.Parameters.AddWithValue("@CevapSayisi", item.CevapSayisi);
            com.Parameters.AddWithValue("@TestAdi", item.TestAdi);
            return Convert.ToInt16(com.ExecuteScalar());
        }

        public static int Update(Testler item)
        {
            SQLiteCommand com = new SQLiteCommand("UPDATE testler SET Sure=@Sure,SoruSayisi=@SoruSayisi,CevapSayisi=@CevapSayisi WHERE TestId=@TestId ", DatabaseManager.Baglanti);
            com.Parameters.AddWithValue("TestId", item.TestId);
            com.Parameters.AddWithValue("Sure", item.Sure);
            com.Parameters.AddWithValue("SoruSayisi", item.SoruSayisi);
            com.Parameters.AddWithValue("CevapSayisi", item.CevapSayisi);
            com.Parameters.AddWithValue("TestAdi", item.TestAdi);
            return com.ExecuteNonQuery();
        }

        public static int Delete(int testId)
        {
            SQLiteCommand com = new SQLiteCommand("DELETE FROM testler WHERE TestId=@TestId");
            com.Parameters.AddWithValue("TestId", testId);
            return com.ExecuteNonQuery();
        }

        public static Testler Select(string testAdi)
        {
            Testler item = null;
            SQLiteCommand com = new SQLiteCommand("SELECT * FROM testler WHERE TestAdi=@TestAdi ", DatabaseManager.Baglanti);
            com.Parameters.AddWithValue("@TestAdi", testAdi);
            SQLiteDataReader rdr=com.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    item = new Testler
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

        public static List<Testler> SelectAll()
        {
            DatabaseManager.BaglantiAc();
            List<Testler> itemList = null;
            SQLiteCommand com = new SQLiteCommand("SELECT * FROM testler", DatabaseManager.Baglanti);
            SQLiteDataReader rdr = com.ExecuteReader();
            if (rdr.HasRows)
            {
                itemList=new List<Testler>();
                while (rdr.Read())
                {
                    Testler item = new Testler
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

        internal static Testler Select(int testId)
        {
            throw new NotImplementedException();
        }
    }
}
