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
    public partial class KaynakSilForm : Form
    {
        public KaynakSilForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int secilenId=Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
            var silinenKaynak = db.Kaynaklar.Where(x => x.kaynak_id == secilenId).FirstOrDefault();
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-F96E4NN\SQLEXPRESS;Initial Catalog=KutuphaneOtomasyonu;Integrated Security=True")) // connection_string'i uygun şekilde değiştirin
            {
                connection.Open();
                SqlCommand command = new SqlCommand("sp_DeleteKaynaklar", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@kaynak_id", secilenId);
               
            }

            db.Kaynaklar.Remove(silinenKaynak);
            db.SaveChanges();
            var kaynaklar = db.Kaynaklar.ToList();
            dataGridView1.DataSource = kaynaklar.ToList();

        }
        KutuphaneOtomasyonuEntities5 db = new KutuphaneOtomasyonuEntities5();
        private void KaynakSilForm_Load(object sender, EventArgs e)
        {
            var kaynaklar = db.Kaynaklar.ToList();
            dataGridView1.DataSource = kaynaklar.ToList();

            //İd ve kayıtları gizledi
            dataGridView1.Columns[0].Visible = false;
           

            //kalan kolonların isimleri düzenlendi
            dataGridView1.Columns[1].HeaderText = "Kaynak Adı";
            dataGridView1.Columns[2].HeaderText = "Yazar";
            dataGridView1.Columns[3].HeaderText = "Yayıncı";
            dataGridView1.Columns[4].HeaderText = "Sayfa Sayısı";
            dataGridView1.Columns[5].HeaderText = "Basım Tarihi";

        }
    }
}
