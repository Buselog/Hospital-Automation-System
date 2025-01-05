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
namespace HastaneSistemOtomasyonu
{
    public partial class FrmHastaDetay : Form
    {
        
        public FrmHastaDetay()
        {
            InitializeComponent();
        }

        private void musaitRandevulariGetir()
        {
            //DataTable oluşturma işlemi
            DataTable dataTable2 = new DataTable();
            //Randevular tablosundan branş ve doktoru comboBox'tan seçilmiş olan, ve bunların yanında randevu durumu müsait (0) olan doktorun randevularını getirme, listeleme işlemi:
            SqlDataAdapter dataAdapter2 = new SqlDataAdapter("Select * from Tbl_Randevular where RandevuBrans='" + cmbBrans.Text + "'" + "and RandevuDoktor='" + cmbDoktor.Text + "'" + "and RandevuDurum='" + 0 + "'", bgl.dbBaglanti());
            //DataTable'ı doldurma, verileri yükleme işlemi
            dataAdapter2.Fill(dataTable2);
            //Son olarak, dataGridView'e bu verileri yükleme işlemi:
            dataGridView2.DataSource = dataTable2;
        }

        private void alinmisRandevulariGetir()
        {
            //Hastanın almış olduğu randevuların listesini getirme işlemi:

            DataTable dataTable = new DataTable(); //Hafızadaki veriler için sanal bir tablo sunar
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from Tbl_Randevular where HastaTc=" + lblTc.Text, bgl.dbBaglanti());
            dataAdapter.Fill(dataTable); //DataAdapter'dan gelen veri, dataTable'ı, sanal tablomuzu doldursun.
            dataGridView1.DataSource = dataTable;
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        public string Tc;
        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {
            lblTc.Text = Tc; //Hasta detay sayfasındaki Tc'ye atama işlemi yaptık.
            //Veri tabanından Tc'ye göre Ad-Soyadı getirme işlemi:
            SqlCommand myCommand = new SqlCommand("Select HastaAd, HastaSoyad from Tbl_Hastalar where HastaTc=@p1",bgl.dbBaglanti());
            myCommand.Parameters.AddWithValue("@p1", lblTc.Text);
            SqlDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
            {
                lblAdSoyad.Text = reader[0] + " " + reader[1]; //okunan ve bulunan ad ve soyad değerleri, 0 ve 1. indexli sütunlarda bulunuyor

            }
            bgl.dbBaglanti().Close();


            //Randevu geçmişini databaseden çekme işlemi:
            //DataGridView'de gösterme işlemi için DataTable ve SqlDataAdapter sınıfları kullanılır
            alinmisRandevulariGetir();



            //Branşları database'den çekme işlemi:
            SqlCommand myCommand2 = new SqlCommand("Select BransAd from Tbl_Branslar",bgl.dbBaglanti());
            SqlDataReader readerBrans = myCommand2.ExecuteReader(); //Database satırlarını okuma işlemi
            while (readerBrans.Read())//Okunacak satır olduğu sürece okumaya devam et, döngü.
            {
                cmbBrans.Items.Add(readerBrans[0]); //Reader'in okuduklarından ilk sütundaki veriyi(BransAd) ekle.
                //Zaten sorguyu çalıştırdığımızda tek bir sütun(BransAd) dönecek. O sütunun indexi de 0.
            }


        }

        //ComboBox'a doktor ad ve soyadları ekleme işlemi
        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear(); // Bir önce seçilen branştan ötürü eski verilerin(doktorların)
            // comboboxta kalmaması, eski verilerin üstüne yeni verilerin eklenmemesi için her branş seçimi
            // sırasında comboboxDoktor temizlensin, sonra aşağıdaki işlemler yapılsın.
            SqlCommand myCommand3 = new SqlCommand("Select DoktorAd, DoktorSoyad from Tbl_Doktorlar where DoktorBrans=@p1", bgl.dbBaglanti());
            myCommand3.Parameters.AddWithValue("@p1", cmbBrans.Text);
            SqlDataReader readerDoktor = myCommand3.ExecuteReader();
            while (readerDoktor.Read()) //Yukarıdaki sorguya göre okunacak satır,veri olduğu sürece okuma işlemi yap
            {
                //Sorgu sonucunda doktor ad ve soyadlarının olduğu satırlar karşımıza çıkar
                //Doktor combobox içine index 0(ad bilgisi) ve index 1(soyad bilgisi) birleştirilerek eklenir.
                //Bu işlem readerın okumak için bulduğu verilerin sayısı süresince devam eder.
                cmbDoktor.Items.Add(readerDoktor[0]+" " + readerDoktor[1]);
            }
            bgl.dbBaglanti().Close();
        }

