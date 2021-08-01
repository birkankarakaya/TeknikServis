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
    public partial class Cihaz : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();

        public Cihaz()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Cihaz (Grup,Marka,Model,StokAdet,Aciklama) values (@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbGrup.Text);
            komut.Parameters.AddWithValue("@p2", txtMarka.Text);
            komut.Parameters.AddWithValue("@p3", txtModel.Text);
            komut.Parameters.AddWithValue("@p4", txtAdet.Text);
            komut.Parameters.AddWithValue("@p5", rtxtAciklama.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız gerçekleşmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cmbGrup.Text = "";
            txtMarka.Text = "";
            txtModel.Text = "";
            txtAdet.Text = "";
            rtxtAciklama.Text = "";
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From Cihaz", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Cihaz_Load(object sender, EventArgs e)
        {
            SqlCommand doldur = new SqlCommand("SELECT * FROM StokGrup", bgl.baglanti());
            SqlDataReader dr = doldur.ExecuteReader();
            while (dr.Read())
            {
                cmbGrup.Items.Add(dr[1]);
            }
        }

        private void cmbGrup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
