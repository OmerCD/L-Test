using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Classes.EntityLayer;

namespace WpfApp1.Classes.FacedeLayer
{
    class FCevaplar
    {

        public static int Insert(Cevaplar item)
        {
            DatabaseManager.BaglantiAc();
            SQLiteCommand com = new SQLiteCommand("INSERT INTO cevaplar(SoruId, Cevap, Dogru) VALUES(@SoruId, @Cevap,@Dogru)", DatabaseManager.Baglanti);//
            com.Parameters.AddWithValue("@SoruId", item.SoruId);
            com.Parameters.AddWithValue("@Cevap", item.Cevap);
            com.Parameters.AddWithValue("@Dogru", item.Dogru);
            return (int)com.ExecuteScalar();
        }

        public static int Update(Cevaplar item)
        {
            SQLiteCommand com = new SQLiteCommand("UPDATE cevaplar SET Cevap=@Cevap, Dogru=@Dogru WHERE CevapId=@CevapId ", DatabaseManager.Baglanti);
            com.Parameters.AddWithValue("@SoruId", item.SoruId);
            com.Parameters.AddWithValue("@Cevap", item.Cevap);
            com.Parameters.AddWithValue("@Dogru", item.Dogru);
            return com.ExecuteNonQuery();
        }

        public static int Delete(int cevapId)
        {
            SQLiteCommand com = new SQLiteCommand("DELETE FROM cevaaplar WHERE CevapId=@CevapId");
            com.Parameters.AddWithValue("CevapId", cevapId);
            return com.ExecuteNonQuery();
        }

        public static List<Cevaplar> SelectAll(int soruId)
        {
            DatabaseManager.BaglantiAc();
            List<Cevaplar> itemList = null;
            var com = new SQLiteCommand("SELECT * FROM cevaplar WHERE SoruId=@SoruId", DatabaseManager.Baglanti);
            com.Parameters.AddWithValue("@SoruId", soruId);
            var rdr = com.ExecuteReader();
            if (rdr.HasRows)
            {
                itemList = new List<Cevaplar>();
                while (rdr.Read())
                {
                    var item = new Cevaplar
                    {
                        CevapId = Convert.ToInt16(rdr["CevapId"]),
                        SoruId = Convert.ToInt16(rdr["SoruId"]),
                        Cevap = rdr["Cevap"].ToString(),
                        Dogru = Convert.ToInt16(rdr["Dogru"])
                    };
                    itemList.Add(item);
                }
            }
            return itemList;
        }
    }
}
