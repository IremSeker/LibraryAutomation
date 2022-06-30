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
    public partial class PersonelForm : Form
    {
        public PersonelForm()
        {
            InitializeComponent();
        }

        Uye u = new Uye();

        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        void uyegriddoldur()
        {
            con = new SqlConnection("Server=localhost;Database=KutuphaneOtomasyonu; Uid=sa; Pwd='12345';");
            da = new SqlDataAdapter("Select UNo,UAd,USoyad, UTel, UEmail, USifre From Uye", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Uye");
            dataGridView1.DataSource = ds.Tables["Uye"];
            con.Close();
        }
        void kitapgriddoldur()
        {
            con = new SqlConnection("Server=localhost;Database=KutuphaneOtomasyonu; Uid=sa; Pwd='12345';");
            da = new SqlDataAdapter("SELECT t1.KNo, t1.KAd, t4.YazAd, t4.YazSoyad, t1.SayfaS, t3.YayAd,t2.KtgAd,Stok FROM Kitap as t1 JOIN Kategori as t2 ON t1.KtgNo = t2.KtgNo JOIN Yayınevi as t3 On t1.YayNo = t3.YayNo JOIN Yazar as t4 On t1.YazNo = t4.YazNo", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Kitap");
            dataGridView2.DataSource = ds.Tables["Kitap"];
            con.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            YeniUye ff = new YeniUye();
            this.Hide();
            ff.Show();
        }
        public static int UNo_;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {
                    UNo_ = (int)row.Cells[0].Value;
                }
            }

            OduncKitap ff = new OduncKitap();
            ff.Show();
        }

        private void PersonelForm_Load_1(object sender, EventArgs e)
        {
            kitapgriddoldur();
            uyegriddoldur();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {
                    UNo_ = (int)row.Cells[0].Value;
                }
            }
            u.UyeSil(UNo_);
            uyegriddoldur();
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

        Kitap k = new Kitap();
        public static int KNo_;
        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Selected)
                {
                    KNo_ = (int)row.Cells[0].Value;
                }
            }
            k.kitapSil(KNo_);
            kitapgriddoldur();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string aranan = textBox2.Text.Trim().ToUpper();
            for (int i = 0; i <= dataGridView2.Rows.Count - 1; i++)
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    foreach (DataGridViewCell cell in dataGridView2.Rows[i].Cells)
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

        private void button5_Click(object sender, EventArgs e)
        {
            YeniKitap ff = new YeniKitap();
            this.Hide();
            ff.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {
                    UNo_ = (int)row.Cells[0].Value;
                }
            }

            OduncKitap ff = new OduncKitap();
            ff.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
