using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyon
{
    public partial class KullaniciListeForm : Form
    {
        public KullaniciListeForm()
        {
            InitializeComponent();
        }

        public void Listele()
        {
            KutuphaneOtomasyonuEntities2 db = new KutuphaneOtomasyonuEntities2();
            var kullanicilar = db.Kullanicilar.ToList();
            dataGridView1.DataSource = kullanicilar.ToList();
            //İd ve kayıtları gizledi
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[7].Visible = false;


            //kalan kolonların isimleri düzenlendi
            dataGridView1.Columns[1].HeaderText = "Ad";
            dataGridView1.Columns[2].HeaderText = "Soyad";
            dataGridView1.Columns[3].HeaderText = "TC";
            dataGridView1.Columns[4].HeaderText = "Mail";
            dataGridView1.Columns[5].HeaderText = "Telefon No";
            dataGridView1.Columns[6].HeaderText = "Ceza";

        }
        private void KullaniciListeForm_Load(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
