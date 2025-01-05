using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace HastaneSistemOtomasyonu
{
    public partial class FrmBransIslemPaneli : Form
    {
        public FrmBransIslemPaneli()
        {
            InitializeComponent();
        }
        private void BransTablosuYukle()
        {
            //Form açıldığında dataGrid üzerinde branşlar gözüksün işlemi
            DataTable dataTableBrans = new DataTable();
            SqlDataAdapter adapterBranslar = new SqlDataAdapter("Select * from Tbl_Branslar", bgl.dbBaglanti());
            adapterBranslar.Fill(dataTableBrans);
            dataGridView1.DataSource = dataTableBrans;
            bgl.dbBaglanti().Close();
        }

        SqlBaglantisi bgl = new SqlBaglantisi(); //Database bağlantısının bulunduğu sınıftan bir nesne üretip,
        //nesne üzerinden sınıftaki database fonksiyonuna ulaşacağız.
        private void FrmBransIslemPaneli_Load(object sender, EventArgs e)
        {
            BransTablosuYukle();
        }
        private void btnBransEkle_Click(object sender, EventArgs e)
        {
            //Eğer, branş ekleme butonuna basıldığı halde textBox içerisine bir branş ad girişi yapılmamışsa, 
            //Sql tarafında boş bir satır ekleme işlemi olmaması için bir kontrol sorgusu yazdık:

            if (string.IsNullOrWhiteSpace(txtBransAd.Text))
            {
                MessageBox.Show("Eklenecek bir branş verisi girişi yapılmadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                //Eğer Branş Adının girildiği textBox'ta bir branş adı verisi varsa,doluysa, else bloğuna geçiş yapılsın.
                //Bir kontrolümüz daha var: Eğer girdiğimiz branş adı zaten ekliyse,varsa tekrar eklenmemesi ve bir MessageBox'ta
                //bunun uyarısının yapılması gerekir:

                SqlCommand commandBrasKontrol = new SqlCommand("Select BransAd from Tbl_Branslar", bgl.dbBaglanti());
                SqlDataReader readerBransAd = commandBrasKontrol.ExecuteReader();
                while (readerBransAd.Read())
                {
                    if (txtBransAd.Text == readerBransAd[0].ToString())
                    {
                        MessageBox.Show("Eklemek istediğiniz branş adı halihazırda mevcuttur.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; //Void metodun çalışmasını durdurmak için eklenmiştir. Butonun çalışmasını durdurur.
                    }
                }
                bgl.dbBaglanti().Close(); //BranşAd kontrol commandı için açılan databse bağlantısını kapattık.


                //TextBoxBranşAd içerisine eklenecek farklı bir branş ad veri girildiyse, branş ekleme işlemini gerçekleştir:
                SqlCommand commandBransEkle = new SqlCommand("Insert into Tbl_Branslar(BransAd) values(@p1)", bgl.dbBaglanti());
                commandBransEkle.Parameters.AddWithValue("@p1", txtBransAd.Text);
                commandBransEkle.ExecuteNonQuery();
                bgl.dbBaglanti().Close();
                MessageBox.Show("Branş Ekleme İşlemi Başarıyla Gerçekleşti.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                BransTablosuYukle(); 
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGrid üzerinde herhangi bir hücreye tıklandığında o hücreye ait bilgileri
            //soldaki boxlarda gösterme işlemi:

            int tutulanId = dataGridView1.SelectedCells[0].RowIndex;
            txtBransId.Text = dataGridView1.Rows[tutulanId].Cells[0].Value.ToString(); //Id verisini textBoxId alanında gösterme işlemi.
            txtBransAd.Text = dataGridView1.Rows[tutulanId].Cells[1].Value.ToString(); //Branş Ad verisini textBoxAd alanında gösterme işlemi.
        }
        private void btnBransSil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBransId.Text))
            {
                MessageBox.Show("Lütfen silmek istediğiniz branşı sağdaki tablo üzerinden seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                SqlCommand commandBransSil = new SqlCommand("Delete from Tbl_Branslar where BransId=@p1", bgl.dbBaglanti());
                commandBransSil.Parameters.AddWithValue("@p1", txtBransId.Text);
                commandBransSil.ExecuteNonQuery();
                bgl.dbBaglanti().Close();
                MessageBox.Show("Silme işlemi başarıyla gerçekleşti.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                BransTablosuYukle();
            }
        }
        private void btnBransGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBransId.Text))
            {
                MessageBox.Show("Güncellemek istediğiniz veriyi sağdaki tablodan seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                SqlCommand commandBransAdKontrol = new SqlCommand("Select BransAd from Tbl_Branslar  where BransId=@p1", bgl.dbBaglanti());
                commandBransAdKontrol.Parameters.AddWithValue("@p1", txtBransId.Text);
                SqlDataReader readerBransKontrol = commandBransAdKontrol.ExecuteReader();
                if (readerBransKontrol.Read())
                {
                    string mevcutBransAd = readerBransKontrol[0].ToString();
                    if (txtBransAd.Text == mevcutBransAd)
                    {
                        MessageBox.Show("Güncellenmek istenen branş adı girdiğiniz branş adı ile aynıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return; //BtnBransGuncelle metot çalışmasını durdurur.
                        //return ifadesi, bir metottan çıkışı sağlar.
                        // void bir metotta, return; ifadesi, "bu noktadan itibaren metodu sonlandır ve metottan çık" anlamına gelir.
                        //Bir değer döndürmez, sadece metot çalışmasını erken bitirir.
                    }
                }
                bgl.dbBaglanti().Close(); //BransKontrol sql sorgusu için açtığımız veritabanı bağlantısını sonlandırdık.

                //Girilen Branş Adı halihazırda mevcut değilse güncelleme işlemini gerçekleştir:
                SqlCommand commandBransGuncelle = new SqlCommand("Update Tbl_Branslar set BransAd=@p1 where BransId=@p2", bgl.dbBaglanti());
                commandBransGuncelle.Parameters.AddWithValue("@p1", txtBransAd.Text);
                commandBransGuncelle.Parameters.AddWithValue("@p2", txtBransId.Text);
                commandBransGuncelle.ExecuteNonQuery();
                bgl.dbBaglanti().Close();
                MessageBox.Show("Güncelleme işlemi başarıyla gerçekleşti.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                BransTablosuYukle();
            }
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtBransId.Clear();
            txtBransAd.Clear();
        }
    }
}
