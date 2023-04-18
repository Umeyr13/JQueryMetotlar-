using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JQueryMetotları.Controllers
{
    public class HomeController : Controller
    {
        private static List<string> liste = new List<string>() { "Teknoloji", "Gıda", "Giyim", "Sağlık" };
        // GET: Home
      

        public ActionResult Index()
        {
            return View();
        } 
        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult Index3()
        {
            return View();
        }

        public ActionResult Index4()
        {
            return View();
        }

        public ActionResult Index5()
        {
            return View();
        }

        public ActionResult Index6()
        {
            return View();
        }

        [HttpPost]
        public JsonResult DosyaYukle(HttpPostedFileBase file)
        {
            if (file !=null)
            {
                if (Directory.Exists(Server.MapPath("~/file")) == false) // Eğer dosya yoksa..
                {
                    Directory.CreateDirectory(Server.MapPath("~/file")); // Dosyayı oluştur..
                }

                file.SaveAs(Path.Combine(Server.MapPath("~/file"),file.FileName));
                return Json(new {hata = false, mesaj="Dosya Yüklendi başka yolu "});
            }
            return Json(new {hata = true, mesaj = "Dosya Yüklenemedi başka yolu " });// Bu şekilde yaparsak index4 te if e gerek kalmaz alert(sonuc.mesaj) olurdu.
        }


        public PartialViewResult VerileriGetir(string Veri="")//istersek ayrıda yapabilirdik. default değer vervip bu şekilde if ile yaptık
        {
            if (string.IsNullOrEmpty(Veri)==false)
            {
                liste.Add(Veri);
            }
            System.Threading.Thread.Sleep(2000);
            return PartialView("_PartialPageListe",liste);
        }

        public JsonResult VerileriGetir_Client(string Veri = "")//istersek ayrıda yapabilirdik. default değer vervip bu şekilde if ile yaptık
        {
            if (string.IsNullOrEmpty(Veri) == false)
            {
                liste.Add(Veri);
            }
            System.Threading.Thread.Sleep(2000);
            return Json(liste,JsonRequestBehavior.AllowGet);//["Teknoloji","Giyim" şeklinde verileri göndericek]
        }
    }
}