using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DelVaksin
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SPemerintah" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SPemerintah.svc or SPemerintah.svc.cs at the Solution Explorer and start debugging.
    public class SPemerintah : ISPemerintah
    {
        public bool confirNik(Penduduk penduduk, string tipe)
        {
            DEL_VAKSINEntities delVaksin = new DEL_VAKSINEntities();
            Penduduk penduduk_ = delVaksin.Penduduks.SingleOrDefault(x => x.NIK == penduduk.NIK);
            if (tipe.Equals("terima"))
            {
                penduduk_.status = 1;
            }
            else
            {
                penduduk_.status = 2;
            }
            delVaksin.SaveChanges();
            delVaksin.Dispose();
            return true;
        }
    }
}
