using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HastaneSistemOtomasyonu
{
    public partial class FrmDoktorBilgiDuzenle : Form
    {
        public FrmDoktorBilgiDuzenle()
        {
            InitializeComponent();
        }

        public string DoktorTc;
        SqlBaglantisi bgl = new SqlBaglantisi();
        private string mevcutAd, mevcutSoyad, mevcutBrans, mevcutSifre;
        private void FrmDoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
            //Sayfa açıldığında ilgili doktorun güncellenmek üzere verileri gelmiş olsun işlemi:

            msdTcNo.Text = DoktorTc;

            SqlCommand commandDoktorBilgileri = new SqlCommand("Select DoktorAd,DoktorSoyad,DoktorBrans,DoktorSifre, DoktorTc from Tbl_Doktorlar where DoktorTc=@p1", bgl.dbBaglanti());
            commandDoktorBilgileri.Parameters.AddWithValue("@p1", msdTcNo.Text); //Tc'ye göre verileri getirsin
            SqlDataReader readerDoktorBilgileri = commandDoktorBilgileri.ExecuteReader(); //Okuma, ilgili verilerde gezinme işlemi
            while (readerDoktorBilgileri.Read()) //Veri olduğu sürece okuma işlemine devam et
            {
                //Box'lar içine şuan girili olan doktor verilerini yazdır:

                txtAd.Text = readerDoktorBilgileri[0].ToString();
                txtSoyad.Text = readerDoktorBilgileri[1].ToString();
                cmbBrans.Text = readerDoktorBilgileri[2].ToString();
                txtSifre.Text = readerDoktorBilgileri[3].ToString();
                msdTcNo.Text = readerDoktorBilgileri[4].ToString();



                //Güncelleme işleminde eğer aynı veriler girilmişse kullanıcıya bunu bildiren bir messagebox gösterme işlemi için
                //şuan girilmiş olan bilgileri hafızaya al:

                //BİLGİLERİ DATABASE'DEN ÇEKTİĞİMİZE DİKKAT! textBox'lardan çekmiyoruz, çünkü box içerikleri değişebilir.
                mevcutAd = readerDoktorBilgileri[0].ToString(); //Doktor Ad
                mevcutSoyad = readerDoktorBilgileri[1].ToString(); //Doktor Soyad
                mevcutBrans = readerDoktorBilgileri[2].ToString(); //Doktor branş(Sql tarafında varchar tipi ile kayıtlı)
                mevcutSifre = readerDoktorBilgileri[3].ToString(); //Doktor şifre

            }
            bgl.dbBaglanti().Close();

            //Branş comboBox'ına branşları çekme işlemi:
            SqlCommand commandBranslar = new SqlCommand("Select BransAd from Tbl_Branslar", bgl.dbBaglanti());
            SqlDataReader readerBranslar = commandBranslar.ExecuteReader(); //Verilerin üzerinde gezin
            while (readerBranslar.Read())//Branş verisi olduğu sürece oku, gezin
            {
                cmbBrans.Items.Add(readerBranslar[0]);
            }
            bgl.dbBaglanti().Close();
        }

        private void btnDoktorBilgiDegisiklikKaydet_Click(object sender, EventArgs e)
        {
            //Butona basıldığında doktor bilgilerini database'de güncellesin işlemi:

            //Eğer şuanki Box'lar içerisindeki veriler, database kısmındaki verilerle aynı ise bir if bloğu içerisine girsin:

            if (txtAd.Text == mevcutAd && txtSoyad.Text == mevcutSoyad && cmbBrans.Text == mevcutBrans && txtSifre.Text == mevcutSifre)
            {
                MessageBox.Show("Güncelleme işlemi için doktor verileri üzerinde değişlik yapmanız beklenmektedir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; //Void metodu durdurur, butonun çalışmasını durdurur, ilerletmez. Bunun yerine alta else bloğu da yazılabilirdi ama tercihen return; yazıldı.
            }

            //Tüm koşullar geçildikten sonra database kısmında update işlemleri yazılır:
            SqlCommand commandBilgiGuncelle = new SqlCommand("Update Tbl_Doktorlar set DoktorAd=@p1, DoktorSoyad=@p2, DoktorBrans=@p3, DoktorSifre=@p4 where DoktorTc=@p5", bgl.dbBaglanti());
            commandBilgiGuncelle.Parameters.AddWithValue("@p1", txtAd.Text);
            commandBilgiGuncelle.Parameters.AddWithValue("@p2", txtSoyad.Text);
            commandBilgiGuncelle.Parameters.AddWithValue("@p3", cmbBrans.Text);
            commandBilgiGuncelle.Parameters.AddWithValue("@p4", txtSifre.Text);
            commandBilgiGuncelle.Parameters.AddWithValue("@p5", msdTcNo.Text);

            commandBilgiGuncelle.ExecuteNonQuery(); //Değişiklikleri database'te execute et.

            bgl.dbBaglanti().Close();
            MessageBox.Show("Bilgiler Başarıyla Güncellendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);



        }
    }
}
