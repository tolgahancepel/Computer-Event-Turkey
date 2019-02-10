using cet.DAL;
using cet.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cet.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Etkinlik()
        {
            using (cetContext context = new cetContext())
            {
                var etkinlik = context.Etkinlik.ToList();
                return View(etkinlik);
            }
        }

        public ActionResult EtkinlikEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EtkinlikEkle(Etkinlik e, HttpPostedFileBase file)
        {
            try
            {
                using (cetContext context = new cetContext())
                {
                    Etkinlik _etkinlik = new Etkinlik();

                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _etkinlik.EtkinlikFoto = memoryStream.ToArray();
                    }
                    _etkinlik.Baslik = e.Baslik;
                    _etkinlik.Tarih = e.Tarih;
                    _etkinlik.Yer = e.Yer;
                    _etkinlik.Icerik = e.Icerik;
                    context.Etkinlik.Add(_etkinlik);
                    context.SaveChanges();
                    return RedirectToAction("Etkinlik", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu" + ex.Message);
            }
        }


        public ActionResult EtkinlikDuzenle(int EtkinlikID)
        {
            using (cetContext context = new cetContext())
            {
                var _etkinlikDuzenle = context.Etkinlik.Where(x => x.Id == EtkinlikID).FirstOrDefault();
                return View(_etkinlikDuzenle);
            }
        }

        [HttpPost]
        public ActionResult EtkinlikDuzenle(Etkinlik etkinlik, HttpPostedFileBase file)
        {
            try
            {
                using (cetContext context = new cetContext())
                {
                    var _etkinlikDuzenle = context.Etkinlik.Where(x => x.Id == etkinlik.Id).FirstOrDefault();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _etkinlikDuzenle.EtkinlikFoto = memoryStream.ToArray();
                    }
                    _etkinlikDuzenle.Baslik = etkinlik.Baslik;
                    _etkinlikDuzenle.Tarih = etkinlik.Tarih;
                    _etkinlikDuzenle.Yer = etkinlik.Yer;
                    _etkinlikDuzenle.Icerik = etkinlik.Icerik;
                    context.SaveChanges();
                    return RedirectToAction("Etkinlik", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Güncellerken hata oluştu" + ex.Message);
            }

        }


        public ActionResult EtkinlikSil(int EtkinlikId)
        {
            try
            {
                using (cetContext context = new cetContext())
                {
                    context.Etkinlik.Remove(context.Etkinlik.First(d => d.Id == EtkinlikId));
                    context.SaveChanges();
                    return RedirectToAction("Etkinlik", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu" + ex.InnerException);
            }
        }


        // BLOG FONKSİYONLARI

        public ActionResult Blog()
        {
            using (cetContext context = new cetContext())
            {
                var blog = context.Blog.ToList();
                return View(blog);
            }
        }

        public ActionResult BlogEkle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult BlogEkle(Blog b, HttpPostedFileBase file)
        {
            try
            {
                using (cetContext context = new cetContext())
                {
                    Blog _blog = new Blog();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _blog.BlogFoto = memoryStream.ToArray();
                    }
                    _blog.Baslik = b.Baslik;
                    _blog.OlusturmaTarihi = DateTime.Now;
                    _blog.Icerik = b.Icerik;
                    context.Blog.Add(_blog);
                    context.SaveChanges();
                    return RedirectToAction("Blog", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu" + ex.Message);
            }
        }


        public ActionResult BlogDuzenle(int BlogID)
        {
            using (cetContext context = new cetContext())
            {
                var _blogduzenle = context.Blog.Where(x => x.Id == BlogID).FirstOrDefault();
                return View(_blogduzenle);
            }
        }

        [HttpPost]
        public ActionResult BlogDuzenle(Blog blog, HttpPostedFileBase file)
        {
            try
            {
                using (cetContext context = new cetContext())
                {
                    var _blogduzenle = context.Blog.Where(x => x.Id == blog.Id).FirstOrDefault();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _blogduzenle.BlogFoto = memoryStream.ToArray();
                    }
                    _blogduzenle.Baslik = blog.Baslik;
                    _blogduzenle.OlusturmaTarihi = blog.OlusturmaTarihi;
                    _blogduzenle.Icerik = blog.Icerik;
                    context.SaveChanges();
                    return RedirectToAction("Blog", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Güncellerken hata oluştu" + ex.Message);
            }
        }


        public ActionResult BlogSil(int BlogId)
        {
            try
            {
                using (cetContext context = new cetContext())
                {
                    context.Blog.Remove(context.Blog.First(d => d.Id == BlogId));
                    context.SaveChanges();
                    return RedirectToAction("Blog", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu" + ex.InnerException);
            }
        }

        // SLIDER FONKSİYONLARI

        public ActionResult Slider()
        {
            using (cetContext context = new cetContext())
            {
                var slider = context.Slider.ToList();
                return View(slider);
            }
        }


        public ActionResult SliderEkle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SliderEkle(Slider s, HttpPostedFileBase file)
        {
            try
            {
                using (cetContext context = new cetContext())
                {
                    Slider _slider = new Slider();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _slider.SliderFoto = memoryStream.ToArray();
                    }
                    _slider.BitisTarihi = s.BitisTarihi;
                    context.Slider.Add(_slider);
                    context.SaveChanges();
                    return RedirectToAction("Slider", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu" + ex.Message);
            }
        }






        public ActionResult SliderDuzenle(int SliderID)
        {
            using (cetContext context = new cetContext())
            {
                var _sliderDuzenle = context.Slider.Where(x => x.ID == SliderID).FirstOrDefault();
                return View(_sliderDuzenle);
            }
        }

        [HttpPost]
        public ActionResult SliderDuzenle(Slider slider, HttpPostedFileBase file)
        {
            try
            {
                using (cetContext context = new cetContext())
                {
                    var _sliderDuzenle = context.Slider.Where(x => x.ID == slider.ID).FirstOrDefault();
                    if (file != null && file.ContentLength > 0)
                    {
                        MemoryStream memoryStream = file.InputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            file.InputStream.CopyTo(memoryStream);
                        }
                        _sliderDuzenle.SliderFoto = memoryStream.ToArray();
                    }
                    _sliderDuzenle.BitisTarihi = slider.BitisTarihi;
                    context.SaveChanges();
                    return RedirectToAction("Slider", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Güncellerken hata oluştu" + ex.Message);
            }

        }


        public ActionResult SliderSil(int SliderId)
        {
            try
            {
                using (cetContext context = new cetContext())
                {
                    context.Slider.Remove(context.Slider.First(d => d.ID == SliderId));
                    context.SaveChanges();
                    return RedirectToAction("Slider", "Admin");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu" + ex.InnerException);
            }
        }


    }
}