using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DelVaksin
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SBPOM" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SBPOM.svc or SBPOM.svc.cs at the Solution Explorer and start debugging.
    public class SBPOM : ISBPOM
    {
        public bool RegisVaksin(Vaksin vaksin)
        {
            DEL_VAKSINEntities delVaksin = new DEL_VAKSINEntities();
            Vaksin vaksinRegis = delVaksin.Vaksins.SingleOrDefault(x => x.ID_vaksin == vaksin.ID_vaksin);
            vaksinRegis.status = 3;
            delVaksin.SaveChanges();
            Regis_Vaksin regisVaksin = new Regis_Vaksin
            {
                ID_vaksin = vaksin.ID_vaksin,
                nama = vaksin.nama,
                status = vaksin.status
            };
            delVaksin.Regis_Vaksin.Add(regisVaksin);
            delVaksin.SaveChanges();
            return true;
        }

        public bool ReportVaksindiGunakan(string id)
        {
            DEL_VAKSINEntities delVaksin = new DEL_VAKSINEntities();
            Vaksin report = delVaksin.Vaksins.SingleOrDefault(x => x.ID_vaksin == id);
            report.status = 8;
            delVaksin.SaveChanges();
            return true;
        }

        public bool ReportVaksinSampai(string id)
        {
            DEL_VAKSINEntities delVaksin = new DEL_VAKSINEntities();
            Vaksin report = delVaksin.Vaksins.SingleOrDefault(x => x.ID_vaksin == id);
            report.status = 6;
            delVaksin.SaveChanges();
            return true;
        }
    }
}
