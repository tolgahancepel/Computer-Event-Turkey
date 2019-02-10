using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cet.Models
{
    public class Blog
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Makale başlığını giriniz."), Display(Name = "Başlık")]
        public string Baslik { get; set; }

        [DisplayName("İçerik")]
        [UIHint("tinymce_full_compressed"), AllowHtml]
        public string Icerik { get; set; }

        public byte[] BlogFoto { get; set; }

        [DisplayName("Olusturma Tarihi")]
        public Nullable<System.DateTime> OlusturmaTarihi { get; set; }

    }
}