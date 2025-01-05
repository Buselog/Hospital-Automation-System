
using System.Data.SqlClient;

namespace HastaneSistemOtomasyonu
{
    internal class SqlBaglantisi
    {

        //SqlConnection veri tipinde değer döndüren, dbBaglanti() adında bir fonksiyon yazıyoruz.
        //Bu fonksiyon içerisine Sql ile bağlantı kurmamıza yarayacak adresi giriyoruz.
        public SqlConnection dbBaglanti()
        {
            SqlConnection databaseBaglantisi = new SqlConnection("Data Source=DESKTOP-V7IDV6Q\\SQLEXPRESS01;Initial Catalog=HastaneOtomasyonu;Integrated Security=True");
            databaseBaglantisi.Open(); //Bu fonksiyon yazıldığında database bağlantısı açık olarak gelsin istediğimiz için .Open() metodunu yazdık.
            return databaseBaglantisi;
        }

    }
}
