using cet.DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cet.Models
{
    public class HomeController : Controller
    {
        cetContext db = new cetContext();

        // GET: Home
        public ActionResult Index()
        {
            
            List<Slider> slider = db.Slider.OrderByDescending(x => x.BitisTarihi).Take(3).ToList();
            return View(slider);
        }

        public ActionResult Etkinlikler()
        {
            using (cetContext context = new cetContext())
            {
                List<Etkinlik> etkinlik = context.Etkinlik.Where(x => x.Tarih >= DateTime.Now).OrderBy(x => x.Tarih).ToList();
                return View(etkinlik);
            }
        }

        [Authorize(Roles = "Admin, kullanici")]
        public ActionResult Blog()
        {
            using (cetContext context = new cetContext())
            {
                List<Blog> blog = context.Blog.OrderBy(x => x.OlusturmaTarihi).ToList();
                return View(blog);
            }
        }

        public ActionResult Hakkimizda()
        {
            return View();
        }

        public ActionResult Iletisim()
        {
            return View();
        }

        public ActionResult EtkinlikDetay(int id)
        {
            var etkinlik = db.Etkinlik.Where(m => m.Id == id).SingleOrDefault();
            if (etkinlik == null)
            {
                return HttpNotFound();

            }
            return View(etkinlik);
        }

        [Authorize(Roles = "Admin, kullanici")]
        public ActionResult BlogDetay(int id)
        {
            var blog = db.Blog.Where(m => m.Id == id).SingleOrDefault();
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            Session["Culture"] = new CultureInfo(lang);
            return Redirect(returnUrl);
        }

    }
}