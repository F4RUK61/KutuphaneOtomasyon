using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyon.Kaynak
{
    
   
    public partial class KaynakEkleForm : Form
    {
        public KaynakEkleForm()
        {
            InitializeComponent();
        }
        KutuphaneOtomasyonuEntities2 db = new KutuphaneOtomasyonuEntities2();
        private void button1_Click(object sender, EventArgs e)
        {
            Kaynaklar kaynanklar = new Kaynaklar();
            kaynanklar.kaynak_ad = adKaynaktxt.Text;
            kaynanklar.kaynak_yazar = yazarKaynaktxt.Text;
            kaynanklar.kaynak_yayıncı = yayıncıKaynaktxt.Text;
            kaynanklar.kaynak_sayfasayisi=Convert.ToInt16(numericUpDown1.Value);
            kaynanklar.kaynak_basımtarihi = dateTimePicker1.Value;
            db.Kaynaklar.Add(kaynanklar);
            db.SaveChanges();

            var kliste = db.Kaynaklar.ToList();
            dataGridView1.DataSource = kliste.ToList();

            //İd ve kayıtları gizledi
            dataGridView1.Columns[0].Visible = false;
            

            //kalan kolonların isimleri düzenlendi
            dataGridView1.Columns[1].HeaderText = "Kaynak Adı";
            dataGridView1.Columns[2].HeaderText = "Yazar";
            dataGridView1.Columns[3].HeaderText = "Yayıncı";
            dataGridView1.Columns[4].HeaderText = "Sayfa Sayısı";
            dataGridView1.Columns[5].HeaderText = "Basım Tarihi";
        }

        private void KaynakEkleForm_Load(object sender, EventArgs e)
        {

        }
    }
}
