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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            YeniUye f2 = new YeniUye();
            this.Hide();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UyeGirisi f2 = new UyeGirisi();
            this.Hide();
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PersonelGirisi f4 = new PersonelGirisi();
            this.Hide();
            f4.Show();
        }
    }
}
