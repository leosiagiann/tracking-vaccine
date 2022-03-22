using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DelVaksin
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AllFunc" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AllFunc.svc or AllFunc.svc.cs at the Solution Explorer and start debugging.
    public class AllFunc : IAllFunc
    {
        //Fungsi Untuk Rumah Sakit
        public bool gunakanVaksin(Vaksin vaksin)
        {
            DEL_VAKSINEntities delVaksin = new DEL_VAKSINEntities();
            Vaksin report = delVaksin.Vaksins.SingleOrDefault(x => x.ID_vaksin == vaksin.ID_vaksin);
            report.status = 7;
            delVaksin.SaveChanges();
            delVaksin.Dispose();
            return true;
        }

        //Fungsi Untuk Penduduk
        public bool Register(Penduduk penduduk)
        {
            DEL_VAKSINEntities delVaksin = new DEL_VAKSINEntities();
            delVaksin.Penduduks.Add(penduduk);
            delVaksin.SaveChanges();
            delVaksin.Dispose();
            return true;
        }

        //Fungsi Untuk Produsen
        public bool editVaksin(Vaksin vaksin)
        {
            DEL_VAKSINEntities delVaksin = new DEL_VAKSINEntities();
            Vaksin report = delVaksin.Vaksins.SingleOrDefault(x => x.ID_vaksin == vaksin.ID_vaksin);
            report.nama = vaksin.nama;
            delVaksin.SaveChanges();
            delVaksin.Dispose();
            return true;
        }

        //Fungsi Untuk Produsen
        public bool tambahVaksin(Vaksin vaksin)
        {
            DEL_VAKSINEntities delVaksin = new DEL_VAKSINEntities();
            delVaksin.Vaksins.Add(vaksin);
            delVaksin.SaveChanges();
            delVaksin.Dispose();
            return true;
        }

        //Fungsi Untuk Badan POM
        public bool terimaVaksin(Vaksin vaksin)
        {
            DEL_VAKSINEntities delVaksin = new DEL_VAKSINEntities();
            Vaksin t_vaksin = delVaksin.Vaksins.SingleOrDefault(x => x.ID_vaksin == vaksin.ID_vaksin);
            t_vaksin.status = 1;
            delVaksin.SaveChanges();
            Regis_Vaksin r_vaksin = delVaksin.Regis_Vaksin.SingleOrDefault(x => x.ID_vaksin == vaksin.ID_vaksin);
            r_vaksin.status = 1;
            delVaksin.SaveChanges();
            delVaksin.Dispose();
            return true;
        }

        //Fungsi Untuk Badan POM
        public bool tolakVaksin(Vaksin vaksin)
        {
            DEL_VAKSINEntities delVaksin = new DEL_VAKSINEntities();
            Vaksin t_vaksin = delVaksin.Vaksins.SingleOrDefault(x => x.ID_vaksin == vaksin.ID_vaksin);
            t_vaksin.status = 2;
            delVaksin.SaveChanges();
            Regis_Vaksin r_vaksin = delVaksin.Regis_Vaksin.SingleOrDefault(x => x.ID_vaksin == vaksin.ID_vaksin);
            r_vaksin.status = 2;
            delVaksin.SaveChanges();
            delVaksin.Dispose();
            return true;
        }

        //Fungsi Untuk Produsen
        public bool hapusVaksin(string id)
        {
            DEL_VAKSINEntities delVaksin = new DEL_VAKSINEntities();
            Vaksin t_vaksin = delVaksin.Vaksins.SingleOrDefault(x => x.ID_vaksin == id);
            delVaksin.Vaksins.Remove(t_vaksin);
            delVaksin.SaveChanges();
            delVaksin.Dispose();
            return true;
        }

        //Fungsi Untuk Produsen
        public bool kirimVaksin(string id)
        {
            DEL_VAKSINEntities delVaksin = new DEL_VAKSINEntities();
            Vaksin t_vaksin = delVaksin.Vaksins.SingleOrDefault(x => x.ID_vaksin == id);
            t_vaksin.status = 5;
            delVaksin.SaveChanges();
            delVaksin.Dispose();
            return true;
        }

        //Fungsi Untuk Badan POM
        public bool bagikanVaksinId(string id)
        {
            DEL_VAKSINEntities delVaksin = new DEL_VAKSINEntities();
            Regis_Vaksin vaksin = delVaksin.Regis_Vaksin.SingleOrDefault(x => x.ID_vaksin == id);
            vaksin.status = 4;
            delVaksin.SaveChanges();
            delVaksin.Dispose();
            return true;
        }

        //Fungsi Untuk Badan POM
        public bool bagikanVaksinAll()
        {
            DEL_VAKSINEntities delVaksin = new DEL_VAKSINEntities();
            IEnumerable<Regis_Vaksin> vaksin = from p in delVaksin.Regis_Vaksin where p.status == 1 select p;
            foreach (var x in vaksin)
            {
                x.status = 4;
            }
            delVaksin.SaveChanges();
            delVaksin.Dispose();
            return true;
        }

        //Fungsi Untuk Penduduk
        public bool daftarVaksin(string NIK)
        {
            DEL_VAKSINEntities delVaksin = new DEL_VAKSINEntities();
            Penduduk penduduk = delVaksin.Penduduks.SingleOrDefault(x => x.NIK == NIK);
            penduduk.status = 3;
            delVaksin.SaveChanges();
            delVaksin.Dispose();
            return true;
        }

        //Fungsi Untuk RumahSakit
        public bool gunakanVaksinPenduduk(Vaksin_Veried vaksin)
        {
            DEL_VAKSINEntities delVaksin = new DEL_VAKSINEntities();
            delVaksin.Vaksin_Veried.Add(vaksin);
            delVaksin.SaveChanges();
            delVaksin.Dispose();
            return true;
        }

        public bool vaksinSudahTerpakai(string id)
        {
            DEL_VAKSINEntities delVaksin = new DEL_VAKSINEntities();
            Vaksin vaksin = delVaksin.Vaksins.SingleOrDefault(x => x.ID_vaksin == id);
            vaksin.status = 7;
            delVaksin.SaveChanges();
            delVaksin.Dispose();
            return true;
        }

        public bool balikStatusPenduduk(string NIK)
        {
            DEL_VAKSINEntities delVaksin = new DEL_VAKSINEntities();
            Penduduk penduduk = delVaksin.Penduduks.SingleOrDefault(x => x.NIK == NIK);
            penduduk.status = 0;
            delVaksin.SaveChanges();
            delVaksin.Dispose();
            return true;
        }

        public bool ubahDataPenduduk(string nik, string nama, int umur, string alamat, string j_kel, string profil)
        {
            DEL_VAKSINEntities delVaksin = new DEL_VAKSINEntities();
            Penduduk penduduk = delVaksin.Penduduks.SingleOrDefault(x => x.NIK == nik);
            penduduk.nama = nama;
            penduduk.umur = umur;
            penduduk.alamat = alamat;
            penduduk.jenis_kelamin = j_kel;
            penduduk.profil = profil;
            delVaksin.SaveChanges();
            delVaksin.Dispose();
            return true;
        }

        public bool ubahPasswordPenduduk(string nik, string password)
        {
            DEL_VAKSINEntities delVaksin = new DEL_VAKSINEntities();
            Penduduk penduduk = delVaksin.Penduduks.SingleOrDefault(x => x.NIK == nik);
            penduduk.pass = password;
            delVaksin.SaveChanges();
            delVaksin.Dispose();
            return true;
        }
    }
}