        //Seçilen Branş ve Doktora göre Aktif randevu listesini databaseden çeken ve gösteren kod
        //En son doktor da seçildikten sonra listeyi gösterme işlemi getirileceği için, bu skop içinde işlem yapılır.
        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            musaitRandevulariGetir();
       
        }

        private void linkLblBilgiDuzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaBilgileriniDuzenle HastaBilgileriniDuzenlePaneli = new FrmHastaBilgileriniDuzenle();
            HastaBilgileriniDuzenlePaneli.HastaTc = lblTc.Text;
            HastaBilgileriniDuzenlePaneli.Show();
        }

        //Aktif randevular grid'inde gözüken herhangi bir hücreye tıklandığında, o satırın verilerini soldaki box'larda gösterme işlemi:
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex; //Seçilen hücrenin 0. sütununa göre satır indexini tutsun. (Id'ye göre yani)
            txtId.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString(); // x. satırın 0. sütununda yazılı değerini txtId box'a işle.
            cmbBrans.Text = dataGridView2.Rows[secilen].Cells[3].Value.ToString();// x. satırın 3. sütununda yazılı branşı cmbBrans box'ına işle.
            cmbDoktor.Text = dataGridView2.Rows[secilen].Cells[4].Value.ToString();
            
        }


        //Aktif randevular dataGrid'inde gözüken randevulardan herhangi bir hücreye tıklandığında, randevu bilgileri soldaki box'larda
        //gözükür hale geldi. Randevu Al butonuna tıklayarak combobox'lara işlenen veriler yardımıyla aktif randevular tablosunu güncelleyeceğiz.
        //RandevuDurumu true haline gelecek, Tc ve şikayet ataması yapılacak.
        //Randevu durumu TRUE'ya dönüşeceği için artık aktif randevular listesinde gözükmeyecek.
        //(Aktif randevular şartına RandevuDurum=0(false) yazmıştık.)
        private void btnRandevuAl_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Randevu almak için lütfen sağ taraftaki müsait randevulardan size uygun olanını seçin","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return; //Void metodun ilerlemesini durdurur, sorun var olduğu sürece işlemi ilerletmez, bir nevi metodu durdurur.
            }

            //Sağ taraftan bir randevu seçildiyse ilgili randevuyu güncelle, randevu durumunu 1, Tc'yi hastanın tcsi, şikayeti
            //hastanın girdiği şikayet yap,ekle. Nereye ekle ? TextBoxId'de yazılı Id'ye sahip randevunun satırına ekle, güncelleme işlemi yap: 
            SqlCommand commandRandevuAl = new SqlCommand("Update Tbl_Randevular set RandevuDurum=1, HastaTC=@p1, HastaSikayet=@p2 where RandevuId=@p3",bgl.dbBaglanti());
            commandRandevuAl.Parameters.AddWithValue("@p1",lblTc.Text);
            commandRandevuAl.Parameters.AddWithValue("@p2",rchSikayet.Text);
            commandRandevuAl.Parameters.AddWithValue("@p3", txtId.Text);
            commandRandevuAl.ExecuteNonQuery();
            bgl.dbBaglanti().Close();
            MessageBox.Show("Randevu Alma İşlemi Başarıyla Gerçekleşti.","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);



            //Update işlemi, yani randevu alma işlemi gerçekleştikten sonra dataGridView()'lerin yeniden yüklenmesi lazım,
            //anlık olarak listeler arası randevu geçişini göstermek için dataGrid işlemlerine sahip metotları tekrar çağırdık:
            alinmisRandevulariGetir();
            musaitRandevulariGetir();

        }

  
    }
}
