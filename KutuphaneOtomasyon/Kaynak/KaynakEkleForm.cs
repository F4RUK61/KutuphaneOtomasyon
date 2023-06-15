using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KutuphaneOtomasyon.Kaynak
{
    
   
    public partial class KaynakEkleForm : Form
    {
        public KaynakEkleForm()
        {
            InitializeComponent();
        }
        KutuphaneOtomasyonuEntities5 db = new KutuphaneOtomasyonuEntities5();
        private void button1_Click(object sender, EventArgs e)
        {
            // Kaynaklar nesnesini önceden tanımlayın
            Kaynaklar kaynaklar = new Kaynaklar();

            kaynaklar.kaynak_ad = adKaynaktxt.Text;
            kaynaklar.kaynak_yazar = yazarKaynaktxt.Text;
            kaynaklar.kaynak_yayıncı = yayıncıKaynaktxt.Text;
            kaynaklar.kaynak_sayfasayisi = Convert.ToInt32(numericUpDown1.Value);
            kaynaklar.kaynak_basımtarihi = dateTimePicker1.Value;

            db.Kaynaklar.Add(kaynaklar);

            // Depolama prosedürünü çağırmak için SQL bağlantısını kullan
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-F96E4NN\SQLEXPRESS;Initial Catalog=KutuphaneOtomasyonu;Integrated Security=True")) // connection_string'i uygun şekilde değiştirin
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_InsertKaynak", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@kaynak_ad", kaynaklar.kaynak_ad);
                command.Parameters.AddWithValue("@kaynak_yazar", kaynaklar.kaynak_yazar);
                command.Parameters.AddWithValue("@kaynak_yayıncı", kaynaklar.kaynak_yayıncı);
                command.Parameters.AddWithValue("@kaynak_sayfasayisi", kaynaklar.kaynak_sayfasayisi);
                command.Parameters.AddWithValue("@kaynak_basımtarihi", kaynaklar.kaynak_basımtarihi);
             
            }

            db.SaveChanges();

            var kliste = db.Kaynaklar.ToList();
            dataGridView1.DataSource = kliste.ToList();

            // İd ve kayıtları gizledi
            dataGridView1.Columns[0].Visible = false;

            // Kalan kolonların isimleri düzenlendi
            dataGridView1.Columns[1].HeaderText = "Kaynak Adı";
            dataGridView1.Columns[2].HeaderText = "Yazar";
            dataGridView1.Columns[3].HeaderText = "Yayıncı";
            dataGridView1.Columns[4].HeaderText = "Sayfa Sayısı";
            dataGridView1.Columns[5].HeaderText = "Basım Tarihi";
        }

        private void KaynakEkleForm_Load(object sender, EventArgs e)
        {

        }

        private void KaynakEkleForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
