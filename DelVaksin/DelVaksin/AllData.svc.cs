using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DelVaksin
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AllData" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AllData.svc or AllData.svc.cs at the Solution Explorer and start debugging.
    public class AllData : IAllData
    {
        public List<Akun> getAllAkun()
        {
            DEL_VAKSINEntities delVaksin = new DEL_VAKSINEntities();
            var temp = from p in delVaksin.Akuns select p;
            return temp.ToList<Akun>();
        }

        public List<Penduduk> getAllPenduduk()
        {
            DEL_VAKSINEntities delVaksin = new DEL_VAKSINEntities();
            var temp = from p in delVaksin.Penduduks select p;
            return temp.ToList<Penduduk>();
        }

        public List<Regis_Vaksin> getAllRegis_Vaksin()
        {
            DEL_VAKSINEntities delVaksin = new DEL_VAKSINEntities();
            var temp = from p in delVaksin.Regis_Vaksin select p;
            return temp.ToList<Regis_Vaksin>();
        }

        public List<Vaksin> getAllVaksin()
        {
            DEL_VAKSINEntities delVaksin = new DEL_VAKSINEntities();
            var temp = from p in delVaksin.Vaksins select p;
            return temp.ToList<Vaksin>();
        }

        public List<Vaksin_Veried> getAllVaksin_Veried()
        {
            DEL_VAKSINEntities delVaksin = new DEL_VAKSINEntities();
            var temp = from p in delVaksin.Vaksin_Veried select p;
            return temp.ToList<Vaksin_Veried>();
        }

        public Penduduk getByIdPenduduk(string NIK)
        {
            DEL_VAKSINEntities delVaksin = new DEL_VAKSINEntities();
            Penduduk penduduk = delVaksin.Penduduks.SingleOrDefault(x => x.NIK == NIK);
            return penduduk;
        }

        public Regis_Vaksin getByIdRegis_Vaksin(string id)
        {
            DEL_VAKSINEntities delVaksin = new DEL_VAKSINEntities();
            Regis_Vaksin regis_Vaksin = delVaksin.Regis_Vaksin.SingleOrDefault(x => x.ID_vaksin == id);
            return regis_Vaksin;
        }

        public Vaksin getByIdVaksin(string id)
        {
            DEL_VAKSINEntities delVaksin = new DEL_VAKSINEntities();
            Vaksin vaksin = delVaksin.Vaksins.SingleOrDefault(x => x.ID_vaksin == id);
            return vaksin;
        }

        public Vaksin_Veried getByIdVaksin_Veried(string id)
        {
            DEL_VAKSINEntities delVaksin = new DEL_VAKSINEntities();
            Vaksin_Veried vaksin_Veried = delVaksin.Vaksin_Veried.SingleOrDefault(x => x.ID_vaksin == id);
            return vaksin_Veried;
        }
    }
}
