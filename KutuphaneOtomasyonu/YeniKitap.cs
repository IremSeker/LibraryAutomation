using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KutuphaneOtomasyonu
{
    public partial class YeniKitap : Form
    {
        public YeniKitap()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        static string conString = "Server=localhost;Database=KutuphaneOtomasyonu; Uid=sa; Pwd='12345';";
        SqlConnection baglanti = new SqlConnection(conString);

        private void KitapEkle_Load_1(object sender, EventArgs e)
        {

            baglanti.Open();

            string strCmd_kat = "select * from Kategori";
            string strCmd_yaz = "select YazNo, YazAd+' ' + YazSoyad as Yazar from Yazar";
            string strCmd_yay = "select * from Yayınevi";

            SqlCommand cmd_kat = new SqlCommand(strCmd_kat, baglanti);
            SqlCommand cmd_yaz = new SqlCommand(strCmd_yaz, baglanti);
            SqlCommand cmd_yay = new SqlCommand(strCmd_yay, baglanti);

            SqlDataAdapter da_kat = new SqlDataAdapter(strCmd_kat, baglanti);
            SqlDataAdapter da_yaz = new SqlDataAdapter(strCmd_yaz, baglanti);
            SqlDataAdapter da_yay = new SqlDataAdapter(strCmd_yay, baglanti);

            DataSet ds_kat = new DataSet();
            DataSet ds_yaz = new DataSet();
            DataSet ds_yay = new DataSet();

            da_kat.Fill(ds_kat);
            da_yaz.Fill(ds_yaz);
            da_yay.Fill(ds_yay);

            cmd_kat.ExecuteNonQuery();
            cmd_yaz.ExecuteNonQuery();
            cmd_yay.ExecuteNonQuery();

            baglanti.Close();

            comboBox1.DataSource = ds_kat.Tables[0];
            comboBox1.DisplayMember = "KtgAd";
            comboBox1.ValueMember = "KtgNo";

            comboBox2.DataSource = ds_yaz.Tables[0];
            comboBox2.DisplayMember = "Yazar";
            comboBox2.ValueMember = "YazNo";

            comboBox4.DataSource = ds_yay.Tables[0];
            comboBox4.DisplayMember = "YayAd";
            comboBox4.ValueMember = "YayNo";

            baglanti.Close();

        }
        Kitap k = new Kitap();
        private void button1_Click(object sender, EventArgs e)
        {
            int kat_no;
            int yaz_no;
            int yay_no;

            kat_no = (int)comboBox1.SelectedValue;
            yaz_no = (int)comboBox2.SelectedValue;
            yay_no = (int)comboBox4.SelectedValue;

            Kitap yenikitap = new Kitap();
            yenikitap.Ad = textBox1.Text.ToString();
            yenikitap.KategoriNo = kat_no;
            yenikitap.YazarNo = yaz_no;
            yenikitap.YayıneviNo = yay_no;
            yenikitap.SayfaS = textBox5.Text;
            k.kitapEkle(yenikitap);

            PersonelForm ff = new PersonelForm();
            this.Hide();
            ff.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
