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
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }

        //DataBase bağlantı adresimizi içeren sınıftan bir nesne oluşturuyoruz.
        //O nesne üzerinden sınıf içerisindeki dbBaglanti() fonksiyonuna ulaşacağız:
        SqlBaglantisi bgl = new SqlBaglantisi();

        private void lnkLblUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayitPaneli hastaKaydet = new FrmHastaKayitPaneli();
            hastaKaydet.Show();
            //arka planda hasta giriş paneli hala var, 
            //çünkü kayıt olduktan sonra giriş sayfasından sisteme giriş yapacak. Saklanmamalı.
        }
        private void btnHastaGiris_Click(object sender, EventArgs e)
        {
            SqlCommand myCommand = new SqlCommand("Select * From Tbl_Hastalar Where HastaTc=@p1 and HastaSifre=@p2", bgl.dbBaglanti());
            myCommand.Parameters.AddWithValue("@p1", msdTC.Text);
            myCommand.Parameters.AddWithValue("p2", txtSifre.Text);
            SqlDataReader reader = myCommand.ExecuteReader();
            if (reader.Read()) //Okuma işlemi hatasız gerçekleştiriliyorsa
            {
                FrmHastaDetay hastaDetay = new FrmHastaDetay(); //Hasta Detay sayfasına gir
                hastaDetay.Tc = msdTC.Text; //TextBox'a girilen Tc, hastaDetay formundaki Tc değerine atansın
                //Sınıf üzerinden nesne vasıtasıyla Tc değişkenine ulaşıldı.
                hastaDetay.Show();
                this.Hide(); //Hasta giriş sayfasını altta gösterme, kapat
            }
            else
            {
                MessageBox.Show("Hatalı TC & Şifre girişi yaptınız.","Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            bgl.dbBaglanti().Close();
        }
    }
}
