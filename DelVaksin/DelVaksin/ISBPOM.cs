using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DelVaksin
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISBPOM" in both code and config file together.
    [ServiceContract]
    public interface ISBPOM
    {
        [OperationContract]
        bool RegisVaksin(Vaksin vaksin);

        [OperationContract]
        bool ReportVaksinSampai(string id);

        [OperationContract]
        bool ReportVaksindiGunakan(string id);
    }
}
