using System.Collections.Generic;
using System.Data.SQLite;
using WpfApp1.Classes.EntityLayer;

namespace WpfApp1.Classes.FacedeLayer
{
    class FKullanicilar
    {
        public FKullanicilar()
        {
            DatabaseManager.BaglantiAc();
        }

        public static int Insert(Kullanicilar item)
        {
            SQLiteCommand com = new SQLiteCommand("INSERT INTO kullanicilar(KullaniciAdi) VALUES(@KullaniciAdi)", DatabaseManager.Baglanti);
            com.Parameters.AddWithValue("KullaniciAdi", item.KullaniciAdi);
            return com.ExecuteNonQuery();
        }

        public static int Delete(int kullaniciId)
        {
            SQLiteCommand com = new SQLiteCommand("DELETE FROM kullanicilar WHERE KullaniciId=@KullaniciId");
            com.Parameters.AddWithValue("KullaniciId", kullaniciId);
            return com.ExecuteNonQuery();
        }

        public static int Update(Kullanicilar item)
        {
            SQLiteCommand com = new SQLiteCommand("UPDATE testler SET KullaniciAdi=@KullaniciAdi WHERE KullaniciId=@KullaniciId ", DatabaseManager.Baglanti);
            com.Parameters.AddWithValue("KullaniciId", item.KullaniciId);
            com.Parameters.AddWithValue("KullaniciAdi", item.KullaniciAdi);
            return com.ExecuteNonQuery();
        }

        public static Kullanicilar Select(int kullaniciId)
        {
            Kullanicilar item = null;
            SQLiteCommand com = new SQLiteCommand("SELECT * FROM kullanicilar WHERE KullaniciId=@KullaniciId ", DatabaseManager.Baglanti);
            com.Parameters.AddWithValue("KullaniciId", kullaniciId);
            SQLiteDataReader rdr = com.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    item = new Kullanicilar
                    {
                        KullaniciId = (int)rdr["KullaniciId"],
                        KullaniciAdi = (string)rdr["KullaniciAdi"]
                    };
                }
            }
            return item;
        }

        public static List<Kullanicilar> SelectAll()
        {
            List<Kullanicilar> itemList = null;
            SQLiteCommand com = new SQLiteCommand("SELECT * FROM kullanicilar", DatabaseManager.Baglanti);
            SQLiteDataReader rdr = com.ExecuteReader();
            if (rdr.HasRows)
            {
                itemList = new List<Kullanicilar>();
                while (rdr.Read())
                {
                    Kullanicilar item = new Kullanicilar
                    {
                        KullaniciId = (int)rdr["KullaniciId"],
                        KullaniciAdi = (string)rdr["KullaniciAdi"]
                    };
                    itemList.Add(item);
                }
            }
            return itemList;
        }
    }
}
