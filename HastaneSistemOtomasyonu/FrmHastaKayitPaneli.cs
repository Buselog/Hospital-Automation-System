using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HastaneSistemOtomasyonu
{
    public partial class FrmHastaKayitPaneli : Form
    {
        public FrmHastaKayitPaneli()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        private void btnHastaKaydet_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtSoyad.Text) || string.IsNullOrWhiteSpace(msdTcNo.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Ad, soyad, tc no ve şifre kısımları boş bırakılamaz.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                //Ad,Soyad,Tc ve Şifre alanları veri ile doldurulmuşsa else bloğuna geçiş yapılsın ve insert into işlemi gerçekleşsin:
                //Butona basıldığı anda, hasta kayıt ekranında doldurulan bilgiler veri tabanına işlenecek.

                if (msdTcNo.Text.Length!=11)
                {
                    MessageBox.Show("Eksik Tc kimlik numarası girişi yaptınız.","Uyraı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return; //Metodu durdurur, buton işlemlerini durdurur devam ettirmez.
                }


                //Son olarak girilmesi zorunlu alanları doldurmuş, 11 haneli tc no yazılmış bir veri girişi yapılmışsa, Sql tarafına insert into işlemi yapılsın:

                SqlCommand myCommand = new SqlCommand("Insert into Tbl_Hastalar(HastaAd, HastaSoyad, HastaTc, HastaTelefon, HastaSifre, HastaCinsiyet) values (@p1, @p2, @p3, @p4, @p5, @p6)", bgl.dbBaglanti());
                myCommand.Parameters.AddWithValue("@p1", txtAd.Text);
                myCommand.Parameters.AddWithValue("@p2", txtSoyad.Text);
                myCommand.Parameters.AddWithValue("@p3", msdTcNo.Text);
                myCommand.Parameters.AddWithValue("@p4", msdTelNo.Text);
                myCommand.Parameters.AddWithValue("@p5", txtSifre.Text);
                myCommand.Parameters.AddWithValue("@p6", cmbCinsiyet.Text);
                myCommand.ExecuteNonQuery(); //Update, delete ve insert işlemlerinde bu kullanılır ki işlemler database'e execute edilsin.
                bgl.dbBaglanti().Close(); //Database bağlantısını kapat.
                MessageBox.Show("Kaydınız başarıyla gerçekleşmiştir. Şifreniz: " + txtSifre.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        



            
        }
    }
}
