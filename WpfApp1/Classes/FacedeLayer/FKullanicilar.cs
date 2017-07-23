using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            SQLiteCommand com = new SQLiteCommand("INSERT INTO kullanicilar(kullanici_adi) VALUES(@kullanici_adi)", DatabaseManager.Baglanti);
            com.Parameters.AddWithValue("kullanici_adi", item.kullanici_adi);
            return com.ExecuteNonQuery();
        }

        public static int Update(Kullanicilar item)
        {
            SQLiteCommand com = new SQLiteCommand("UPDATE testler SET kullanici_adi=@kullanici_adi WHERE kullanici_id=@kullanici_id ", DatabaseManager.Baglanti);
            com.Parameters.AddWithValue("kullanici_id", item.kullanici_id);
            com.Parameters.AddWithValue("kullanici_adi", item.kullanici_adi);
            return com.ExecuteNonQuery();
        }

        public static Kullanicilar Select(int _kullanici_id)
        {
            Kullanicilar item = null;
            SQLiteCommand com = new SQLiteCommand("SELECT * FROM kullanicilar WHERE kullanici_id=@kullanici_id ", DatabaseManager.Baglanti);
            com.Parameters.AddWithValue("kullanici_id", _kullanici_id);
            SQLiteDataReader rdr = com.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    item = new Kullanicilar
                    {
                        kullanici_id = (int)rdr["kullanici_id"],
                        kullanici_adi = (string)rdr["kullanici_adi"]
                    };
                }
            }
            return item;
        }

        public static List<Kullanicilar> SelectAll(int _kullanici_id)
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
                        kullanici_id = (int)rdr["kullanici_id"],
                        kullanici_adi = (string)rdr["kullanici_adi"]
                    };
                    itemList.Add(item);
                }
            }
            return itemList;
        }
    }
}
