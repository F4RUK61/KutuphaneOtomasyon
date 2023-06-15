using KutuphaneOtomasyon.Kayit;
using KutuphaneOtomasyon.Kaynak;
using KutuphaneOtomasyon.Kullanici;
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
    public partial class IslemPaneli : Form
    {

        KutuphaneOtomasyonuEntities5 db = new KutuphaneOtomasyonuEntities5();
        public IslemPaneli()
        {
            InitializeComponent();
        }
        
        private void Ekle_Click(object sender, EventArgs e)
        {
            
        }

        private void IslemPaneli_Load(object sender, EventArgs e)
        {
            // Kullanici Butonları Girişte Kapalıdır
            silKullanicibtn.Visible = false;
            ekleKullanicibtn.Visible = false;
            güncelleKullanicibtn.Visible = false;

            // Kaynak Butonları Girişte Kapalıdır
            ekleKaynakbtn.Visible = false;
            guncelleKaynakbtn.Visible = false;
            silKaynakbtn.Visible = false;
        }
        KullaniciListeForm klisteForm;
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (ekleKullanicibtn.Visible == false)
            {
                ekleKullanicibtn.Visible = true;
                güncelleKullanicibtn.Visible = true;
                silKullanicibtn.Visible = true;
                klisteForm = new KullaniciListeForm();
                klisteForm.MdiParent = this;
                klisteForm.Show();
            }
            else 
            {
                ekleKullanicibtn.Visible = false;
                silKullanicibtn.Visible = false;
                güncelleKullanicibtn.Visible = false;
                klisteForm.Close();
            }

            


        }

        private void ekleKullanicibtn_Click(object sender, EventArgs e)
        {
            KullaniciEkleForm ekleForm = new KullaniciEkleForm();
            ekleForm.MdiParent = this;
            ekleForm.Show();

        }

        private void silKullanicibtn_Click(object sender, EventArgs e)
        {
            KullaniciSilForm kSil = new KullaniciSilForm();
            kSil.MdiParent = this;
            kSil.Show();
        }

        private void güncelleKullanicibtn_Click(object sender, EventArgs e)
        {
            KullaniciGuncelleForm kGuncel = new KullaniciGuncelleForm();
            kGuncel.MdiParent = this;
            kGuncel.Show();
        }

        KaynakListeForm Kliste;
        private void button2_Click(object sender, EventArgs e)
        {
            if (ekleKaynakbtn.Visible == false)
            {
                ekleKaynakbtn.Visible = true;
                guncelleKaynakbtn.Visible = true;
                silKaynakbtn.Visible = true;
                Kliste = new KaynakListeForm();
                Kliste.MdiParent = this;
                Kliste.Show();
            }
            else
            {
                ekleKaynakbtn.Visible = false;
                guncelleKaynakbtn.Visible = false;
                silKaynakbtn.Visible = false;
                Kliste.Close();
            }

            
        }

        private void ekleKaynakbtn_Click(object sender, EventArgs e)
        {
            KaynakEkleForm kEkle = new KaynakEkleForm();
            kEkle.MdiParent = this;
            kEkle.Show();
        }

        private void silKaynakbtn_Click(object sender, EventArgs e)
        {
            KaynakSilForm kSil = new KaynakSilForm();
            kSil.MdiParent = this;
            kSil.Show();
        }

        private void guncelleKaynakbtn_Click(object sender, EventArgs e)
        {
            KaynakGuncelleForm kGuncel = new KaynakGuncelleForm();
            kGuncel.MdiParent = this;
            kGuncel.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OduncForm odunc = new OduncForm();
            odunc.MdiParent = this;
            odunc.Show();

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GeriAlForm geri = new GeriAlForm();
            geri.MdiParent = this;
            geri.Show();
        }

        private void kullaniciBilgiPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
