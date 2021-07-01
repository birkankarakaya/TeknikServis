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
    public partial class SifreDegistir : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        Anasayfa anasayfa = new Anasayfa();

        public SifreDegistir()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Sifre1 = textBox1.Text, Sifre2 = textBox2.Text;
            if (Sifre1 == Sifre2)
            {
                SqlCommand komut = new SqlCommand("UPDATE Giris SET Sifre='" + Sifre1 + "'  WHERE ID=2", bgl.baglanti());
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Giriş Bilgileri Güncellendi.");
                this.Close();
            }
        }
    }
}
