using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using iTextSharp.text;
using iTextSharp.text.pdf;
using static System.Net.Mime.MediaTypeNames;

namespace TeknikServis
{
    public partial class RaporDetay : Form
    {
        public string id;
        sqlbaglantisi bgl = new sqlbaglantisi();

        public RaporDetay()
        {
            InitializeComponent();
        }

        private void RaporDetay_Load(object sender, EventArgs e)
        {
            label2.Text = id;
            string sql = "Select * from Rapor where ID=@id";
            SqlCommand sorgu = new SqlCommand(sql, bgl.baglanti());
            sorgu.Parameters.AddWithValue("@id", id);

            SqlDataReader sonuc = sorgu.ExecuteReader();
            while (sonuc.Read())
            {
                txtCariUnvan.Text = sonuc["Unvan"].ToString();
                txtYetkili.Text = sonuc["Yetkili"].ToString();
                rtxtAdres.Text = sonuc["Adres"].ToString();
                cmbIlce.Text = sonuc["Ilce"].ToString();
                cmbIl.Text = sonuc["Il"].ToString();
                mskTelefon.Text = sonuc["Telefon"].ToString();
                txtEmail.Text = sonuc["Email"].ToString();
                txtCihazSeriNo.Text = sonuc["CihazSeriNo"].ToString();
                txtCihazBarkodNo.Text = sonuc["CihazBarkodNo"].ToString();
                cmbMarka.Text = sonuc["Marka"].ToString();
                cmbModel.Text = sonuc["Model"].ToString();
                cmbPersonel.Text = sonuc["TeslimAlan"].ToString();
                txtTeslimEden.Text = sonuc["TeslimEden"].ToString();
                txtYapilanIslem.Text = sonuc["YapilanIslem"].ToString();
                txtAlinanTarih.Text = sonuc["AlinanTarih"].ToString();
                txtTeslimEdilenTarih.Text = sonuc["TeslimEdilenTarih"].ToString();
                txtTutar.Text = sonuc["Tutar"].ToString();
                label19.Text = sonuc["DegisimYapildiMi"].ToString();
                label22.Text = sonuc["Aksesuar"].ToString();
                rtxtAksesuar.Text = sonuc["AlinanAksesuar"].ToString();
                rtxtAciklama.Text = sonuc["Aciklama"].ToString();
                label26.Text = sonuc["Durum"].ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Document document = new iTextSharp.text.Document(PageSize.A4, 20, 20, 20, 20);
            PdfWriter.GetInstance(document, new FileStream("D:\\" + txtYetkili.Text + ".pdf", FileMode.Create));
            document.Open();
            iTextSharp.text.Font italikFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12f, iTextSharp.text.Font.ITALIC);
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(@"C:\Users\Lenovo\Desktop\indir.png");
            PdfPCell cell = new PdfPCell(img);
            Paragraph p = new Paragraph(txtYetkili.Text);
            Paragraph p1 = new Paragraph("Yapılan İşlem: " + txtYapilanIslem.Text);
            Paragraph p2 = new Paragraph("Teslim Alınan Tarih: " + txtAlinanTarih.Text);
            Paragraph p3 = new Paragraph("Teslim Edilen Tarih: " + txtTeslimEdilenTarih.Text);
            Paragraph p4 = new Paragraph("Tutar: " + txtTutar.Text);

            document.Add(img);
            document.Add(p);
            document.Add(p1);
            document.Add(p2);
            document.Add(p3);
            document.Add(p4);
            document.Close();
        }
    }
}
