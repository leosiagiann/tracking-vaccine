using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace DelVaksinClient.Controllers
{
    public class PendudukController : Controller
    {
        public ActionResult Index(string NIK, string optional)
        {
            ServiceSemuaData.AllDataClient obj = new ServiceSemuaData.AllDataClient();
            IEnumerable<ServiceSemuaData.Penduduk> ambilAkun = obj.getAllPenduduk();
            bool cek = false;
            int status = new int();
            foreach (var p in ambilAkun)
            {
                if (p.NIK == NIK)
                {
                    status = (int)p.status;
                    cek = true;
                    break;
                }
            }
            if (optional == "true")
            {
                ViewBag.berhasil = true;
            }
            if (optional == "updateProfil")
            {
                ViewBag.update = true;
            }
            if (optional == "changePassword")
            {
                ViewBag.pw = true;
            }
            ViewBag.nik = NIK;
            ViewBag.status = status;
            ServiceSemuaData.Penduduk penduduk = obj.getByIdPenduduk(NIK);
            ViewBag.penduduk = penduduk;
            ViewBag.ulala = true;
            if (cek)
                return View(obj.getAllRegis_Vaksin());
            else
                return RedirectToAction("/Index", "Home", new { logout = "salahjalan" });
        }

        public ActionResult DaftarVaksin(string NIK)
        {
            ServiceSemuaFungsi.AllFuncClient obj = new ServiceSemuaFungsi.AllFuncClient();
            obj.daftarVaksin(NIK);
            return RedirectToAction("/Index", "Penduduk", new { NIK = NIK });
        }

        public ActionResult UpdateProfil(string nik, string nama, int umur, string alamat, string j_kel, HttpPostedFileBase file)
        {
            if(file != null)
            {
                string fileName = Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/Content/img"), fileName);
                file.SaveAs(path);
                ServiceSemuaFungsi.AllFuncClient obj = new ServiceSemuaFungsi.AllFuncClient();
                obj.ubahDataPenduduk(nik, nama, umur, alamat, j_kel, fileName);
            }
            else
            {
                ServiceSemuaData.AllDataClient obj = new ServiceSemuaData.AllDataClient();
                ServiceSemuaData.Penduduk penduduk = obj.getByIdPenduduk(nik);
                ServiceSemuaFungsi.AllFuncClient obj_ = new ServiceSemuaFungsi.AllFuncClient();
                obj_.ubahDataPenduduk(nik, nama, umur, alamat, j_kel, penduduk.profil);
            }
            return RedirectToAction("/Index", "Penduduk", new { NIK = nik, optional = "updateProfil" });
        }

        public ActionResult UpdatePassword(string nik, string password)
        {
            ServiceSemuaFungsi.AllFuncClient obj = new ServiceSemuaFungsi.AllFuncClient();
            obj.ubahPasswordPenduduk(nik, password);
            return RedirectToAction("/Index", "Penduduk", new { NIK = nik, optional = "changePassword" });
        }
    }
}