using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikServis
{
    public class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-HK06P7L\\SQLEXPRESS;Initial Catalog=admin_TeknikServis;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
