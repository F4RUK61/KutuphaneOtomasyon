//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KutuphaneOtomasyon
{
    using System;
    using System.Collections.Generic;
    
    public partial class Personeller
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personeller()
        {
            this.Kayitlar = new HashSet<Kayitlar>();
        }
    
        public int Personel_id { get; set; }
        public string Personel_ad { get; set; }
        public string Personel_soyad { get; set; }
        public string Personel_tc { get; set; }
        public string Personel_tel { get; set; }
        public string Personel_mail { get; set; }
        public string Persone_kullaniciAd { get; set; }
        public string Personel_sifre { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kayitlar> Kayitlar { get; set; }
    }
}