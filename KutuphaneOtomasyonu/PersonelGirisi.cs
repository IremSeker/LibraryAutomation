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
    public partial class PersonelGirisi : Form
    {
        public PersonelGirisi()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT * FROM Personel where PNo=@PNo AND PSifre=@PSifre";
            con = new SqlConnection("Server=localhost;Database=KutuphaneOtomasyonu; Uid=sa; Pwd='12345';");
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@PNo", textBox1.Text);
            cmd.Parameters.AddWithValue("@PSifre", textBox2.Text);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Tebrikler! Başarılı bir şekilde giriş yaptınız.");
                PersonelForm f3 = new PersonelForm();
                this.Hide();
                f3.Show();
            }
            else
            {
                MessageBox.Show("Personel numaranızı ve şifrenizi kontrol ediniz!!");
            }
            con.Close();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }
    }
}
