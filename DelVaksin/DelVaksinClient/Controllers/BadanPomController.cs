using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DelVaksinClient.Controllers
{
    public class BadanPomController : Controller
    {
        public ActionResult Index(string optional)
        {
            ServiceSemuaData.AllDataClient obj = new ServiceSemuaData.AllDataClient();
            ViewBag.iniprod = true;
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
            return View(obj.getAllRegis_Vaksin());
        }

        public ActionResult Tolak(string id)
        {
            ServiceSemuaData.AllDataClient obj = new ServiceSemuaData.AllDataClient();
            ServiceSemuaData.Vaksin vaksin = obj.getByIdVaksin(id);
            ServiceSemuaFungsi.AllFuncClient objFungsi = new ServiceSemuaFungsi.AllFuncClient();
            ServiceSemuaFungsi.Vaksin vaksinTake = new ServiceSemuaFungsi.Vaksin
            {
                ID_vaksin = vaksin.ID_vaksin,
                nama = vaksin.nama,
                status = vaksin.status
            };
            objFungsi.tolakVaksin(vaksinTake);
            return RedirectToAction("/Index", "BadanPom", new { optional = "tolak" });
        }

        public ActionResult Terima(string id)
        {
            ServiceSemuaData.AllDataClient obj = new ServiceSemuaData.AllDataClient();
            ServiceSemuaData.Vaksin vaksin = obj.getByIdVaksin(id);
            ServiceSemuaFungsi.AllFuncClient objFungsi = new ServiceSemuaFungsi.AllFuncClient();
            ServiceSemuaFungsi.Vaksin vaksinTake = new ServiceSemuaFungsi.Vaksin
            {
                ID_vaksin = vaksin.ID_vaksin,
                nama = vaksin.nama,
                status = vaksin.status
            };
            objFungsi.terimaVaksin(vaksinTake);
            return RedirectToAction("/Index", "BadanPom", new { optional = "terima" });
        }

        public ActionResult Bagikan()
        {
            ServiceSemuaData.AllDataClient obj = new ServiceSemuaData.AllDataClient();
            ViewBag.iniprod = true;
            return View(obj.getAllRegis_Vaksin());
        }

        public ActionResult Sebar(string id)
        {
            ServiceSemuaFungsi.AllFuncClient obj = new ServiceSemuaFungsi.AllFuncClient();
            obj.bagikanVaksinId(id);
            return RedirectToAction("/Bagikan", "BadanPom", new { optional = "sebar" });
        }

        public ActionResult TampilSemua()
        {
            ServiceSemuaFungsi.AllFuncClient obj = new ServiceSemuaFungsi.AllFuncClient();
            obj.bagikanVaksinAll();
            return RedirectToAction("/Bagikan");
        }

        public ActionResult LihatSampai()
        {
            ServiceSemuaData.AllDataClient obj = new ServiceSemuaData.AllDataClient();
            ViewBag.iniprod = true;
            return View(obj.getAllVaksin());
        }

        public ActionResult LihatPakai()
        {
            ServiceSemuaData.AllDataClient obj = new ServiceSemuaData.AllDataClient();
            ViewBag.iniprod = true;
            return View(obj.getAllVaksin());
        }

        public ActionResult Detail(string id)
        {
            ServiceSemuaData.AllDataClient obj = new ServiceSemuaData.AllDataClient();
            ServiceSemuaData.Vaksin_Veried vaksin_veried = obj.getByIdVaksin_Veried(id);
            ServiceSemuaData.Vaksin vaksin = obj.getByIdVaksin(vaksin_veried.ID_vaksin);
            ServiceSemuaData.Penduduk penduduk = obj.getByIdPenduduk(vaksin_veried.NIK);
            ViewBag.nik = penduduk.NIK;
            ViewBag.namaPenduduk = penduduk.nama;
            ViewBag.j_kel = penduduk.jenis_kelamin;
            ViewBag.alamat = penduduk.alamat;
            ViewBag.umur = penduduk.umur;
            ViewBag.id = vaksin.ID_vaksin;
            ViewBag.namaVaksin = vaksin.nama;
            ViewBag.namaPerawat = vaksin_veried.nama_perawat;
            ViewBag.iniprod = true;
            return View();
        }
    }
}