﻿using System;
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
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From Rapor", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }
    }
}
