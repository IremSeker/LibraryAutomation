using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu
{
    public partial class YeniUye : Form
    {
        public YeniUye()
        {
            InitializeComponent();
        }

        Uye u = new Uye();
        private void button1_Click(object sender, EventArgs e)
        {
            Uye yeniuye = new Uye();
            yeniuye.Ad = textBox1.Text;
            yeniuye.Soyad = textBox2.Text;
            yeniuye.Telefon = maskedTextBox1.Text;
            yeniuye.Email = textBox4.Text;
            yeniuye.Sifre = textBox5.Text;
            u.uyeEkle(yeniuye);

            UyeForm f3 = new UyeForm();
            this.Hide();
            f3.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox5.PasswordChar = '\0';
            }
            else
            {
                textBox5.PasswordChar = '*';
            }
        }

        private void YeniUye_Load(object sender, EventArgs e)
        {

        }
    }
}
