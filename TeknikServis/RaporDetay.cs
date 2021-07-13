using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis
{
    public partial class RaporDetay : Form
    {
        public string id;
        sqlbaglantisi bgl = new sqlbaglantisi();

        public RaporDetay()
        {
            InitializeComponent();
        }

        private void RaporDetay_Load(object sender, EventArgs e)
        {
            label2.Text = id;
            string sql = "Select * from Rapor where ID=@id";
            SqlCommand sorgu = new SqlCommand(sql, bgl.baglanti());
            sorgu.Parameters.AddWithValue("@id", id);

            SqlDataReader sonuc = sorgu.ExecuteReader();
            while (sonuc.Read())
            {
                txtCariUnvan.Text = sonuc["Unvan"].ToString();
                txtYetkili.Text = sonuc["Yetkili"].ToString();
                rtxtAdres.Text = sonuc["Adres"].ToString();
                cmbIlce.Text = sonuc["Ilce"].ToString();
                cmbIl.Text = sonuc["Il"].ToString();
                mskTelefon.Text = sonuc["Telefon"].ToString();
                txtEmail.Text = sonuc["Email"].ToString();
                txtCihazSeriNo.Text = sonuc["CihazSeriNo"].ToString();
                txtCihazBarkodNo.Text = sonuc["CihazBarkodNo"].ToString();
                cmbMarka.Text = sonuc["Marka"].ToString();
                cmbModel.Text = sonuc["Model"].ToString();
                cmbPersonel.Text = sonuc["TeslimAlan"].ToString();
                txtTeslimEden.Text = sonuc["TeslimEden"].ToString();
                txtYapilanIslem.Text = sonuc["YapilanIslem"].ToString();
                txtAlinanTarih.Text = sonuc["AlinanTarih"].ToString();
                txtTeslimEdilenTarih.Text = sonuc["TeslimEdilenTarih"].ToString();
                txtTutar.Text = sonuc["Tutar"].ToString();
                label19.Text = sonuc["DegisimYapildiMi"].ToString();
                label22.Text = sonuc["Aksesuar"].ToString();
                rtxtAksesuar.Text = sonuc["AlinanAksesuar"].ToString();
                rtxtAciklama.Text = sonuc["Aciklama"].ToString();
                label26.Text = sonuc["Durum"].ToString();
            }
        }
    }
}
