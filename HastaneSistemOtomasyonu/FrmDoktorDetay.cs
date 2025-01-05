using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace HastaneSistemOtomasyonu
{
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }

        //Sadece ilgili doktora ait randevuların sağdaki datagrid üzerine getirme işlemini bir metot içerisine yazıp ilgili yerlerde çağıracağız:
        private void randevularıYukle()
        {
            DataTable tableRandevular = new DataTable();
            SqlDataAdapter adapterRandevular = new SqlDataAdapter("Select RandevuId,RandevuTarih, RandevuSaat, RandevuDurum, HastaTC, HastaSikayet from Tbl_Randevular where RandevuDoktor='" + lblDoktorAdSoyad.Text + "'", bgl.dbBaglanti());
            adapterRandevular.Fill(tableRandevular);
            dataGridView1.DataSource = tableRandevular;
        }

        SqlBaglantisi bgl = new SqlBaglantisi(); //Bağlantıyı aç

        public string DoktorTc;
        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            lblDoktorTc.Text = DoktorTc; // Sol üst kutucukta doktorTc'sini göster.

            //TC'ye göre database'den doktor ad-soyad çekme işlemi: 

            SqlCommand commandDoktorAdSoyad = new SqlCommand("Select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorTc=@p1",bgl.dbBaglanti());
            commandDoktorAdSoyad.Parameters.AddWithValue("@p1",DoktorTc);
            SqlDataReader readerAdSoyad = commandDoktorAdSoyad.ExecuteReader(); //Verileri oku, üstünde gezin.
            while (readerAdSoyad.Read())//Okunacak veri olduğu sürece okuma işlemine devam et.
            {
                lblDoktorAdSoyad.Text = readerAdSoyad[0] + " " + readerAdSoyad[1]; //readerAdSoyad[0] -> DoktorAd, readerAdSoyad[1]->DoktorSoyad verilerini birleştir, bir string olarak labelAdSoyad alanına ata.
            }
            bgl.dbBaglanti().Close();

            //Sadece ilgili doktora ait randevuların sağdaki datagrid üzerine getirme işlemi:
            randevularıYukle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGrid üzerindeki Hasta Şikayet üzerine iki defa tıklandığında şikayeti soldaki rich textBox'ta detaylıca gözüksün.

            if (e.ColumnIndex==5)
            {
                int secilenHucre = dataGridView1.SelectedCells[0].RowIndex; //Seçilen hücrenin 0 indexine(id) göre row(satır) bellekte tutulsun.
                string sikayetIcerik = dataGridView1.Rows[secilenHucre].Cells[5].Value.ToString(); //x. satırın 5. sütunundaki veriyi string yapıya çevir, string bir değişkende tut
                rchSikayet.Text = sikayetIcerik; //aldığımız veriyi soldaki richTextBox'taki text alanında göster.
            }
        }
        private void btnDoktorBilgiDuzenle_Click(object sender, EventArgs e)
        {
              //Doktor bilgi düzenle butonuna tıklandığında ilgili forma ait bir nesne üretilsin,
            //Bu sırada Tc bilgisi ilgili forma aktarılsın,
            //ve .Show() metodu ile form kullanıcıya gözüksün.

            FrmDoktorBilgiDuzenle doktorBilgiDuzenle = new FrmDoktorBilgiDuzenle();
            doktorBilgiDuzenle.DoktorTc = lblDoktorTc.Text;
            doktorBilgiDuzenle.Show();
        }
        private void btnDuyurular_Click(object sender, EventArgs e)
        {
            //Duyurular butonuna basıldığında duyurular formu açılsın ve kullanıcıya gösterilsin:
            FrmDuyurular duyurular = new FrmDuyurular();
            duyurular.Show();
        }
        private void btnCikis_Click(object sender, EventArgs e)
        {
            //Çıkış butonuna basıldığında uygulama sonlandırılsın.
            Application.Exit();
        }
    }
}
