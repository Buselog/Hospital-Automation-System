using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HastaneSistemOtomasyonu
{
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }

        public string Tc;
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            lblTc.Text = Tc;
            SqlCommand command = new SqlCommand("Select SekreterAd_Soyad from Tbl_Sekreterler where SekreterTc=@p1", bgl.dbBaglanti());
            command.Parameters.AddWithValue("@p1",lblTc.Text);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lblAdSoyad.Text = reader[0].ToString();
            }
            bgl.dbBaglanti().Close();

            //Branşlar DataGrid'ine database'den veri çekme işlemi
            DataTable dataTableBranslar = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Tbl_Branslar", bgl.dbBaglanti());
            adapter.Fill(dataTableBranslar);
            dataGridView1.DataSource = dataTableBranslar;

            //Doktorlar DataGrid'ine databaseden veri çekme işlemi
            DataTable dataTableDoktorlar = new DataTable();
            SqlDataAdapter adapter1 = new SqlDataAdapter("Select (DoktorAd+' '+DoktorSoyad) as 'Doktorlar', DoktorBrans as 'Branş' from Tbl_Doktorlar",bgl.dbBaglanti());
            adapter1.Fill(dataTableDoktorlar);
            dataGridView2.DataSource = dataTableDoktorlar;

            //Randevu Kayıt Alanındaki Branş ComboBox'ı Veri ile Doldurma İşlemi
            SqlCommand commandBransDoldur = new SqlCommand("Select BransAd from Tbl_Branslar", bgl.dbBaglanti());
            SqlDataReader readerBrans = commandBransDoldur.ExecuteReader();
            while (readerBrans.Read()) //Okunacak brans verisi olduğu sürece veriler üzerinde gezinmeye devam et
            {
                cmbBrans.Items.Add(readerBrans[0]);
            }
            bgl.dbBaglanti().Close();
        }
        //Butona basıldığında randevuyu oluşturma, kaydetme işlemi
        private void btnRandevuKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand commandRandevuEkle = new SqlCommand("Insert into Tbl_Randevular(RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) values(@p1, @p2, @p3, @p4)",bgl.dbBaglanti());
            commandRandevuEkle.Parameters.AddWithValue("@p1",msdTarih.Text);
            commandRandevuEkle.Parameters.AddWithValue("@p2", msdSaat.Text);
            commandRandevuEkle.Parameters.AddWithValue("@p3", cmbBrans.Text);
            commandRandevuEkle.Parameters.AddWithValue("@p4", cmbDoktor.Text);

            commandRandevuEkle.ExecuteNonQuery();
            bgl.dbBaglanti().Close();
            MessageBox.Show("Randevu Başarıyla Oluşturuldu.","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        //Randevu alma kısmında, branş seçildiğinde branşa göre doktor seçeneklerini combobox'ta gösterme işlemi
        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();
            SqlCommand commandDoktorDoldur = new SqlCommand("Select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorBrans=@p1", bgl.dbBaglanti());
            commandDoktorDoldur.Parameters.AddWithValue("@p1",cmbBrans.Text); //Branşlara göre doktorları gösterme işlemi
            SqlDataReader reader = commandDoktorDoldur.ExecuteReader();
            while (reader.Read()) //Okunacak veri olduğu sürece okumaya devam et, verilerde gezin
            {
                cmbDoktor.Items.Add(reader[0]+" "+ reader[1]); //Doktor Ad ve Soyadı birleştirerek yazdır
            }
            bgl.dbBaglanti().Close();
        }
        private void btnDuyuruKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand commandDuyuruOlustur = new SqlCommand("insert into Tbl_Duyurular(Duyuru) values(@p1)",bgl.dbBaglanti());
            commandDuyuruOlustur.Parameters.AddWithValue("@p1",rchDuyuru.Text);
            commandDuyuruOlustur.ExecuteNonQuery();
            MessageBox.Show("Duyuru Başarıyla Eklendi.");
            bgl.dbBaglanti().Close();
  
            rchDuyuru.Clear();
        }
        private void btnDoktorIslemPanelineGit_Click(object sender, EventArgs e)
        {
            FrmDoktorIslemPaneli doktorIslemPaneli = new FrmDoktorIslemPaneli();
            doktorIslemPaneli.Show();
        }
        private void btnBransIslemPanelineGit_Click(object sender, EventArgs e)
        {
            FrmBransIslemPaneli bransIslemPaneli = new FrmBransIslemPaneli();
            bransIslemPaneli.Show();
        }
        private void btnRandevulariListele_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi randevuListesi = new FrmRandevuListesi();
            randevuListesi.Show();
        }
        private void btnDuyurulariListele_Click(object sender, EventArgs e)
        {
            FrmDuyurular duyurularListesi = new FrmDuyurular();
            duyurularListesi.Show();
        } 
    }
}
