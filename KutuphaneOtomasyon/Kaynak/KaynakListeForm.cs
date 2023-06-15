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
    public partial class KaynakListeForm : Form
    {
        KutuphaneOtomasyonuEntities5 db = new KutuphaneOtomasyonuEntities5();
        public KaynakListeForm()
        {
            InitializeComponent();
        }

        private void KaynakListeForm_Load(object sender, EventArgs e)
        {
            var kaynaklar = db.Kaynaklar.ToList();
            dataGridView1.DataSource = kaynaklar.ToList();

            //İd ve kayıtları gizledi
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[6].Visible = false;


            //kalan kolonların isimleri düzenlendi
            dataGridView1.Columns[1].HeaderText = "Kaynak Adı";
            dataGridView1.Columns[2].HeaderText = "Yazar";
            dataGridView1.Columns[3].HeaderText = "Yayıncı";
            dataGridView1.Columns[4].HeaderText = "Sayfa Sayısı";
            dataGridView1.Columns[5].HeaderText = "Basım Tarihi";
            
        }
    }
}
