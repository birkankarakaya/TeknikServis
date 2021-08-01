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
                txtWeb.Text = sonuc["WebSitesi"].ToString();
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

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE Musteri SET CariUnvan=@p1, CariGrup=@p2, CariKod=@p3, Tur=@p4, TCKNO=@p5, FirmaAdi=@p6, Ad=@p7, Soyad=@p8" +
                "Telefon=@p9, Email=@p10, Fax=@p11, WebSitesi=@p12, Adres=@p13, Il=@p14, Ilce=@p15, VergiDairesi=@p16, VergiNo=@p17, TicariSicil=@p18, FaturaAdresi=@p19, SevkAdresi=@p20, PostaKod=@p21 WHERE ID=" + label2.Text);
            komut.Parameters.AddWithValue("@p1", txtCariUnvan.Text);
            komut.Parameters.AddWithValue("@p2", txtCariGrup.Text);
            komut.Parameters.AddWithValue("@p3", txtCariKod.Text);
            komut.Parameters.AddWithValue("@p4", label10.Text);
            komut.Parameters.AddWithValue("@p5", txtTC.Text);
            komut.Parameters.AddWithValue("@p6", txtFirmaAd.Text);
            komut.Parameters.AddWithValue("@p7", txtAd.Text);
            komut.Parameters.AddWithValue("@p8", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p9", mskTelefon.Text);
            komut.Parameters.AddWithValue("@p10", txtEmail.Text);
            komut.Parameters.AddWithValue("@p11", txtFax.Text);
            komut.Parameters.AddWithValue("@p12", txtWeb.Text);
            komut.Parameters.AddWithValue("@p13", rtxtAdres.Text);
            komut.Parameters.AddWithValue("@p14", cmbIlce.Text);
            komut.Parameters.AddWithValue("@p15", cmbIl.Text);
            komut.Parameters.AddWithValue("@p16", txtVergiDairesi.Text);
            komut.Parameters.AddWithValue("@p17", txtVergiNo.Text);
            komut.Parameters.AddWithValue("@p18", txtTicariSicil.Text);
            komut.Parameters.AddWithValue("@p19", rtxtFaturaAdresi.Text);
            komut.Parameters.AddWithValue("@p20", rtxtSevkAdresi.Text);
            komut.Parameters.AddWithValue("@p21", txtPostaKod.Text);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Güncelleme Başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
