using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cet.Models
{
    public class Etkinlik
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Etkinlik Adı")]
        [Required(ErrorMessage = "{0} boş geçilemez.")]
        public string Baslik { get; set; }

        [Display(Name = "Resim")]
        public byte[] EtkinlikFoto { get; set; }

        [Display(Name = "Tarih")]
        public DateTime Tarih { get; set; }

        [Display(Name = "Yer")]
        [Required(ErrorMessage = "{0} boş geçilemez.")]
        public string Yer { get; set; }

        [Display(Name = "İçerik")]
        [UIHint("tinymce_full_compressed"), AllowHtml]
        public string Icerik { get; set; }
    }
}