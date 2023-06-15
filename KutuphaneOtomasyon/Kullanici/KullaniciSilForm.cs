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
    public partial class KullaniciSilForm : Form
    {
        public KullaniciSilForm()
        {
            InitializeComponent();
        }
        KutuphaneOtomasyonuEntities5 db = new KutuphaneOtomasyonuEntities5();
        public void Listele()
        {

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
        private void KullaniciSilForm_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int secilenId = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
            var kullanici = db.Kullanicilar.Where(x => x.kullanici_id == secilenId).FirstOrDefault();
            // Depolama prosedürünü çağırmak için SQL bağlantısını kullan
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-F96E4NN\SQLEXPRESS;Initial Catalog=KutuphaneOtomasyonu;Integrated Security=True")) // connection_string'i uygun şekilde değiştirin
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_DeleteKullanici", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@kullanici_id", secilenId);
                command.ExecuteNonQuery();
            }
            db.Kullanicilar.Remove(kullanici);
           
            Listele();
        }

    }

}
