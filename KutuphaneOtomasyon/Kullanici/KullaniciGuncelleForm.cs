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

namespace KutuphaneOtomasyon.Kullanici
{
    public partial class KullaniciGuncelleForm : Form
    {
        KutuphaneOtomasyonuEntities5 db = new KutuphaneOtomasyonuEntities5();

        public KullaniciGuncelleForm()
        {
            InitializeComponent();
        }

        public void Listele()
        {
            var kullanicilar = db.Kullanicilar.ToList();
            dataGridView1.DataSource = kullanicilar.ToList();

            // İd ve kayıtları gizledi
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[7].Visible = false;

            // Kalan kolonların isimleri düzenlendi
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            kullaniciAdtxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            kullaniciSoyadtxt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            kullaniciTCtxt.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            kullaniciMailtxt.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            kullaniciTeltxt.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            kullaniciCezatxt.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int secilenId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            string kullaniciAd = kullaniciAdtxt.Text;
            string kullaniciSoyad = kullaniciSoyadtxt.Text;
            string kullaniciTC = kullaniciTCtxt.Text;
            string kullaniciMail = kullaniciMailtxt.Text;
            string kullaniciTel = kullaniciTeltxt.Text;
            float kullaniciCeza = float.Parse(kullaniciCezatxt.Text);

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-F96E4NN\SQLEXPRESS;Initial Catalog=KutuphaneOtomasyonu;Integrated Security=True"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_UpdateKullanici", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@kullanici_id", secilenId);
                    command.Parameters.AddWithValue("@kullanici_ad", kullaniciAd);
                    command.Parameters.AddWithValue("@kullanici_soyad", kullaniciSoyad);
                    command.Parameters.AddWithValue("@kullanici_tc", kullaniciTC);
                    command.Parameters.AddWithValue("@kullanici_mail", kullaniciMail);
                    command.Parameters.AddWithValue("@kullanici_tel", kullaniciTel);
                    command.Parameters.AddWithValue("@kullanici_ceza", kullaniciCeza);
                    command.ExecuteNonQuery();

                }
            }

            Listele();
        }
    }
}
