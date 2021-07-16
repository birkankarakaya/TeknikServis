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
    public partial class ServisKayıtları : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();

        public ServisKayıtları()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Close();
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
            string srg = txtYetkili.Text;
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from Rapor where (Yetkili like '%" + srg + "%') " , bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void ServisKayıtları_Load(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select ID, Unvan,Yetkili,Adres,Ilce,Il,Telefon,CihazSeriNo,Marka,Model,Durum From Rapor ORDER BY AlinanTarih DESC", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;

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

        private void btnRaporDetay_Click(object sender, EventArgs e)
        {
            RaporDetay raporDetay = new RaporDetay();
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            raporDetay.id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            raporDetay.Show();
        }
    }
}
