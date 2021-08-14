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
    public partial class MusteriListe : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        Rapor rapor = new Rapor();
        

        public MusteriListe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rapor rapor = new Rapor();
            rapor.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cihaz cihaz = new Cihaz();
            cihaz.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string srg = txtAranan.Text;
            string srg2 = cmbGrup.Text;
            if (cmbGrup.Text != null)
            {
                string sorgu = "Select ID,FirmaAdi,Ad,Soyad,Telefon,Email,Adres,Ilce,Il From Musteri where (FirmaAdi like '%" + srg + "%' OR Ad Like '%" + srg + "%') OR Tur='" + srg2 + "'";
                SqlDataAdapter adap = new SqlDataAdapter(sorgu, bgl.baglanti());
                DataSet ds = new DataSet();
                adap.Fill(ds);
                this.dataGridView1.DataSource = ds.Tables[0];
                bgl.baglanti().Close();
            }
            else
            {
                string sorgu = "Select ID,FirmaAdi,Ad,Soyad,Telefon,Email,Adres,Ilce,Il From Musteri where (FirmaAdi like '%" + srg + "%' OR Ad Like '%" + srg + "%')";
                SqlDataAdapter adap = new SqlDataAdapter(sorgu, bgl.baglanti());
                DataSet ds = new DataSet();
                adap.Fill(ds);
                this.dataGridView1.DataSource = ds.Tables[0];
                bgl.baglanti().Close();
            }
            
        }

        private void MusteriListe_Load(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select ID,FirmaAdi,Ad,Soyad,Telefon,Email,Adres,Ilce,Il From Musteri", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            cmbGrup.Text = "";
            txtAranan.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ServisKayıtları servisKayıtları = new ServisKayıtları();
            servisKayıtları.Show();
            this.Close();
        }

        private void btnPersonel_Click(object sender, EventArgs e)
        {
            Personel personel = new Personel();
            personel.Show();
            this.Close();
        }

        private void btnMusteri_Click(object sender, EventArgs e)
        {
            Musteri musteri = new Musteri();
            musteri.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            rapor.unvan = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            rapor.yetkili = dataGridView1.Rows[secilen].Cells[2].Value.ToString() +" "+ dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            rapor.adres = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            rapor.ilce = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
            rapor.il = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            rapor.telefon = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            rapor.email = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            rapor.Show();
        }

        

        private void button8_Click(object sender, EventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            
            DialogResult sonuc = MessageBox.Show("Seçili kayıt silinecek ve tekrar getirilemeyecek. Emin misiniz?","Bilgi", MessageBoxButtons.YesNoCancel);
            if (sonuc == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("DELETE FROM Musteri WHERE ID=@p", bgl.baglanti());
                komut.Parameters.AddWithValue("@p", dataGridView1.Rows[secilen].Cells[0].Value);
                komut.ExecuteNonQuery();
                MessageBox.Show("Kayıt Silme İşleminiz Başarılı!");
            }            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Musteri musteri = new Musteri();
            musteri.Show();
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Rapor rapor = new Rapor();
            rapor.Show();
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MusteriDetay musteriDetay = new MusteriDetay();
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            musteriDetay.id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            musteriDetay.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
        }
    }
}
