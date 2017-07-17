using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Data;
using System.Data.SQLite;

namespace WpfApp1.Classes
{
    class SoruKayit
    {
        public string Soru { get; set; }
        public List<CevapSistemi> Cevaplar { get; set; }
        public SoruKayit()
        {
            Cevaplar = new List<CevapSistemi>();
        }

    }
    struct CevapSistemi
    {
        public CevapSistemi(string cevap, bool dogru)
        {
            Cevap = cevap;
            Dogru = dogru;
        }
        public string Cevap { get; set; }
        public bool Dogru { get; set; }
    }
    public class SoruSistemi
    {
        public SoruSistemi(int testid)
        {
            _testId = testid;
            _soruKayıtlar = new List<SoruKayit>();
        }
        int _testId;
        List<SoruKayit> _soruKayıtlar;
        public void SoruEkle(String soru, params CheckBox[] cevaplar)
        {
            SoruKayit sorukayit = new SoruKayit
            {
                Soru = soru
            };
            foreach (var item in cevaplar)
            {
                sorukayit.Cevaplar.Add(new CevapSistemi(((TextBox)item.Content).Text, (bool)item.IsChecked));
            }
            _soruKayıtlar.Add(sorukayit);

        }
        public void SorulariKaydet()
        {
            foreach (var item in _soruKayıtlar)
            {
                int soruId;
                using (SQLiteCommand komut = new SQLiteCommand("Insert Into sorular(test_id,soru) VALUES(@tId,@soru); Select last_insert_rowid()",UserControllers.UcTestler.baglanti))
                {
                    komut.Parameters.AddWithValue("@tId", _testId);
                    komut.Parameters.AddWithValue("@soru", item.Soru);
                    soruId = Convert.ToInt16(komut.ExecuteScalar());
                }
                foreach (var cevap in item.Cevaplar)
                {
                    using (var cevapKomut= new SQLiteCommand("Insert Into cevaplar(soru_id,cevap,dogru) VALUES (@sId,@c,@d)",UserControllers.UcTestler.baglanti))
                    {
                        cevapKomut.Parameters.AddWithValue("@sId", soruId);
                        cevapKomut.Parameters.AddWithValue("@c", cevap.Cevap);
                        cevapKomut.Parameters.AddWithValue("@d", cevap.Dogru);
                        cevapKomut.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
