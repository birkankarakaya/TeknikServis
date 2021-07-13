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
    public partial class Musteri : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        
        public Musteri()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Musteri (CariUnvan,CariGrup,CariKod,Tur,TCKNO,FirmaAdi,Ad,Soyad,Telefon,Email,Fax,WebSitesi,Adres,Ilce,Il,VergiDairesi,VergiNo,TicariSicil,FaturaAdresi,SevkAdresi,PostaKod) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17,@p18,@p19,@p20,@p21)", bgl.baglanti());
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
            komut.Parameters.AddWithValue("@p19", rtxtFaturaAdres.Text);
            komut.Parameters.AddWithValue("@p20", rtxtSevkiyatAdres.Text);
            komut.Parameters.AddWithValue("@p21", txtPostaKod.Text);
            
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label10.Text = "Şahıs";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                label10.Text = "Şirket";
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select ID,FirmaAdi,Ad,Soyad,Telefon,Email,Adres,Ilce,Il From Musteri", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        private void Musteri_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'admin_TeknikServisDataSet1.ilceler' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.ilcelerTableAdapter.Fill(this.admin_TeknikServisDataSet1.ilceler);
            SqlCommand sehir = new SqlCommand("SELECT * FROM iller", bgl.baglanti());
            SqlDataReader dr = sehir.ExecuteReader();
            while (dr.Read())
            {
                cmbIl.Items.Add(dr[1]);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            SqlCommand ilce = new SqlCommand("SELECT * FROM ilceler Where sehirid = @p1", bgl.baglanti());
            ilce.Parameters.AddWithValue("@p1",cmbIl.SelectedIndex +1);
            SqlDataReader dr1 = ilce.ExecuteReader();
            while (dr1.Read())
            {
                cmbIlce.Items.Add(dr1[1]);
            }
        }

        private void cmbIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
