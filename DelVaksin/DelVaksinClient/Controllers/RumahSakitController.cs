using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DelVaksinClient.Controllers
{
    public class RumahSakitController : Controller
    {
        public ActionResult Index(string optional)
        {
            ServiceSemuaData.AllDataClient obj = new ServiceSemuaData.AllDataClient();
            ViewBag.inirumsak = true;
            if (optional == "true")
            {
                ViewBag.berhasil = true;
            }
            if (optional == "sampai")
            {
                ViewBag.sampai = true;
            }
            return View(obj.getAllVaksin());
        }

        public ActionResult Report(string id)
        {
            ServiceBPOM.SBPOMClient obj = new ServiceBPOM.SBPOMClient();
            obj.ReportVaksinSampai(id);
            return RedirectToAction("/Index", "RumahSakit", new { optional = "sampai" });
        }

        public ActionResult Gunakan(string id)
        {
            ServiceSemuaData.AllDataClient obj = new ServiceSemuaData.AllDataClient();
            IList<ServiceSemuaData.Penduduk> penduduk = obj.getAllPenduduk();
            ViewBag.penduduk = penduduk;
            ViewBag.id = id;
            ViewBag.inirumsak = true;
            return View();
        }

        public ActionResult GunakanVaksin(string id, string nik, string nama)
        {
            ServiceSemuaFungsi.AllFuncClient obj = new ServiceSemuaFungsi.AllFuncClient();
            ServiceSemuaFungsi.Vaksin_Veried vaksin_Veried = new ServiceSemuaFungsi.Vaksin_Veried
            {
                ID_vaksin = id,
                NIK = nik,
                nama_perawat = nama
            };
            obj.gunakanVaksinPenduduk(vaksin_Veried);
            obj.balikStatusPenduduk(nik);
            obj.vaksinSudahTerpakai(id);
            return RedirectToAction("/Index", "RumahSakit");
        }

        public ActionResult History()
        {
            ServiceSemuaData.AllDataClient obj = new ServiceSemuaData.AllDataClient();
            ViewBag.inirumsak = true;
            return View(obj.getAllVaksin_Veried());
        }

        public ActionResult ReportVaksin(string optional)
        {
            ServiceSemuaData.AllDataClient obj = new ServiceSemuaData.AllDataClient();
            ViewBag.inirumsak = true;
            if (optional == "gunakan")
            {
                ViewBag.gunakan = true;
            }
            return View(obj.getAllVaksin());
        }

        public ActionResult ReportUse(string id)
        {
            ServiceBPOM.SBPOMClient obj = new ServiceBPOM.SBPOMClient();
            obj.ReportVaksindiGunakan(id);
            return RedirectToAction("/ReportVaksin", "RumahSakit", new { optional = "gunakan" });
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
            ViewBag.inirumsak = true;
            return View();
        }
    }
}