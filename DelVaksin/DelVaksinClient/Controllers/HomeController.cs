using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DelVaksinClient.ServiceSemuaData;

namespace DelVaksinClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string logout)
        {
            if(logout == "true")
            {
                ViewBag.Logout = true;
            }
            if (logout == "false")
            {
                ViewBag.Wrong = true;
            }
            if (logout == "salahjalan")
            {
                ViewBag.WrongWay = true;
            }
            ViewBag.session = "Home";
            return View();
        }
        
        public ActionResult Logout()
        {
            return RedirectToAction("/Index", "Home", new { logout = "true" });
        }

        public ActionResult LoginUser(string username, string password)
        {
            ServiceSemuaData.AllDataClient obj = new ServiceSemuaData.AllDataClient();
            IList<Akun> ambilAkun = obj.getAllAkun();
            string role = "", NIK = "";
            bool cek = false, pen = false;
            foreach (var p in ambilAkun)
            {
                if (p.username == username && p.pass == password)
                {
                    role = p.roll;
                    cek = true;
                    break;
                }
            }
            if (cek) { }
            else
            {
                IList<Penduduk> ambilPenduduk = obj.getAllPenduduk();
                foreach (var p in ambilPenduduk)
                {
                    if (p.username == username && p.pass == password)
                    {
                        role = "Penduduk";
                        NIK = p.NIK;
                        cek = true;
                        pen = true;
                        break;
                    }
                }
            }
            if (cek)
            {
                if (pen) return RedirectToAction("/Index", role, new { NIK = NIK, optional = "true" });
                else return RedirectToAction("/Index", role, new { optional = "true" });
            }
            else
            {
                return RedirectToAction("/Index", "Home", new { logout = "false" });
            }
        }

        public ActionResult RegistrasiUser(string NIK, string nama, int umur, string alamat, string j_kel, string username, string password)
        {
            ServiceSemuaFungsi.AllFuncClient obj = new ServiceSemuaFungsi.AllFuncClient();
            string photo;
            if (j_kel == "L") photo = "cowok.jpg";
            else photo = "cewek.jpg";
            ServiceSemuaFungsi.Penduduk penduduk = new ServiceSemuaFungsi.Penduduk
            {
                NIK = NIK,
                nama = nama,
                umur = umur,
                alamat = alamat,
                jenis_kelamin = j_kel,
                username = username,
                pass = password,
                profil = photo,
                status = 0
            };
            obj.Register(penduduk);
            return RedirectToAction("/Index");
        }
    }
}