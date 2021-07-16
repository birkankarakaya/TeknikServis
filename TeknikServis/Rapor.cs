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
    public partial class Rapor : Form
    {
        public Rapor()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void button3_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Close();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand kaydet = new SqlCommand("insert into Rapor " +
                "(Unvan,Yetkili,Adres,Ilce,Il,Telefon,Email,CihazSeriNo,CihazBarkodNo,Marka,Model,TeslimAlan,TeslimEden,YapilanIslem,AlinanTarih,TeslimEdilenTarih,DegisimYapildiMi,Aksesuar,Aciklama,Durum,Tutar) values " +
                "(@r1,@r2,@r3,@r4,@r5,@r6,@r7,@r8,@r9,@r10,@r11,@r12,@r13,@r14,@r15,@r16,@r17,@r18,@r19,@r20,@r21)", bgl.baglanti());
            kaydet.Parameters.AddWithValue("@r1", txtUnvan.Text);
            kaydet.Parameters.AddWithValue("@r2", txtYetkili.Text);
            kaydet.Parameters.AddWithValue("@r3", rtxtAdres.Text);
            kaydet.Parameters.AddWithValue("@r4", txtIlce.Text);
            kaydet.Parameters.AddWithValue("@r5", txtIl.Text);
            kaydet.Parameters.AddWithValue("@r6", mskTelefon.Text);
            kaydet.Parameters.AddWithValue("@r7", txtEmail.Text);
            
            kaydet.Parameters.AddWithValue("@r8", txtSeriNo.Text);
            kaydet.Parameters.AddWithValue("@r9", txtBarkodNo.Text);
            kaydet.Parameters.AddWithValue("@r10", cmbCihaz.Text);
            kaydet.Parameters.AddWithValue("@r11", cmbModel.Text);
            kaydet.Parameters.AddWithValue("@r12", cmbPersonel.Text);
            kaydet.Parameters.AddWithValue("@r13", txtTeslimEden.Text);
            kaydet.Parameters.AddWithValue("@r14", txtYapilanIslem.Text.ToString());
            kaydet.Parameters.AddWithValue("@r15", Convert.ToDateTime(dtAlinanTarih.Value));
            kaydet.Parameters.AddWithValue("@r16", Convert.ToDateTime(dtEdilenTarih.Value));
            
            kaydet.Parameters.AddWithValue("@r17", chcDegisim.Checked);
            kaydet.Parameters.AddWithValue("@r18", chcAksesuar.Checked);
            kaydet.Parameters.AddWithValue("@r19", rtxtAciklama.Text);
            
            kaydet.Parameters.AddWithValue("@r20", cmbDurum.Text);
            kaydet.Parameters.AddWithValue("@r21", Convert.ToDecimal(txtTutar.Text));
            kaydet.ExecuteNonQuery();
            MessageBox.Show("Kaydınız gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmbCihaz_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Rapor_Load(object sender, EventArgs e)
        {
            txtUnvan.Text = unvan;
            txtYetkili.Text = yetkili;
            rtxtAdres.Text = adres;
            txtIlce.Text = ilce;
            txtIl.Text = il;
            mskTelefon.Text = telefon;
            txtEmail.Text = email;

            // TODO: Bu kod satırı 'admin_TeknikServisDataSet.Cihaz' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.cihazTableAdapter.Fill(this.admin_TeknikServisDataSet.Cihaz);

            SqlCommand doldur1 = new SqlCommand("SELECT * FROM Personel", bgl.baglanti());
            SqlDataReader dr1 = doldur1.ExecuteReader();
            while (dr1.Read())
            {
                cmbPersonel.Items.Add(dr1[2] + " " + dr1[3]);
            }


            SqlCommand doldur2 = new SqlCommand("SELECT * FROM Durum", bgl.baglanti());
            SqlDataReader dr2 = doldur2.ExecuteReader();
            while (dr2.Read())
            {
                cmbDurum.Items.Add(dr2[1]);
            }

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID, Unvan,Yetkili,Adres,Ilce,Il,Telefon,CihazSeriNo,Marka,Model,Durum From Rapor ORDER BY AlinanTarih DESC", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;


            //Gelen Verileri koşullu renklendirme
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();
                if ((dataGridView1.Rows[i].Cells[10].Value.ToString()) == "Tamamlandı     ")
                {
                    renk.BackColor = Color.LightGreen;
                }
                else if ((dataGridView1.Rows[i].Cells[10].Value.ToString()) == "Onay bekliyor  ")
                {
                    renk.BackColor = Color.Yellow;
                }
                else if ((dataGridView1.Rows[i].Cells[10].Value.ToString()) == "Teslim Edildi  ")
                {
                    renk.BackColor = Color.LightSkyBlue;
                }
                else if ((dataGridView1.Rows[i].Cells[10].Value.ToString()) == "Teslim Alındı  ")
                {
                    renk.BackColor = Color.LightPink;
                }
                dataGridView1.Rows[i].DefaultCellStyle = renk;
            }




        }

        public string unvan, yetkili, adres, ilce, il, telefon, email;

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnRaporDetay_Click(object sender, EventArgs e)
        {
            RaporDetay raporDetay = new RaporDetay();
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            raporDetay.id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            raporDetay.Show();
        }

        private void Kayıtlar_Enter(object sender, EventArgs e)
        {

        }

        private void cmbDurum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MusteriListe musteriListe = new MusteriListe();
            musteriListe.Show();
            this.Close();
        }
    }
}
