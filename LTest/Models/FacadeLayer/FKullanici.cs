using System.Collections.Generic;
using System.Data.SQLite;
using LTest.Models.EntityLayer;

namespace LTest.Models.FacadeLayer
{
    class FKullanici
    {
        public FKullanici()
        {
            DatabaseManager.BaglantiAc();
        }

        public static int Insert(Kullanici item)
        {
            SQLiteCommand com = new SQLiteCommand("INSERT INTO Kullanicilar(KullaniciAdi,Puan,TestId) VALUES(@KullaniciAdi,@Puan, @TestId)", DatabaseManager.Baglanti);
            com.Parameters.AddWithValue("KullaniciAdi", item.KullaniciAdi);
            com.Parameters.AddWithValue("KullaniciAdi", item.Puan);
            com.Parameters.AddWithValue("KullaniciAdi", item.TestId);
            return com.ExecuteNonQuery();
        }

        public static int Delete(int kullaniciId)
        {
            SQLiteCommand com = new SQLiteCommand("DELETE FROM Kullanicilar WHERE KullaniciId=@KullaniciId");
            com.Parameters.AddWithValue("KullaniciId", kullaniciId);
            return com.ExecuteNonQuery();
        }

        //public static int Update(Kullanici item)
        //{
        //    SQLiteCommand com = new SQLiteCommand("UPDATE Testler SET KullaniciAdi=@KullaniciAdi WHERE KullaniciId=@KullaniciId ", DatabaseManager.Baglanti);
        //    com.Parameters.AddWithValue("KullaniciId", item.KullaniciId);
        //    com.Parameters.AddWithValue("KullaniciAdi", item.KullaniciAdi);
        //    return com.ExecuteNonQuery();
        //}

        public static Kullanici Select(int kullaniciId)
        {
            Kullanici item = null;
            SQLiteCommand com = new SQLiteCommand("SELECT * FROM Kullanicilar WHERE KullaniciId=@KullaniciId ", DatabaseManager.Baglanti);
            com.Parameters.AddWithValue("KullaniciId", kullaniciId);
            SQLiteDataReader rdr = com.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    item = new Kullanici
                    {
                        KullaniciId = (int)rdr["KullaniciId"],
                        KullaniciAdi = (string)rdr["KullaniciAdi"],
                        Puan = (int)rdr["Puan"],
                        TestId = (int)rdr["TestId"]

                    };
                }
            }
            return item;
        }

        public static List<Kullanici> SelectAll()
        {
            List<Kullanici> itemList = null;
            SQLiteCommand com = new SQLiteCommand("SELECT * FROM Kullanicilar", DatabaseManager.Baglanti);
            SQLiteDataReader rdr = com.ExecuteReader();
            if (rdr.HasRows)
            {
                itemList = new List<Kullanici>();
                while (rdr.Read())
                {
                    Kullanici item = new Kullanici
                    {
                        KullaniciId = (int)rdr["KullaniciId"],
                        KullaniciAdi = (string)rdr["KullaniciAdi"],
                        Puan = (int)rdr["Puan"],
                        TestId = (int)rdr["TestId"]
                    };
                    itemList.Add(item);
                }
            }
            return itemList;
        }
    }
}
