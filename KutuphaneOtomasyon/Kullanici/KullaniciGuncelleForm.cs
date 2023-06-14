using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyon.Kullanici
{
    public partial class KullaniciGuncelleForm : Form
    {
        KutuphaneOtomasyonuEntities3 db = new KutuphaneOtomasyonuEntities3();
        public KullaniciGuncelleForm()
        {
            InitializeComponent();
        }
        public void Listele()
        {

            var kullanicilar = db.Kullanicilar.ToList();
            dataGridView1.DataSource = kullanicilar.ToList();

            //İd ve kayıtları gizledi
            dataGridView1.Columns[0].Visible = false;
            

            //kalan kolonların isimleri düzenlendi
            dataGridView1.Columns[1].HeaderText = "Ad";
            dataGridView1.Columns[2].HeaderText = "Soyad";
            dataGridView1.Columns[3].HeaderText = "TC";
            dataGridView1.Columns[4].HeaderText = "Mail";
            dataGridView1.Columns[5].HeaderText = "Telefon No";
            dataGridView1.Columns[6].HeaderText = "Ceza";

        }
        private void KullaniciGuncelleForm_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int secilenId = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
            var kullanici = db.Kullanicilar.Where(x => x.kullanici_id == secilenId).FirstOrDefault();
            kullanici.kullanici_ad = kullaniciAdtxt.Text;
            kullanici.kullanici_soyad = kullaniciSoyadtxt.Text;
            kullanici.kullanici_tc = kullaniciTCtxt.Text;
            kullanici.kullanici_tel = kullaniciTeltxt.Text;
            kullanici.kullanici_mail = kullaniciMailtxt.Text;
            kullanici.kullanici_ceza =Convert.ToInt16 (kullaniciCezatxt.Text);

            db.SaveChanges();
            Listele();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            kullaniciAdtxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            kullaniciSoyadtxt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            kullaniciTCtxt.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            kullaniciMailtxt.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            kullaniciTeltxt.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            kullaniciCezatxt.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }
    }
}
