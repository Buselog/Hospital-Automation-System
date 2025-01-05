using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace HastaneSistemOtomasyonu
{
    public partial class FrmRandevuListesi : Form
    {
        public FrmRandevuListesi()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        private void FrmRandevuListesi_Load(object sender, EventArgs e)
        {
            //DataGrid üzerine randevu listesini getirme işlemi:
            DataTable dataTableRandevular = new DataTable();
            SqlDataAdapter adapterRandevular = new SqlDataAdapter("Select * from Tbl_Randevular",bgl.dbBaglanti());
            adapterRandevular.Fill(dataTableRandevular);
            dataGridView1.DataSource = dataTableRandevular;
            bgl.dbBaglanti().Close();
        }
    }
}
