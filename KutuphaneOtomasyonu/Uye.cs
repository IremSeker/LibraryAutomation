using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu
{
    class Uye
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }


        static string conString = "Server=localhost;Database=KutuphaneOtomasyonu; Uid=sa; Pwd='12345';";
        SqlConnection baglanti = new SqlConnection(conString);
        SqlCommand cmd;

        public void uyeEkle(Uye yeniuye)
        {
            try
            {
                baglanti.Open();
                string ekle = "Insert Into Uye (UAd,USoyad,UTel,UEmail,USifre) Values ('" + yeniuye.Ad + "','" + yeniuye.Soyad + "'," + yeniuye.Telefon + ",'" + yeniuye.Email + "'," + yeniuye.Sifre +")";
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
        public void UyeSil(int UNo)
        {
            string sql = "DELETE FROM Uye WHERE UNo=@UNo";
            cmd = new SqlCommand(sql, baglanti);
            cmd.Parameters.AddWithValue("@UNo", UNo);
            baglanti.Open();
            cmd.ExecuteNonQuery();
            baglanti.Close();
        }


    }

}
