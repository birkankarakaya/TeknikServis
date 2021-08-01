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
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void Anasayfa_Load(object sender, EventArgs e)
        {
            //grafik1
            SqlCommand komutg1 = new SqlCommand("select Durum,Count(*) from Rapor group by Durum", bgl.baglanti());
            SqlDataReader dr1 = komutg1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Islemler"].Points.AddXY(dr1[0], dr1[1]);
                chart1.Series["Islemler"].Color = Color.Aqua;
            }
            


            //grafik2
            SqlCommand komutg2 = new SqlCommand("Select Tur,Count(*) from Musteri group by Tur", bgl.baglanti());
            SqlDataReader dr2 = komutg2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Musteri"].Points.AddXY(dr2[0], dr2[1]);
                chart2.Series["Musteri"].Color = Color.Orange;
            }


            //dgw1
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select ID, Yetkili, Adres, Ilce, Il, Telefon, Durum from Rapor where Durum='Onay bekliyor'", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;



            //dgw2
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select ID, Yetkili, Adres, Ilce, Il, Telefon, Durum from Rapor where Durum='Tamamlandı'", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Personel personel = new Personel();
            personel.Show();
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cihaz cihaz = new Cihaz();
            cihaz.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Musteri musteri = new Musteri();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rapor rapor = new Rapor();
            rapor.Show();
            this.Close();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void müşteriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Musteri musteri = new Musteri();
            musteri.Show();
            this.Close();
        }

        private void müşteriListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MusteriListe musteriListe = new MusteriListe();
            musteriListe.Show();
            this.Close();
        }

        private void stokGruplarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StokGrupları stokGrupları = new StokGrupları();
            stokGrupları.Show();
        }

        private void personellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personel personel = new Personel();
            personel.Show();
            this.Close();
        }

        private void raporlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rapor rapor = new Rapor();
            rapor.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServisKayıtları servisKayıtları = new ServisKayıtları();
            servisKayıtları.Show();
            this.Close();
        }

        private void servisKayıtEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rapor rapor = new Rapor();
            rapor.Show();
            this.Close();
        }

        private void btnPersonel_Click(object sender, EventArgs e)
        {
            Personel personel = new Personel();
            personel.Show();
            this.Close();
        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            Musteri musteri = new Musteri();
            musteri.Show();
            this.Close();
        }

        private void şifreDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SifreDegistir sifre = new SifreDegistir();
            sifre.Show();
        }

        private void servisKayıtlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServisKayıtları servisKayıtları = new ServisKayıtları();
            servisKayıtları.Show();
            this.Close();
        }

        private void durumlarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
