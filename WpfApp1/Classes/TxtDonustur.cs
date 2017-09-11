using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Classes
{
    class TxtDonustur
    {
        public string Yazdir(string[] sorular, string[,] cevaplar, string testAdi)
        {
            try
            {
                File.Delete("temp/test.txt");
                FileStream fs = new FileStream("temp/test.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(testAdi);
                for (int i = 0; i < sorular.Length; i++)
                {
                    sw.WriteLine(sorular[i]);
                    for (int k = 0; k < cevaplar.GetLength(1); k++)
                    {
                        sw.WriteLine(cevaplar[i, k]);
                    }
                }
                sw.Flush();sw.Close();fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            return "temp/test.txt";
        }
    }
}
