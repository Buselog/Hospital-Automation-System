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
using System.Diagnostics.Eventing.Reader;

namespace HastaneSistemOtomasyonu
{
    public partial class FrmSekreterGiris : Form
    {
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }


        SqlBaglantisi bgl = new SqlBaglantisi();
        private void btnSekreterGiris_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select * from Tbl_Sekreterler where SekreterTc=@p1 and SekreterSifre=@p2", bgl.dbBaglanti());
            command.Parameters.AddWithValue("@p1",msdTC.Text);
            command.Parameters.AddWithValue("@p2",txtSifre.Text);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read()) //Tüm veri doğru okunuyorsa, okunduysa
            {
                FrmSekreterDetay sekreterDetay = new FrmSekreterDetay();
                sekreterDetay.Tc = msdTC.Text; //Sekreter detay panelinde tc kullanılacak diye hazır nesne oluşturulmuşken buradan atamasını yaptık.
                sekreterDetay.Show(); //Detay panelini göster
                this.Hide(); //Sekreter giriş sayfasını gizle, kapat
            }
            else
            {
                MessageBox.Show("Hatalı Tc & Şifre girişi yaptınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            bgl.dbBaglanti().Close();
        }
    }
}
