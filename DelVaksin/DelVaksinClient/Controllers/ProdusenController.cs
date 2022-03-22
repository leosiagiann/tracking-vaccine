using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DelVaksinClient.Controllers
{
    public class ProdusenController : Controller
    {
        public ActionResult Index(string optional)
        {
            ServiceSemuaData.AllDataClient obj = new ServiceSemuaData.AllDataClient();
            if (optional == "true")
            {
                ViewBag.berhasil = true;
            }
            if (optional == "tambah")
            {
                ViewBag.tambah = true;
            }
            if (optional == "edit")
            {
                ViewBag.edit = true;
            }
            if (optional == "hapus")
            {
                ViewBag.hapus = true;
            }
            if (optional == "verifikasi")
            {
                ViewBag.verifikasi = true;
            }
            if (optional == "kirim")
            {
                ViewBag.kirim = true;
            }
            return View(obj.getAllVaksin());
        }

        public ActionResult TambahVaksin(string id, string nama)
        {
            ServiceSemuaFungsi.AllFuncClient obj = new ServiceSemuaFungsi.AllFuncClient();
            ServiceSemuaFungsi.Vaksin vaksinBaru = new ServiceSemuaFungsi.Vaksin
            {
                ID_vaksin = id,
                nama = nama,
                status = 0
            };
            obj.tambahVaksin(vaksinBaru);
            return RedirectToAction("/Index", "Produsen", new { optional = "tambah" });
        }

        public ActionResult Delete(string id)
        {
            ServiceSemuaFungsi.AllFuncClient obj = new ServiceSemuaFungsi.AllFuncClient();
            obj.hapusVaksin(id);
            return RedirectToAction("/Index", "Produsen", new { optional = "hapus" });
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            ServiceSemuaData.AllDataClient obj = new ServiceSemuaData.AllDataClient();
            ServiceSemuaData.Vaksin vaksin = obj.getByIdVaksin(id);
            return View(vaksin);
        }

        [HttpPost]
        public ActionResult Edit(ServiceSemuaData.Vaksin vaksin)
        {
            ServiceSemuaFungsi.AllFuncClient obj = new ServiceSemuaFungsi.AllFuncClient();
            ServiceSemuaFungsi.Vaksin vaksinBaru = new ServiceSemuaFungsi.Vaksin
            {
                ID_vaksin = vaksin.ID_vaksin,
                nama = vaksin.nama,
                status = vaksin.status
            };
            obj.editVaksin(vaksinBaru);
            return RedirectToAction("/Index", "Produsen", new { optional = "edit" });
        }

        public ActionResult Verifikasi(string id)
        {
            ServiceSemuaData.AllDataClient objdata = new ServiceSemuaData.AllDataClient();
            ServiceSemuaData.Vaksin vaksin = objdata.getByIdVaksin(id);
            ServiceBPOM.SBPOMClient obj = new ServiceBPOM.SBPOMClient();
            ServiceBPOM.Vaksin vaksinRegis = new ServiceBPOM.Vaksin
            {
                ID_vaksin = vaksin.ID_vaksin,
                nama = vaksin.nama,
                status = vaksin.status
            };
            obj.RegisVaksin(vaksinRegis);
            return RedirectToAction("/Index", "Produsen", new { optional = "verifikasi" });
        }

        public ActionResult Detail(string id)
        {
            ServiceSemuaData.AllDataClient obj = new ServiceSemuaData.AllDataClient();
            ServiceSemuaData.Vaksin vaksin = obj.getByIdVaksin(id);
            ViewBag.id = vaksin.ID_vaksin;
            ViewBag.nama = vaksin.nama;
            ViewBag.status = vaksin.status;
            return View();
        }

        public ActionResult Send(string id)
        {
            ServiceSemuaFungsi.AllFuncClient obj = new ServiceSemuaFungsi.AllFuncClient();
            obj.kirimVaksin(id);
            return RedirectToAction("/Index", "Produsen", new { optional = "kirim" });
            return RedirectToAction("/Index");
        }
    }
}