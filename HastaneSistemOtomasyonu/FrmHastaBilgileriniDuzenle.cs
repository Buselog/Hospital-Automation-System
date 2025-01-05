using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HastaneSistemOtomasyonu
{
    public partial class FrmHastaBilgileriniDuzenle : Form
    {

        private string mevcutAd, mevcutSoyad, mevcutTel, mevcutSifre;
        public FrmHastaBilgileriniDuzenle()
        {
            InitializeComponent();
        }

        public string HastaTc;
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void FrmHastaBilgileriniDuzenle_Load(object sender, EventArgs e)
        {
            msdTcNo.Text = HastaTc; //Hasta Detay Panelinde buradaki TCNo değişkenine formdan oluşturduğumuz
            //nesne ile ulaştık, hasta detay sayfasındaki lblTc.Text'i TCNo'ya atadık.
            //Burada da içi veri dolu TCNo'yu msdTcNo box içine atadık.
            //Panel açıldığında Tc bilgisi box içinde olacak şekilde açılacak. 

            SqlCommand command = new SqlCommand("Select * from Tbl_Hastalar where  HastaTc=@p1", bgl.dbBaglanti());
            command.Parameters.AddWithValue("@p1",msdTcNo.Text);
            SqlDataReader readerHasta = command.ExecuteReader(); 
            while (readerHasta.Read()) //Veri olduğu sürece okuma işlemini gerçekleştir, gezin.
            {
                txtAd.Text = readerHasta[1].ToString(); // Select * dediğimiz için Id de tabloda 0. index olarak gelecek. Ad bilgisi 1. indexte.
                txtSoyad.Text = readerHasta[2].ToString();
                msdTcNo.Text = readerHasta[3].ToString(); //Object dönen veriyi Text'e atadığımız için ToString()'e çevirmeliyiz.
                msdTelNo.Text = readerHasta[4].ToString();
                txtSifre.Text = readerHasta[5].ToString();
                cmbCinsiyet.Text = readerHasta[6].ToString();


                //Güncelleme işleminde eğer aynı veriler girilmişse kullanıcıya bunu bildiren bir messagebox gösterme işlemi için
                //şuan girilmiş olan bilgileri hafızaya al:

                //BİLGİLERİ DATABASE'DEN ÇEKTİĞİMİZE DİKKAT! textBox'lardan çekmiyoruz, çünkü box içerikleri değişebilir.
                mevcutAd = readerHasta[1].ToString(); //Doktor Ad
                mevcutSoyad = readerHasta[2].ToString(); //Doktor Soyad
                mevcutTel = readerHasta[4].ToString(); //Doktor şifre
                mevcutSifre = readerHasta[5].ToString();

            }

            bgl.dbBaglanti().Close();

        }

        private void btnHastaBilgiDegisiklikKaydet_Click(object sender, EventArgs e)
        {

            //Butona basıldığında doktor bilgilerini database'de güncellesin işlemi:

            //Eğer şuanki Box'lar içerisindeki veriler, database kısmındaki verilerle aynı ise bir if bloğu içerisine girsin:

            if (txtAd.Text == mevcutAd && txtSoyad.Text == mevcutSoyad && msdTelNo.Text==mevcutTel && txtSifre.Text == mevcutSifre)
            {
                MessageBox.Show("Güncelleme işlemi için hasta verileri üzerinde değişlik yapmanız beklenmektedir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; //Void metodu durdurur, butonun çalışmasını durdurur, ilerletmez. Bunun yerine alta else bloğu da yazılabilirdi ama tercihen return; yazıldı.
            }


            //Tüm koşullar geçildikten sonra database kısmında update işlemleri yazılır:


            SqlCommand command2 = new SqlCommand("Update Tbl_Hastalar set HastaAd=@p1, HastaSoyad=@p2, HastaTelefon=@p3, HastaSifre=@p4, HastaCinsiyet=@p5 where HastaTc=@p6",bgl.dbBaglanti());
            command2.Parameters.AddWithValue("@p1",txtAd.Text);
            command2.Parameters.AddWithValue("@p2", txtSoyad.Text);
            command2.Parameters.AddWithValue("@p3", msdTelNo.Text);
            command2.Parameters.AddWithValue("@p4", txtSifre.Text);
            command2.Parameters.AddWithValue("@p5", cmbCinsiyet.Text);
            command2.Parameters.AddWithValue("@p6", msdTcNo.Text);
            command2.ExecuteNonQuery(); //Veri tabanı üzerinde insert, update, delete işlemlerinden sonra Execute etmeyi unutma
            bgl.dbBaglanti().Close();
            MessageBox.Show("Bilgiler Başarıyla Güncellendi.", "Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
