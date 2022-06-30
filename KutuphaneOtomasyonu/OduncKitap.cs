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
    public partial class OduncKitap : Form
    {
        public OduncKitap()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;

        Uye u = new Uye();

        public int UNoOdunc;
        private void OduncKitap_Load(object sender, EventArgs e)
        {
            UNoOdunc = PersonelForm.UNo_;
            odunckitapgriddoldur();

        }
        public void odunckitapgriddoldur()
        {
            con = new SqlConnection("Server=localhost;Database=KutuphaneOtomasyonu; Uid=sa; Pwd='12345';");
            da = new SqlDataAdapter("SELECT KI.KAd, YAZ.YazAd, YAZ.YazSoyad, KI.SayfaS, KI.Stok, KA.VerTarih, KA.TesTarih, YAY.YayAd, KAT.KtgAd FROM Kayit AS KA JOIN Uye AS U ON U.UNo = KA.UNo JOIN (Kitap AS KI JOIN Yazar AS YAZ ON YAZ.YazNo = KI.YazNo JOIN Kategori AS KAT ON KAT.KtgNo = KI.KtgNo JOIN Yayınevi AS YAY ON YAY.YayNo = KI.YayNo )ON KI.KNo = KA.KNo WHERE U.UNo = " + UNoOdunc.ToString() + "", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Kayit");
            dataGridView1.DataSource = ds.Tables["Kayit"];
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
