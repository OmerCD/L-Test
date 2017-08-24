using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Classes.EntityLayer;

namespace WpfApp1.Classes.FacedeLayer
{
    class FSorular
    {
        public static int Insert(Sorular item)
        {
            DatabaseManager.BaglantiAc();
            SQLiteCommand com = new SQLiteCommand("INSERT INTO sorular(TestId, Soru) VALUES(@TestId, @Soru); Select last_insert_rowid()", DatabaseManager.Baglanti);//
            com.Parameters.AddWithValue("@TestId", item.TestId);
            com.Parameters.AddWithValue("@Soru", item.Soru);
            return Convert.ToInt16(com.ExecuteScalar());
        }

        public static int Update(Sorular item)
        {
            SQLiteCommand com = new SQLiteCommand("UPDATE sorular SET Soru=@Soru WHERE SoruId=@SoruId ", DatabaseManager.Baglanti);
            com.Parameters.AddWithValue("SoruId", item.SoruId);
            com.Parameters.AddWithValue("Soru", item.Soru);
            return com.ExecuteNonQuery();
        }

        public static int Delete(int soruId)
        {
            SQLiteCommand com = new SQLiteCommand("DELETE FROM sorular WHERE SoruId=@SoruId");
            com.Parameters.AddWithValue("SoruId", soruId);
            return com.ExecuteNonQuery();
        }

        public static List<Sorular> SelectAll(int testId)
        {
            DatabaseManager.BaglantiAc();
            List<Sorular> itemList = null;
            SQLiteCommand com = new SQLiteCommand("SELECT * FROM sorular WHERE TestId=@TestId", DatabaseManager.Baglanti);
            com.Parameters.AddWithValue("@TestId", testId);
            SQLiteDataReader rdr = com.ExecuteReader();
            if (rdr.HasRows)
            {
                itemList = new List<Sorular>();
                while (rdr.Read())
                {
                    var item = new Sorular
                    {
                        TestId = Convert.ToInt16(rdr["TestId"]),
                        SoruId = Convert.ToInt16(rdr["SoruId"]),
                        Soru = rdr["Soru"].ToString()
                    };
                    itemList.Add(item);
                }
            }
            return itemList;
        }
    }
}
