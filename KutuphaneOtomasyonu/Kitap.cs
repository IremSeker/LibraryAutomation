using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu
{
    class Kitap
    {
        public string Ad { get; set; }
        public int KategoriNo { get; set; }
        public int YazarNo { get; set; }
        public int YayıneviNo { get; set; }
        public string SayfaS { get; set; }


        static string conString = "Server=localhost;Database=KutuphaneOtomasyonu; Uid=sa; Pwd='12345';";
        SqlConnection baglanti = new SqlConnection(conString);
        SqlCommand cmd;

        public void kitapEkle(Kitap yenikitap)
        {
            try
            {
                baglanti.Open();
                string ekle = "Insert Into Kitap (KAd, KtgNo, YazNo, YayNo, SayfaS) Values ('" + yenikitap.Ad + "','" + yenikitap.KategoriNo + "','" + yenikitap.YazarNo + "','" + yenikitap.YayıneviNo + "'," + yenikitap.SayfaS + ")";
                SqlCommand komut = new SqlCommand(ekle, baglanti);
                komut.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (baglanti != null)
                {
                    baglanti.Close();
                    MessageBox.Show("Kayıt İşlemi Gerçekleşti.");
                }
            }
        }
        public void kitapSil(int KNo)
        {
            string sql = "DELETE FROM Kitap WHERE KNo=@KNo";
            cmd = new SqlCommand(sql, baglanti);
            cmd.Parameters.AddWithValue("@KNo", KNo);
            baglanti.Open();
            cmd.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
