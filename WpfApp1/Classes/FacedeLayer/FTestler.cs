using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Classes.FacedeLayer
{
    class FTestler
    {
        public FTestler()
        {
            DatabaseManager.BaglantiAc();
        }

        public static int Insert(Testler item)
        {
            SQLiteCommand com =new SQLiteCommand("INSERT INTO testler(sure,soru_sayisi,cevap_sayisi,test_adi) VALUES(@sure,@soru_sayisi,@cevap_sayisi, @test_adi)", DatabaseManager.Baglanti);
            com.Parameters.AddWithValue("sure",item.sure);
            com.Parameters.AddWithValue("soru_sayisi", item.soru_sayisi);
            com.Parameters.AddWithValue("cevap_sayisi", item.cevap_sayisi);
            com.Parameters.AddWithValue("test_adi", item.test_adi);
            return com.ExecuteNonQuery();
        }

        public static int Update(Testler item)
        {
            SQLiteCommand com = new SQLiteCommand("UPDATE testler SET sure=@sure,soru_sayisi=@soru_sayisi,cevap_sayisi=@cevap_sayisi WHERE test_id=@test_id ", DatabaseManager.Baglanti);
            com.Parameters.AddWithValue("test_id", item.test_id);
            com.Parameters.AddWithValue("sure", item.sure);
            com.Parameters.AddWithValue("soru_sayisi", item.soru_sayisi);
            com.Parameters.AddWithValue("cevap_sayisi", item.cevap_sayisi);
            com.Parameters.AddWithValue("test_adi", item.test_adi);
            return com.ExecuteNonQuery();
        }

        public static Testler Select(int _test_id)
        {
            Testler item = null;
            SQLiteCommand com = new SQLiteCommand("SELECT * FROM testler WHERE test_id=@test_id ", DatabaseManager.Baglanti);
            com.Parameters.AddWithValue("test_id", _test_id);
            SQLiteDataReader rdr=com.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    item = new Testler
                    {
                        test_id = (int) rdr["test_id"],
                        sure = (int) rdr["sure"],
                        soru_sayisi = (int) rdr["soru_sayisi"],
                        cevap_sayisi = (int) rdr["cevap_sayisi"],
                        test_adi = (string) rdr["test_adi"]
                    };
                }
            }
            return item;
        }

        public static List<Testler> SelectAll(int _test_id)
        {
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
                        test_id = (int) rdr["test_id"],
                        sure = (int) rdr["sure"],
                        soru_sayisi = (int) rdr["soru_sayisi"],
                        cevap_sayisi = (int) rdr["cevap_sayisi"],
                        test_adi = (string) rdr["test_adi"]
                    };
                    itemList.Add(item);
                }
            }
            return itemList;
        }
    }
}
