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
    public partial class MusteriDetay : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string id;

        public MusteriDetay()
        {
            InitializeComponent();
        }

        private void MusteriDetay_Load(object sender, EventArgs e)
        {
            label2.Text = id;

            string sql = "Select * from Musteri where ID=@id";
            SqlCommand sorgu = new SqlCommand(sql, bgl.baglanti());
            sorgu.Parameters.AddWithValue("@id", id);
            
            SqlDataReader sonuc = sorgu.ExecuteReader();
            while(sonuc.Read())
            {
                txtCariUnvan.Text = sonuc["CariUnvan"].ToString();
                txtCariGrup.Text = sonuc["CariGrup"].ToString();
                txtCariKod.Text = sonuc["CariKod"].ToString();
                txtTC.Text = sonuc["TCKNO"].ToString();
                txtFirmaAd.Text = sonuc["FirmaAdi"].ToString();
                txtAd.Text = sonuc["Ad"].ToString();
                txtSoyad.Text = sonuc["Soyad"].ToString();
                mskTelefon.Text = sonuc["Telefon"].ToString();
                txtEmail.Text = sonuc["Email"].ToString();
                txtFax.Text = sonuc["Fax"].ToString();
                txtWebSitesi.Text = sonuc["WebSitesi"].ToString();
                rtxtAdres.Text = sonuc["Adres"].ToString();
                cmbIlce.Text = sonuc["Ilce"].ToString();
                cmbIl.Text = sonuc["Il"].ToString();
                txtVergiDairesi.Text = sonuc["VergiDairesi"].ToString();
                txtVergiNo.Text = sonuc["VergiNo"].ToString();
                txtTicariSicil.Text = sonuc["TicariSicil"].ToString();
                rtxtFaturaAdresi.Text = sonuc["FaturaAdresi"].ToString();
                rtxtSevkAdresi.Text = sonuc["SevkAdresi"].ToString();
                txtPostaKod.Text = sonuc["PostaKod"].ToString();
                label23.Text = sonuc["Tur"].ToString();
            }
        }
    }
}
