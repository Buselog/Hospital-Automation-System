using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace HastaneSistemOtomasyonu
{
    public partial class FrmDuyurular : Form
    {
        public FrmDuyurular()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        private void FrmDuyurular_Load(object sender, EventArgs e)
        {
            //Duyuru datagrid'inin üzerine duyurular listesini çekme işlemi:
            DataTable dataTableDuyurular = new DataTable();
            SqlDataAdapter adapterDuyurular = new SqlDataAdapter("Select * from Tbl_Duyurular",bgl.dbBaglanti());
            adapterDuyurular.Fill(dataTableDuyurular);
            dataGridView1.DataSource = dataTableDuyurular;
            bgl.dbBaglanti().Close();

        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilenDuyuruId = dataGridView1.SelectedCells[0].RowIndex;
            string duyuruIcerigi = dataGridView1.Rows[secilenDuyuruId].Cells[1].Value.ToString();
            MessageBox.Show(duyuruIcerigi, "Duyuru", MessageBoxButtons.OK);
        }
    }
}
