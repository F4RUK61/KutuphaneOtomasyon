using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyon.Kayit
{
    public partial class OduncForm : Form
    {
        public OduncForm()
        {
            InitializeComponent();
        }
        KutuphaneOtomasyonuEntities2 db = new KutuphaneOtomasyonuEntities2();
        private void OduncForm_Load(object sender, EventArgs e)
        {
            //listeledik (kayıtları)
            var kayitlist = db.Kayitlar.ToList();
            dataGridView1.DataSource = kayitlist.ToList();

            //listeledik (kaynakları)
            var kaynakList = db.Kaynaklar.ToList();
            dataGridView2.DataSource = kaynakList.ToList();

            dataGridView1.Columns[6].Visible = false;
            



            dataGridView1.Columns[1].HeaderText = "Kullanıcı";
            dataGridView1.Columns[2].HeaderText = "Kaynak Ad";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string arananSecilen = TCBultxt.Text;
            var kullaniciVarMi = db.Kullanicilar.Where(x => x.kullanici_tc == arananSecilen).FirstOrDefault();

            if(kullaniciVarMi!=null)
                label2.Text = kullaniciVarMi.kullanici_ad + " " + kullaniciVarMi.kullanici_soyad;
            else
                 label2.Text= "Böyle bir kullanıcı henüz yok";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string gelenAd = textBox1.Text;
            var bulunanKaynaklar = db.Kaynaklar.Where(x => x.kaynak_ad.Contains(gelenAd)).ToList();
            dataGridView2.DataSource = bulunanKaynaklar;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //kişiyi aldık
            string secilenKisiTC = TCBultxt.Text;
            var secilenKisi = db.Kullanicilar.Where(x => x.kullanici_tc.Equals(secilenKisiTC)).FirstOrDefault();

            //kitabı aldık
            int secilenKitapId=Convert.ToInt16(dataGridView2.CurrentRow.Cells[0].Value);
            var secilenKitap = db.Kaynaklar.Where(x => x.kaynak_id == secilenKitapId).FirstOrDefault();

            Kayitlar yeniKayit = new Kayitlar();
            yeniKayit.kaynak_id = secilenKitap.kaynak_id;
            yeniKayit.kullanici_id = secilenKisi.kullanici_id;
            yeniKayit.alis_tarih = DateTime.Today;
            yeniKayit.son_tarih = DateTime.Today.AddDays(15);
            yeniKayit.durum = false;
            db.Kayitlar.Add(yeniKayit);
            db.SaveChanges();

            var kayitlist = db.Kayitlar.ToList();
            dataGridView1.DataSource = kayitlist.ToList();

        }
    }
}
