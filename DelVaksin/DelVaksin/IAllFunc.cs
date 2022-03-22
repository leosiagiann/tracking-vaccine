using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DelVaksin
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAllFunc" in both code and config file together.
    [ServiceContract]
    public interface IAllFunc
    {
        [OperationContract]
        bool Register(Penduduk penduduk);

        [OperationContract]
        bool terimaVaksin(Vaksin vaksin);

        [OperationContract]
        bool tolakVaksin(Vaksin vaksin);

        [OperationContract]
        bool gunakanVaksin(Vaksin vaksin);

        [OperationContract]
        bool tambahVaksin(Vaksin vaksin);

        [OperationContract]
        bool editVaksin(Vaksin vaksin);

        [OperationContract]
        bool hapusVaksin(string id);

        [OperationContract]
        bool kirimVaksin(string id);

        [OperationContract]
        bool bagikanVaksinId(string id);

        [OperationContract]
        bool bagikanVaksinAll();

        [OperationContract]
        bool daftarVaksin(string NIK);

        [OperationContract]
        bool gunakanVaksinPenduduk(Vaksin_Veried vaksin);

        [OperationContract]
        bool vaksinSudahTerpakai(string id);

        [OperationContract]
        bool balikStatusPenduduk(string NIK);

        [OperationContract]
        bool ubahDataPenduduk(string nik, string nama, int umur, string alamat, string j_kel, string profil);

        [OperationContract]
        bool ubahPasswordPenduduk(string nik, string password);
    }
}
