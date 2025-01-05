using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneSistemOtomasyonu
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        private void btnHastaGiris_Click(object sender, EventArgs e)
        {
            FrmHastaGiris hastaGiris = new FrmHastaGiris();
            hastaGiris.Show();
            this.Hide(); // Ana sayfayı gizle, hasta giriş sayfası gözüksün sadece.
        }

        private void btnDoktorGiris_Click(object sender, EventArgs e)
        {
            FrmDoktorGiris doktorGiris = new FrmDoktorGiris();
            doktorGiris.Show();
            this.Hide();
        }

        private void btnSekreterGiris_Click(object sender, EventArgs e)
        {
            FrmSekreterGiris sekreterGiris = new FrmSekreterGiris();
            sekreterGiris.Show();
            this.Hide();
        }

        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {

        }
    }
}
