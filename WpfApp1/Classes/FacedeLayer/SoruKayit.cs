using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Controls;

namespace WpfApp1.Classes
{
    internal class FSoruKayit
    {
        public string Soru { get; set; }
        public List<CevapSistemi> Cevaplar { get; set; }
        public FSoruKayit()
        {
            Cevaplar = new List<CevapSistemi>();
        }
    }
    internal struct CevapSistemi
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
            _soruKayıtlar = new List<FSoruKayit>();
        }

        private readonly int _testId;
        private readonly List<FSoruKayit> _soruKayıtlar;
        public void SoruEkle(string soru, params CheckBox[] cevaplar)
        {
            var sorukayit = new FSoruKayit
            {
                Soru = soru
            };
            foreach (var item in cevaplar)
            {
                sorukayit.Cevaplar.Add(new CevapSistemi(((TextBox)item.Content).Text, item.IsChecked != null && (bool)item.IsChecked));
            }
            _soruKayıtlar.Add(sorukayit);

        }
        public void SorulariKaydet()
        {
            foreach (var item in _soruKayıtlar)
            {
                int soruId;
                using (var komut = new SQLiteCommand("Insert Into sorular(TestId,Soru) VALUES(@TestId,@Soru); Select last_insert_rowid()", DatabaseManager.Baglanti))
                {
                    komut.Parameters.AddWithValue("@TestId", _testId);
                    komut.Parameters.AddWithValue("@Soru", item.Soru);
                    soruId = Convert.ToInt16(komut.ExecuteScalar());
                }
                foreach (var cevap in item.Cevaplar)
                {
                    using (var cevapKomut= new SQLiteCommand("Insert Into cevaplar(SoruId,Cevap,Dogru) VALUES (@SoruId,@Cevap,@Dogru)",DatabaseManager.Baglanti))
                    {
                        cevapKomut.Parameters.AddWithValue("@SoruId", soruId);
                        cevapKomut.Parameters.AddWithValue("@Cevap", cevap.Cevap);
                        cevapKomut.Parameters.AddWithValue("@Dogru", cevap.Dogru);
                        cevapKomut.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
