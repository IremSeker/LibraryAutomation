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
    public partial class UyeForm : Form
    {
        public UyeForm()
        {
            InitializeComponent();
        }
        public int UNoOdunc;
        private void UyeForm_Load(object sender, EventArgs e)
        {
            kitapgriddoldur();
            UNoOdunc = UyeForm.UNo_;
            odunckitapgriddoldur();

        }

        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;

        public string email_uye;
        void kitapgriddoldur()
        {
            con = new SqlConnection("Server=localhost;Database=KutuphaneOtomasyonu; Uid=sa; Pwd='12345';");
            da = new SqlDataAdapter("SELECT t1.KNo, t1.KAd, t4.YazAd, t4.YazSoyad, t1.SayfaS, t3.YayAd,t2.KtgAd,Stok FROM Kitap as t1 JOIN Kategori as t2 ON t1.KtgNo = t2.KtgNo  JOIN Yayınevi as t3 On t1.YayNo = t3.YayNo JOIN Yazar as t4 On t1.YazNo = t4.YazNo", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Kitap");
            dataGridView1.DataSource = ds.Tables["Kitap"];
            con.Close();
        }
        public void odunckitapgriddoldur()
        {
            con = new SqlConnection("Server=localhost;Database=KutuphaneOtomasyonu; Uid=sa; Pwd='12345';");
            da = new SqlDataAdapter("SELECT t1.KAd, t4.YazAd, t4.YazSoyad, t1.SayfaS, t3.YayAd,t2.KtgAd,Stok FROM Kitap as t1 RIGHT JOIN Kategori as t2 ON t1.KtgNo = t2.KtgNo RIGHT JOIN Yayınevi as t3 On t1.YayNo = t3.YayNo RIGHT JOIN Yazar as t4 On t1.YazNo = t4.YazNo WHERE t1.KNo IN (SELECT KNo FROM Kayit WHERE KayNo IN (SELECT KayNo FROM Uye WHERE UNo= " + UNoOdunc.ToString() + "))", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Kitap");
            dataGridView2.DataSource = ds.Tables["Kitap"];
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            int KNo = 1000;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {
                    KNo = (int)row.Cells[0].Value;
                }
            }

            email_uye = UyeGirisi.email;
            con = new SqlConnection("Server=localhost;Database=KutuphaneOtomasyonu; Uid=sa; Pwd='12345';");            
            da = new SqlDataAdapter("select UNo from Uye where UEmail='" + email_uye + "'", con);
            ds = new DataSet();

            int _UNo;
            con.Open();
            da.Fill(ds, "Uye");
            con.Close();

            _UNo = (int)ds.Tables["Uye"].Rows[0]["UNo"];
            DateTime now = DateTime.Now;
            string date_str = now.ToString("dd/MM/yyyy HH:mm:ss");

            string query = String.Format("insert into Kayit (KNo, UNo, VerTarih) values({0}, {1}, '{2}')", KNo, _UNo, now);

            con.Open();
            SqlCommand komut = new SqlCommand(query, con);
            komut.ExecuteNonQuery();
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string aranan = textBox1.Text.Trim().ToUpper();
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in dataGridView1.Rows[i].Cells)
                    {
                        if (cell.Value != null)
                        {
                            if (cell.Value.ToString().ToUpper() == aranan)
                            {
                                cell.Style.BackColor = Color.Red;
                                break;
                            }
                        }
                    }
                }
            }
        }
        public static int UNo_;
        Uye u = new Uye();
        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Selected)
                {
                    UNo_ = (int)row.Cells[0].Value;
                }
            }
            u.UyeSil(UNo_);
            odunckitapgriddoldur();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            odunckitapgriddoldur();
        }
    }
}
