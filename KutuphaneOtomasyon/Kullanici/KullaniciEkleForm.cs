﻿using System;
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
    
    public partial class KullaniciEkleForm : Form
    {
        KutuphaneOtomasyonuEntities3 db = new KutuphaneOtomasyonuEntities3();
        public KullaniciEkleForm()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Kullanicilar kullanıcılar = new Kullanicilar();
            kullanıcılar.kullanici_ad = kullaniciAdtxt.Text;
            kullanıcılar.kullanici_soyad = kullaniciSoyadtxt.Text;
            kullanıcılar.kullanici_tc = kullaniciTCtxt.Text;
            kullanıcılar.kullanici_tel = kullaniciTeltxt.Text;
            kullanıcılar.kullanici_mail = kullaniciMailtxt.Text;
            kullanıcılar.kullanici_ceza = Convert.ToUInt16(kullaniciCezatxt.Text);
           
            db.Kullanicilar.Add(kullanıcılar);
            db.SaveChanges();
            Listele();

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
        private void KullaniciEkleForm_Load(object sender, EventArgs e)
        {
            Listele();
        }

        
    }
}
