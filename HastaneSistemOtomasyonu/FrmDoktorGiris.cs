using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HastaneSistemOtomasyonu
{
    public partial class FrmDoktorGiris : Form
    {
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        private void btnDoktorGiris_Click(object sender, EventArgs e)
        {
            //Butona tıklandığında doğru tc ve şifre girilmişse doktor detay sayfasına gitsin işlemi:

            SqlCommand commandDoktorGiris = new SqlCommand("Select * from Tbl_Doktorlar where DoktorTc=@p1 and DoktorSifre=@p2",bgl.dbBaglanti());
            commandDoktorGiris.Parameters.AddWithValue("@p1",msdTC.Text);
            commandDoktorGiris.Parameters.AddWithValue("@p2",txtSifre.Text);
            SqlDataReader readerDoktor = commandDoktorGiris.ExecuteReader();
            if (readerDoktor.Read())
            {
                FrmDoktorDetay doktorDetay = new FrmDoktorDetay();
                doktorDetay.DoktorTc = msdTC.Text; //Doktor detay sayfası için Tc verisi buradan atandı.
                doktorDetay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Tc & Şifre Girişi yaptınız.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            bgl.dbBaglanti().Close();
        }
    }
}
