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
    public partial class KaynakGuncelleForm : Form
    {
        public KaynakGuncelleForm()
        {
            InitializeComponent();
        }
        KutuphaneOtomasyonuEntities5 db = new KutuphaneOtomasyonuEntities5();
        private void KaynakGuncelleForm_Load(object sender, EventArgs e)
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            adKaynaktxt.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            yazarKaynaktxt.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            yayıncıKaynaktxt.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            numericUpDown1.Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[4].Value);
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[5].Value);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int secilenKaynak = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
            var guncellenecekKaynak = db.Kaynaklar.Where(x => x.kaynak_id == secilenKaynak).FirstOrDefault();

            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-F96E4NN\SQLEXPRESS;Initial Catalog=KutuphaneOtomasyonu;Integrated Security=True")) // connection_string'i uygun şekilde değiştirin
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_UpdateKaynaklar", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@kaynak_id", guncellenecekKaynak.kaynak_id);
                command.Parameters.AddWithValue("@kaynak_ad", guncellenecekKaynak.kaynak_ad);
                command.Parameters.AddWithValue("@kaynak_yazar", guncellenecekKaynak.kaynak_yazar);
                command.Parameters.AddWithValue("@kaynak_yayıncı", guncellenecekKaynak.kaynak_yayıncı);
                command.Parameters.AddWithValue("@kaynak_sayfasayisi", guncellenecekKaynak.kaynak_sayfasayisi);
                command.Parameters.AddWithValue("@kaynak_basımtarihi", guncellenecekKaynak.kaynak_basımtarihi);
                
            }
            
            guncellenecekKaynak.kaynak_ad = adKaynaktxt.Text;
            guncellenecekKaynak.kaynak_yazar = yazarKaynaktxt.Text;
            guncellenecekKaynak.kaynak_yayıncı = yayıncıKaynaktxt.Text;
            guncellenecekKaynak.kaynak_sayfasayisi =Convert.ToInt16(numericUpDown1.Value);
            guncellenecekKaynak.kaynak_basımtarihi = dateTimePicker1.Value;
            db.SaveChanges();

            var kaynaklar = db.Kaynaklar.ToList();
            dataGridView1.DataSource = kaynaklar.ToList();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
