using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace HastaneSistemOtomasyonu
{

    public partial class FrmDoktorIslemPaneli : Form
    {
        private string mevcutTc;
        public FrmDoktorIslemPaneli()
        {
            InitializeComponent();
        }
        private void DoktorListesiGetir()
        {
            //Databasedeki doktorları datagridview'de gösterme işlemini bir metot içerisine yazarak ilgili yerlerde çağıracağız:
            DataTable dataTableDoktorlar = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Tbl_Doktorlar", bgl.dbBaglanti());
            adapter.Fill(dataTableDoktorlar);
            dataGridView1.DataSource = dataTableDoktorlar;
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void FrmDoktorIslemPaneli_Load(object sender, EventArgs e)
        {
            //Form yüklendiği anda doktor listesi(dataGridView) verilerle dolu şekilde gözüksün:
            DoktorListesiGetir();

            //Branş combobox'ına branşları getirme işlemi
            SqlCommand commandBransBox = new SqlCommand("Select BransAd from Tbl_Branslar",bgl.dbBaglanti());
            SqlDataReader readerBransBox = commandBransBox.ExecuteReader();
            while (readerBransBox.Read()) //Sorgu sonucunda okunacak veri olduğu sürece veri üzerinde gezin
            {
                cmbBrans.Items.Add(readerBransBox[0].ToString());
            }
            bgl.dbBaglanti().Close();

        }

        private void btnDoktorEkle_Click(object sender, EventArgs e)
        {

            //Tüm alanlar zorunludur, boş alan bırakılamaz. Boş alan varsa kullanıcıya uyarı mesajı ver:
            if(string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtSoyad.Text)|| string.IsNullOrWhiteSpace(cmbBrans.Text)||string.IsNullOrWhiteSpace(msdTC.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Eklemek istediğiniz doktor için tüm alanları doğru şekilde doldurduğunuzdan emin olun.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            //Tc kimliğin doğru girildiğinden emin ol, eksik haneli tc girilmişse kullanıcıya uyarı mesajı ver:
            if (msdTC.Text.Length!=11)
            {
                MessageBox.Show("Eksik Tc Kimlik numarası girişi yaptınız.\nLütfen girdiğiniz Tc kimlik numarasını kontrol edin.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            //Aynı kişi olmaması sorgusu:
            //Veri tabanında doktorlar tablosundaki tüm tc kimlikleri oku, eğer bir tanesi bile Box içerisine girilen Tc ile aynı ise sisteme ekletme, kullanıcıya uyarı mesajı ver:
            SqlCommand commandTcSorgu = new SqlCommand("Select DoktorTc from Tbl_Doktorlar",bgl.dbBaglanti());
            SqlDataReader readerTcSorgu = commandTcSorgu.ExecuteReader();
            while (readerTcSorgu.Read()) //Okunacak veri olduğu sürece oku,gezin
            {
                if (msdTC.Text == readerTcSorgu[0].ToString())
                {
                    MessageBox.Show("Eklemek istediğiniz doktor sistemde kayıtlı bulunmaktadır.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    return;
                }
            }


            //Tüm koşullardan geçildiği takdirde sql tarafında doktor tablosu için insert into işlemi yapılsın:
            //Doktor Ekleme İşlemi
            SqlCommand commandDoktorEkle = new SqlCommand("insert into Tbl_Doktorlar(DoktorAd, DoktorSoyad,DoktorBrans, DoktorTc,DoktorSifre) values(@p1,@p2,@p3,@p4,@p5)",bgl.dbBaglanti());
            commandDoktorEkle.Parameters.AddWithValue("@p1",txtAd.Text);
            commandDoktorEkle.Parameters.AddWithValue("@p2", txtSoyad.Text);
            commandDoktorEkle.Parameters.AddWithValue("@p3", cmbBrans.Text);
            commandDoktorEkle.Parameters.AddWithValue("@p4", msdTC.Text);
            commandDoktorEkle.Parameters.AddWithValue("@p5", txtSifre.Text);
            commandDoktorEkle.ExecuteNonQuery(); //Veri tabanına execute et.
            bgl.dbBaglanti().Close();
            MessageBox.Show("Doktor Başarıyla Eklendi.","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);

            DoktorListesiGetir(); //Her ekleme işleminden sonra DataGridView'da eklenen verinin anında gözükmesi için gridView yeniden doldurulur, bunu yapan metodu çağırdık.

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewdeki herhangi bir doktora tek tıklandığı zaman doktorun bilgilerinin
            //sol taraftaki box'larda gözükmesini istiyorum.
            //Bu nedenle datagrid'in bize Properties->Events başlığı altında sunduğu CellClick işlemine
            //çift tıklayarak işlemi yazacağım.

            int secilen = dataGridView1.SelectedCells[0].RowIndex; //Seçilen hücrenin 0. sütununa göre satır indexini tutsun. (Id'ye göre yani)
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString(); // x. satırın 1. sütununda yazılı değerini txtAd'a işle.
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();// x. satırın 2. sütununda yazılı değeri txtSoyad box'ına işle.
            cmbBrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            msdTC.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            msdTC.Enabled = false;
            txtSifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();

            mevcutTc = dataGridView1.Rows[secilen].Cells[4].Value.ToString(); //Database'den çektik, Tc textBox içerisinde bir değişiklik, güncelleme yapılmak istenmesi halinde uyarı ekranı vereceğiz.
        }

        private void btnDoktorSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(msdTC.Text))
            {
                MessageBox.Show("Doktor silme işlemi için lütfen sağdaki doktor listesinden silmek istediğiniz doktoru seçin.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return; //Hata var olduğu sürece metodun çalışmasını durdurur, buton işlemine devam ettirmez.
            }
            
            SqlCommand commandDoktorSil = new SqlCommand("Delete from Tbl_Doktorlar where DoktorTc=@p1",bgl.dbBaglanti());
            commandDoktorSil.Parameters.AddWithValue("@p1",msdTC.Text);
            commandDoktorSil.ExecuteNonQuery();
            bgl.dbBaglanti().Close();
            MessageBox.Show("Silme işlemi başarıyla gerçekleşti.","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);

            DoktorListesiGetir(); //DataGrid'de gösterilen doktorlar listesindeki değişimi anlık olarak kullanıcıya göstermek amacıyla bu metodu çağırdık.
        }

        private void btnDoktorGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(msdTC.Text))
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz doktoru sağdaki doktor listesinden seçiniz.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if(msdTC.Text.Length!=11 || msdTC.Text != mevcutTc)
            {
                MessageBox.Show("Tc kimlik numarası alanı değiştirilemez.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
       
            //Tüm sorgulardan geçtikten sonra database tarafında insert into işlemiyle yeni doktor kaydı yapılsın.
            SqlCommand commandDoktorGuncelle = new SqlCommand("Update Tbl_Doktorlar set DoktorAd=@p1, DoktorSoyad=@p2, DoktorBrans=@p3,DoktorSifre=@p4 where DoktorTc=@p5",bgl.dbBaglanti());
            commandDoktorGuncelle.Parameters.AddWithValue("@p1",txtAd.Text);
            commandDoktorGuncelle.Parameters.AddWithValue("@p2", txtSoyad.Text);
            commandDoktorGuncelle.Parameters.AddWithValue("@p3", cmbBrans.Text);
            commandDoktorGuncelle.Parameters.AddWithValue("@p4", txtSifre.Text);
            commandDoktorGuncelle.Parameters.AddWithValue("@p5", msdTC.Text);
            commandDoktorGuncelle.ExecuteNonQuery();
            bgl.dbBaglanti().Close();
            MessageBox.Show("Güncelleme işlemi başarıyla gerçekleşti.","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);

            DoktorListesiGetir(); //DataGrid'de gösterilen doktorlar listesindeki değişimi anlık olarak kullanıcıya göstermek amacıyla bu metodu çağırdık.

        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtAd.Clear();
            txtSoyad.Clear();
            cmbBrans.Text = "";
            msdTC.Clear();
            txtSifre.Clear();
            msdTC.Enabled = true;
        }
    }
}
