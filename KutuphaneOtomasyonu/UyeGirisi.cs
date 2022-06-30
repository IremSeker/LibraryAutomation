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
    public partial class UyeGirisi : Form
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public UyeGirisi()
        {
            InitializeComponent();
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

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public static string email;
        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT * FROM Uye where UEmail=@UEmail AND USifre=@USifre";
            con = new SqlConnection("Server=localhost;Database=KutuphaneOtomasyonu; Uid=sa; Pwd='12345';");
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@UEmail", textBox1.Text);
            cmd.Parameters.AddWithValue("@USifre", textBox2.Text);
            con.Open();
            dr = cmd.ExecuteReader();
            try
            {
                if (dr.Read())
                {
                    MessageBox.Show("Tebrikler! Başarılı bir şekilde giriş yaptınız.");
                    UyeForm f3 = new UyeForm();
                    this.Hide();
                    f3.Show();
                }
            }
            catch
            {
                MessageBox.Show("Emailinizi ve şifrenizi kontrol ediniz!!");
            }
            finally
            {
                con.Close();
                email = textBox1.Text;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
