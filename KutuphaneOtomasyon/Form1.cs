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
    public partial class Form1 : Form
    {
        KutuphaneOtomasyonuEntities3 db = new KutuphaneOtomasyonuEntities3();

        

        public Form1()
        {
            InitializeComponent();
        }

        private void PersonelGirişbtn_Click(object sender, EventArgs e)
        {
            string gelenAd = adGiristxt.Text;
            string gelenSifre = sifreGiristxt.Text;

            var personel = db.Personeller.Where(x => x.Persone_kullaniciAd.Equals(gelenAd)&&x.Personel_sifre.Equals(gelenSifre)).FirstOrDefault();

            if (personel == null) 
            {
                MessageBox.Show(text: "Kullanı adı veya Şifre hatalı");
            }
            else 
            {
                MessageBox.Show(text: "Başarılı");
                IslemPaneli panel = new IslemPaneli();
                panel.Show();
                this.Hide();
            }
            
            
        }

        private void sifreGiristxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
