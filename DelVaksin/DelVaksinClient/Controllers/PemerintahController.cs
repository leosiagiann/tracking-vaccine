using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DelVaksinClient.Controllers
{
    public class PemerintahController : Controller
    {
        public ActionResult Index(string optional)
        {
            ServiceSemuaData.AllDataClient obj = new ServiceSemuaData.AllDataClient();
            ViewBag.iniPem = true;
            if (optional == "true")
            {
                ViewBag.berhasil = true;
            }
            if (optional == "terima")
            {
                ViewBag.terima = true;
            }
            if (optional == "tolak")
            {
                ViewBag.tolak = true;
            }
            return View(obj.getAllPenduduk());
        }

        public ActionResult Terima(string id)
        {
            ServicePemerintah.SPemerintahClient obj = new ServicePemerintah.SPemerintahClient();
            ServiceSemuaData.AllDataClient obj_ = new ServiceSemuaData.AllDataClient();
            ServiceSemuaData.Penduduk penduduk = obj_.getByIdPenduduk(id);
            ServicePemerintah.Penduduk penduduk1 = new ServicePemerintah.Penduduk
            {
                NIK = penduduk.NIK
            };
            obj.confirNik(penduduk1, "terima");
            return RedirectToAction("/Index", "Pemerintah", new { optional = "terima" });
        }

        public ActionResult Tolak(string id)
        {
            ServicePemerintah.SPemerintahClient obj = new ServicePemerintah.SPemerintahClient();
            ServiceSemuaData.AllDataClient obj_ = new ServiceSemuaData.AllDataClient();
            ServiceSemuaData.Penduduk penduduk = obj_.getByIdPenduduk(id);
            ServicePemerintah.Penduduk penduduk1 = new ServicePemerintah.Penduduk
            {
                NIK = penduduk.NIK
            };
            obj.confirNik(penduduk1, "tolak");
            return RedirectToAction("/Index", "Pemerintah", new { optional = "tolak" });
        }

        public ActionResult ListPenduduk()
        {
            ServiceSemuaData.AllDataClient obj = new ServiceSemuaData.AllDataClient();
            IList<ServiceSemuaData.Vaksin_Veried> vaksin = obj.getAllVaksin_Veried();
            ViewBag.vaksin = vaksin;
            ViewBag.iniPem = true;
            return View(obj.getAllPenduduk());
        }
    }
}