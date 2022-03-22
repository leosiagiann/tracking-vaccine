using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DelVaksin
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAllData" in both code and config file together.
    [ServiceContract]
    public interface IAllData
    {
        [OperationContract]
        List<Akun> getAllAkun();

        [OperationContract]
        List<Vaksin> getAllVaksin();

        [OperationContract]
        List<Vaksin_Veried> getAllVaksin_Veried();

        [OperationContract]
        List<Regis_Vaksin> getAllRegis_Vaksin();

        [OperationContract]
        List<Penduduk> getAllPenduduk();

        [OperationContract]
        Vaksin getByIdVaksin(string id);

        [OperationContract]
        Vaksin_Veried getByIdVaksin_Veried(string id);

        [OperationContract]
        Regis_Vaksin getByIdRegis_Vaksin(string id);

        [OperationContract]
        Penduduk getByIdPenduduk(string NIK);
    }
}
